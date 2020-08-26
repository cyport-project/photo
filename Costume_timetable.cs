using C1.C1Schedule;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Linq;





namespace 写真館システム
{
    public partial class Costume_timetable : UserControlExp
    {
        struct CostumeYotei
        {
            public String Subject;
            public String Location;
            public int Duration;
            public DateTime Start;
            public DateTime End;
            public String Label;
            public int LinkID;
        }

        //店舗リスト
        public struct StoreArray
        {
            public string store_code;
            public string store_name;
        }

        //店舗リストの生成
        private List<StoreArray> storeList = new List<StoreArray>();

        //検索用データの取得
        public string costume_store_name = null;
        public int costume_store_index = 0;
        public string costume_store_code = null;
        public bool status1 = false;
        public bool status2 = false;
        public bool status3 = false;
        public bool status4 = false;
        public bool status5 = false;
        public string costume_status1 = null;
        public string costume_status2 = null;
        public string costume_status3 = null;
        public string costume_status4 = null;
        public string costume_status5 = null;
        public string costume_class = null;
        public string costume_code = null;
        public string costume_appearance = null;
        public string costume_brand_name = null;
        public string costume_color = null;
        public string costume_handle = null;
        public string costume_size = null;
        public long costume_minimam_price1 = 0;
        public long costume_minimam_price2 = 0;
        public long costume_minimam_price3 = 0;
        public long costume_max_price1 = 0;
        public long costume_max_price2 = 0;
        public long costume_max_price3 = 0;
        public StringBuilder strSQL = new StringBuilder();
        public StringBuilder strSQLWhere = new StringBuilder();
        public string strSQL2 = null;

        //検索文字フラグ
        public bool class_flag = false;
        public bool code_flag = false;
        public bool appearance_flag = false;
        public bool brandName_flag = false;
        public bool color_flag = false;
        public bool handle_flag = false;
        public bool size_flag = false;
        public bool minimamPrice1_flag = false;
        public bool minimamPrice2_flag = false;
        public bool minimamPrice3_flag = false;
        public bool maxPrice1_flag = false;
        public bool maxPrice2_flag = false;
        public bool maxPrice3_flag = false;

        //nullチェック
        public DateTime? startDate = null;
        public TimeSpan? startTime = null;
        public DateTime? endDate = null;
        public TimeSpan? endTime = null;
        public string shootingPurpose = null;

        //現在の日付取得
        public DateTime? nowDate = DateTime.Now.Date;
        public DateTime? nowDate2 = DateTime.Now.Date.AddDays(1);
        public DateTime? nowDate3 = DateTime.Now.Date.AddDays(2);
        public DateTime? nowDate4 = DateTime.Now.Date.AddDays(3);
        public DateTime? nowDate5 = DateTime.Now.Date.AddDays(4);
        public DateTime? nowDate6 = DateTime.Now.Date.AddDays(5);
        public DateTime? nowDate7 = DateTime.Now.Date.AddDays(6);

        public string rokuyoString = "";

        //ファイルパス用変数
        public StringBuilder dirPath = new StringBuilder();
        public String ImagePath = null;
        public String ImageFile = null;
        public String FilePath = null;

        //取得用リストの作成
        public List<DB.t_costume_reservation> costumeGridGetList = new List<DB.t_costume_reservation>();
        private int costumeGridGetListIndex = 0;
        private List<DB.t_costume_reservation> yoyakuCostumeList = new List<DB.t_costume_reservation>();

        //取得用データ領域
        public struct costumeGridMainteArray
        {
            public string image;
            public string costume_reservation_code;
            public string costume_code;
            public string costume_name;
            public string store_code;
            public string store_name;
            public string store_and_rental_shop_name;
            public string Class;
            public string price;
            public string memo;
            public string shooting_purpose;
            public string facility;
            public string name;
            public DateTime? start_date;
            public TimeSpan? start_time;
            public DateTime? end_date;
            public TimeSpan? end_time;
        }
        //取得用リストの作成
        public List<costumeGridMainteArray> costumeGridMainteList = new List<costumeGridMainteArray>();

        //取得用データ領域
        public struct costumeGridRentArray
        {
            public string image;
            public string costume_reservation_code;
            public string costume_code;
            public string costume_name;
            public string store_code;
            public string store_name;
            public string store_and_rental_shop_name;
            public string Class;
            public string price;
            public string memo;
            public string shooting_purpose;
            public string facility;
            public string name;
            public DateTime? start_date;
            public TimeSpan? start_time;
            public DateTime? end_date;
            public TimeSpan? end_time;
        }
        //取得用リストの作成
        public List<costumeGridRentArray> costumeGridRentList = new List<costumeGridRentArray>();

        //検索フラグ
        public bool search_flag = true;

        //初期化フラグ
        public bool init_flag = false;

        public string shooting_purpose = null;

        //public DateTime date = DateTime.Now.Date;

        public int ListCount = 0;


        checkOperation chk ;

        public Costume_timetable()
        {
            InitializeComponent();

            chk = new checkOperation(this);

            //// suspend C1Schedule updates while loading data
            c_time_line.BeginUpdate();


            ///***************************************
            // * 連絡先（衣装）をスケジュールに追加
            //****************************************/
            C1.C1Schedule.ContactCollection contcol;
            contcol = this.c_time_line.DataStorage.ContactStorage.Contacts;
            C1.C1Schedule.Contact contact;
            int index = 0;

            for (int i = 0; contcol.Count > 0; i++)
                contcol.RemoveAt(0);


            ////施設
            //String[] ishouList = { "和装", "洋装", "その他" };
            String[] ishouList = { ""};
            foreach (String ishou in ishouList)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = ishou,
                    Color = Color.Cyan
                    
                };
                //背景色の変更
                //indexが0の場合
                if(index == 0)
                {
                    contact.Color = Color.Cyan;
                }
                //indexが1の場合
                else if(index == 1)
                {
                    contact.Color = Color.Pink;
                }
                //indexが2の場合
                else
                {
                    contact.Color = Color.LightYellow;
                }
                contcol.Insert(index, contact);
                index++;
            }


            ///***************************************
            // * 予定の追加
            //****************************************/
            ////ラベル設定
            var myLabel = new Dictionary<String, Color>();
            myLabel.Add("", Color.Orange);
 

            ////予定設定
            var ylist = new List<CostumeYotei>();
            ylist.Add(new CostumeYotei
            {
                Subject = "",
                Location = "",
                Duration = 60,
                Start = new DateTime(2018, 10, 19, 13, 30, 0),
                End = new DateTime(2018, 10, 19, 14, 00, 0),
                Label = "",
                LinkID = 0
            });

            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

            //// 新しい予定を作成します。   
            C1.C1Schedule.Appointment app;

            foreach (CostumeYotei y in ylist)
            {
                // 予定の詳細を設定します。    
                app = this.c_time_line.DataStorage.AppointmentStorage.Appointments.Add();
                app.Subject = y.Subject;
                app.Location = y.Location;
                app.Duration = TimeSpan.FromMinutes(y.Duration);
                app.Start = y.Start;
                app.Label = new C1.C1Schedule.Label(myLabel[y.Label], y.Label, y.Label);
                app.Links.Add(contcol[y.LinkID]); 
            }

            ////this.contactsTableAdapter.Fill(reservation_timetableDataSet.Contacts);

            //// resume C1Schedule updates
            c_time_line.EndUpdate();

        }

        //
        //ページの初期化
        //
        public override void PageRefresh()
        {
            //TextBox項目の初期化の初期化
            t_class.Text = null;
            t_costume_code.Text = null;
            t_appearance.Text = null;
            t_brand_name.Text = null;
            t_color.Text = null;
            t_handle.Text = null;
            t_size.Text = null;
            t_minimam_price1.Text = null;
            t_minimam_price2.Text = null;
            t_minimam_price3.Text = null;
            t_max_price1.Text = null;
            t_max_price2.Text = null;
            t_max_price3.Text = null;
            //
            //   ComboBoxの初期化
            //
            //店舗名
            if(init_flag == false)
            {
                //storeCodeListの初期化
                storeList.Clear();
                //dataReaderの初期化
                NpgsqlDataReader dataReader = null;
                //conectionの確立
                var dbc = new DB.DBConnect();
                //コネクションオープン
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select store_code, store_name ");
                sb.Append(@"from m_store ");
                sb.Append(@"where m_store.delete_flag = '0' order by m_store.store_code");
                //SQLの実行
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();
                //データからListの生成
                while (dataReader.Read())
                {

                    //storeCodeListの生成
                    storeList.Add(new StoreArray
                    {
                        store_code = dataReader["store_code"].ToString(),
                        store_name = dataReader["store_name"].ToString()
                    });

                }
                //コネクションクロース
                dbc.npg.Close();

                //店舗名の生成
                for (int i = 0; i < storeList.Count; i++)
                {
                    d_costume_store_name.Items.Add(storeList[i].store_name);
                }
                //初期化フラグを初期化済みにする
                init_flag = true;
            }
            d_costume_store_name.SelectedIndex = 0;
           

            //チェックボックスの初期化
            c_status1.Checked = true;
            c_status2.Checked = false;
            c_status3.Checked = false;
            c_status4.Checked = false;
            c_status5.Checked = false;

            //グリッドビュー初期化
            g_costume_result.Rows.Clear();
            g_date1.HeaderText = DateTime.Now.Date.ToString("MM月dd日");
            g_date2.HeaderText = DateTime.Now.AddDays(1).ToString("MM月dd日");
            g_date3.HeaderText = DateTime.Now.AddDays(2).ToString("MM月dd日");
            g_date4.HeaderText = DateTime.Now.AddDays(3).ToString("MM月dd日");
            g_date5.HeaderText = DateTime.Now.AddDays(4).ToString("MM月dd日");
            g_date6.HeaderText = DateTime.Now.AddDays(5).ToString("MM月dd日");
            g_date7.HeaderText = DateTime.Now.AddDays(6).ToString("MM月dd日");

            //タイムライン日付設定
            setTimeLineDate();

            d_costume_timeline_start_hour.Items.Clear();
            d_costume_timeline_end_hour.Items.Clear();
            d_costume_timeline_start_time.Items.Clear();
            d_costume_timeline_end_time.Items.Clear();
            for (int i = 0; i <= 23; i++)
            {
                d_costume_timeline_start_hour.Items.Add(i);
                d_costume_timeline_end_hour.Items.Add(i);
            }
            for(int i = 0; i <= 59; i+=15)
            {
                d_costume_timeline_start_time.Items.Add(i);
                d_costume_timeline_end_time.Items.Add(i);
            }
            d_costume_timeline_start_hour.Text = DateTime.Now.Hour.ToString();
            d_costume_timeline_end_hour.Text = DateTime.Now.Hour.ToString();
            d_costume_timeline_start_time.Text = "0";
            d_costume_timeline_end_time.Text = "0";

            timeLineClear();

        }
        
        private void setTimeLineDate()
        {

            //TimeLine 表示
            DateTime nowDay = c_time_line.CurrentDate;
            String nowStrDay = nowDay.ToLongDateString();
            JapaneseLunisolarCalendar jpnOldDays = new JapaneseLunisolarCalendar();
            int oldMonth = jpnOldDays.GetMonth(nowDay); //旧暦の月を取得
            int oldDay = jpnOldDays.GetDayOfMonth(nowDay);//旧暦の日を取得　



            //閏月を取得

            int uruMonth = jpnOldDays.GetLeapMonth(jpnOldDays.GetYear(nowDay), jpnOldDays.GetEra(nowDay));

            //閏月がある場合の旧暦月の補正
            if ((uruMonth > 0) && (oldMonth - uruMonth >= 0))
            {
                oldMonth = oldMonth - 1;              //旧暦月の補正
            }

            //六曜を求める
            int rokuyo = (oldMonth + oldDay) % 6;
            switch (rokuyo)
            {
                case 0:
                    rokuyoString = "大安";
                    break;
                case 1:
                    rokuyoString = "赤口";
                    break;
                case 2:
                    rokuyoString = "先勝";
                    break;
                case 3:
                    rokuyoString = "友引";
                    break;
                case 4:
                    rokuyoString = "先負";
                    break;
                case 5:
                    rokuyoString = "仏滅";
                    break;
                default:
                    rokuyoString = "";
                    break;
            }

            label6.Text = nowStrDay + " " + rokuyoString;
        }

        public void searchDataGet()
        {
            
            costume_store_name = this.d_costume_store_name.Text;
            costume_store_index = this.d_costume_store_name.SelectedIndex;
            costume_store_code = storeList[costume_store_index].store_code;
            
            if(class_flag == true || this.t_class.Text == "")
            {
                costume_class = this.t_class.Text;
            }
            if(code_flag == true || this.t_costume_code.Text == "")
            {
                costume_code = this.t_costume_code.Text;
            }
            if(appearance_flag == true || this.t_appearance.Text == "")
            {
                costume_appearance = this.t_appearance.Text;
            }
            if(brandName_flag == true || this.t_brand_name.Text == "")
            {
                costume_brand_name = this.t_brand_name.Text;
            }
            if(color_flag == true || this.t_color.Text == "")
            {
                costume_color = this.t_color.Text;
            }
            if(handle_flag == true || this.t_handle.Text == "")
            {
                costume_handle = this.t_handle.Text;
            }
            if(size_flag == true || this.t_size.Text == "")
            {
                costume_size = this.t_size.Text;
            }
            if(minimamPrice1_flag == true)
            {
                long tmp = 0;
                if(long.TryParse(this.t_minimam_price1.Text,out tmp))
                    costume_minimam_price1 = tmp;
                else
                    costume_minimam_price1 = 0;
            }
            else
            {
                costume_minimam_price1 = 0;
            }
            if(maxPrice1_flag == true)
            {
                long tmp = 0;
                if (long.TryParse(this.t_max_price1.Text, out tmp))
                    costume_max_price1 = tmp;
                else
                    costume_max_price1 = 9999999999;
            }
            else
            {
                costume_max_price1 = 9999999999;
            }
            if(minimamPrice2_flag == true)
            {
                long tmp = 0;
                if (long.TryParse(this.t_minimam_price2.Text, out tmp))
                    costume_minimam_price2 = tmp;
                else
                    costume_minimam_price2 = 0;
            }
            else
            {
                costume_minimam_price2 = 0;
            }
            if(maxPrice2_flag == true)
            {
                long tmp = 0;
                if (long.TryParse(this.t_max_price2.Text, out tmp))
                    costume_max_price2 = tmp;
                else
                    costume_max_price2 = 9999999999;
            }
            else
            {
                costume_max_price2 = 9999999999;
            }
            if(minimamPrice3_flag == true)
            {
                long tmp = 0;
                if (long.TryParse(this.t_minimam_price3.Text, out tmp))
                    costume_minimam_price3 = tmp;
                else
                    costume_minimam_price3 = 0;
            }
            else
            {
                costume_minimam_price3 = 0;
            }
            if(maxPrice3_flag == true)
            {
                long tmp = 0;
                if (long.TryParse(this.t_max_price3.Text, out tmp))
                    costume_max_price3 = tmp;
                else
                    costume_max_price3 = 999999999;
            }
            else
            {
                costume_max_price3 = 999999999;
            }
            if(status1 == true)
            {
                costume_status1 = "0";
            }else if(status1 == false)
            {
                costume_status1 = null;
            }
            if(status2 == true)
            {
                costume_status2 = "1";
            }else if(status2 == false)
            {
                costume_status2 = null;
            }
            if(status3 == true)
            {
                costume_status3 = "2";
            }else if(status3 == false)
            {
                costume_status3 = null;
            }
            if(status4 == true)
            {
                costume_status4 = "3";
            }else if(status4 == false)
            {
                costume_status4 = null;
            }
            if(status5 == true)
            {
                costume_status5 = "4";
            }else if(status5 == false)
            {
                costume_status5 = null;
            }
        }
 

        //店舗名からカーソル離れた時に起きるイベント
        public void d_costume_store_name_Leave(object sender,EventArgs e)
        {
            search_flag = true;
        }

        //分類からカーソルが離れた時に起きるイベント
        public void t_class_Leave(object sender,EventArgs e)
        {
            if (this.t_class.TextLength > 0)
            {
                search_flag = true;
                class_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_class.Text))
            {
                class_flag = false;
            }
        }

        //衣装コードからカーソルが離れた時に起きるイベント
        public void t_costume_code_Leave(object sender,EventArgs e)
        {
            if(this.t_costume_code.TextLength > 0)
            {
                search_flag = true;
                code_flag = true;
            }else if (string.IsNullOrWhiteSpace(this.t_costume_code.Text))
            {
                code_flag = false;
            }
            
        }

        //見た目からカーソルが離れた時に起きるイベント
        public void t_appearance_Leave(object sender,EventArgs e)
        {
            if(this.t_appearance.TextLength > 0)
            {
                search_flag = true;
                appearance_flag = true;
            }else if (string.IsNullOrWhiteSpace(this.t_appearance.Text))
            {
                appearance_flag = false;
            }
        }

        //ブランド名からカーソルが離れた時に起きるイベント
        public void t_brand_name_Leave(object sender,EventArgs e)
        {
            if (this.t_brand_name.TextLength > 0)
            {
                search_flag = true;
                brandName_flag = true;
            }else if (string.IsNullOrWhiteSpace(this.t_brand_name.Text))
            {
                brandName_flag = false;
            }

        }

        //色からカーソルが離れた時に起きるイベント
        public void t_color_Leave(object sender,EventArgs e)
        {
            if(this.t_color.TextLength > 0)
            {
                search_flag =  true;
                color_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_color.Text))
            {
                color_flag = false;
            }
        }

        //柄からカーソルが離れた時に起きるイベント
        public void t_handle_Leave(object sender,EventArgs e)
        {
            if(this.t_handle.TextLength > 0)
            {
                search_flag = true;
                handle_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_handle.Text))
            {
                handle_flag = false;
            }
        }

        //サイズからカーソルが離れた時に起きるイベント
        public void t_size_Leave(object sender,EventArgs e)
        {
            if(this.t_size.TextLength > 0)
            {
                search_flag = true;
                size_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_size.Text))
            {
                size_flag = false;
            }
        }

        //最低金額1からカーソルが離れた時に起きるイベント
        public void t_minimam_price1_Leave(object sender,EventArgs e)
        {
            if(this.t_minimam_price1.TextLength > 0)
            {
                search_flag = true;
                minimamPrice1_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_minimam_price1.Text))
            {
                minimamPrice1_flag = false;
            }
        }

        //最低金額2からカーソルが離れた時に起きるイベント
        public void t_minimam_price2_Leave(object sender,EventArgs e)
        {
            if(this.t_minimam_price2.TextLength > 0)
            {
                search_flag = true;
                minimamPrice2_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_minimam_price2.Text))
            {
                minimamPrice2_flag = false;
            }
        }

        //最低金額3からカーソルが離れた時に起きるイベント
        public void t_minimam_price3_Leave(object sender,EventArgs e)
        {
            if(this.t_minimam_price3.TextLength > 0)
            {
                search_flag = true;
                minimamPrice3_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_minimam_price3.Text))
            {
                minimamPrice3_flag = false;
            }
        }

        //最高金額1からカーソルが離れた時に起きるイベント
        public void t_max_price1_Leave(object sender, EventArgs e)
        {
            if (this.t_max_price1.TextLength > 0)
            {
                search_flag = true;
                maxPrice1_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_max_price1.Text))
            {
                maxPrice1_flag = false;
            }
                
            
        }
        //最高金額2からカーソルが離れた時に起きるイベント
        public void t_max_price2_Leave(object sender,EventArgs e)
        {
            if(this.t_max_price2.TextLength > 0)
            {
                search_flag = true;
                maxPrice2_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_max_price2.Text))
            {
                maxPrice2_flag = false;
            }
        }

        //最高金額3からカーソルが離れた時に起きるイベント
        public void t_max_price3_Leave(object sender,EventArgs e)
        {
            if(this.t_max_price3.TextLength > 0)
            {
                search_flag = true;
                maxPrice3_flag = true;
            }
            else if (string.IsNullOrWhiteSpace(this.t_max_price3.Text))
            {
                maxPrice3_flag = false;
            }
        }

        //チェック1にチェックが入ったかを調べる
        public void c_status1_CheckedChanged(object sender,EventArgs e)
        {
            if(this.c_status1.Checked == true)
            {
                search_flag = true;
                status1 = true;
            }else if(this.c_status1.Checked == false)
            {
                status1 = false;
            }
        }

        //チェック2にチェックが入ったかを調べる
        public void c_status2_CheckedChanged(object sender,EventArgs e)
        {
            if(this.c_status2.Checked == true)
            {
                search_flag = true;
                status2 = true;
            }else if(this.c_status2.Checked == false)
            {
                status2 = false;
            }
         }

        //チェック3にチェックが入ったかを調べる
        public void c_status3_CheckedChanged(object sender,EventArgs e)
        {
            if(this.c_status3.Checked == true)
            {
                search_flag = true;
                status3 = true;
            }else if(this.c_status3.Checked == false)
            {
                status3 = false;
            }
        }

        //チェック4にチェックが入ったかを調べる
        public void c_status4_CheckedChanged(object sender,EventArgs e)
        {
            if(this.c_status4.Checked == true)
            {
                search_flag = true;
                status4 = true;
            }else if(this.c_status4.Checked == false)
            {
                status4 = false;
            }
        }

        //チェック5にチェックが入ったかを調べる
        public void c_status5_CheckedChanged(object sender,EventArgs e)
        {
            if(this.c_status5.Checked == true)
            {
                search_flag = true;
                status5 = true;
            }else if(this.c_status5.Checked == false)
            {
                status5 = false;
            }
        }

        private void b_Customer_serach_Click(object sender, EventArgs e)
        {
            pageParent.PageRefresh();
            MainForm.sendPage(this, MainForm.Customer_search);

        }

        private void b_regist_Click(object sender, EventArgs e)
        {
            pageParent.PageRefresh();
            MainForm.sendPage(this, MainForm.Costume_reservation);

        }

        private void b_resevation_Click(object sender, EventArgs e)
        {
            if(costumeGridGetList.Count == 0)
            {
                Utile.Message.showMessageOK("I05000");
                return;
            }

            MainForm.Costume_reservation.costumeReservationList.Clear();
            foreach (var costumeGridGet in costumeGridGetList)
            {
                if(costumeGridGet.start_date == DateTime.MinValue && costumeGridGet.end_date == DateTime.MinValue)
                {
                    Utile.Message.showMessageOK("I05002");
                    return;
                }

                //衣装予約引数の引き渡し
                MainForm.Costume_reservation.costumeReservationList.Add(costumeGridGet);
            }
            MainForm.Costume_reservation.PageRefresh();
            MainForm.sendPage(this, MainForm.Costume_reservation);

        }


        private void g_costume_result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1 && e.RowIndex == -1)
            {
                for(int i = 0; g_costume_result.Rows.Count >i;i++)
                {
                    g_costume_result.Rows[i].Cells[1].Value = true;
                }
            }

            if (e.ColumnIndex == 3)
            {
                MainForm.Costume_master.PageRefresh(g_costume_result.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                MainForm.sendPage(this, MainForm.Costume_master);
            }
        }

        private void c_time_line_Create(object sender, CancelAppointmentEventArgs e)
        {
            //ポップアップイベントキャンセル
            e.Cancel = true;
        }

        private void c_time_line_Edit(object sender, CancelAppointmentEventArgs e)
        {
            //ポップアップイベントキャンセル
            e.Cancel = true;

            var cr = DB.t_costume_reservation.getSingle(e.Appointment.Label.Text);
            if (cr == null)
            {
                Utile.Message.showMessageOK("I05003");
                return;
            }
            MainForm.Costume_reservation.costumeReservationList.Clear();
            MainForm.Costume_reservation.costumeReservationList.Add(cr);

            MainForm.Costume_reservation.PageRefresh();
            MainForm.sendPage(this, MainForm.Costume_reservation);
        }

        private void c1Calendar1_SelectionChanged(object sender, C1.Win.C1Schedule.SelectionChangedEventArgs e)
        {
            setTimeLineDate();
        }

        private void b_costume_reservation_Click(object sender, EventArgs e)
        {

            g_costume_result.Rows.Clear();
            g_costume_result.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            g_costume_result.RowTemplate.Height = 80;

            var root = (System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString());
            var imgdir = (System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString());
            var storePath = System.IO.Path.Combine(root, imgdir);
            storePath = System.IO.Path.Combine(storePath, costume_store_name);

            using (var dbc = new DB.DBConnect())
            {

                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select* ");
                sb.Append(@"from t_costume_reservation as cr ");
                sb.Append(@"where @date BETWEEN cr.start_date and cr.end_date ");
                sb.Append(@"and cr.store_code = @store_code ");
                sb.Append(@"order by cr.costume_code asc ");

                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@store_code", costume_store_code));
                command.Parameters.Add(new NpgsqlParameter("@date", c1Calendar1.SelectedDates[0]));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var store_code = dataReader["store_code"].ToString();
                    var costume_code = dataReader["costume_code"].ToString();

                    var cos = DB.m_costume.getSingle(store_code, costume_code);

                    var markList = new List<string>();
                    var date = c1Calendar1.SelectedDates[0];
                    g_date1.HeaderText = date.ToString("MM月dd日");
                    g_date2.HeaderText = date.AddDays(1).ToString("MM月dd日");
                    g_date3.HeaderText = date.AddDays(2).ToString("MM月dd日");
                    g_date4.HeaderText = date.AddDays(3).ToString("MM月dd日");
                    g_date5.HeaderText = date.AddDays(4).ToString("MM月dd日");
                    g_date6.HeaderText = date.AddDays(5).ToString("MM月dd日");
                    g_date7.HeaderText = date.AddDays(6).ToString("MM月dd日");
                    for (int i = 0; i < 7; i++)
                    {
                        var mark = yoyakuMark(store_code, costume_code, date.AddDays(i));
                        markList.Add(mark);
                    }

                    Bitmap resizeBmp = null;
                    string costumePath = System.IO.Path.Combine(storePath, costume_code);
                    string imgPath = System.IO.Path.Combine(costumePath, cos.image1);
                    if (System.IO.File.Exists(imgPath))
                    {
                        //存在したら、サイズ変更
                        Bitmap img = new Bitmap(imgPath);

                        //セルの高さに合わせて縮小する
                        int resizeHeight = g_costume_result.RowTemplate.Height;
                        int resizeWidth = (int)(img.Width * ((double)resizeHeight / (double)img.Height));

                        resizeBmp = new Bitmap(resizeWidth, resizeHeight);

                        Graphics g = Graphics.FromImage(resizeBmp);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(img, 0, 0, resizeBmp.Width, resizeBmp.Height);
                    }
                    var rental = cos.rental_store == "" ? "" : " > " + cos.rental_store;
                    var store_name_and_rental = costume_store_name + Environment.NewLine + rental;

                    g_costume_result.Rows.Add(
                       "",
                       false,
                       resizeBmp,
                       costume_code,
                       store_name_and_rental,
                       cos.Class + Environment.NewLine +
                       cos.brand_name + Environment.NewLine +
                       cos.color + Environment.NewLine +
                       cos.handle + Environment.NewLine +
                       cos.size,
                       cos.price1.ToString() + Environment.NewLine +
                       cos.price2.ToString() + Environment.NewLine +
                       cos.price3.ToString(),
                       cos.remarks,
                       markList[0],
                       markList[1],
                       markList[2],
                       markList[3],
                       markList[4],
                       markList[5],
                       markList[6]
                    );
                }
            }
                
        }

        private string changeLikeString(string str)
        {
            if(str == null)
            {
                return "";
            }
            return "%" + str + "%";
        }

        private string yoyakuMark(string store_code, string costume_code, DateTime date)
        {
            using(var dbc = new DB.DBConnect())
            {
                string reslut = "";

                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(" ");
                sb.Append("select case when count(*)> 0 then '●' else '' end as reslut ");
                sb.Append("from t_costume_reservation as cr ");
                sb.Append("where cr.store_code = :store_code ");
                sb.Append("and cr.costume_code = :costume_code ");
                sb.Append("and :date BETWEEN cr.start_date and cr.end_date ");

                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);

                //nakanishi
                //command.Parameters.Add(new NpgsqlParameter("@store_code", store_code));
                command.Parameters.Add(new NpgsqlParameter("store_code", NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters["store_code"].Value = store_code;

                //command.Parameters.Add(new NpgsqlParameter("@costume_code", costume_code));
                command.Parameters.Add(new NpgsqlParameter("costume_code", NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters["costume_code"].Value = costume_code;

                //command.Parameters.Add(new NpgsqlParameter("@date", date));
                command.Parameters.Add(new NpgsqlParameter("date", NpgsqlTypes.NpgsqlDbType.Date));
                command.Parameters["date"].Value = date;

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    reslut = dataReader["reslut"].ToString();
                }
                return reslut;
            }
        }
        private void b_kensaku_Click(object sender, EventArgs e)
        {

            //フォーマットチェック
            chk.clear();
            chk.addControl(t_max_price1);
            chk.addControl(t_max_price2);
            chk.addControl(t_max_price3);
            chk.addControl(t_minimam_price1);
            chk.addControl(t_minimam_price2);
            chk.addControl(t_minimam_price3);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^\d{1,10}?\z", @"半角数字"))
                return;

            searchDataGet();
            //by nakanishi
            timeLineClear();

            g_costume_result.Rows.Clear();
            g_costume_result.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            g_costume_result.RowTemplate.Height = 80;

            var root = (System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString());
            var imgdir = (System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString());
            var storePath = System.IO.Path.Combine(root, imgdir);
            storePath = System.IO.Path.Combine(storePath, costume_store_name);

            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select* ");
                sb.Append(@"from m_costume as cos ");
                sb.Append(@"where cos.delete_flag = '0' ");
                sb.Append(@"and cos.store_code = :store_code ");
                sb.Append("and(@class = '' or cos.\"class\" like @class) ");
                sb.Append(@"and(@costume_code = '' or cos.costume_code like :costume_code) ");
                sb.Append(@"and(@appearance = '' or cos.appearance like @appearance) ");
                sb.Append(@"and(@brand_name = '' or cos.brand_name like @brand_name) ");
                sb.Append(@"and(@color = '' or cos.color like @color) ");
                sb.Append(@"and(@handle = '' or cos.handle like @handle) ");
                sb.Append(@"and(@size = '' or cos.size like @size) ");
                sb.Append(@"and(cos.price1 between @minprice1 and @maxprice1) ");
                sb.Append(@"and(cos.price2 between @minprice2 and @maxprice2) ");
                sb.Append(@"and(cos.price3 between @minprice3 and @maxprice3) ");
                sb.Append(@"and not(@status1 = '' and cos.status = '0') ");
                sb.Append(@"and not(@status2 = '' and cos.status = '1') ");
                sb.Append(@"and not(@status3 = '' and cos.status = '2') ");
                sb.Append(@"and not(@status4 = '' and cos.status = '3') ");
                sb.Append(@"and not(@status5 = '' and cos.status = '4') ");
                sb.Append(@"order by cos.costume_code ");
                
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                //command.Parameters.Add(new NpgsqlParameter("@store_code", costume_store_code));
                command.Parameters.Add(new NpgsqlParameter("store_code", NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters["store_code"].Value = costume_store_code;

                command.Parameters.Add(new NpgsqlParameter("@class", changeLikeString(costume_class)));

                //command.Parameters.Add(new NpgsqlParameter("@costume_code", changeLikeString(costume_code)));
                command.Parameters.Add(new NpgsqlParameter("costume_code", NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters["costume_code"].Value = changeLikeString(costume_code);

                command.Parameters.Add(new NpgsqlParameter("@appearance", changeLikeString(costume_appearance)));
                command.Parameters.Add(new NpgsqlParameter("@brand_name", changeLikeString(costume_brand_name)));
                command.Parameters.Add(new NpgsqlParameter("@color", changeLikeString(costume_color)));
                command.Parameters.Add(new NpgsqlParameter("@handle", changeLikeString(costume_handle)));
                command.Parameters.Add(new NpgsqlParameter("@size", changeLikeString(costume_size)));
                command.Parameters.Add(new NpgsqlParameter("@minprice1", costume_minimam_price1));
                command.Parameters.Add(new NpgsqlParameter("@minprice2", costume_minimam_price2));
                command.Parameters.Add(new NpgsqlParameter("@minprice3", costume_minimam_price3));
                command.Parameters.Add(new NpgsqlParameter("@maxprice1", costume_max_price1));
                command.Parameters.Add(new NpgsqlParameter("@maxprice2", costume_max_price2));
                command.Parameters.Add(new NpgsqlParameter("@maxprice3", costume_max_price3));
                command.Parameters.Add(new NpgsqlParameter("@status1", costume_status1 == null ? "" : costume_status1));
                command.Parameters.Add(new NpgsqlParameter("@status2", costume_status2 == null ? "" : costume_status2));
                command.Parameters.Add(new NpgsqlParameter("@status3", costume_status3 == null ? "" : costume_status3));
                command.Parameters.Add(new NpgsqlParameter("@status4", costume_status4 == null ? "" : costume_status4));
                command.Parameters.Add(new NpgsqlParameter("@status5", costume_status5 == null ? "" : costume_status5));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    //var costume = new DB.m_costume();
                    var store_code = dataReader["store_code"].ToString();
                    var costume_code = dataReader["costume_code"].ToString();
                    var markList = new List<string>();
                    var date = c1Calendar1.SelectedDates[0];
                    g_date1.HeaderText = date.ToString("MM月dd日");
                    g_date2.HeaderText = date.AddDays(1).ToString("MM月dd日");
                    g_date3.HeaderText = date.AddDays(2).ToString("MM月dd日");
                    g_date4.HeaderText = date.AddDays(3).ToString("MM月dd日");
                    g_date5.HeaderText = date.AddDays(4).ToString("MM月dd日");
                    g_date6.HeaderText = date.AddDays(5).ToString("MM月dd日");
                    g_date7.HeaderText = date.AddDays(6).ToString("MM月dd日");
                    for (int i = 0; i < 7; i++)
                    {
                        var mark = yoyakuMark(store_code, costume_code, date.AddDays(i));
                        markList.Add(mark);
                    }

                    Bitmap resizeBmp = null;
                    string costumePath = System.IO.Path.Combine(storePath, costume_code);
                    string imgPath = System.IO.Path.Combine(costumePath, dataReader["image1"].ToString());
                    if (System.IO.File.Exists(imgPath))
                    {
                        //存在したら、サイズ変更
                        Bitmap img = new Bitmap(imgPath);

                        //セルの高さに合わせて縮小する
                        int resizeHeight = g_costume_result.RowTemplate.Height;
                        int resizeWidth = (int)(img.Width * ((double)resizeHeight / (double)img.Height));

                        resizeBmp = new Bitmap(resizeWidth, resizeHeight);

                        Graphics g = Graphics.FromImage(resizeBmp);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(img, 0, 0, resizeBmp.Width, resizeBmp.Height);
                    }
                    var rental = dataReader["rental_store"].ToString() == "" ? "" : " > " + dataReader["rental_store"].ToString();
                    var store_name_and_rental = costume_store_name + Environment.NewLine + rental;

                    g_costume_result.Rows.Add(
                       "",
                       false,
                       resizeBmp,
                       costume_code,
                       store_name_and_rental,
                       dataReader["class"].ToString() + Environment.NewLine +
                       dataReader["brand_name"].ToString() + Environment.NewLine +
                       dataReader["color"].ToString() + Environment.NewLine +
                       dataReader["handle"].ToString() + Environment.NewLine +
                       dataReader["size"].ToString(),
                       dataReader["price1"].ToString() + Environment.NewLine +
                       dataReader["price2"].ToString() + Environment.NewLine +
                       dataReader["price2"].ToString() ,
                       dataReader["remarks"].ToString(),
                       markList[0],
                       markList[1],
                       markList[2],
                       markList[3],
                       markList[4],
                       markList[5],
                       markList[6]
                    );
                }
            }
        }

        private void g_check_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in g_costume_result.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                if (chk.Value == chk.TrueValue)
                {
                    chk.Value = chk.FalseValue;
                }
                else
                {
                    chk.Value = chk.TrueValue;
                }
            }
        }


        private void b_ikkkatu_timetable_drow_Click(object sender, EventArgs e)
        {
            //costumeGridGetList.Clear();
            foreach(DataGridViewRow row in g_costume_result.Rows)
            {
                var chk = "";
                if (row.Cells[1].Value != null)
                {
                    chk = row.Cells[1].Value.ToString();
                }
                if (chk == "1" || chk == "True")
                {
                    var addFlg = true;
                    foreach(var cos in costumeGridGetList)
                    {
                        if (cos.costume_code == row.Cells[3].Value.ToString())
                            addFlg = false;
                    }
                    if(addFlg)
                        costumeGridGetList.Add(new DB.t_costume_reservation
                        {
                            costume_reservation_code = "",
                            start_date = DateTime.MinValue,
                            start_time = TimeSpan.MinValue,
                            end_date = DateTime.MinValue,
                            end_time = TimeSpan.MinValue,
                            reservator = DB.m_customer.getSingle(MainForm.session_t_reception.customer_code).surname + DB.m_customer.getSingle(MainForm.session_t_reception.customer_code).name,
                            memo = null,
                            cancellation_date = DateTime.MinValue,
                            shooting_purpose = null,
                            store_code = costume_store_code,
                            costume_code = row.Cells[3].Value.ToString(),
                            facility = null,
                            name = null,
                            name_kana = null,
                            sex = null,
                            birthday = DateTime.MinValue,
                            height = 0,
                            foot = 0,
                            sleeve = 0

                        });
                }
            }
            yoyakuCostumeList.Clear();
            foreach (var cos in costumeGridGetList)
            {
                using (var dbc = new DB.DBConnect())
                {
                    var q = from t in dbc.t_costume_reservation
                            where t.store_code == costume_store_code && t.costume_code == cos.costume_code
                            select t;
                    foreach(var data in q)
                    {
                        yoyakuCostumeList.Add(data);
                    }
                }
            }

            //タイムラインの描画を止める
            c_time_line.BeginUpdate();
            
            ///***************************************
            // * 連絡先（衣装）をスケジュールに追加
            //****************************************/
            C1.C1Schedule.ContactCollection contcol;
            contcol = this.c_time_line.DataStorage.ContactStorage.Contacts;
            C1.C1Schedule.Contact contact;
            int index = 0;
            costumeGridGetListIndex = 0;

            //画像を削除
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

            for (int i = 0; contcol.Count > 0; i++)
                contcol.RemoveAt(0);

            //衣装
            List<string> costume_codeList = new List<string>();

            for(int i = 0; i < costumeGridGetList.Count; i++)
            {
                costume_codeList.Add(costumeGridGetList[i].costume_code);
                if (costumeGridGetListIndex % 3 == 2)
                {
                    costumeGridGetListIndex++;
                    break;
                }
                else
                {
                    costumeGridGetListIndex++;
                }
            }

            foreach (String costume_code in costume_codeList)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = costume_code,
                    Color = Color.Cyan

                };
                contcol.Insert(index, contact);
                index++;
            }

            for(int i = costumeGridGetListIndex; i < 3; i++)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = new string(' ', i),
                    Color = Color.Cyan

                };
                contcol.Insert(index, contact);
                index++;
            }

            ///***************************************
            // * 予定の追加
            //****************************************/
            //// 新しい予定を作成します。   
            C1.C1Schedule.Appointment app;
            for(int i = 0; i < costumeGridGetListIndex; i++)
            {
                var root = (System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString());
                var imgdir = (System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString());
                var storePath = System.IO.Path.Combine(root, imgdir);
                storePath = System.IO.Path.Combine(storePath, costume_store_name);
                var costumePath = System.IO.Path.Combine(storePath, costumeGridGetList[i].costume_code);
                var imgPath = System.IO.Path.Combine(costumePath, DB.m_costume.getSingle(costume_store_code, costumeGridGetList[i].costume_code).image1);

                if (i % 3 == 0)
                {
                    pictureBox6.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (i % 3 == 1)
                {
                    pictureBox5.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (i % 3 == 2)
                {
                    pictureBox4.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                if (costumeGridGetList[i].start_date != DateTime.MinValue)
                {
                    var start = new DateTime(costumeGridGetList[i].start_date.Year, costumeGridGetList[i].start_date.Month, costumeGridGetList[i].start_date.Day,
                        costumeGridGetList[i].start_time.Hours, costumeGridGetList[i].start_time.Minutes, 0);
                    var end = new DateTime(costumeGridGetList[i].end_date.Year, costumeGridGetList[i].end_date.Month, costumeGridGetList[i].end_date.Day,
                        costumeGridGetList[i].end_time.Hours, costumeGridGetList[i].end_time.Minutes, 0);
                    var duration = end.Subtract(start);

                    // 予定の詳細を設定します。    
                    app = this.c_time_line.DataStorage.AppointmentStorage.Appointments.Add();
                    app.Subject = "予定";
                    app.Location = "予定";
                    app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                    app.Start = start;
                    app.Label = new C1.C1Schedule.Label(Color.Orange, "予定", "予定");
                    app.Links.Add(contcol[i]); 
                }

                foreach(var y in yoyakuCostumeList)
                {
                    if(y.costume_code == costumeGridGetList[i].costume_code)
                    {
                        var start = new DateTime(y.start_date.Year, y.start_date.Month, y.start_date.Day,
                            y.start_time.Hours, y.start_time.Minutes, 0);
                        var end = new DateTime(y.end_date.Year, y.end_date.Month, y.end_date.Day,
                            y.end_time.Hours, y.end_time.Minutes, 0);
                        var duration = end.Subtract(start);

                        // 予定の詳細を設定します。    
                        app = this.c_time_line.DataStorage.AppointmentStorage.Appointments.Add();
                        app.Subject = y.shooting_purpose;
                        app.Location = y.facility;
                        app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                        app.Start = start;
                        app.Label = new C1.C1Schedule.Label(Color.SkyBlue, y.costume_reservation_code, y.costume_reservation_code);
                        app.Links.Add(contcol[i]); 
                    }
                }

            }
            ////this.contactsTableAdapter.Fill(reservation_timetableDataSet.Contacts);

            //// resume C1Schedule updates
            c_time_line.EndUpdate();

            if (costumeGridGetListIndex == costumeGridGetList.Count)
            {

                b_next_cos.Visible = false;
                b_prev_cos.Visible = false;
            }
            else
            {
                b_next_cos.Visible = true;
                b_prev_cos.Visible = false;
            }
        }

        private void b_ikkatu_mainte_Click(object sender, EventArgs e)
        {
            int i = 0;
            costumeGridMainteList.Clear();
            foreach (DataGridViewRow row in g_costume_result.Rows)
            {
                var chk = "";
                if (row.Cells[1].Value != null)
                {
                    chk = row.Cells[1].Value.ToString();
                }
                if (chk == "1" || chk == "True")
                {
                    costumeGridMainteList.Add(new costumeGridMainteArray
                    {
                        costume_code = row.Cells[3].Value.ToString(),
                        store_code = storeList[this.d_costume_store_name.SelectedIndex].store_code,
                    });
                }
                i++;
            }

            foreach (var costumeGridMainte in costumeGridMainteList)
            {
                StringBuilder sb = new StringBuilder();

                // 接続インスタンスを作成。
                var dbc = new DB.DBConnect();
                dbc.npg.Open();
                using (var transaction = dbc.npg.BeginTransaction())
                {
                    sb.Append("update m_costume set ");
                    sb.Append(" status = '" + 1 + "'");
                    sb.Append(" where store_code = '" + costumeGridMainte.store_code + "'");
                    sb.Append(" and costume_code = '" + costumeGridMainte.costume_code + "'");
                    sb.Append(" and delete_flag = '" + 0 + "'");
                    string strSQL3 = sb.ToString();
                    var command = new NpgsqlCommand(strSQL3, dbc.npg);

                    try
                    {
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch(NpgsqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        dbc.npg.Close();
                    }
                }
            }
        }

        private void b_ikkatsu_rental_Click(object sender, EventArgs e)
        {
            int i = 0;
            costumeGridRentList.Clear();
            foreach (DataGridViewRow row in g_costume_result.Rows)
            {
                var chk = "";
                if (row.Cells[1].Value != null)
                {
                    chk = row.Cells[1].Value.ToString();
                }
                if (chk == "1" || chk == "True")
                {
                    costumeGridRentList.Add(new costumeGridRentArray {
                        costume_code = row.Cells[3].Value.ToString(),
                        store_code = storeList[this.d_costume_store_name.SelectedIndex].store_code,
                    });
                }
                i++;
            }
            MainForm.Costume_timetable.Hide();
            Form rental = new rental();
            rental.Show();
            MainForm.Costume_timetable.Show();
        }

        private void timeLineClear()
        {

            costumeGridGetList.Clear();
            C1.C1Schedule.ContactCollection contcol;
            contcol = this.c_time_line.DataStorage.ContactStorage.Contacts;
            C1.C1Schedule.Contact contact;
            int index = 0;

            //画像を削除
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

            for (int i = 0; contcol.Count > 0; i++)
                contcol.RemoveAt(0);

            ////施設
            String[] ishouList = { "", " ", "  " };
            foreach (String ishou in ishouList)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = ishou,
                    Color = Color.Cyan

                };
                contcol.Insert(index, contact);
                index++;
            }

            //// resume C1Schedule updates
            c_time_line.EndUpdate();
        }

        private void b_clear_Click(object sender, EventArgs e)
        {
            timeLineClear();
        }

        private void c1Calendar1_Click(object sender, EventArgs e)
        {
            setTimeLineDate();
        }

        private void b_return_Click(object sender, EventArgs e)
        {
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void b_next_day_Click(object sender, EventArgs e)
        {
            c_time_line.ShowDates(new DateTime[] { c_time_line.CurrentDate.AddDays(1) });
            setTimeLineDate();
        }

        private void b_prev_day_Click(object sender, EventArgs e)
        {

            c_time_line.ShowDates(new DateTime[] { c_time_line.CurrentDate.AddDays(-1) });
            setTimeLineDate();
        }

        private void b_next_cos_Click(object sender, EventArgs e)
        {
            int i = costumeGridGetListIndex;

            //タイムラインの描画を止める
            c_time_line.BeginUpdate();

            ///***************************************
            // * 連絡先（衣装）をスケジュールに追加
            //****************************************/
            C1.C1Schedule.ContactCollection contcol;
            contcol = this.c_time_line.DataStorage.ContactStorage.Contacts;
            C1.C1Schedule.Contact contact;
            int index = 0;

            //画像を削除
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

            for (i = 0; contcol.Count > 0; i++)
                contcol.RemoveAt(0);


            //衣装
            List<string> ishouList = new List<string>();

            for (i = costumeGridGetListIndex; i < costumeGridGetList.Count; i++)
            {
                ishouList.Add(costumeGridGetList[i].costume_code);
                if (costumeGridGetListIndex % 3 == 2)
                {
                    costumeGridGetListIndex++;
                    break;
                }
                else
                {
                    costumeGridGetListIndex++;
                }
            }

            foreach (String ishou in ishouList)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = ishou,
                    Color = Color.Cyan

                };
                contcol.Insert(index, contact);
                index++;
            }

            for (i = costumeGridGetListIndex; i%3 != 0; i++)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = new string(' ', i),
                    Color = Color.Cyan

                };
                contcol.Insert(index, contact);
                index++;
                //costumeGridGetListIndex++;
            }

            ///***************************************
            // * 予定の追加
            //****************************************/
            //// 新しい予定を作成します。   
            C1.C1Schedule.Appointment app;


            //年月日時間に分割する
            //施設予約を読み込む
            for (i = costumeGridGetListIndex - ishouList.Count; i < costumeGridGetListIndex; i++)
            {
                var root = (System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString());
                var imgdir = (System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString());
                var storePath = System.IO.Path.Combine(root, imgdir);
                storePath = System.IO.Path.Combine(storePath, costume_store_name);
                var costumePath = System.IO.Path.Combine(storePath, costumeGridGetList[i].costume_code);
                var imgPath = System.IO.Path.Combine(costumePath, DB.m_costume.getSingle(costume_store_code, costumeGridGetList[i].costume_code).image1);

                if (i % 3 == 0)
                {
                    pictureBox6.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (i % 3 == 1)
                {
                    pictureBox5.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (i % 3 == 2)
                {
                    pictureBox4.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                if (costumeGridGetList[i].start_date != DateTime.MinValue)
                {
                    var start = new DateTime(costumeGridGetList[i].start_date.Year, costumeGridGetList[i].start_date.Month, costumeGridGetList[i].start_date.Day,
                        costumeGridGetList[i].start_time.Hours, costumeGridGetList[i].start_time.Minutes, 0);
                    var end = new DateTime(costumeGridGetList[i].end_date.Year, costumeGridGetList[i].end_date.Month, costumeGridGetList[i].end_date.Day,
                        costumeGridGetList[i].end_time.Hours, costumeGridGetList[i].end_time.Minutes, 0);
                    var duration = end.Subtract(start);

                    // 予定の詳細を設定します。    
                    app = this.c_time_line.DataStorage.AppointmentStorage.Appointments.Add();
                    app.Subject = "予定";
                    app.Location = "予定";
                    app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                    app.Start = start;
                    app.Label = new C1.C1Schedule.Label(Color.Orange, "予定", "予定");
                    app.Links.Add(contcol[i%3]);
                }

                foreach (var y in yoyakuCostumeList)
                {
                    if (y.costume_code == costumeGridGetList[i].costume_code)
                    {
                        var start = new DateTime(y.start_date.Year, y.start_date.Month, y.start_date.Day,
                            y.start_time.Hours, y.start_time.Minutes, 0);
                        var end = new DateTime(y.end_date.Year, y.end_date.Month, y.end_date.Day,
                            y.end_time.Hours, y.end_time.Minutes, 0);
                        var duration = end.Subtract(start);

                        // 予定の詳細を設定します。    
                        app = this.c_time_line.DataStorage.AppointmentStorage.Appointments.Add();
                        app.Subject = y.shooting_purpose;
                        app.Location = y.facility;
                        app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                        app.Start = start;
                        app.Label = new C1.C1Schedule.Label(Color.SkyBlue, y.costume_reservation_code, y.costume_reservation_code);
                        app.Links.Add(contcol[i % 3]); 
                    }
                }
            }

            ////this.contactsTableAdapter.Fill(reservation_timetableDataSet.Contacts);

            //// resume C1Schedule updates
            c_time_line.EndUpdate();

            if (costumeGridGetListIndex == costumeGridGetList.Count)
                b_next_cos.Visible = false;
            else
                b_next_cos.Visible = true;
            b_prev_cos.Visible = true;
        }

        private void b_prev_cos_Click(object sender, EventArgs e)
        {


            if (pictureBox5.Image == null)
            {
                costumeGridGetListIndex = costumeGridGetListIndex - 4;
            }
            else if (pictureBox4.Image == null)
            {
                costumeGridGetListIndex = costumeGridGetListIndex - 5;
            }
            else
            {
                costumeGridGetListIndex = costumeGridGetListIndex - 6;
            }

            if (costumeGridGetListIndex == 0)
                b_prev_cos.Visible = false;
            else
                b_prev_cos.Visible = true;

            int i = costumeGridGetListIndex;

            //タイムラインの描画を止める
            c_time_line.BeginUpdate();

            ///***************************************
            // * 連絡先（衣装）をスケジュールに追加
            //****************************************/
            C1.C1Schedule.ContactCollection contcol;
            contcol = this.c_time_line.DataStorage.ContactStorage.Contacts;
            C1.C1Schedule.Contact contact;
            int index = 0;

            //画像を削除
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

            for (i = 0; contcol.Count > 0; i++)
                contcol.RemoveAt(0);

            string[] costumeCode = new string[ListCount];

            //衣装
            List<string> ishouList = new List<string>();

            for (i = costumeGridGetListIndex; i < costumeGridGetList.Count; i++)
            {
                ishouList.Add(costumeGridGetList[i].costume_code);
                if (costumeGridGetListIndex % 3 == 2)
                {
                    costumeGridGetListIndex++;
                    break;
                }
                else
                {
                    costumeGridGetListIndex++;
                }
            }

            costumeCode = ishouList.ToArray();
            foreach (String ishou in ishouList)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = ishou,
                    Color = Color.Cyan

                };
                contcol.Insert(index, contact);
                index++;
            }

            for (i = costumeGridGetListIndex; i % 3 != 0; i++)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = new string(' ', i),
                    Color = Color.Cyan

                };
                contcol.Insert(index, contact);
                index++;
                //costumeGridGetListIndex++;
            }

            ///***************************************
            // * 予定の追加
            //****************************************/

            //// 新しい予定を作成します。   
            C1.C1Schedule.Appointment app;

            //年月日時間に分割する
            //施設予約を読み込む
            for (i = costumeGridGetListIndex - ishouList.Count; i < costumeGridGetListIndex; i++)
            {

                var root = (System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString());
                var imgdir = (System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString());
                var storePath = System.IO.Path.Combine(root, imgdir);
                storePath = System.IO.Path.Combine(storePath, costume_store_name);
                var costumePath = System.IO.Path.Combine(storePath, costumeGridGetList[i].costume_code);
                var imgPath = System.IO.Path.Combine(costumePath, DB.m_costume.getSingle(costume_store_code, costumeGridGetList[i].costume_code).image1);

                if (i % 3 == 0)
                {
                    pictureBox6.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (i % 3 == 1)
                {
                    pictureBox5.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (i % 3 == 2)
                {
                    pictureBox4.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                if (costumeGridGetList[i].start_date != DateTime.MinValue)
                {
                    var start = new DateTime(costumeGridGetList[i].start_date.Year, costumeGridGetList[i].start_date.Month, costumeGridGetList[i].start_date.Day,
                        costumeGridGetList[i].start_time.Hours, costumeGridGetList[i].start_time.Minutes, 0);
                    var end = new DateTime(costumeGridGetList[i].end_date.Year, costumeGridGetList[i].end_date.Month, costumeGridGetList[i].end_date.Day,
                        costumeGridGetList[i].end_time.Hours, costumeGridGetList[i].end_time.Minutes, 0);
                    var duration = end.Subtract(start);

                    // 予定の詳細を設定します。    
                    app = this.c_time_line.DataStorage.AppointmentStorage.Appointments.Add();
                    app.Subject = "予定";
                    app.Location = "";
                    app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                    app.Start = start;
                    app.Label = new C1.C1Schedule.Label(Color.Orange, "予定", "予定");
                    app.Links.Add(contcol[i % 3]);
                }

                foreach (var y in yoyakuCostumeList)
                {
                    if (y.costume_code == costumeGridGetList[i].costume_code)
                    {
                        var start = new DateTime(y.start_date.Year, y.start_date.Month, y.start_date.Day,
                            y.start_time.Hours, y.start_time.Minutes, 0);
                        var end = new DateTime(y.end_date.Year, y.end_date.Month, y.end_date.Day,
                            y.end_time.Hours, y.end_time.Minutes, 0);
                        var duration = end.Subtract(start);

                        // 予定の詳細を設定します。    
                        app = this.c_time_line.DataStorage.AppointmentStorage.Appointments.Add();
                        app.Subject = y.shooting_purpose;
                        app.Location = y.facility;
                        app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                        app.Start = start;
                        app.Label = new C1.C1Schedule.Label(Color.SkyBlue, y.costume_reservation_code, y.costume_reservation_code);
                        app.Links.Add(contcol[i % 3]); 
                    }
                }
            }

            ////this.contactsTableAdapter.Fill(reservation_timetableDataSet.Contacts);

            //// resume C1Schedule updates
            c_time_line.EndUpdate();
        }

        private void b_date_range_Click(object sender, EventArgs e)
        {
            //期間範囲を取得
            DateTime start_date = d_costume_timeline_start_date.Value.Date;
            TimeSpan start_time = new TimeSpan(int.Parse(d_costume_timeline_start_hour.SelectedItem.ToString()), int.Parse(d_costume_timeline_start_time.SelectedItem.ToString()), 0);
            DateTime end_date = d_costume_timeline_end_date.Value.Date;
            TimeSpan end_time = new TimeSpan(int.Parse(d_costume_timeline_end_hour.SelectedItem.ToString()), int.Parse(d_costume_timeline_end_time.SelectedItem.ToString()), 0);

            var index = 0;
            //衣装コード取得
            foreach(var cos in costumeGridGetList)
            {
                cos.start_date = start_date;
                cos.start_time = start_time;
                cos.end_date = end_date;
                cos.end_time = end_time;
            }

            //タイムラインの描画を止める
            c_time_line.BeginUpdate();

            ///***************************************
            // * 連絡先（衣装）をスケジュールに追加
            //****************************************/
            C1.C1Schedule.ContactCollection contcol;
            contcol = this.c_time_line.DataStorage.ContactStorage.Contacts;
            C1.C1Schedule.Contact contact;
            index = 0;
            costumeGridGetListIndex = 0;

            //画像を削除
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

            for (int i = 0; contcol.Count > 0; i++)
                contcol.RemoveAt(0);

            //衣装
            List<string> costume_codeList = new List<string>();

            for (int i = 0; i < costumeGridGetList.Count; i++)
            {
                costume_codeList.Add(costumeGridGetList[i].costume_code);
                if (costumeGridGetListIndex % 3 == 2)
                {
                    costumeGridGetListIndex++;
                    break;
                }
                else
                {
                    costumeGridGetListIndex++;
                }
            }

            foreach (String costume_code in costume_codeList)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = costume_code,
                    Color = Color.Cyan

                };
                contcol.Insert(index, contact);
                index++;
            }

            for (int i = costumeGridGetListIndex; i < 3; i++)
            {
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = new string(' ', i),
                    Color = Color.Cyan

                };
                contcol.Insert(index, contact);
                index++;
            }

            ///***************************************
            // * 予定の追加
            //****************************************/
            //// 新しい予定を作成します。   
            C1.C1Schedule.Appointment app;
            for (int i = 0; i < costumeGridGetListIndex; i++)
            {
                var root = (System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString());
                var imgdir = (System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString());
                var storePath = System.IO.Path.Combine(root, imgdir);
                storePath = System.IO.Path.Combine(storePath, costume_store_name);
                var costumePath = System.IO.Path.Combine(storePath, costumeGridGetList[i].costume_code);
                var imgPath = System.IO.Path.Combine(costumePath, DB.m_costume.getSingle(costume_store_code, costumeGridGetList[i].costume_code).image1);

                if (i % 3 == 0)
                {
                    pictureBox6.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (i % 3 == 1)
                {
                    pictureBox5.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (i % 3 == 2)
                {
                    pictureBox4.Image = System.Drawing.Image.FromFile(imgPath);
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                DateTime yoyakuStart = DateTime.MinValue;
                DateTime yoyakuEnd = DateTime.MaxValue;
                if (costumeGridGetList[i].start_date != DateTime.MinValue)
                {
                    var start = new DateTime(costumeGridGetList[i].start_date.Year, costumeGridGetList[i].start_date.Month, costumeGridGetList[i].start_date.Day,
                        costumeGridGetList[i].start_time.Hours, costumeGridGetList[i].start_time.Minutes, 0);
                    var end = new DateTime(costumeGridGetList[i].end_date.Year, costumeGridGetList[i].end_date.Month, costumeGridGetList[i].end_date.Day,
                        costumeGridGetList[i].end_time.Hours, costumeGridGetList[i].end_time.Minutes, 0);
                    var duration = end.Subtract(start);

                    // 予定の詳細を設定します。    
                    app = this.c_time_line.DataStorage.AppointmentStorage.Appointments.Add();
                    app.Subject = "予定";
                    app.Location = "";
                    app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                    app.Start = start;
                    app.Label = new C1.C1Schedule.Label(Color.Orange, "予定", "予定");
                    app.Links.Add(contcol[i]);

                    yoyakuStart = start;
                    yoyakuEnd = end;
                }

                foreach (var y in yoyakuCostumeList)
                {
                    if (y.costume_code == costumeGridGetList[i].costume_code)
                    {
                        var start = new DateTime(y.start_date.Year, y.start_date.Month, y.start_date.Day,
                            y.start_time.Hours, y.start_time.Minutes, 0);
                        var end = new DateTime(y.end_date.Year, y.end_date.Month, y.end_date.Day,
                            y.end_time.Hours, y.end_time.Minutes, 0);
                        var duration = end.Subtract(start);

                        if (!(start >= yoyakuEnd || end <= yoyakuStart)){
                            Utile.Message.showMessageOK("I05004");
                            return;
                        }

                        // 予定の詳細を設定します。    
                        app = this.c_time_line.DataStorage.AppointmentStorage.Appointments.Add();
                        app.Subject = y.shooting_purpose;
                        app.Location = y.facility;
                        app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                        app.Start = start;
                        app.Label = new C1.C1Schedule.Label(Color.SkyBlue, y.costume_reservation_code, y.costume_reservation_code);
                        app.Links.Add(contcol[i]); 
                    }
                }

            }
            ////this.contactsTableAdapter.Fill(reservation_timetableDataSet.Contacts);

            //// resume C1Schedule updates
            c_time_line.EndUpdate();

            if (costumeGridGetListIndex == costumeGridGetList.Count)
            {

                b_next_cos.Visible = false;
                b_prev_cos.Visible = false;
            }
            else
            {
                b_next_cos.Visible = true;
                b_prev_cos.Visible = false;
            }
        }

        private void d_costume_store_name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //検索結果クリア
            g_costume_result.Rows.Clear();

            costume_store_name = this.d_costume_store_name.Text;
            costume_store_index = this.d_costume_store_name.SelectedIndex;
            costume_store_code = storeList[costume_store_index].store_code;


            //営業時間の開始時間と終了時間を設定
            var store = DB.m_store.getSingle(storeList[this.d_costume_store_name.SelectedIndex].store_code);

            c_time_line.CalendarInfo.StartDayTime = new TimeSpan(store.start_time.Hours, store.start_time.Minutes, 0);
            c_time_line.CalendarInfo.EndDayTime = new TimeSpan(store.end_time.Hours, store.end_time.Minutes, 0);
        }

        private void c_time_line_Load(object sender, EventArgs e)
        {

        }
    }
}
