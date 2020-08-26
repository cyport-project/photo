using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace 写真館システム
{
    public partial class Costume_search : UserControlExp
    {

        //店舗構造体の生成
        public struct storeCodeArray
        {
            public string store_code;
            public string store_name;
        }
        //店舗リスト生成
        List<storeCodeArray> storeCodeList = new List<storeCodeArray>();


        //衣装画像のパス
        string Costume_Image_Dir = null;

        //SQLWHERE格納用変数
        public String strSQLWHERE = "";

        public Costume_search()
        {
            InitializeComponent();

            //衣装画像パス設定
            var photo_root = System.Configuration.ConfigurationManager.AppSettings["photo_root"];
            var Costume_Image = System.Configuration.ConfigurationManager.AppSettings["Costume_Image"];
            Costume_Image_Dir = System.IO.Path.Combine(photo_root, Costume_Image);

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            //コンボボックスの設定
            d_tenpo.Items.Clear();
            for (int i = 0; i < storeCodeList.Count; i++)
            {
                d_tenpo.Items.Add(storeCodeList[i].store_name);
            }
            d_tenpo.SelectedIndex = -1;

            //テキストボックスの初期化
            t_bunrui.Text = null;
            t_code.Text = null;
            t_appearance.Text = null;
            t_color.Text = null;
            t_gara.Text = null;
            t_size.Text = null;
            t_code.Text = null;
            t_price_from1.Text = null;
            t_price_to1.Text = null;
            t_price_from2.Text = null;
            t_price_to2.Text = null;
            t_price_from3.Text = null;
            t_price_to3.Text = null;
            t_tekiyou.Text = null;

            //チェックボックスの初期化
            c_available.Checked = true;
            c_borrow.Checked = false;
            c_maintenance.Checked = false;
            c_lent.Checked = false;
            c_scrap.Checked = false;
            
        }

        public override void PageRefresh()
        {
            //店舗データ読み込み
            List<Dictionary<string, object>> m_storeList = DB.m_store.getStoreList();
            storeCodeList.Clear();
            foreach (var m_store in m_storeList)
            {
                storeCodeList.Add(new storeCodeArray
                {
                    store_code = m_store["store_code"].ToString(),
                    store_name = m_store["store_name"].ToString()
                });
            }
            //コンボボックス初期化
            //コンボボックスの設定
            d_tenpo.Items.Clear();
            for (int i = 0; i < storeCodeList.Count; i++)
            {
                d_tenpo.Items.Add(storeCodeList[i].store_name);
            }
            d_tenpo.SelectedIndex = -1;

            //テキストボックスの初期化
            t_bunrui.Text = null;
            t_code.Text = null;
            t_appearance.Text = null;
            t_color.Text = null;
            t_gara.Text = null;
            t_size.Text = null;
            t_code.Text = null;
            t_price_from1.Text = null;
            t_price_to1.Text = null;
            t_price_from2.Text = null;
            t_price_to2.Text = null;
            t_price_from3.Text = null;
            t_price_to3.Text = null;
            t_tekiyou.Text = null;

            //チェックボックスの初期化
            c_available.Checked = true;
            c_maintenance.Checked = false;
            c_borrow.Checked = false;
            c_lent.Checked = false;
            c_scrap.Checked = false;

            //datagridview　の初期化
            dataGridView1.Rows.Clear();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            //表の初期化
            dataGridView1.Rows.Clear();
            strSQLWHERE = null;

            //WHERE句の設定
            //店舗名
            var storecode = storeCodeList.Find(x => x.store_name == d_tenpo.Text).store_code;
            strSQLWHERE += d_tenpo.Text != "" ? "c.store_code = " + "'" + storecode + "'": "" ;

            //分類
            strSQLWHERE += t_bunrui.Text != "" &&　strSQLWHERE.Length >0 ? " and ": "";
            strSQLWHERE += t_bunrui.Text != ""  ? " c.class like " + "'%" + t_bunrui.Text + "%'": "";

            //コード
            strSQLWHERE += t_code.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_code.Text != "" ? " c.costume_code like " + "'%" + t_code.Text + "%'" : "";

            //見た目
            strSQLWHERE += t_appearance.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_appearance.Text != "" ? " c.appearance like " + "'%" + t_appearance.Text + "%'" : "";

            //ブランド
            strSQLWHERE += t_brand.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_brand.Text != "" ? " c.brand_name like " + "'%" + t_brand.Text + "%'" : "";

            //色
            strSQLWHERE += t_color.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_color.Text != "" ? " c.color like " + "'%" + t_color.Text + "%'" : "";

            //柄
            strSQLWHERE += t_gara.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_gara.Text != "" ? " c.handle like " + "'%" + t_gara.Text + "%'" : "";

            //サイズ
            strSQLWHERE += t_size.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_size.Text != "" ? " c.size like " + "'%" + t_size.Text + "%'" : "";

            //価格１
            strSQLWHERE += t_price_from1.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_price_from1.Text != "" ? " c.price1 >= " + "'" + t_price_from1.Text + "'" : "";
            strSQLWHERE += t_price_to1.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_price_to1.Text != "" ? " c.price1 <= " + "'" + t_price_to1.Text + "'" : "";

            //価格２
            strSQLWHERE += t_price_from2.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_price_from2.Text != "" ? " c.price2 >= " + "'" + t_price_from2.Text + "'" : "";
            strSQLWHERE += t_price_to2.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_price_to2.Text != "" ? " c.price2 <= " + "'" + t_price_to2.Text + "'" : "";

            //価格３
            strSQLWHERE += t_price_from3.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_price_from3.Text != "" ? " c.price3 >= " + "'" + t_price_from3.Text + "'" : "";
            strSQLWHERE += t_price_to3.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_price_to3.Text != "" ? " c.price3 <= " + "'" + t_price_to3.Text + "'" : "";

            //摘要
            strSQLWHERE += t_tekiyou.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_tekiyou.Text != "" ? " c.remarks like " + "'%" + t_tekiyou.Text + "%'" : "";

            //チェックボックス
            String strCHKBox = c_available.Checked == true ? " c.status = '0' " : "";

            strCHKBox += c_maintenance.Checked == true && strCHKBox.Length >0  ? " or " : "";
            strCHKBox += c_maintenance.Checked == true ? " c.status = '1' " : "";

            strCHKBox += c_lent.Checked == true && strCHKBox.Length > 0 ? " or " : "";
            strCHKBox += c_lent.Checked == true ? " c.status = '2' " : "";

            strCHKBox += c_scrap.Checked == true && strCHKBox.Length > 0 ? " or " : "";
            strCHKBox += c_scrap.Checked == true ? " c.status = '3' " : "";

            strCHKBox += c_borrow.Checked == true && strCHKBox.Length > 0 ? " or " : "";
            strCHKBox += c_borrow.Checked == true ? " c.status = '4' " : "";

            strSQLWHERE += strCHKBox.Length > 0 && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += strCHKBox.Length > 0 ? "(" + strCHKBox +")"  : "";

            

            strSQLWHERE = strSQLWHERE.Length > 0 ? " WHERE " + strSQLWHERE : "";

            //結果格納クエリーの初期化
            NpgsqlDataReader costumeReader = null;

            using (var db = new DB.DBConnect())
            {
                db.npg.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append(@"SELECT 
                            c.costume_code as costume_code, 
                            c.image1 as image1,
                            c.appearance,
                            c.store_code as store_code,
                            c.rental_store as rental_store,
                            c.class as class,
                            c.brand_name as bland_name,
                            c.color as color,    
                            c.handle as handle,
                            c.size as size,
                            c.price1 as price1,
                            c.price2 as price2,
                            c.price3 as price3,
                            c.costume_name as costume_name,
                            c.usability as usability,
                            c.status,
                            c.remarks as remarks, 
                            c.initial_use_count as initial_use_count, 
                            cr.number as number,
                            cr.latest_date_from as latest_date_from,
                            cr.latest_date_to as latest_date_to
                            ");
                sb.Append(@"FROM
                            (SELECT * FROM m_costume 
                             WHERE delete_flag = '0' ) AS c
                            LEFT JOIN (
                            SELECT distinct costume_code,count(costume_code) as number,
                                   max(start_date) as latest_date_from,
                                   max(end_date) as latest_date_to
                            FROM t_costume_reservation
                             group by costume_code) AS cr ON c.costume_code = cr.costume_code
                            ");
                sb.Append(@strSQLWHERE);
                sb.Append(@"ORDER BY c.costume_code");
                var command = new NpgsqlCommand(sb.ToString(), db.npg);

                costumeReader = command.ExecuteReader();
                if (costumeReader.HasRows)
                {
                    while (costumeReader.Read())
                    {
                        //セル内の文字を改行する。
                        dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        //行テンプレートの高さを設定する
                        dataGridView1.RowTemplate.Height = 80;

                        //種類編集
                        string Str_class = costumeReader["class"].ToString() +
                                             Environment.NewLine +
                                           costumeReader["bland_name"].ToString() +
                                             Environment.NewLine +
                                           costumeReader["color"].ToString() +
                                             Environment.NewLine +
                                           costumeReader["handle"].ToString() +
                                             Environment.NewLine +
                                           costumeReader["size"].ToString();
                        //価格編集
                        string price = costumeReader["price1"].ToString() +
                                            Environment.NewLine +
                                       costumeReader["price2"].ToString() +
                                            Environment.NewLine +
                                       costumeReader["price3"].ToString();
                        //店舗編集
                        string Strstore = storeCodeList.Find(x => x.store_code == costumeReader["store_code"].ToString()).store_name;
                        string Strlentstore = costumeReader["rental_store"].ToString() != "" ? Strstore + Environment.NewLine +
                                 "->" + costumeReader["rental_store"].ToString() : Strstore;
                        //使用可否編集
                        int intVal = int.Parse(costumeReader["usability"].ToString());
                        string usability = Enum.ToObject(typeof(Utile.Data.衣装使用可否), intVal).ToString();

                        //直近のレンタル日
                        DateTime.TryParse(costumeReader["latest_date_from"].ToString(), out DateTime latest_date_from);
                        DateTime.TryParse(costumeReader["latest_date_to"].ToString(), out DateTime latest_date_to);

                        string Strlatest_date = costumeReader["latest_date_from"].ToString() != "" ? latest_date_from.ToShortDateString() : "";
                        Strlatest_date += costumeReader["latest_date_to"].ToString() != "" ? "～" + latest_date_to.ToShortDateString() : "";

                        //レンタル回数
                        int rental_count = costumeReader["number"].ToString() == "" ? 0 : int.Parse(costumeReader["number"].ToString());


                        //画像ファイルのサイズ変更
                        //画像ファイル存在チェック
                        string costume_code = costumeReader["costume_code"].ToString();
                        string image1 = costumeReader["image1"].ToString();

                        var path = System.IO.Path.Combine(Costume_Image_Dir, Strstore, costume_code, image1);
                        Bitmap resizeBmp = null;
                        if (System.IO.File.Exists(path))
                        {
                            //存在したら、サイズ変更
                            Bitmap img = new Bitmap(path);
                            int resizeHeight = dataGridView1.RowTemplate.Height;
                            int resizeWidth = (int)(img.Width * ((double)resizeHeight / (double)img.Height));

                            resizeBmp = new Bitmap(resizeWidth, resizeHeight);

                            Graphics g = Graphics.FromImage(resizeBmp);
                            //Bitmap newimg = new Bitmap(img);    
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.DrawImage(img, 0, 0, resizeBmp.Width, resizeBmp.Height);
                        }


                        dataGridView1.Rows.Add(
                            resizeBmp,
                            costume_code,
                            Strlentstore,
                            Str_class,
                            price,
                            costumeReader["costume_name"].ToString(),
                            usability,
                            (rental_count + int.Parse(costumeReader["initial_use_count"].ToString())).ToString(),
                            Strlatest_date,
                            costumeReader["remarks"].ToString()
                            );

                    }
                }
                else
                {
                    MessageBox.Show("検索結果が0件でした。", "お知らせ", MessageBoxButtons.OK);

                }



            }

        }

        private void b_return_Click(object sender, EventArgs e)
        {
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void d_tenpo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_tenpo.SelectedIndex = -1;
            }
        }
    }
}
