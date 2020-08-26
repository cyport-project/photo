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
using Microsoft.VisualBasic;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace 写真館システム
{
    public partial class Photo_selection : UserControlExp
    {

        public string Photographer_Select_dir = null;
        public string Secondary_Select_dir = null;
        public string Save_dir = null;

        public List<string> photoDirList = new List<string>();

        public int tagCount = 7;
        public readonly List<Color> TAGS = new List<Color>(new List<Color>()
          {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.YellowGreen,
            Color.Green,
            Color.Blue,
            Color.Purple
          });

        public ImageList imageListBase;

        public Photo_selection()
        {
            InitializeComponent();

            //コンフィグファイル読み込み
            tagCount = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Tag Count"]);
            var photo_root = System.Configuration.ConfigurationManager.AppSettings["photo_root"];
            var Photographer_Select = System.Configuration.ConfigurationManager.AppSettings["Photographer_Select"];
            var Secondary_Select = System.Configuration.ConfigurationManager.AppSettings["Secondary_Select"];

            Photographer_Select_dir = System.IO.Path.Combine(photo_root, Photographer_Select);
            Secondary_Select_dir = System.IO.Path.Combine(photo_root, Secondary_Select);
            
            //*************************
            //サムネイル一覧
            //*************************
            this.thumbnailList.BackColor = Color.White;
            imageList1.Images.Clear();
            imageListBase = new ImageList(this.components);
            imageListBase.ImageSize = imageList1.ImageSize;
            imageListBase.ColorDepth = ColorDepth.Depth32Bit;


            //*************************
            //右タブ一覧
            //*************************
            this.tagsPanel.RowCount = tagCount;

            for(int i = 0; tagCount > i; i++)
            {
                tagControl tagControl = new tagControl(this);
                tagControl.BackColor = TAGS[i];
                tagControl.tagId = i;
                this.tagsPanel.Controls.Add(tagControl, 0, i);
            }


        }
        public override void PageRefresh()
        {
            //写真選択フォームをすべて閉じる
            selectPanel.Controls.Clear();

            //写真格納フォルダ取得
            photoDirList = DB.t_shooting_data.getPhotoDir(MainForm.session_t_reception.reception_code);
            
            //二次選択フォルダ取得
            DB.t_selection selection = DB.t_selection.getFirst(MainForm.session_t_reception.reception_code);
            if (selection == null)
            {
                int index = 1;
                DB.m_customer customer = DB.m_customer.getSingle(MainForm.session_t_reception.customer_code);
                Save_dir = DateTime.Now.Date.ToString("yyyyMMdd") + "-" + index.ToString() + "-" + customer.surname;
                StringBuilder sb = new StringBuilder();

                while (sb.Length == 0)
                {
                    using (var dbc = new DB.DBConnect())
                    {
                        dbc.npg.Open();
                        sb.Append("select count(s.folder_name) as count ");
                        sb.Append("from t_selection as s ");
                        sb.Append("where s.folder_name = '@folder_name'".Replace("@folder_name", Save_dir));
                        NpgsqlCommand command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                        var dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                            if ((long)dataReader["count"] != 0)
                            {
                                index++;
                                Save_dir = DateTime.Now.Date.ToString("yyyyMMdd") + index.ToString() + customer.name;
                                sb.Clear();
                            }
                        }
                    }
                }
            }
            else
            {
                Save_dir = selection.folder_name;
            }
            
            //サムネイル一覧初期化
            thumbnailListRefresh();

            //DBからタグ一覧へ格納
            db2tag();

            //サムネイル一覧タグ付け
            thumbnailListTagRefresh();

        }
        public void db2tag()
        {
            try
            {
                foreach (tagControl tagControl in this.tagsPanel.Controls)
                {
                    tagControl.imgNameList.Clear();
                    tagControl.imageList1.Images.Clear();
                    tagControl.thumbnailList.Items.Clear();
                }
                using (var dbc = new DB.DBConnect())
                {
                    dbc.npg.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"select * ");
                    sb.Append(@"from t_selection as s ");
                    sb.Append(@"where s.reception_code = '@reception_code'".Replace("@reception_code", MainForm.session_t_reception.reception_code));

                    NpgsqlCommand command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int color = (int)dataReader["color"];
                        foreach (tagControl tagControl in this.tagsPanel.Controls)
                        {
                            if (tagControl.tagId == color)
                            {
                                var path = System.IO.Path.Combine(Secondary_Select_dir, ((string)dataReader["folder_name"]).Trim(), tagControl.tagId.ToString());

                                foreach (string fpath in System.IO.Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories))
                                {
                                    var fname = System.IO.Path.GetFileName(fpath);
                                    foreach (var key in imageListBase.Images.Keys)
                                    {
                                        if (key.Replace("/", "_") == fname)
                                        {
                                            tagControl.imageList1.Images.Add(key, imageListBase.Images[imageListBase.Images.IndexOfKey(key)]);
                                            ListViewItem lvi = new ListViewItem(key);
                                            lvi.ImageIndex = tagControl.imageList1.Images.Count - 1;
                                            tagControl.thumbnailList.Items.Add(lvi);
                                            tagControl.imgNameList.Add(key);
                                        }
                                    }
                                }
                                tagControl.d_tagName.SelectedIndex = DB.m_product.getProductList().Values.ToList().IndexOf((string)dataReader["product_name"]);
                                tagControl.l_count.Text = tagControl.thumbnailList.Items.Count.ToString() + "枚";
                                tagControl.d_tag.Checked = tagControl.thumbnailList.Items.Count > 0 ? true : false; 
                            }
                        }
                    }
                }
            }
            catch
            {
                Utile.Message.showMessageOK("E12001");
            }
        }

        public void thumbnailListRefresh()
        {
            try
            {

                //サムネイル一覧の操作
                List<string[]> photoPathList = new List<string[]>();
                foreach(string pd in photoDirList)
                {
                    var path = System.IO.Path.Combine(Photographer_Select_dir, pd);
                    foreach(string p in System.IO.Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories))
                    {
                        string[] item = { pd, p };
                        photoPathList.Add(item);
                    }
                }

                progressBar1.Minimum = 0;
                progressBar1.Maximum = photoPathList.Count * 2 + 1;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                imageList1.Images.Clear();
                imageListBase.Images.Clear();

                foreach (string[] ppath in photoPathList)
                {
                    //サムネイル作成
                    Size ts = new Size();
                    PointF tp = new PointF();
                    Bitmap img = new Bitmap(ppath[1]);
                    if (img.Size.Width > img.Size.Height)
                    {
                        ts = new Size(img.Size.Width, img.Size.Width);
                        tp = new PointF(0, (img.Size.Width - img.Size.Height) / 2);
                    }
                    else
                    {
                        ts = new Size(img.Size.Height, img.Size.Height);
                        tp = new PointF((img.Size.Height - img.Size.Width) / 2, 0);
                    }
                    Bitmap tb = new Bitmap(ts.Width, ts.Height);
                    Graphics tg = Graphics.FromImage(tb);
                    tg.Clear(Color.White);
                    tg.DrawImage(img, tp.X, tp.Y, img.Width, img.Height);
                    img.Dispose();
                    tg.Dispose();
                
                    string fname = ppath[0] + "/" + System.IO.Path.GetFileName(ppath[1]);
                    this.imageList1.Images.Add(fname, tb);
                    tb.Dispose();

                    progressBar1.Value = progressBar1.Value+1;
                }

                for (int i = 0; imageList1.Images.Count > i; i++)
                {
                    imageListBase.Images.Add(imageList1.Images.Keys[i], imageList1.Images[i]);
                    progressBar1.Value = progressBar1.Value+1;
                }

                progressBar1.Value = progressBar1.Value+1;

                progressBar1.Visible = false;
            }
            catch
            {

                Utile.Message.showMessageOK("E12002");
            }
        }

        public void thumbnailListTagRefresh()
        {
            try
            {

                imageList1.Images.Clear();
                for (int i = 0; imageListBase.Images.Count > i; i++)
                {
                    Image img = imageListBase.Images[i];
                    Graphics tg = Graphics.FromImage(img);
                    //タグ付け
                    string fname = imageListBase.Images.Keys[i];
                    foreach (tagControl tagControl in this.tagsPanel.Controls)
                    {
                        if (tagControl.imgNameList.Contains(fname))
                        {
                            Font fnt = new Font("MS UI Gothic", 10);
                            SolidBrush b = new SolidBrush(this.TAGS[tagControl.tagId]);
                            tg.DrawString("■", fnt, b, 0, tagControl.tagId * 10);
                            fnt.Dispose();
                            b.Dispose();
                        }
                    }

                    //imageList1　差し替え
                    imageList1.Images.Add(fname, img);
                    tg.Dispose();
                    img.Dispose();

                }

                this.thumbnailList.Items.Clear();
                //thumbnailListに格納
                for (int i = 0; this.imageList1.Images.Count > i; i++)
                {
                    ListViewItem lvi = new ListViewItem("[" + i.ToString().PadLeft(4, '0') + "] " + this.imageList1.Images.Keys[i]);
                    lvi.ImageIndex = i;
                    this.thumbnailList.Items.Add(lvi);
                }
            }
            catch
            {
                Utile.Message.showMessageOK("E12003");

            }
        }

        public void thumbnailListTagRefresh(string fname)
        {
            try
            {

                int index = imageListBase.Images.IndexOfKey(fname);
                Image img = imageListBase.Images[index];
                Graphics tg = Graphics.FromImage(img);
                //タグ付け
                foreach (tagControl tagControl in this.tagsPanel.Controls)
                {
                    if (tagControl.imgNameList.Contains(fname))
                    {
                        Font fnt = new Font("MS UI Gothic", 10);
                        SolidBrush b = new SolidBrush(this.TAGS[tagControl.tagId]);
                        tg.DrawString("■", fnt, b, 0, tagControl.tagId * 10);
                        fnt.Dispose();
                        b.Dispose();
                    }
                }

                //imageList1　差し替え
                imageList1.Images.Add(fname, img);
                tg.Dispose();
                img.Dispose();

                ListViewItem lvi = new ListViewItem("[" + index.ToString().PadLeft(4,'0') + "] " + fname);
                lvi.ImageIndex = imageList1.Images.Count -1;
                thumbnailList.Items.Add(lvi);

                thumbnailList.Sorting = System.Windows.Forms.SortOrder.Ascending;
                thumbnailList.Items.RemoveAt(index);
            }
            catch
            {
                Utile.Message.showMessageOK("E12003");

            }
        }

        private void b_renew_Click(object sender, EventArgs e)
        {
            //サムネイル一覧初期化
            thumbnailListRefresh();

            //サムネイル一覧タグ付け
            thumbnailListTagRefresh();
        }
        private void selectPanel_DragDrop(object sender, DragEventArgs e)
        {
            // ドラッグできるアイテムが存在するかチェックします。
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem srcItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                
                Point p = this.selectPanel.PointToClient(new Point(e.X, e.Y));

                //同一写真が開かれているときはreturn
                foreach(Photo_form pf in selectPanel.Controls)
                {
                    if (pf.imgName == this.imageList1.Images.Keys[srcItem.ImageIndex])
                        return;
                }

                Photo_form f1 = new Photo_form(this, this.imageList1.Images.Keys[srcItem.ImageIndex]);
                f1.TopLevel = false;
                f1.Location = p;
                selectPanel.Controls.Add(f1);
                selectPanel.Controls.SetChildIndex(f1,0);
                f1.Show();

            }
        }
        private void selectPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void selectPanel_DragOver(object sender, DragEventArgs e)
        {
        }
        private void thumbnailList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            thumbnailList.DoDragDrop((ListViewItem)e.Item, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void b_allClose_Click(object sender, EventArgs e)
        {
            selectPanel.Controls.Clear();
        }

        private List<Photo_form> getPhoto_formList()
        {

            List<Photo_form> Photo_formList = new List<Photo_form>();

            foreach (Control con in this.selectPanel.Controls)
            {
                if (con.GetType() == typeof(Photo_form))
                {
                    Photo_form f = (Photo_form)con;
                    if (f.checkBox1.Checked == true)
                    {
                        Photo_formList.Add(f);
                    }
                }
            }
            return Photo_formList;
        }
        private void collect()
        {

            foreach (tagControl tc in this.tagsPanel.Controls)
            {
                //写真コピー
                ///フォルダ初期化
                var folderPath = System.IO.Path.Combine(Secondary_Select_dir, Save_dir.Trim(), tc.tagId.ToString());
                folderPath = System.IO.Path.GetFullPath(folderPath);
                if (System.IO.Directory.Exists(folderPath))
                {
                    System.IO.DirectoryInfo target = new System.IO.DirectoryInfo(folderPath);
                    foreach (System.IO.FileInfo ftarget in target.GetFiles())
                    {
                        ftarget.Delete();
                    }
                }
                else
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                if (tc.d_tag.Checked & tc.thumbnailList.Items.Count != 0)
                {
                    ///コピー
                    foreach (var key in tc.imageList1.Images.Keys)
                    {
                        var moto = System.IO.Path.Combine(Photographer_Select_dir, key);
                        var saki = System.IO.Path.Combine(folderPath, key.Replace("/", "_"));
                        System.IO.File.Copy(moto, saki, true);
                    }
                }

                //DB登録
                DB.t_selection selection = new DB.t_selection();
                selection.reception_code = MainForm.session_t_reception.reception_code;
                selection.color = tc.tagId;
                selection.product_name = tc.d_tagName.SelectedItem.ToString();
                selection.folder_name = Save_dir;
                selection.images = tc.thumbnailList.Items.Count;
                selection.order_code = null;
                selection.store_code = MainForm.session_m_staff.store_code;

                selection.Command();

            }

        }
        private void b_collect_Click(object sender, EventArgs e)
        {
            collect();
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void b_tarnRight_Click(object sender, EventArgs e)
        {

            List<Photo_form> form2List = getPhoto_formList();

            if (form2List.Count == 0) return;

            foreach (Photo_form f in form2List)
            {
                f.pictureBox1.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                f.pictureBox1.Size = new Size(f.pictureBox1.Size.Height, f.pictureBox1.Size.Width);
                f.pictureBox1.Refresh();
                f.pictureBox1.Location = new Point((int)(f.panel1.Size.Width / 2 - f.pictureBox1.Size.Width / 2), (int)(f.panel1.Size.Height / 2 - f.pictureBox1.Size.Height / 2));

            }
        }

        private void b_turnLeft_Click(object sender, EventArgs e)
        {

            List<Photo_form> form2List = getPhoto_formList();

            if (form2List.Count == 0) return;

            foreach (Photo_form f in form2List)
            {
                f.pictureBox1.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                f.pictureBox1.Size = new Size(f.pictureBox1.Size.Height, f.pictureBox1.Size.Width);
                f.pictureBox1.Refresh();
                f.pictureBox1.Location = new Point((int)(f.panel1.Size.Width / 2 - f.pictureBox1.Size.Width / 2), (int)(f.panel1.Size.Height / 2 - f.pictureBox1.Size.Height / 2));

            }
        }

        private void b_plas_Click(object sender, EventArgs e)
        {

            List<Photo_form> form2List = getPhoto_formList();
            foreach (Photo_form f in form2List)
            {
                f.picScale(1.1);
            }
        }

        private void b_minus_Click(object sender, EventArgs e)
        {

            List<Photo_form> form2List = getPhoto_formList();
            foreach (Photo_form f in form2List)
            {
                f.picScale(0.9);
            }
        }

        private void b_max_Click(object sender, EventArgs e)
        {

            List<Photo_form> form2List = getPhoto_formList();

            if (form2List.Count == 0) return;

            foreach (Photo_form f in form2List)
            {
                if (f.WindowState == FormWindowState.Maximized)
                {
                    f.WindowState = FormWindowState.Normal;
                    f.pictureBox1.Size = new Size(f.panel1.Size.Width, f.panel1.Size.Height);
                }
                else
                {
                    f.WindowState = FormWindowState.Maximized;
                    f.pictureBox1.Size = new Size(f.panel1.Size.Width, f.panel1.Size.Height);
                }
                f.pictureBox1.Location = new Point(0, 0);

            }
        }

        private void b_arrangeLine_Click(object sender, EventArgs e)
        {

            List<Photo_form> form2List = getPhoto_formList();
            Size s = selectPanel.Size;

            if (form2List.Count == 0) return;

            s.Width = (int)(s.Width / form2List.Count);

            int left = 0;
            foreach (Photo_form f in form2List)
            {
                f.WindowState = FormWindowState.Normal;
                f.Size = s;
                f.Location = new Point(left, 0);
                f.pictureBox1.Location = new Point((int)(f.panel1.Size.Width / 2 - f.pictureBox1.Size.Width / 2), (int)(f.panel1.Size.Height / 2 - f.pictureBox1.Size.Height / 2));
                left += f.Size.Width;
            }
        }

        private void b_arrangeVertical_Click(object sender, EventArgs e)
        {

            List<Photo_form> form2List = getPhoto_formList();
            Size s = selectPanel.Size;

            if (form2List.Count == 0) return;

            s.Height = (int)(s.Height / form2List.Count);

            int top = 0;
            foreach (Photo_form f in form2List)
            {
                f.WindowState = FormWindowState.Normal;
                f.Size = s;
                f.Location = new Point(0, top);
                f.pictureBox1.Location = new Point((int)(f.panel1.Size.Width / 2 - f.pictureBox1.Size.Width / 2), (int)(f.panel1.Size.Height / 2 - f.pictureBox1.Size.Height / 2));
                top += f.Size.Height;
            }
        }

        private void b_arrange_Click(object sender, EventArgs e)
        {
            arrange();
        }
        public void arrange()
        {

            List<Photo_form> form2List = getPhoto_formList();
            var tmp = (int)Math.Ceiling((double)form2List.Count / 2.0);
            int leftCount = tmp < 5 ? tmp : 4;
            int topCount = 0;
            Size s = selectPanel.Size;

            if (form2List.Count == 0) return;

            s.Width = (int)(s.Width / leftCount);
            topCount = (int)((double)form2List.Count / (double)leftCount - 0.01) + 1;
            s.Height = (int)(s.Height / topCount);

            int left = 0;
            int top = 0;
            foreach (Photo_form f in form2List)
            {
                f.WindowState = FormWindowState.Normal;
                f.Size = s;
                f.Location = new Point(left, top);
                f.pictureBox1.Location = new Point((int)(f.panel1.Size.Width / 2 - f.pictureBox1.Size.Width / 2), (int)(f.panel1.Size.Height / 2 - f.pictureBox1.Size.Height / 2));

                left += f.Size.Width;
                if (left + leftCount > selectPanel.Width)
                {
                    left = 0;
                    top += s.Height;
                }
            }
        }

        private void b_hand_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void b_camera_Click(object sender, EventArgs e)
        {
            int ccount = selectPanel.Controls.Count;
            for(int i=0; ccount>i; i++)
            {
                selectPanel.Controls[i].BringToFront();
            }
            Bitmap btm = new Bitmap(selectPanel.Width,selectPanel.Height);
            string savePath = System.IO.Path.Combine(Photographer_Select_dir, photoDirList[0], "キャプチャー" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png");
            selectPanel.DrawToBitmap(btm,new Rectangle(0,0,selectPanel.Width,selectPanel.Height));
            btm.Save(savePath);
            for (int i = 0; ccount > i; i++)
            {
                selectPanel.Controls[i].BringToFront();
            }
            MessageBox.Show("セレクト画面のキャプチャーを作成しました。\nサムネイル一覧に反映する場合は更新ボタンをクリックしてください。");
        }

        private void b_folder_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("格納先フォルダを指定してください。",DefaultResponse:Save_dir.Trim());
            if(str != "")
            {
                using (var dbc = new DB.DBConnect())
                {
                    dbc.npg.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select count(s.folder_name) as count ");
                    sb.Append("from t_selection as s ");
                    sb.Append("where s.folder_name = '@folder_name_target' ".Replace("@folder_name_target", str));
                    sb.Append("and s.folder_name <> '@folder_name' ".Replace("@folder_name", Save_dir));
                    NpgsqlCommand command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if ((long)dataReader["count"] != 0)
                        {
                            MessageBox.Show("登録済みの格納先フォルダのため、指定できません。");
                        }
                        else
                        {
                            Save_dir = str;
                        }
                    }
                }
            }
            
        }


        private void d_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {

                List<Photo_form> PhotoFormList = getPhoto_formList();

                foreach (var fp in PhotoFormList)
                {
                    var s1 = fp.pictureBox1.BackgroundImage.Size;
                    var s2 = fp.pictureBox1.Size;
                    var format = s1.Width > s1.Height ? (float)s1.Width / (float)s2.Width : (float)s1.Height / (float)s2.Height;

                    float scale = 0;
                    try
                    {
                        scale = float.Parse(d_scale.Text) / 100;
                    }
                    catch
                    {
                        Utile.Message.showMessageOK("W12004");
                    }

                    fp.picScale(format * scale);
                }
            }
    }

        private void b_print_Click(object sender, EventArgs e)
        {
            //DBに登録
            collect();

            //顧客情報格納
            string table = "Order_list1";
            Dictionary<string, string> item = new Dictionary<string, string>();
            item.Add("customerCode", MainForm.session_t_reception.customer_code.ToString());
            item.Add("folderName", Save_dir.Trim());
            DB.m_customer cus = DB.m_customer.getSingle(MainForm.session_t_reception.customer_code.ToString());
            item.Add("customerSurnameKana", cus.surname_kana);
            item.Add("customerNameKana", cus.name_kana);
            item.Add("customerSurName", cus.surname);
            item.Add("customerName", cus.name);
            item.Add("orderEntryDate", MainForm.session_t_reception.receipt_date.ToString("yyyy年MM月dd日"));

            Utile.RepoerDB rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();
            rdb.insert(item);

            //写真データ格納

            table = "Order_list2";
            rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();
            using(var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select * ");
                sb.Append(@"from t_selection as s ");
                sb.Append(@"where s.reception_code = '@reception_code' ".Replace("@reception_code",MainForm.session_t_reception.reception_code));

                NpgsqlCommand command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if ((int)dataReader["images"] != 0)
                    {
                        string path = System.IO.Path.Combine(Secondary_Select_dir, dataReader["folder_name"].ToString().Trim(), ((int)dataReader["color"]).ToString());
                        foreach (string fpath in System.IO.Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories))
                        {
                            item = new Dictionary<string, string>();
                            item.Add("product", dataReader["color"].ToString() + " - " + dataReader["product_name"].ToString());
                            //会計処理が未実装のため""をいれる
                            item.Add("unit", "");
                            item.Add("photo", System.IO.Path.GetFullPath(fpath));
                            rdb.insert(item);
                        }
                    }
                }
            }

            PrintForm p = new PrintForm();
            p.PrintReport.Load(@"./Asset/Format/Order_list.flxr", "発注内容一覧");
            p.c1FlexViewer.DocumentSource = p.PrintReport;
            p.Show();
        }
    }
}
