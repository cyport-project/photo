using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using 写真館システム.DB;
using System.Text.RegularExpressions;

namespace 写真館システム
{
    public partial class Costume_master : UserControlExp
    {
        //変更フラグ
        //private Boolean changeValue;
        private modifyCheck mod;

        //現在ページ
        private int currentPage;
        // 総ページ
        private int totalPage;
        //チェッククラス
        private checkOperation chk;

        //構造体の生成（店舗）
        public struct storeCodeArray
        {
            public string store_code;
            public string store_name;
        }
        //店舗リストの生成
        private List<storeCodeArray> storeCodeList = new List<storeCodeArray>();


        //リストの生成（データベース）
        private List<DB.m_costume> costumeDBList = new List<DB.m_costume>();

        private string Costume_Image_Path = "";
        
        //画像選択時のファイルパス
        String[] imagePath = { "", "", "", "" };

        public Costume_master()
        {
            InitializeComponent();

            //LostFocus設定
            t_image_file1.Leave += new EventHandler(t_image_file1_Leave);
            t_image_file2.Leave += new EventHandler(t_image_file2_Leave);
            t_image_file3.Leave += new EventHandler(t_image_file3_Leave);
            t_image_file4.Leave += new EventHandler(t_image_file4_Leave);

            //チェックリストの生成
            chk = new checkOperation(this);

            mod = new modifyCheck();
            mod.add(t_age);
            mod.add(t_brand);
            mod.add(t_bunrui);
            mod.add(t_color);
            mod.add(t_costume);
            mod.add(t_costume_code);
            mod.add(t_customer_display);
            mod.add(t_gara);
            mod.add(t_image_file1);
            mod.add(t_image_file2);
            mod.add(t_image_file3);
            mod.add(t_image_file4);
            mod.add(t_kashidashi_tenpo);
            mod.add(t_mitame);
            mod.add(t_price1);
            mod.add(t_price2);
            mod.add(t_price3);
            mod.add(t_rank);
            mod.add(t_size);
            mod.add(t_tekiyou);
            mod.add(d_seibetsu);
            mod.add(d_siyoukahi);
            mod.add(d_status);
            mod.add(t_initial_use_count);
        }

        private void Set_intialDiaplay()
        {

            //storeCodeListの初期化
            storeCodeList.Clear();
            NpgsqlDataReader dataReader = null;
            var dbc = new DB.DBConnect();
            dbc.npg.Open();
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select store_code, store_name ");
            sb.Append(@"from m_store ");
            sb.Append(@"where m_store.delete_flag = '0' order by m_store.store_code");
            var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                //storeCodeListの生成
                storeCodeList.Add(new storeCodeArray
                {
                    store_code = dataReader["store_code"].ToString(),
                    store_name = dataReader["store_name"].ToString()
                });

            }

            dbc.npg.Close();

            //店舗名の生成
            d_tenpo.Items.Clear();
            for (int i = 0; i < storeCodeList.Count; i++)
            {
                d_tenpo.Items.Add(storeCodeList[i].store_name);
            }

            if (costumeDBList.Count == 0)
            {
                ShowBlank();
            }
            else
            {
                Listshow();
            }


            //変更フラグクリア
            mod.reset();

            //エラー項目クリア
            chk.clear();

        }

        private void ShowBlank()
        {

            d_tenpo.Enabled = true;
            t_costume_code.Enabled = true;

            d_tenpo.SelectedIndex = d_tenpo.FindStringExact(DB.m_store.getSingle(MainForm.session_m_staff.store_code).store_name);
            t_costume_code.Text = null;
            t_costume.Text = null;
            t_size.Text = null;
            d_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_seibetsu.SelectedIndex = -1;
            t_brand.Text = null;
            t_rank.Text = null;
            d_siyoukahi.DataSource = Enum.GetValues(typeof(Utile.Data.衣装使用可否));
            d_siyoukahi.SelectedIndex = -1;
            t_price1.Text = null;
            t_price2.Text = null;
            t_price3.Text = null;
            t_color.Text = null;
            t_age.Text = null;
            t_tekiyou.Text = null;
            t_image_file1.Text = null;
            t_image_file2.Text = null;
            t_image_file3.Text = null;
            t_image_file4.Text = null;
            t_bunrui.Text = null;
            t_mitame.Text = null;
            t_gara.Text = null;
            d_status.DataSource = Enum.GetValues(typeof(Utile.Data.衣装ステータス));
            d_status.SelectedIndex = -1;
            t_kashidashi_tenpo.Text = null;
            t_customer_display.Text = null;
            t_initial_use_count.Text = null;

            t_current_page.Text = (totalPage + 1).ToString("0");
            t_total_page.Text = (totalPage + 1).ToString("0");

            //pictureboxのクリア
            this.p_image1.Image = null;
            this.p_image2.Image = null;
            this.p_image3.Image = null;
            this.p_image4.Image = null;
            mod.reset();
        }
        //list表示
        public void Listshow()
        {

            d_tenpo.Enabled = false;
            t_costume_code.Enabled = false;

            var cos = costumeDBList[currentPage - 1];
            d_tenpo.SelectedIndex = d_tenpo.FindStringExact(DB.m_store.getSingle(cos.store_code).store_name);
            t_costume_code.Text = cos.costume_code;
            t_costume.Text = cos.costume_name;
            t_size.Text = cos.size;
            d_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_seibetsu.SelectedIndex = int.Parse(cos.sex);
            t_brand.Text = cos.brand_name;
            t_rank.Text = cos.rank;
            d_siyoukahi.DataSource = Enum.GetValues(typeof(Utile.Data.衣装使用可否));
            d_siyoukahi.SelectedIndex = int.Parse(cos.usability);
            t_price1.Text = cos.price1.ToString();
            t_price2.Text = cos.price2.ToString();
            t_price3.Text = cos.price3.ToString();
            t_color.Text = cos.color;
            t_age.Text = cos.target_age.ToString();
            t_tekiyou.Text = cos.remarks;
            t_image_file1.Text = cos.image1;
            t_image_file2.Text = cos.image2;
            t_image_file3.Text = cos.image3;
            t_image_file4.Text = cos.image4;
            t_bunrui.Text = cos.Class;
            t_mitame.Text = cos.appearance;
            t_gara.Text = cos.handle;
            d_status.DataSource = Enum.GetValues(typeof(Utile.Data.衣装ステータス));
            d_status.SelectedIndex = int.Parse(cos.status);
            t_kashidashi_tenpo.Text = cos.rental_store;
            t_customer_display.Text = cos.customer_display;
            t_initial_use_count.Text = cos.initial_use_count.ToString();

            t_current_page.Text = (string)currentPage.ToString("0");
            t_total_page.Text = (string)totalPage.ToString("0");

            //pictureboxのクリア
            setImage(p_image1, t_image_file1);
            setImage(p_image2, t_image_file2);
            setImage(p_image3, t_image_file3);
            setImage(p_image4, t_image_file4);

            mod.reset();
        }


        //ページの初期化
        public override void PageRefresh()
        {

            //データ取得
            costumeDBList = DB.m_costume.GetAllTable();
            totalPage = costumeDBList.Count;
            currentPage = 1;

            var rootPath = System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString();
            var cosDir = System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString();
            Costume_Image_Path = System.IO.Path.Combine(rootPath, cosDir);

            Set_intialDiaplay();

            b_new_regist.Visible = true;
            b_regist.Visible = true;
            b_delete.Visible = true;
            t_current_page.Visible = true;
            label4.Visible = true;
            t_total_page.Visible = true;
            b_decrease.Visible = true;
            b_increase.Visible = true;

            //d_tenpo.Enabled = false;
            //t_costume_code.Enabled = false;

        }

        public void PageRefresh(string id)
        {

            //データ取得
            costumeDBList = DB.m_costume.GetAllTable();
            totalPage = costumeDBList.Count;
            currentPage = 1;
            foreach (var cos in costumeDBList)
            {
                if (cos.costume_code == id)
                    break;
                currentPage++;
            }

            var rootPath = System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString();
            var cosDir = System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString();
            Costume_Image_Path = System.IO.Path.Combine(rootPath, cosDir);

            Set_intialDiaplay();

            b_new_regist.Visible = false;
            b_regist.Visible = false;
            b_delete.Visible = false;
            t_current_page.Visible = false;
            label4.Visible = false;
            t_total_page.Visible = false;
            b_decrease.Visible = false;
            b_increase.Visible = false;


        }

        private void setImage(PictureBox pic, TextBox tex)
        {
            var storeName = d_tenpo.SelectedItem.ToString();
            var cosId = t_costume_code.Text;
            var imgPath = System.IO.Path.Combine(Costume_Image_Path, storeName, cosId, tex.Text);

            if (System.IO.File.Exists(imgPath))
            {
                try
                {
                    //ファイル表示およびサイズモード設定
                    pic.Image = System.Drawing.Image.FromFile(imgPath);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    //画像の破損チェック
                    chk.clear();
                    chk.addControl(tex);
                    chk.check("I15003", chk.checkTextboxFile, null);
                    pic.Image = null;
                    return;
                    //  エラー表示無効なファイルと
                }
                
            }
            else
            {
                pic.Image = null;
            }
        }

        private void t_image_file4_Leave(object sender, EventArgs e)
        {
            setImage(p_image4, t_image_file4);

        }

        private void t_image_file3_Leave(object sender, EventArgs e)
        {
            setImage(p_image3, t_image_file3);
        }

        private void t_image_file2_Leave(object sender, EventArgs e)
        {
            setImage(p_image2, t_image_file2);
        }

        private void t_image_file1_Leave(object sender, EventArgs e)
        {
            setImage(p_image1, t_image_file1);
        }

        //◀ボタン[クリック]処理
        private void b_decrease_Click(object sender, EventArgs e)
        {
            d_tenpo.Enabled = false;
            t_costume_code.Enabled = false;

            using (var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_costume
                        where t.delete_flag =="0"
                        select t;
                totalPage = q.Count();
            }

            if (currentPage > 1)
            {
                if (!mod.chackMessage("処理"))
                    return;

                currentPage--;
                Listshow();
            }
        }

        //▶ボタン[クリック]処理
        private void b_increase_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                if (!mod.chackMessage("処理"))
                    return;

                currentPage++;
                Listshow();
            }
        }

        //新規登録
        private void b_new_regist_Click(object sender, EventArgs e)
        {
            if (!mod.chackMessage("処理"))
                return;

            d_tenpo.Enabled = true;
            t_costume_code.Enabled = true;

            ShowBlank();
            t_total_page.Text = (totalPage + 1).ToString();
            t_current_page.Text = (totalPage + 1).ToString();
            currentPage = totalPage + 1;

            mod.reset();
        }

        //削除
        private void b_delete_Click(object sender, EventArgs e)
        {
            if (!mod.chackMessage("削除"))
                return;

            if (totalPage == currentPage - 1)
                return;

            var cos = costumeDBList[currentPage - 1];
            cos.Command(delete: true);

            costumeDBList = DB.m_costume.GetAllTable();
            totalPage = costumeDBList.Count;
            currentPage = 1;

            Set_intialDiaplay();

            this.PageRefresh();
            MainForm.backPage(this);
        }

        //登録
        private void b_regist_Click(object sender, EventArgs e)
        {
            //if (!mod.chackMessage("登録"))
            //    return;

            //入力チェック
            chk.clear();
            chk.addControl(d_tenpo);
            chk.addControl(t_costume_code);
            chk.addControl(t_costume);
            chk.addControl(t_size);
            chk.addControl(d_seibetsu);
            chk.addControl(t_brand);
            chk.addControl(t_rank);
            chk.addControl(d_siyoukahi);
            chk.addControl(t_price1);
            chk.addControl(t_price2);
            chk.addControl(t_price3);
            chk.addControl(t_color);
            chk.addControl(t_age);
            chk.addControl(t_bunrui);
            chk.addControl(t_mitame);
            chk.addControl(t_gara);
            chk.addControl(d_status);
            chk.addControl(t_image_file1);
            chk.addControl(t_initial_use_count);
            if (chk.check("W00000", chk.checkControlImportant))
                return;

            //桁数チェック
            //衣装コード
            chk.clear();
            chk.addControl(t_costume_code);
            if (chk.check("W00001", chk.checkTextboxLength, 8))
                return;

            //衣装名・ブランド名
            chk.clear();
            chk.addControl(t_costume);
            chk.addControl(t_brand);
            if (chk.check("W00001", chk.checkTextboxLength, 40))
                return;

            //年齢
            chk.clear();
            chk.addControl(t_age);
            if (chk.check("W00001", chk.checkTextboxLength, 2))
                return;

            //価格・色・分類・柄・サイズ・ランク
            chk.clear();
            chk.addControl(t_size);
            chk.addControl(t_rank);
            chk.addControl(t_price1);
            chk.addControl(t_price2);
            chk.addControl(t_price3);
            chk.addControl(t_color);
            chk.addControl(t_bunrui);
            chk.addControl(t_gara);
            if (chk.check("W00001", chk.checkTextboxLength, 10))
                return;

            //見た目
            chk.clear();
            chk.addControl(t_mitame);
            if (chk.check("W00001", chk.checkTextboxLength, 20))
                return;

            //摘要・イメージファイル
            chk.clear();
            chk.addControl(t_tekiyou);
            chk.addControl(t_image_file1);
            chk.addControl(t_image_file2);
            chk.addControl(t_image_file3);
            chk.addControl(t_image_file4);
            if (chk.check("W00001", chk.checkTextboxLength, 255))
                return;

            //イメージファイル
            //正規表現
            chk.clear();
            chk.addControl(t_image_file1);
            chk.addControl(t_image_file2);
            chk.addControl(t_image_file3);
            chk.addControl(t_image_file4);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^[a-zA-Z0-9.]+$", @"英数字"))
                return;

            //貸出店舗・お客様表示用
            chk.clear();
            chk.addControl(t_kashidashi_tenpo);
            chk.addControl(t_customer_display);
            if (chk.check("W00001", chk.checkTextboxLength, 30))
                return;

            //正規表現
            //価格
            chk.clear();
            chk.addControl(t_price1);
            chk.addControl(t_price2);
            chk.addControl(t_price3);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^\d{1,10}\z", @"0～9999999999"))
                return;

            //正規表現
            //年齢
            chk.clear();
            chk.addControl(t_age);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^\d{1,3}?\z", @"0～999"))
                return;


            //正規表現
            //使用回数初期値
            chk.clear();
            chk.addControl(t_initial_use_count);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^\d{1,4}?\z", @"0～9999"))
                return;


            var textBoxTextList = new[] { t_image_file1, t_image_file2, t_image_file3, t_image_file4 };
            //画像ファイルの重複
            chk.clear();
            chk.addControl(t_image_file1);
            chk.addControl(t_image_file2);
            chk.addControl(t_image_file3);
            chk.addControl(t_image_file4);
            if (chk.UniquCheck("I15002", chk.checkTextUniqueFormat, null))
                return;


            //画像をフォルダにコピー
            for (int i = 0; i< 4;i++)
            {
                string path = imagePath[i];
                string textBoxText = textBoxTextList[i].Text;
                if(path == "") continue;

                
                var storeName = d_tenpo.SelectedItem.ToString();
                var cosId = t_costume_code.Text;
                var copyPath = System.IO.Path.Combine(Costume_Image_Path, storeName, cosId);
                var copyPath2 = System.IO.Path.Combine(Costume_Image_Path, storeName, cosId, textBoxText);

                //画像の破損チェック
                try
                {
                    System.Drawing.Image.FromFile(path);
                }
                catch
                {
                    chk.clear();
                    chk.check("I15003", chk.checkTextboxFile, null);
                    Utile.Message.showMessageOK("I15003");
                    return;
                }

                if (!System.IO.Directory.Exists(copyPath)) ;
                {
                    Directory.CreateDirectory(copyPath);
                }

                if (!System.IO.File.Exists(copyPath2) && textBoxText != "")
                {
                    System.IO.File.Copy(path, copyPath2, true);
                }


            }


            DB.m_costume cos = new m_costume();
            if (totalPage == currentPage - 1)
            {
                //新規登録
                cos.store_code = DB.m_store.getSingleName(d_tenpo.SelectedItem.ToString()).store_code;
                cos.costume_code = t_costume_code.Text;
                cos.costume_name = t_costume.Text;
                cos.size = t_size.Text;
                cos.sex = d_seibetsu.SelectedIndex.ToString();
                cos.brand_name = t_brand.Text;
                cos.rank = t_rank.Text;
                cos.usability = d_siyoukahi.SelectedIndex.ToString();
                cos.price1 = int.Parse(t_price1.Text);
                cos.price2 = int.Parse(t_price2.Text);
                cos.price3 = int.Parse(t_price3.Text);
                cos.color = t_color.Text;
                cos.target_age = int.Parse(t_age.Text);
                cos.remarks = t_tekiyou.Text;
                cos.image1 = t_image_file1.Text;
                cos.image2 = t_image_file2.Text;
                cos.image3 = t_image_file3.Text;
                cos.image4 = t_image_file4.Text;
                cos.Class = t_bunrui.Text;
                cos.appearance = t_mitame.Text;
                cos.handle = t_gara.Text;
                d_status.DataSource = Enum.GetValues(typeof(Utile.Data.衣装ステータス));
                cos.status = d_status.SelectedIndex.ToString();
                cos.rental_store = t_kashidashi_tenpo.Text;
                cos.customer_display = t_customer_display.Text;
                cos.initial_use_count = int.Parse(t_initial_use_count.Text);　
            }
            else
            {
                //更新
                cos = costumeDBList[currentPage - 1];
                cos.costume_name = t_costume.Text;
                cos.size = t_size.Text;
                cos.sex = d_seibetsu.SelectedIndex.ToString();
                cos.brand_name = t_brand.Text;
                cos.rank = t_rank.Text;
                cos.usability = d_siyoukahi.SelectedIndex.ToString();
                cos.price1 = int.Parse(t_price1.Text);
                cos.price2 = int.Parse(t_price2.Text);
                cos.price3 = int.Parse(t_price3.Text);
                cos.color = t_color.Text;
                cos.target_age = int.Parse(t_age.Text);
                cos.remarks = t_tekiyou.Text;
                cos.image1 = t_image_file1.Text;
                cos.image2 = t_image_file2.Text;
                cos.image3 = t_image_file3.Text;
                cos.image4 = t_image_file4.Text;
                cos.Class = t_bunrui.Text;
                cos.appearance = t_mitame.Text;
                cos.handle = t_gara.Text;
                d_status.DataSource = Enum.GetValues(typeof(Utile.Data.衣装ステータス));
                cos.status = d_status.SelectedIndex.ToString();
                cos.rental_store = t_kashidashi_tenpo.Text;
                cos.customer_display = t_customer_display.Text;
                cos.initial_use_count = int.Parse(t_initial_use_count.Text);
            }

            cos.Command();

            this.PageRefresh();
            MainForm.backPage(this);
        }

        //戻る
        private void b_return_Click(object sender, EventArgs e)
        {
            if (!mod.chackMessage("戻る処理"))
                return;

            this.PageRefresh();
            MainForm.backPage(this);

        }

        private void t_current_page_Leave(object sender, EventArgs e)
        {
            using (var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_costume
                        where t.delete_flag == "0"
                        select t;
                totalPage = q.Count();
            }

            chk.clear();
            chk.addControl(t_current_page);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^\d{1,5}?\z", @"数値")
                || chk.check("W00000", chk.checkControlImportant))
            {
                return;
            }

            d_tenpo.Enabled = false;
            t_costume_code.Enabled = false;
            currentPage = int.Parse(t_current_page.Text);

            if (currentPage > 0 && currentPage <= totalPage)
            {
                if (!mod.chackMessage("処理"))
                    return;

                Listshow();
            }
            else
            {
                Utile.Message.showMessageOK("I15001");
            }
        }


        private void b_image_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = @"画像ファイル(*.png, *.jpg, *.gif, *bmp) | *.png; *.jpg; *.gif; *bmp";
            openFileDialog1.InitialDirectory = System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString();
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                imagePath[0] = path;
                string[] pathSplit = path.Split('\\');
                t_image_file1.Text = path;
                setImage(p_image1, t_image_file1);
                t_image_file1.Text = pathSplit[pathSplit.Length - 1];
            }
        }

        private void b_image_select2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = @"画像ファイル(*.png, *.jpg, *.gif, *bmp) | *.png; *.jpg; *.gif; *bmp";
            openFileDialog1.InitialDirectory = System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString();
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                imagePath[1] = path;
                string[] pathSplit = path.Split('\\');
                t_image_file2.Text = path;
                setImage(p_image2, t_image_file2);
                t_image_file2.Text = pathSplit[pathSplit.Length - 1];
            }
        }

        private void b_image_select3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = @"画像ファイル(*.png, *.jpg, *.gif, *bmp) | *.png; *.jpg; *.gif; *bmp";
            openFileDialog1.InitialDirectory = System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString();
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                imagePath[2] = path;
                string[] pathSplit = path.Split('\\');
                t_image_file3.Text = path;
                setImage(p_image3, t_image_file3);
                t_image_file3.Text = pathSplit[pathSplit.Length - 1];
            }
        }

        private void b_image_select4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = @"画像ファイル(*.png, *.jpg, *.gif, *bmp) | *.png; *.jpg; *.gif; *bmp";
            openFileDialog1.InitialDirectory = System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString();
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                imagePath[3] = path;
                string[] pathSplit = path.Split('\\');

                t_image_file4.Text =path;
                setImage(p_image4, t_image_file4);
                t_image_file4.Text = pathSplit[pathSplit.Length - 1];
            }
        }
    }
}
