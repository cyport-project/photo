using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C1.C1Schedule;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Npgsql;
using C1.Win.C1Schedule;

namespace 写真館システム
{
    public partial class Reservation_timetable : UserControlExp
    {
        private Dictionary<string, string> storeList;
        private Dictionary<DateTime, int> workCount;
        private Dictionary<string, string> scheduleList;
        public string scheduleLabel = "スケジュール  ";

        public Reservation_timetable()
        {
            InitializeComponent();
            //現在日付表示
            c1Calendar1.SelectedDates = new DateTime[]{DateTime.Now.Date};

        }
        private void setSchedule(DateTime selectDate)
        {
            //開始時間と終了時間を設定
            var storeId = storeList[d_tenpomei.SelectedItem.ToString()];
            var store = DB.m_store.getSingle(storeId);

            //営業時間設定
            c1Schedule1.CalendarInfo.StartDayTime = new TimeSpan(store.start_time.Hours, store.start_time.Minutes, 0);
            c1Schedule1.CalendarInfo.EndDayTime = new TimeSpan(store.end_time.Hours, store.end_time.Minutes, 0);


            //タイムテーブル登録
            // suspend C1Schedule updates while loading data
            c1Schedule1.BeginUpdate();

            using (var dbc = new DB.DBConnect())
            {
                string selectStore = storeList[d_tenpomei.SelectedItem.ToString()];
                /***************************************
                * 連絡先（施設、スケジュール、スタッフ）をスケジュールに追加
                ****************************************/
                C1.C1Schedule.ContactCollection contcol = this.c1Schedule1.DataStorage.ContactStorage.Contacts;
                for (int i = 0; contcol.Count > 0; i++)
                    contcol.RemoveAt(0);
                C1.C1Schedule.Contact contact;
                var code_index = new Dictionary<string, int>();
                int index = 0;
                int ScheduleIndex = 0;
                int StaffIndex = 0;
                //施設
                foreach (DB.m_facility fac in dbc.m_facility.Where(x => x.delete_flag == "0" & x.store_code == selectStore))
                {

                    contact = new C1.C1Schedule.Contact(index)
                    {
                        Text = fac.facility_name,
                        Color = Color.Cyan
                    };
                    contcol.Insert(index, contact);
                    code_index.Add(fac.facility_code, index);
                    index++;
                }

                //スケジュール
                contact = new C1.C1Schedule.Contact(index)
                {
                    Text = scheduleLabel,
                    Color = Color.Yellow
                };
                contcol.Insert(index, contact);
                code_index.Add(scheduleLabel, index);
                ScheduleIndex = index;
                index++;

                //スタッフシフト
                StaffIndex = index;
                var q = from t in dbc.m_staff
                        where t.store_code == selectStore & t.delete_flag == "0"
                        select t;
                foreach (DB.m_staff staff in q)
                {
                    contact = new C1.C1Schedule.Contact(index)
                    {
                        Text = staff.staff_name,
                        Color = Color.LightGreen
                    };
                    contcol.Insert(index, contact);
                    code_index.Add("staff" + staff.staff_code, index);
                    index++;
                }

                /***************************************
                * 予定の追加
                ****************************************/
                //作業回数初期化
                workCount = new Dictionary<DateTime, int>();
                //スケジュールリスト初期化
                scheduleList = new Dictionary<string, string>();
                // 新しい予定を作成します。   
                C1.C1Schedule.Appointment app;

                foreach (DB.t_facility_reservation fr in dbc.t_facility_reservation.Where(x => x.store_code == storeId).Select(x => x))
                {
                    var start = new DateTime(fr.start_date.Year, fr.start_date.Month, fr.start_date.Day,
                        fr.start_time.Hours, fr.start_time.Minutes, 0);
                    var end = new DateTime(fr.end_date.Year, fr.end_date.Month, fr.end_date.Day,
                        fr.end_time.Hours, fr.end_time.Minutes, 0);
                    var duration = end.Subtract(start);

                    //ラベル
                    Color labelColor = new Color();
                    string labelName = null;
                    if (fr.task_class == null)
                    {
                        // スケジュール
                        labelColor = Color.Yellow;
                        labelName = scheduleLabel;
                        // 予定の詳細を設定します。    
                        app = this.c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add();
                        app.Subject = fr.remarks;
                        app.Location = "";
                        app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                        app.Start = start;
                        app.Label = new C1.C1Schedule.Label(labelColor, labelName, labelName);
                        app.Links.Add(contcol[ScheduleIndex]);
                        scheduleList.Add(app.Key[0].ToString(), fr.facility_reservation_code);
                    }
                    else
                    {
                        // 施設
                        labelColor = ColorTranslator.FromHtml(DB.m_task.getSingle(fr.task_class).color);
                        labelName = DB.m_task.getSingle(fr.task_class).task_name;
                        // 予定の詳細を設定します。    
                        app = this.c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add();
                        app.Subject = fr.shooting_purpose;
                        app.Location = fr.reservator;
                        app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                        app.Start = start;
                        app.Label = new C1.C1Schedule.Label(labelColor, labelName, labelName);
                        app.Links.Add(contcol[code_index[fr.facility_code]]);
                        scheduleList.Add(app.Key[0].ToString(), fr.facility_reservation_code);

                        //作業回数
                        if (workCount.ContainsKey(start.Date)){
                            workCount[start.Date] += 1;
                        }
                        else
                        {
                            workCount.Add(start.Date, 0);
                        }
                    }

                }
                var emptyStaff = new List<C1.C1Schedule.Contact>();
                foreach (DB.m_staff staff in dbc.m_staff.Where(x => x.delete_flag == "0" & x.store_code == selectStore).Select(x => x))
                {
                    var dateList = DB.m_staff_shift.getDateList(staff.staff_code);
                    var c = from t in contcol.ToList()
                            where t.Text == staff.staff_name
                            select t;
                    if(dateList.IndexOf(selectDate) == -1)
                    {
                        contcol.RemoveAt(contcol.IndexOf(c.First()));
                    }
                    else
                    {
                        foreach(var date in dateList)
                        {
                            var ss = DB.m_staff_shift.getSingle(staff.staff_code, date);
                            if (ss != null && (int.Parse(ss.work_class) == (int)Utile.Data.就業区分.通常勤務 ||
                                               int.Parse(ss.work_class) == (int)Utile.Data.就業区分.休日出勤))
                            {
                                var start = new DateTime(date.Year, date.Month, date.Day, ss.start_time.Hours, ss.start_time.Minutes, 0);
                                var end = new DateTime(date.Year, date.Month, date.Day, ss.end_time.Hours, ss.end_time.Minutes, 0);
                                var duration = end.Subtract(start);
                                // スタッフシフト
                                Color labelColor = Color.LightGreen;
                                string labelName = "出勤";
                                // 予定の詳細を設定します。    
                                app = this.c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add();
                                app.Subject = "出勤";
                                app.Location = "";
                                app.Duration = TimeSpan.FromMinutes(duration.TotalMinutes);
                                app.Start = start;
                                app.Label = new C1.C1Schedule.Label(labelColor, labelName, labelName);
                                app.Links.Add(contcol[contcol.IndexOf(c.First())]);
                            }

                        }
                    }
                }

                //this.contactsTableAdapter.Fill(reservation_timetableDataSet.Contacts);

                // resume C1Schedule updates
                c1Schedule1.EndUpdate();
            }
        }
        public override void PageRefresh()
        {
            //現在日付表示
            //c1Calendar1.SelectedDates = new DateTime[]{DateTime.Now.Date};

            //店舗名コンボボックス
            List<Dictionary<string, object>> m_storeList = DB.m_store.getStoreList();
            d_tenpomei.Items.Clear();
            storeList = new Dictionary<string, string>();
            foreach(var m_store in m_storeList)
            {
                storeList.Add(m_store["store_name"].ToString(), m_store["store_code"].ToString());
                d_tenpomei.Items.Add(m_store["store_name"].ToString());
            }
            if(storeList.Count == 0)
            {
                Utile.Message.showMessageOK("I01000");
                this.pageParent.PageRefresh();
                MainForm.backPage(this);
            }

            d_tenpomei.SelectedIndex = d_tenpomei.FindStringExact(DB.m_store.getSingle( MainForm.session_m_staff.store_code).store_name);

            //店舗取得
            var selectStore = storeList[d_tenpomei.SelectedItem.ToString()];

            //日付ラベル
            DateTime selectDate = c1Calendar1.SelectedDates.First();
            setDateLabel(selectDate);

            //お知らせ
            setNotice(selectDate);

            //タイムテーブル登録
            setSchedule(selectDate);

            //タブリスト設定
            setTabList(selectDate, selectStore);
        }

        private void setDateLabel(DateTime date)
        {
            l_year.Text = date.ToString("yyyy年");
            l_date.Text = date.ToString("MM月dd日（ddd）@rokuyou".Replace("@rokuyou", getRokuyou(date)));
        }

        private void setNotice(DateTime date)
        {
            var storeCode = storeList[d_tenpomei.SelectedItem.ToString()];
            DB.t_calendar_information cal = DB.t_calendar_information.getSingle(storeCode,date);
            if(cal == null)
            {
                d_osirase.Text = "";
            }
            else
            {
                d_osirase.Text = cal.notice;
            }
            
        }

        private string getRokuyou(DateTime date)
        {
            var kyureki = new System.Globalization.JapaneseLunisolarCalendar();
            int kyureki_m = kyureki.GetMonth(date);
            int kyureki_d = kyureki.GetDayOfMonth(date);

            // 閏月を取得
            DateTime kyureki_ganjitu = kyureki.AddDays(date, 1 - kyureki.GetDayOfYear(date));
            int uruu_m = kyureki.GetLeapMonth(kyureki.GetYear(kyureki_ganjitu), kyureki.GetEra(kyureki_ganjitu));
            // 2017年であれば、閏月=6 が返る。6番目の月が閏月、すなわち「閏5月」となる。
            // 閏月のない年では、閏月=0 が返る。

            // 閏月がある場合の旧暦月の補正
            if ((uruu_m > 0) && (kyureki_m >= uruu_m))
                kyureki_m--;

            // 六曜を算出
            return ((Utile.Data.六曜)((kyureki_m + kyureki_d) % 6)).ToString();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b_return_Click(object sender, EventArgs e)
        {

            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void c1Schedule1_Load(object sender, EventArgs e)
        {

        }

        private void c1Schedule1_Click(object sender, EventArgs e)
        {
            //MainForm.Facility_reservation.PageRefresh();
            //MainForm.sendPage(this, MainForm.Facility_reservation);
        }
        private void setTabList(DateTime selectDate, string selectStore)
        {

            //予約一覧設定
            d_yoyaku.Rows.Clear();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT fa.facility_name" +
                    ", to_char(fr.start_date,'yyyy/MM/dd') as start_date" +
                    ", to_char(fr.start_date,'yyyy/MM/dd') || to_char(fr.start_time, ' hh24:mi') || ' ～ ' || to_char(fr.end_date, 'yyyy/MM/dd') || to_char(fr.end_time, ' hh24:mi') as start_time" +
                    ", fr.shooting_purpose, cus.surname || cus.\"name\" as name" +
                    ", cus.sex ");
                sb.Append("from t_facility_reservation as fr ");
                sb.Append("left join m_facility as fa ");
                sb.Append("on fa.facility_code = fr.facility_code ");
                sb.Append("left join m_store as st ");
                sb.Append("on st.store_code = fr.store_code ");
                sb.Append("left join t_reservation as res ");
                sb.Append("on res.facility_reservation_code = fr.facility_reservation_code ");
                sb.Append("left join t_reception as rec ");
                sb.Append("on res.reception_code = rec.reception_code ");
                sb.Append("left join m_customer as cus ");
                sb.Append("on rec.customer_code = cus.customer_code ");
                sb.Append("where @date BETWEEN fr.start_date and fr.end_date ");
                sb.Append("and @store_code = fr.store_code ");
                sb.Append("and res.reception_code is not NULL ");

                NpgsqlCommand command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@date", selectDate));
                command.Parameters.Add(new NpgsqlParameter("@store_code", selectStore));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    d_yoyaku.Rows.Add(
                        dataReader["facility_name"],
                        dataReader["name"],
                        (Utile.Data.性別)(int.Parse(dataReader["sex"].ToString())),
                        dataReader["start_date"],
                        dataReader["start_time"],
                        dataReader["shooting_purpose"]
                    );
                }
            }
            //衣装予約一覧設定
            d_isyou_yoyaku.Rows.Clear();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT cr.costume_code ");
                sb.Append(", st.store_name ");
                sb.Append(", to_char(cr.start_date,'yyyy/MM/dd') || to_char(cr.start_time, ' hh24:mi') || ' ～ ' || to_char(cr.end_date, 'yyyy/MM/dd') || to_char(cr.end_time, ' hh24:mi') as datetime ");
                sb.Append(", cus.surname || cus.\"name\" as name ");
                sb.Append(", cus.sex ");
                sb.Append(", cr.memo ");
                sb.Append("FROM public.t_costume_reservation as cr ");
                sb.Append("inner join m_store as st ");
                sb.Append("on st.store_code = cr.store_code ");
                sb.Append("inner join t_reservation as res ");
                sb.Append("on res.costume_reservation_code = cr.costume_reservation_code ");
                sb.Append("inner join t_reception as rec ");
                sb.Append("on rec.reception_code = res.reception_code ");
                sb.Append("inner join m_customer as cus ");
                sb.Append("on cus.customer_code = rec.customer_code ");
                sb.Append("WHERE @date BETWEEN cr.start_date and cr.end_date ");
                sb.Append("and @store_code = cr.store_code ");

                NpgsqlCommand command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@date", selectDate));
                command.Parameters.Add(new NpgsqlParameter("@store_code", selectStore));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    d_isyou_yoyaku.Rows.Add(
                        dataReader["costume_code"],
                        dataReader["store_name"],
                        dataReader["datetime"],
                        dataReader["name"],
                        (Utile.Data.性別)(int.Parse(dataReader["sex"].ToString())),
                        dataReader["memo"]
                    );
                }
            }
            //スケジュール一覧設定
            d_sukejuru.Rows.Clear();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT to_char(fr.start_date,'yyyy/MM/dd') || to_char(fr.start_time, ' hh24:mi') || ' ～ ' || to_char(fr.end_date, 'yyyy/MM/dd') || to_char(fr.end_time, ' hh24:mi') as datetime ");
                sb.Append(", fr.remarks ");
                sb.Append("from t_facility_reservation as fr ");
                sb.Append("left join t_reservation as res ");
                sb.Append("on res.facility_reservation_code = fr.facility_reservation_code ");
                sb.Append("where @date BETWEEN fr.start_date and fr.end_date ");
                sb.Append("and @store_code = fr.store_code ");
                sb.Append("and res.reception_code is NULL; ");


                NpgsqlCommand command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@date", selectDate));
                command.Parameters.Add(new NpgsqlParameter("@store_code", selectStore));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    d_sukejuru.Rows.Add(
                        dataReader["datetime"],
                        dataReader["remarks"]
                    );
                }
            }
        }
        private void c1Schedule1_BeforeViewChange(object sender, EventArgs e)
        {
            //日付取得
            var selectDate = c1Calendar1.SelectedDates[0];

            //店舗取得
            var selectStore = storeList[d_tenpomei.SelectedItem.ToString()];

            //日付ラベル設定
            setDateLabel(selectDate);

            //お知らせ設定
            setNotice(selectDate);

            //タブリスト設定
            setTabList(selectDate, selectStore);

            //スケジュール再読み込み
            setSchedule(selectDate);
        }
        
        private void c1Schedule1_Create(object sender, CancelAppointmentEventArgs e)
        {
            //スタッフだったらreturn
            var staff = DB.m_staff.getSingleName(storeList[d_tenpomei.SelectedItem.ToString()],e.Appointment.Links[0].Text);
            if (staff != null) return;

            //受付未選択で施設予約だったらreturn
            if(e.Appointment.Links[0].Text != scheduleLabel && MainForm.session_t_reception == null)
            {
                Utile.Message.showMessageOK("I03007");
                return;
            }

            //画面遷移情報格納
            MainForm.Facility_reservation.facility_reservation = new DB.t_facility_reservation();
            MainForm.Facility_reservation.facility_reservation.start_date = e.Appointment.Start.Date;
            MainForm.Facility_reservation.facility_reservation.start_time = e.Appointment.Start.TimeOfDay;
            MainForm.Facility_reservation.facility_reservation.end_date = e.Appointment.End.Date;
            MainForm.Facility_reservation.facility_reservation.end_time = e.Appointment.End.TimeOfDay;
            MainForm.Facility_reservation.facility_reservation.selection_start_date = e.Appointment.Start.Date;
            MainForm.Facility_reservation.facility_reservation.selection_end_date = e.Appointment.Start.Date;
            MainForm.Facility_reservation.facility_reservation.store_code = storeList[d_tenpomei.SelectedItem.ToString()];
            if (e.Appointment.Links[0].Text == scheduleLabel)
                MainForm.Facility_reservation.facility_reservation.facility_code = scheduleLabel;
            else
                MainForm.Facility_reservation.facility_reservation.facility_code = DB.m_facility.getSingleName(storeList[d_tenpomei.SelectedItem.ToString()], e.Appointment.Links[0].Text).facility_code;
            MainForm.Facility_reservation.facility_reservation.photographer = MainForm.session_m_staff.staff_name;
            MainForm.Facility_reservation.facility_reservation.selector = MainForm.session_m_staff.staff_name;
            //ポップアップイベントキャンセル
            e.Cancel = true;
            //コントロールリフレッシュ
            MainForm.Facility_reservation.PageRefresh();
            //画面遷移
            MainForm.sendPage(this, MainForm.Facility_reservation);

        }

        private void c1Schedule1_Edit(object sender, CancelAppointmentEventArgs e)
        {
            if (!scheduleList.ContainsKey(e.Appointment.Key[0].ToString()))
                return;

            //受付未選択で施設予約だったらreturn
            if (e.Appointment.Links[0].Text != scheduleLabel && MainForm.session_t_reception == null)
            {
                Utile.Message.showMessageOK("I03007");
                return;
            }

            //画面遷移情報格納
            MainForm.Facility_reservation.facility_reservation = DB.t_facility_reservation.getSingle(scheduleList[e.Appointment.Key[0].ToString()]);
            //ポップアップイベントキャンセル
            e.Cancel = true;
            //コントロールリフレッシュ
            MainForm.Facility_reservation.PageRefresh();
            //画面遷移
            MainForm.sendPage(this, MainForm.Facility_reservation);

        }

        private void b_print_Click(object sender, EventArgs e)
        {
            C1.Win.C1Schedule.C1Schedule printSchedule = new C1.Win.C1Schedule.C1Schedule();
            this.tableLayoutPanel2.Controls.Remove(this.c1Schedule1);
            printSchedule = this.c1Schedule1;

            printSchedule.CalendarInfo.TimeInterval = C1.C1Schedule.TimeScaleEnum.ThirtyMinutes;
            printSchedule.Size = new System.Drawing.Size(2600, 500);

            //コントロールの外観を描画するBitmapの作成
            Bitmap bmp = new Bitmap(printSchedule.Width, printSchedule.Height);
            //キャプチャする
            printSchedule.DrawToBitmap(bmp, new Rectangle(0, 0, printSchedule.Size.Width, printSchedule.Height));
            //ファイルに保存する
            bmp.Save("./Asset/Reservation_timetable.png");
            //後始末
            bmp.Dispose();

            //コントロールを戻す
            this.c1Schedule1.CalendarInfo.TimeInterval = C1.C1Schedule.TimeScaleEnum.FifteenMinutes;
            this.tableLayoutPanel2.Controls.Add(this.c1Schedule1);


            //レポートデータ登録
            //　日付取得
            DateTime selectDate = c1Calendar1.SelectedDates.First();
            string table = "Booking_schedule";
            Dictionary<string, string> item = new Dictionary<string, string>();
            item.Add("予約日", selectDate.ToString("yyyy年MM月dd日"));
            item.Add("お知らせ", d_osirase.Text);
            item.Add("店舗名", d_tenpomei.SelectedItem.ToString());
            item.Add("スタッフ名", MainForm.session_m_staff.staff_name);
            item.Add("顧客情報", "");

            Utile.RepoerDB rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();
            rdb.insert(item);

            /*****************
             * 印刷
             *****************/

            PrintForm p = new PrintForm();
            p.PrintReport.Load(@"./Asset/Format/Booking_schedule.flxr", "施設予約スケジュール表");
            p.c1FlexViewer.DocumentSource = p.PrintReport;
            p.Show();
        }

        private void b_prev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            c1Calendar1.SelectedDates = new DateTime[] { c1Calendar1.SelectedDates[0].AddDays(-1) };
        }

        private void b_next_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            c1Calendar1.SelectedDates = new DateTime[] { c1Calendar1.SelectedDates[0].AddDays(1) };
        }
        private void d_tenpomei_SelectedValueChanged(object sender, EventArgs e)
        {
            //店舗取得
            var selectStore = storeList[d_tenpomei.SelectedItem.ToString()];

            //日付取得
            DateTime selectDate = c1Calendar1.SelectedDates.First();

            //日付ラベル
            setDateLabel(selectDate);

            //お知らせ
            setNotice(selectDate);

            //タイムテーブル登録
            setSchedule(selectDate);

            //タブリスト設定
            setTabList(selectDate, selectStore);
        }

        private void c1Calendar1_BeforeDayFormat(object sender, BeforeDayFormatEventArgs e)
        {
            int step = 5;
            int rbMax = 255;
            int rbMin = 100;
            if(workCount != null && workCount.ContainsKey(e.Date))
            {
                int rb = rbMax - (workCount[e.Date.Date] * step);
                rb = rb > rbMin ? rb : rbMin ;
                e.Style.BackColor =Color.FromArgb(rb, 255, rb);
            }
        }

        private void c1Schedule1_BeforeAppointmentShow(object sender, CancelAppointmentEventArgs e)
        {
            //ポップアップイベントキャンセル
            e.Cancel = true;
        }


    }

}
