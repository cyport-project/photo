
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
    public partial class Costume_reservation_search : UserControlExp
    {
        //日付変数
		private DateTime? uketsuke_date_from;
        private DateTime? uketsuke_date_to;
        private DateTime? yoyakustart_date;
        private DateTime? yoyakuend_date;


        //店舗構造体の生成
        public struct storeCodeArray
        {
            public string store_code;
            public string store_name;
        }
        //店舗リスト生成
        List<storeCodeArray> storeCodeList = new List<storeCodeArray>();

        //施設構造体の生成
        public struct facilityCodeArray
        {
            public string facility_code;
            public string facility_name;
        }
        //店舗リスト生成
        List<facilityCodeArray> facilityCodeList = new List<facilityCodeArray>();


        //衣装画像のパス
        string Costume_Image_Dir = null;

        public Costume_reservation_search()
        {
            InitializeComponent();

            //衣装画像パス設定
            var photo_root = System.Configuration.ConfigurationManager.AppSettings["photo_root"];
            var Costume_Image = System.Configuration.ConfigurationManager.AppSettings["Costume_Image"];
            Costume_Image_Dir = System.IO.Path.Combine(photo_root, Costume_Image);

            // 新規追加する行のデフォルト高さを設定
            dataGridView1.RowTemplate.Height = 60;
            // 画像未設定時に×画像が表示されないようにする
            dataGridView1.Columns[0].DefaultCellStyle.NullValue = null;
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

            // コンボボックス初期設定
            //店舗名
            d_tenpo.Items.Clear();

            for (var i = 0; i < storeCodeList.Count; i++)
            {
                d_tenpo.Items.Add(storeCodeList[i].store_name);
            }
            d_tenpo.SelectedIndex = -1;

            //施設名
            //施設データ読み込み
            var store = MainForm.session_m_staff.store_code;
            var m_facilityList = DB.m_facility.getFacilityList(store);
            facilityCodeList.Clear();
            foreach (var m_facility in m_facilityList)
            {
                facilityCodeList.Add(new facilityCodeArray
                {
                    facility_code = m_facility["facility_code"].ToString(),
                    facility_name = m_facility["facility_name"].ToString()
                });
            }
            //コンボボックスセット
            d_shisetsu.Items.Clear();
            for(var i = 0; i < facilityCodeList.Count; i++)
            {
                d_shisetsu.Items.Add(facilityCodeList[i].facility_name);
            }
            d_shisetsu.SelectedIndex = -1;

            Set_d_costume_start_jihun();

            Set_d_costume_end_jihun();

            d_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_seibetsu.SelectedIndex = -1;

            //日付の初期設定
            uketsuke_date_from = null;
            uketsuke_date_to = null;
            yoyakustart_date = null;
            yoyakuend_date = null;

            Set_d_uketsuke_date_from(uketsuke_date_from);
            Set_d_uketsuke_date_to(uketsuke_date_to);
            Set_d_costume_yoyakustart_date(yoyakustart_date);
            Set_d_costume_yoyakuend_date(yoyakuend_date);

            //テキストボックスの初期化
            t_customer.Text = null;
            t_costume_code.Text = null;
            t_customer_kana.Text = null;
            t_tekiyou.Text = null;

            //グリッドビュークリア
            dataGridView1.Rows.Clear();

        }


        private void UserCotrol1_Load(object sender, EventArgs e)
		{
            // コンボボックス初期設定
            // コンボボックス初期設定
            //店舗名
            d_tenpo.Items.Clear();

            //施設名
            d_shisetsu.Items.Clear();

            Set_d_costume_start_jihun();

            Set_d_costume_end_jihun();

            //テキストボックスの初期化
            t_customer.Text = null;
            t_costume_code.Text = null;
            t_customer_kana.Text = null;
            t_tekiyou.Text = null;
        }
		
        private void Set_d_costume_start_jihun()
        {
            d_costume_start_jihun.Items.Clear();
            for (int i=0; i < 24; i++)
            {
                int minute = i * 60;
                int h = minute / 60;
                int m = minute % 60;
                d_costume_start_jihun.Items.Add(h.ToString("0") + ":" + m.ToString("00"));
            }
        }

        private void Set_d_costume_end_jihun()
        {
            d_costume_end_jihun.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                int minute = i * 60;
                int h = minute / 60;
                int m = minute % 60;
                d_costume_end_jihun.Items.Add(h.ToString("0") + ":" + m.ToString("00"));
            }
        }

        private void Set_d_uketsuke_date_from(DateTime? DateTime)
        {

            if (DateTime == null)
            {
                d_uketsuke_date_from.Format = DateTimePickerFormat.Custom;
                d_uketsuke_date_from.CustomFormat = " ";
                uketsuke_date_from = null;
            }
            else
            {
                d_uketsuke_date_from.Format = DateTimePickerFormat.Long;
                d_uketsuke_date_from.Value = (DateTime)DateTime;
            }
        }

        private void Set_d_uketsuke_date_to(DateTime? DateTime)
        {

            if (DateTime == null)
            {
                d_uketsuke_date_to.Format = DateTimePickerFormat.Custom;
                d_uketsuke_date_to.CustomFormat = " ";
                uketsuke_date_to = null;
            }
            else
            {
                d_uketsuke_date_to.Format = DateTimePickerFormat.Long;
                d_uketsuke_date_to.Value = (DateTime)DateTime;
            }
        }

        private void Set_d_costume_yoyakustart_date(DateTime? DateTime)
        {

            if (DateTime == null)
            {
                d_costume_yoyakustart_date.Format = DateTimePickerFormat.Custom;
                d_costume_yoyakustart_date.CustomFormat = " ";
                yoyakustart_date = null;
            }
            else
            {
                d_costume_yoyakustart_date.Format = DateTimePickerFormat.Long;
                d_costume_yoyakustart_date.Value = (DateTime)DateTime;
            }
        }

        private void Set_d_costume_yoyakuend_date(DateTime? DateTime)
        {

            if (DateTime == null)
            {
                d_costume_yoyakuend_date.Format = DateTimePickerFormat.Custom;
                d_costume_yoyakuend_date.CustomFormat = " ";
                yoyakuend_date = null;
            }
            else
            {
                d_costume_yoyakuend_date.Format = DateTimePickerFormat.Long;
                d_costume_yoyakuend_date.Value = (DateTime)DateTime;
            }
        }

        private void d_uketsuke_date_from_ValueChanged(object sender, EventArgs e)
        {
            uketsuke_date_from = d_uketsuke_date_from.Value;
            Set_d_uketsuke_date_from(uketsuke_date_from);
        }

        private void d_uketsuke_date_from_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                uketsuke_date_from = null;
                Set_d_uketsuke_date_from(uketsuke_date_from);
            }
        }

        private void d_uketsuke_date_from_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_uketsuke_date_from.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void d_uketsuke_date_to_ValueChanged(object sender, EventArgs e)
        {
            uketsuke_date_to = d_uketsuke_date_to.Value;
            Set_d_uketsuke_date_to(uketsuke_date_to);
        }

        private void d_uketsuke_date_to_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                uketsuke_date_to = null;
                Set_d_uketsuke_date_to(uketsuke_date_to);
            }
        }

        private void d_uketsuke_date_to_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_uketsuke_date_to.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void d_costume_yoyakustart_date_ValueChanged(object sender, EventArgs e)
        {
            yoyakustart_date = d_costume_yoyakustart_date.Value;
            Set_d_costume_yoyakustart_date(yoyakustart_date);
        }

        private void d_costume_yoyakustart_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                yoyakustart_date = null;
                Set_d_costume_yoyakustart_date(yoyakustart_date);
            }
        }

        private void d_costume_yoyakustart_date_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_costume_yoyakustart_date.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void d_costume_yoyakuend_date_ValueChanged(object sender, EventArgs e)
        {
            yoyakuend_date = d_costume_yoyakuend_date.Value;
            Set_d_costume_yoyakuend_date(yoyakuend_date);
        }

        private void d_costume_yoyakuend_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                yoyakuend_date = null;
                Set_d_costume_yoyakuend_date(yoyakuend_date);
            }
        }

        private void d_costume_yoyakuend_date_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_costume_yoyakuend_date.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            //SQLWHERE格納用変数
            String strSQLWHERE = "";

            //WHERE句の編集
            //受付開始日
            strSQLWHERE = uketsuke_date_from != null ? "rec.receipt_date >= " + "'" + uketsuke_date_from + "'" : "";
            
            //受付終了日
            strSQLWHERE += uketsuke_date_to != null && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += uketsuke_date_to != null ? "rec.receipt_date <= " + "'" + uketsuke_date_to + "'" : "";

            //店舗名称
            var storecode = storeCodeList.Find(x => x.store_name == d_tenpo.Text).store_code;
            strSQLWHERE += d_tenpo.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += d_tenpo.Text != "" ? "cr.store_code = " + "'" + storecode + "'" : "";

            //衣装コード
            strSQLWHERE += t_costume_code.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_costume_code.Text != "" ? "cr.costume_code LIKE " + "'%" + t_costume_code.Text + "%'" : "";

            //施設名
            strSQLWHERE += d_shisetsu.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += d_shisetsu.Text != "" ? "cr.facility = " + "'" + d_shisetsu.Text + "'" : "";

            //衣装予約開始年月日
            strSQLWHERE += yoyakustart_date != null && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += yoyakustart_date != null ? "cr.start_date >= " + "'" + yoyakustart_date + "'" : "";

            //衣装予約開始時分
            strSQLWHERE += d_costume_start_jihun.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += d_costume_start_jihun.Text != "" ? "cr.start_time >= " + "'" + d_costume_start_jihun.Text + "'" : "";

            //衣装予約終了年月日
            strSQLWHERE += yoyakuend_date != null && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += yoyakuend_date != null ? "cr.end_date <= " + "'" + yoyakuend_date + "'" : "";

            //衣装予約終了時分
            strSQLWHERE += d_costume_end_jihun.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += d_costume_end_jihun.Text != "" ? "cr.end_time <= " + "'" + d_costume_end_jihun.Text + "'" : "";

            //お客様名
            strSQLWHERE += t_customer.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_customer.Text != "" ? "cr.name LIKE " + "'%" + t_customer.Text + "%'" : "";

            //お客様名(カナ)
            strSQLWHERE += t_customer_kana.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_customer_kana.Text != "" ? "cr.name_kana LIKE " + "'%" + t_customer_kana.Text + "%'" : "";

            //性別
            var intval = (d_seibetsu.Text == "男" ? (int)Utile.Data.性別.男  : (int)Utile.Data.性別.女) + 1 ;
            strSQLWHERE += d_seibetsu.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += d_seibetsu.Text != "" ? " cr.sex =" + "'" + intval + "'" : "";

            //摘要
            strSQLWHERE += t_tekiyou.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_tekiyou.Text != "" ? " cr.memo LIKE " + "'%" + t_tekiyou.Text + "%'" : "";

            strSQLWHERE = strSQLWHERE.Length > 0 ? " WHERE " + strSQLWHERE : "";

            dataGridView1.Rows.Clear();
            //結果格納クエリーの初期化
            NpgsqlDataReader costumeReservationReader = null;

            using (var db = new DB.DBConnect())
            {
                db.npg.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append(@"SELECT 
                            rec.receipt_date as receipt_date,
                            cr.store_code as store_code, 
                            cr.costume_code as costume_code,
                            cr.facility as facility,
                            cr.start_date as start_date,
                            cr.start_time as start_time,
                            cr.end_date as end_date,
                            cr.end_time as end_time,
                            cr.name as name,    
                            cr.name_kana as name_kana,
                            cr.sex as sex,
                            cr.memo as memo,
                            c.image1 as image1
                                                        ");
                sb.Append(@"FROM
                            t_costume_reservation AS cr
                            LEFT JOIN m_costume AS c  ON 
                            c.store_code= cr.store_code and c.costume_code = cr.costume_code
                            LEFT JOIN  t_reservation AS res ON
                            cr.costume_reservation_code = res.costume_reservation_code
                            LEFT JOIN t_reception AS rec ON
                            res.reception_code = rec.reception_code
                            ");

                sb.Append(@strSQLWHERE);
                sb.Append(@" ORDER BY rec.receipt_date,cr.store_code,cr.costume_code");
                var command = new NpgsqlCommand(sb.ToString(), db.npg);

                costumeReservationReader = command.ExecuteReader();
                if (costumeReservationReader.HasRows)
                {
                    while (costumeReservationReader.Read())
                    {

                        //セル内の文字を改行する。
                        dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                        //行テンプレートの高さを設定する
                        dataGridView1.RowTemplate.Height = 80;

                        //店舗編集
                        string Strstore = storeCodeList.Find(x => x.store_code == costumeReservationReader["store_code"].ToString()).store_name;

                        /*画像編集
                         * 画像ファイルのサイズ変更
                         * 画像ファイル存在チェック
                        */
                        string costume_code = costumeReservationReader["costume_code"].ToString();
                        string image1 = costumeReservationReader["image1"].ToString();
                        var path = System.IO.Path.Combine(Costume_Image_Dir, Strstore, costume_code, image1);
                        Bitmap resizeBmp = null;
                        if (System.IO.File.Exists(path))
                        {
                            //存在したら、サイズ変更
                            Bitmap img = new Bitmap(path);

                            //セルの高さに合わせて縮小する
                            int resizeHeight = dataGridView1.RowTemplate.Height;
                            int resizeWidth = (int)(img.Width * ((double)resizeHeight / (double)img.Height));

                            resizeBmp = new Bitmap(resizeWidth, resizeHeight);

                            Graphics g = Graphics.FromImage(resizeBmp);
                            //Bitmap newimg = new Bitmap(img);    
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.DrawImage(img, 0, 0, resizeBmp.Width, resizeBmp.Height);
                        }

                        //日付編集
                        DateTime.TryParse(costumeReservationReader["receipt_date"].ToString(), out DateTime receipt_date);
                        DateTime.TryParse(costumeReservationReader["start_date"].ToString(), out DateTime start_date);
                        DateTime.TryParse(costumeReservationReader["start_time"].ToString(), out DateTime start_time);
                        DateTime.TryParse(costumeReservationReader["end_date"].ToString(), out DateTime end_date);
                        DateTime.TryParse(costumeReservationReader["end_time"].ToString(), out DateTime end_time);

                        //性別変換
                        int.TryParse(costumeReservationReader["sex"].ToString(), out int intVal);
                        var sex = costumeReservationReader["sex"].ToString() != "" ? (string)Enum.ToObject(typeof(Utile.Data.性別), intVal).ToString() : "";
  
  //                      int intVal = int.Parse(costumeReservationReader["sex"].ToString());
  //                      var sex = (string)Enum.ToObject(typeof(Utile.Data.性別), intVal);
                        

                        //結果出力
                        dataGridView1.Rows.Add(
                            resizeBmp,
                            receipt_date.ToShortDateString(),
                            Strstore,
                            costumeReservationReader["costume_code"].ToString(),
                            costumeReservationReader["facility"].ToString(),
                            start_date.ToShortDateString(),
                            start_time.ToShortTimeString(),
                            end_date.ToShortDateString(),
                            end_time.ToShortTimeString(),
                            costumeReservationReader["name"].ToString(),
                            costumeReservationReader["name_kana"].ToString(),
                            sex,
                            costumeReservationReader["memo"].ToString()
                            );
                        }
                }
                else
                {
                    MessageBox.Show("検索結果が0件でした。", "お知らせ", MessageBoxButtons.OK);

                }
            }
        }

        private void b_print_Click(object sender, EventArgs e)
        {
            var table = "Costume_reservation_list";
            Utile.RepoerDB rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();
            for(var i = 0;i < dataGridView1.RowCount; i++)
            {
                Dictionary<string, string> dataitem = new Dictionary<string, string>();
                dataitem.Add("ReceiptDate", dataGridView1.Rows[i].Cells[1].Value.ToString());
                dataitem.Add("StoreName", dataGridView1.Rows[i].Cells[2].Value.ToString());
                dataitem.Add("CostumeCode", dataGridView1.Rows[i].Cells[3].Value.ToString());
                dataitem.Add("FacilityName", dataGridView1.Rows[i].Cells[4].Value.ToString());
                var reservationdate= dataGridView1.Rows[i].Cells[5].Value.ToString() + " " +
                      dataGridView1.Rows[i].Cells[6].Value.ToString() + "～" +
                      dataGridView1.Rows[i].Cells[7].Value.ToString() + " " +
                      dataGridView1.Rows[i].Cells[8].Value.ToString();
                dataitem.Add("ReservationDate",reservationdate);
                dataitem.Add("CostumerNamekana", dataGridView1.Rows[i].Cells[10].Value.ToString());
                dataitem.Add("CostumerName", dataGridView1.Rows[i].Cells[9].Value.ToString());
                dataitem.Add("Sex", dataGridView1.Rows[i].Cells[11].Value.ToString());
                dataitem.Add("Remarks", dataGridView1.Rows[i].Cells[12].Value.ToString());

                var store = DB.m_store.getSingleName(dataGridView1.Rows[i].Cells[2].Value.ToString());
                var costume = DB.m_costume.getSingle(store.store_code,
                    dataGridView1.Rows[i].Cells[3].Value.ToString());

                var photo_root = System.Configuration.ConfigurationManager.AppSettings["photo_root"];
                var Costume_Image = System.Configuration.ConfigurationManager.AppSettings["Costume_Image"];
                var Costume_Image_Dir = System.IO.Path.Combine(photo_root, Costume_Image);
                string image1 = costume.image1;
                var path = System.IO.Path.Combine(Costume_Image_Dir, store.store_name
                    , costume.costume_code, image1);

                dataitem.Add("Folder", System.IO.Path.GetFullPath(path));
                rdb.insert(dataitem);
            }

            PrintForm P = new PrintForm();
            P.PrintReport.Load(@"Asset/Format/Costume_reservation_list.flxr", "Costume_reservation_list");
            P.c1FlexViewer.DocumentSource = P.PrintReport;
            P.Show();
        }

        private void b_return_Click(object sender, EventArgs e)
        {
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void d_tenpo_SelectedValueChange(object sender, EventArgs e)
        {
            //施設名
            //施設データ読み込み
            var store =  storeCodeList.Find(x => x.store_name == d_tenpo.Text).store_code;
            var m_facilityList = DB.m_facility.getFacilityList(store);
            facilityCodeList.Clear();
            foreach (var m_facility in m_facilityList)
            {
                facilityCodeList.Add(new facilityCodeArray
                {
                    facility_code = m_facility["facility_code"].ToString(),
                    facility_name = m_facility["facility_name"].ToString()
                });
            }
            //コンボボックスセット
            d_shisetsu.Items.Clear();
            for (var i = 0; i < facilityCodeList.Count; i++)
            {
                d_shisetsu.Items.Add(facilityCodeList[i].facility_name);
            }
            d_shisetsu.SelectedIndex = -1;
        }

        private void d_tenpo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_tenpo.SelectedIndex = -1;
            }
        }

        private void d_shisetsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_shisetsu.SelectedIndex = -1;
            }
        }

        private void d_costume_end_jihun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_costume_end_jihun.SelectedIndex = -1;
            }
        }

        private void d_costume_start_jihun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_costume_start_jihun.SelectedIndex = -1;
            }
        }

        private void d_seibetsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_seibetsu.SelectedIndex = -1;
            }
        }
    }
}
