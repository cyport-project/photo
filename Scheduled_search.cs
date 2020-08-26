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
using System.Data.SqlClient;
using System.Data.Entity;

namespace 写真館システム
{
    public partial class Scheduled_search : UserControlExp
    {
        static DateTime? t_yoyaku_date_from;　//datepickerでは、nullが使えないので変数を用意
        static DateTime? t_yoyaku_date_to;  //datepickerでは、nullが使えないので変数を用意　
        static DateTime? t_isyouyoyaku_date;  //datepickerでは、nullが使えないので変数を用意

        //SQLWHERE格納用変数
        public String strSQLWHERE = "";

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


        public Scheduled_search()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
                        
            //日付の初期化
            t_yoyaku_date_from = null;
            t_yoyaku_date_to = null;  　
            t_isyouyoyaku_date = null;

            Set_d_yoyaku_date_from(t_yoyaku_date_from);
            Set_d_yoyaku_date_to(t_yoyaku_date_to);
            Set_d_isyouyoyaku_date(t_isyouyoyaku_date);

            //コンボボックスの初期化
            d_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_seibetsu.SelectedIndex = -1;

            //時間コンボボックスの初期化
            Set_d_yoyakukaishijihun();
            Set_d_yoyakusyuuryoujihun();

            //テキストボックスの初期化
            t_isyoukodo.Text = null;
            t_okyakusamamei.Text = null;
            t_satsueimokuteki.Text = null;
            t_tekiyou.Text = null;

            //gridview初期化
            dataGridView1.Rows.Clear();
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
            d_tenpomei.Items.Clear();

            for (var i = 0; i < storeCodeList.Count; i++)
            {
                d_tenpomei.Items.Add(storeCodeList[i].store_name);
            }
            d_tenpomei.SelectedIndex = -1;

            //施設名取得
            var store = MainForm.session_m_staff.store_code;
            var shisetulist = DB.m_facility.getFacilityList(store);
            d_shisetsumei.Items.Clear();

            foreach (var shisetsu in shisetulist)
            {
                d_shisetsumei.Items.Add(shisetsu["facility_name"]);
            }
            d_shisetsumei.SelectedIndex = -1;

            //日付の初期化
            t_yoyaku_date_from = null;
            t_yoyaku_date_to = null;
            t_isyouyoyaku_date = null;


            Set_d_yoyaku_date_from(t_yoyaku_date_from);
            Set_d_yoyaku_date_to(t_yoyaku_date_to);
            Set_d_isyouyoyaku_date(t_isyouyoyaku_date);

            //コンボボックスの初期化
            d_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_seibetsu.SelectedIndex = -1;

            //時間コンボボックスの初期化
            Set_d_yoyakukaishijihun();
            Set_d_yoyakusyuuryoujihun();

            //テキストボックスの初期化
            t_isyoukodo.Text = null;
            t_okyakusamamei.Text = null;
            t_satsueimokuteki.Text = null;
            t_tekiyou.Text = null;

            //gridview初期化
            dataGridView1.Rows.Clear();
        }

        private void Set_d_yoyakukaishijihun()
        {
            d_yoyakukaishijihun.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                int minute = i * 60;
                int h = minute / 60;
                int m = minute % 60;
                d_yoyakukaishijihun.Items.Add(h.ToString("0") + ":" + m.ToString("00"));
            }
        }

        private void Set_d_yoyakusyuuryoujihun()
        {
            d_yoyakusyuuryoujihun.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                int minute = i * 60;
                int h = minute / 60;
                int m = minute % 60;
                d_yoyakusyuuryoujihun.Items.Add(h.ToString("0") + ":" + m.ToString("00"));
            }
        }


        private void Set_d_yoyaku_date_from(DateTime? DateTime)
        {
            if (DateTime == null)
            {
                d_yoyaku_date_from.Format = DateTimePickerFormat.Custom;
                d_yoyaku_date_from.CustomFormat = " ";

            }
            else
            {
                d_yoyaku_date_from.Format = DateTimePickerFormat.Long;
                d_yoyaku_date_from.Value = (DateTime)DateTime;
            }

        }
        private void Set_d_yoyaku_date_to(DateTime? DateTime)
        {
            if (DateTime == null)
            {
                d_yoyaku_date_to.Format = DateTimePickerFormat.Custom;
                d_yoyaku_date_to.CustomFormat = " ";

            }
            else
            {
                d_yoyaku_date_to.Format = DateTimePickerFormat.Long;
                d_yoyaku_date_to.Value = (DateTime)DateTime;
            }

        }
        private void Set_d_isyouyoyaku_date(DateTime? DateTime)
        {
            if (DateTime == null)
            {
                d_isyouyoyaku_date.Format = DateTimePickerFormat.Custom;
                d_isyouyoyaku_date.CustomFormat = " ";

            }
            else
            {
                d_isyouyoyaku_date.Format = DateTimePickerFormat.Long;
                d_isyouyoyaku_date.Value = (DateTime)DateTime;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

 

        private void d_yoyaku_date_from_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                t_yoyaku_date_from = null;
                Set_d_yoyaku_date_from(t_yoyaku_date_from);
            }
        }

        private void d_yoyaku_date_from_ValueChanged(object sender, EventArgs e)
        {
            t_yoyaku_date_from = d_yoyaku_date_from.Value;
            Set_d_yoyaku_date_from(t_yoyaku_date_from);

        }

        private void d_yoyaku_date_from_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_yoyaku_date_from.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void d_yoyaku_date_to_ValueCHanged(object sender, EventArgs e)
        {
            t_yoyaku_date_to = d_yoyaku_date_to.Value;
            Set_d_yoyaku_date_to(t_yoyaku_date_to);
        }

        private void d_yoyaku_date_to_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                t_yoyaku_date_to = null;
                Set_d_yoyaku_date_to(t_yoyaku_date_to);
            }
        }

        private void d_yoyaku_date_to_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_yoyaku_date_to.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void d_isyouyoyaku_date_ValueChanged(object sender, EventArgs e)
        {
            t_isyouyoyaku_date = d_isyouyoyaku_date.Value;
            Set_d_isyouyoyaku_date(t_isyouyoyaku_date);
        }

        private void d_isyouyoyaku_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                t_isyouyoyaku_date = null;
                Set_d_isyouyoyaku_date(t_isyouyoyaku_date);

            }
        }

        private void d_isyouyoyaku_date_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_isyouyoyaku_date.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {

            // DataGridView初期化（データクリア）
            dataGridView1.Rows.Clear();

            //where句の編集
            strSQLWHERE = "";
            //予約年月日（自）

            strSQLWHERE += t_yoyaku_date_from != null ? "fac.start_date >= "+ "'" + t_yoyaku_date_from + "'" : "";

            //予約年月日（至）
            strSQLWHERE += t_yoyaku_date_to != null && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += t_yoyaku_date_to != null ? " fac.start_date <= " + "'" + t_yoyaku_date_to + "'" : "";

            //店舗名称

            strSQLWHERE += d_tenpomei.Text != "" && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += d_tenpomei.Text != "" ? " ms.store_name LIKE " + "'%" + d_tenpomei.Text + "%'" : "";

            //予約開始時分
            strSQLWHERE += d_yoyakukaishijihun.Text != "" && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += d_yoyakukaishijihun.Text != "" ? " fac.start_time >=" + "'" + d_yoyakukaishijihun.Text + "'" : "";

            //予約終了時分
            strSQLWHERE += d_yoyakusyuuryoujihun.Text != "" && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += d_yoyakusyuuryoujihun.Text != "" ? " fac.end_time <=" + "'" + d_yoyakusyuuryoujihun.Text + "'" : "";

            //施設名
            strSQLWHERE += d_shisetsumei.Text != "" && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += d_shisetsumei.Text != "" ? " faci.facility_name LIKE " + "'%" + d_shisetsumei.Text + "%'" : "";

            //お客様名
            strSQLWHERE += t_okyakusamamei.Text != "" && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += t_okyakusamamei.Text != "" ? " cu.surname || cu.name LIKE " + "'%" + t_okyakusamamei.Text + "%'" : "";

            //性別

            var intval = d_seibetsu.Text == "男" ? (int)Utile.Data.性別.男 : (int)Utile.Data.性別.女;

            strSQLWHERE += d_seibetsu.Text != "" && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += d_seibetsu.Text != "" ? "  cu.sex =" + "'" + intval + "'" : "";
            
            
            //撮影目的
            strSQLWHERE += t_satsueimokuteki.Text != "" && strSQLWHERE.Length > 0 ? " and":"" ;
            
            strSQLWHERE += t_satsueimokuteki.Text != "" ? "  fac.shooting_purpose LIKE " + "'%" + t_satsueimokuteki.Text + "%'" : "";


            //衣装コード
            strSQLWHERE += t_isyoukodo.Text != "" && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += t_isyoukodo.Text != "" ? "  cos.costume_code = " + "'" + t_isyoukodo.Text + "'" : "";

            //衣装予約年月日
            strSQLWHERE += t_isyouyoyaku_date != null && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += t_isyouyoyaku_date != null ? "  cos.start_date = " + "'" + t_isyouyoyaku_date + "'" : "";

            //摘要
            strSQLWHERE += t_tekiyou.Text != "" && strSQLWHERE.Length > 0 ? " and" : "";

            strSQLWHERE += t_tekiyou.Text != "" ? "  fac.remarks LIKE " + "'%" + t_tekiyou.Text + "%'" : "";

            strSQLWHERE = strSQLWHERE.Length > 0 ? "WHERE " + strSQLWHERE : "";

            //結果格納クエリーの初期化
            NpgsqlDataReader dataReader = null;

            //検索結果の表示
            using (var db = new DB.DBConnect())
            {
                db.npg.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append(@"select 
                        rec.receipt_date as receipt_date,
                        ms.store_name as store,
                        fac.start_date as start_date,
                        fac.start_time as start_time,
                        fac.end_time as end_time,
                        faci.facility_name as facility_name,
                        cu.surname || cu.name as name,
                        cu.surname_kana || cu.name_kana as namekana,
                        cu.sex as sex,
                        fac.shooting_purpose as shooting_purpose,
                        cos.costume_code as costume_code,
                        cos.start_date as costume_Start_date,
                        cos.start_time as costume_start_time,
                        cos.end_date as costume_end_date,
                        cos.end_time as costume_end_time,
                        fac.remarks as remarks ");
                sb.Append(@"from 
                       ((((((
                        t_facility_reservation fac
                        INNER JOIN m_facility faci ON
                        fac.store_code = faci.store_code and fac.facility_code = faci.facility_code)
                        INNER JOIN m_store ms ON
                        fac.store_code = ms.store_code)
                        LEFT JOIN t_reservation res ON
                        res.facility_reservation_code = fac.facility_reservation_code)
                        LEFT JOIN  t_reception rec ON
                        res.reception_code = rec.reception_code)
                        LEFT JOIN m_customer cu ON 
                        rec.customer_code = cu.customer_code)
                        LEFT JOIN t_costume_reservation cos ON
                        res.costume_reservation_code = cos.costume_reservation_code)
                        ");
                sb.Append(@strSQLWHERE);
                sb.Append(@"ORDER BY receipt_date");

                Console.WriteLine(sb.ToString());
                var command = new NpgsqlCommand(sb.ToString(), db.npg);

                dataReader = command.ExecuteReader();

                if (dataReader.HasRows) {
                    while (dataReader.Read())
                    {

                        //性別をEUMから取得
                        int intVal = 0;
                        if (dataReader["sex"].ToString() != "")
                        {
                            intVal = int.Parse(dataReader["sex"].ToString());
                        }
                        var sex = (Utile.Data.性別)Enum.ToObject(typeof(Utile.Data.性別), intVal);

                        //日付の編集
                        DateTime receipt_date = DateTime.Parse(dataReader["receipt_date"].ToString());
                        DateTime startdate = DateTime.Parse(dataReader["start_date"].ToString());
                        DateTime starttime = DateTime.Parse(dataReader["start_time"].ToString());
                        DateTime endtime = DateTime.Parse(dataReader["end_time"].ToString());
                    
                    //NULLの場合があるので、別途細工
                    DateTime.TryParse(dataReader["costume_start_date"].ToString(), out DateTime _costumestartdate);
                        DateTime.TryParse(dataReader["costume_start_time"].ToString(), out DateTime _costumestarttime);
                        DateTime.TryParse(dataReader["costume_end_date"].ToString(), out DateTime _costumeenddate);
                        DateTime.TryParse(dataReader["costume_end_time"].ToString(), out DateTime _costumeendtime);

                        var strcostume_date = dataReader["costume_start_date"].ToString() != "" ?
                           _costumestartdate.ToShortDateString() + " " +
                           _costumeendtime.ToShortTimeString() +
                           "～" +
                           _costumeenddate.ToShortDateString() + " " +
                           _costumeendtime.ToShortTimeString() : "";


                        dataGridView1.Rows.Add(
                            receipt_date.ToShortDateString(),
                            dataReader["store"].ToString(),
                            startdate.ToShortDateString(),
                            starttime.ToShortTimeString(),
                            endtime.ToShortTimeString(),
                            dataReader["facility_name"].ToString(),
                            dataReader["name"].ToString(),
                            dataReader["namekana"].ToString(),
                            sex,
                            dataReader["shooting_purpose"].ToString(),
                            dataReader["costume_code"].ToString(),
                            strcostume_date,
                            dataReader["remarks"].ToString());
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

            //TODO 印書DBへの登録
            string table = "Reservation_list";
            Utile.RepoerDB rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();
            for(var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var reservation_time = dataGridView1.Rows[i].Cells[3].Value.ToString() + "～" +
                    dataGridView1.Rows[i].Cells[4].Value.ToString();
                Dictionary<string, string> dataitem = new Dictionary<string, string>();
                var reservationDate = DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                dataitem.Add("ReservationDate", reservationDate.ToLongDateString());
                dataitem.Add("Store", dataGridView1.Rows[i].Cells[1].Value.ToString());
                dataitem.Add("ReservationTime", reservation_time);
                dataitem.Add("Facility", dataGridView1.Rows[i].Cells[5].Value.ToString());
                dataitem.Add("CustomerName", dataGridView1.Rows[i].Cells[6].Value.ToString());
                dataitem.Add("CustomerNameKana", dataGridView1.Rows[i].Cells[7].Value.ToString());
                dataitem.Add("Sex", dataGridView1.Rows[i].Cells[8].Value.ToString());
                dataitem.Add("ShootingPurpose", dataGridView1.Rows[i].Cells[9].Value.ToString());
                dataitem.Add("CostumeCode", dataGridView1.Rows[i].Cells[10].Value.ToString());
                dataitem.Add("CostumeReservationDate", dataGridView1.Rows[i].Cells[11].Value.ToString());
                dataitem.Add("Remarks", dataGridView1.Rows[i].Cells[12].Value.ToString());

                rdb.insert(dataitem);
            }

            //印書開始
            PrintForm p = new PrintForm();
            p.PrintReport.Load(@"./Asset/Format/Reservation_list.flxr", "Reservation_list レポート");
            p.c1FlexViewer.DocumentSource = p.PrintReport;
            p.Show();

            //TODO ボタンの活性化
            b_print.Enabled = true;
            b_return.Enabled = true;
        }

        private void b_return_Click(object sender, EventArgs e)
        {
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void d_tenpomei_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_tenpomei.SelectedIndex = -1;
            }
        }

        private void d_yoyakukaishijihun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_yoyakukaishijihun.SelectedIndex = -1;
            }
        }

        private void d_yoyakusyuuryoujihun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_yoyakusyuuryoujihun.SelectedIndex = -1;
            }
        }

        private void d_shisetsumei_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_shisetsumei.SelectedIndex = -1;
            }
        }

        private void d_seibetsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                d_seibetsu.SelectedIndex = -1;
            }
        }

        private void d_tenpomei_SelectedValueChanged(object sender, EventArgs e)
        {
            var store = storeCodeList.Find(x => x.store_name == d_tenpomei.Text).store_code;
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
            d_shisetsumei.Items.Clear();
            for (var i = 0; i < facilityCodeList.Count; i++)
            {
                d_shisetsumei.Items.Add(facilityCodeList[i].facility_name);
            }
            d_shisetsumei.SelectedIndex = -1;
        }
    }
}
