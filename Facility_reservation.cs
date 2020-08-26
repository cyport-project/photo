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
using System.Reflection;

namespace 写真館システム
{
    public partial class Facility_reservation : UserControlExp
    {
        //画面引き渡し
        public DB.t_facility_reservation facility_reservation;

        private checkOperation chk;
        private modifyCheck mod;

        private List<string> yoyakuFrList;
        private List<string> sescheduleFrList;

        public Facility_reservation()
        {
            InitializeComponent();

            //入力チェック
            chk = new checkOperation(this);

            //変更チェック
            mod = new modifyCheck();

            mod.add(d_tenpomei);
            mod.add(d_shisetumei);
            mod.add(d_satueisya);
            mod.add(d_select_name);
            mod.add(d_tasukukubun);
            mod.add(d_satsueimokuteki);
            mod.add(d_start_date);
            mod.add(d_start_time);
            mod.add(d_end_date);
            mod.add(d_end_time);
            mod.add(d_select_start_date);
            mod.add(d_select_start_time);
            mod.add(d_select_end_date);
            mod.add(d_select_end_time);
            mod.add(d_yoyakusya);
            mod.add(d_tyushi);
            mod.add(d_tekiyou);

        }


         public override void PageRefresh()
        {
            //顧客情報設定
            if(MainForm.session_t_reception != null)
            {
                DB.m_customer cus = DB.m_customer.getSingle(MainForm.session_t_reception.customer_code);
                l_customer_code.Text = cus.customer_code;
                l_customer_name.Text = $"{cus.surname} {cus.name}";
                l_birthday.Text = cus.birthday.ToString("yyyy年MM月dd日");
                l_age.Text = GetAge(cus.birthday, DateTime.Now).ToString();
                l_sex.Text = ((Utile.Data.性別)(int.Parse(cus.sex))).ToString();
                l_postal_code.Text = cus.postal_code;
                l_address1.Text = cus.address1;
                l_address2.Text = cus.address2;
                l_address3.Text = cus.address3;
                l_phone_number1.Text = cus.phone_number1;
                l_phone_number2.Text = cus.phone_number2;
                l_phone_number3.Text = cus.phone_number3;
                l_mail_address.Text = cus.mail_address;

            }
            else
            {
                l_customer_code.Visible = false;
                l_customer_name.Visible = false;
                l_birthday.Visible = false;
                l_age.Visible = false;
                l_sex.Visible = false;
                l_postal_code.Visible = false;
                l_address1.Visible = false;
                l_address2.Visible = false;
                l_address3.Visible = false;
                l_phone_number1.Visible = false;
                l_phone_number2.Visible = false;
                l_phone_number3.Visible = false;
                l_mail_address.Visible = false;
            }

            //コンボボックス設定
            d_tenpomei.DataSource = DB.m_store.getStoreNameList();
            d_shisetumei.DataSource = DB.m_facility.getFacilityNameList(facility_reservation.store_code);
            d_satueisya.DataSource = DB.m_staff.getStaffNameList(facility_reservation.store_code);
            d_select_name.DataSource = DB.m_staff.getStaffNameList(facility_reservation.store_code);
            d_tasukukubun.DataSource = DB.m_task.getTaskNameList();
            d_satsueimokuteki.DataSource = Enum.GetValues(typeof(Utile.Data.撮影目的));
            //　初期値設定
            d_tenpomei.SelectedIndex = d_tenpomei.FindStringExact(DB.m_store.getSingle(facility_reservation.store_code).store_name);
            if (facility_reservation.facility_code == MainForm.Reservation_timetable.scheduleLabel)
                d_shisetumei.SelectedIndex = -1;
            else
                d_shisetumei.SelectedIndex = d_shisetumei.FindStringExact(DB.m_facility.getSingle(facility_reservation.store_code, facility_reservation.facility_code).facility_name);
            var staff = DB.m_staff.getSingleName(facility_reservation.store_code, facility_reservation.photographer);
            if (staff != null)
            {
                d_satueisya.SelectedIndex = d_satueisya.FindStringExact(staff.staff_name);
                d_select_name.SelectedIndex = d_select_name.FindStringExact(staff.staff_name);
            }
            else
            {
                d_satueisya.SelectedIndex = -1;
                d_select_name.SelectedIndex = -1;
            }
            DB.m_task task = DB.m_task.getSingle(facility_reservation.task_class);
            if (task != null)
                d_tasukukubun.SelectedIndex = d_tasukukubun.FindStringExact(task.task_name);
            else
                d_tasukukubun.SelectedIndex = 0;
            if(facility_reservation.shooting_purpose == null)
                d_satsueimokuteki.SelectedIndex = 0;
            else
                d_satsueimokuteki.SelectedIndex = d_satsueimokuteki.FindStringExact(facility_reservation.shooting_purpose);

            //テキスト・カレンダー設定
            d_start_date.Value = facility_reservation.start_date;
            d_start_time.Text = facility_reservation.start_time.ToString(@"hh\:mm");
            if(facility_reservation.end_date != DateTime.MinValue)
                d_end_date.Value = facility_reservation.end_date;
            else
                d_end_date.Value = DateTime.Today.Date;
            if (facility_reservation.end_time != TimeSpan.MinValue)
                d_end_time.Text = (facility_reservation.start_time + TimeSpan.FromHours(1)).ToString(@"hh\:mm");
            else
                d_end_time.Text = "";
            if (facility_reservation.selection_start_date != null && facility_reservation.selection_start_date.Value != DateTime.MinValue)
                d_select_start_date.Value = facility_reservation.selection_start_date.Value;
            else
                d_select_start_date.Value = facility_reservation.start_date;
            if (facility_reservation.selection_start_time != null && facility_reservation.selection_start_time.Value != TimeSpan.MinValue)
                d_select_start_time.Text = facility_reservation.selection_start_time.Value.ToString(@"hh\:mm");
            else
                d_select_start_time.Text = facility_reservation.start_time.ToString(@"hh\:mm"); ;
            if (facility_reservation.selection_end_date != null && facility_reservation.selection_end_date.Value != DateTime.MinValue)
                d_select_end_date.Value = facility_reservation.selection_end_date.Value;
            else
                d_select_end_date.Value = facility_reservation.end_date;
            if (facility_reservation.selection_end_time != null && facility_reservation.selection_end_time.Value != TimeSpan.MinValue)
                d_select_end_time.Text = facility_reservation.selection_end_time.Value.ToString(@"hh\:mm");
            else
                d_select_end_time.Text = (facility_reservation.start_time + TimeSpan.FromHours(1)).ToString(@"hh\:mm"); ;
            d_yoyakusya.Text = facility_reservation.reservator;
            if (facility_reservation.cancellation_date != null && facility_reservation.cancellation_date.Value != DateTime.MinValue)
            {
                d_tyushi.Value = facility_reservation.cancellation_date.Value;
                d_tyushi.Checked = true;
            }
            else
            {
                d_tyushi.Value = DateTime.Today.Date;
                d_tyushi.Checked = false;
            }

            d_tekiyou.Text = facility_reservation.remarks;

            //リスト更新
            if (MainForm.session_t_reception != null)
                setYoyakuTabList(MainForm.session_t_reception.reception_code);
            sescheduleTabList(facility_reservation.start_date, facility_reservation.store_code);

            //スケジュール切り替え
            if (facility_reservation.facility_code == MainForm.Reservation_timetable.scheduleLabel)
                d_check.Checked = true;
            else
                d_check.Checked = false;
            changeSchedule();

            //変更チェックリセット
            mod.reset();

            //入力チェックリセット
            chk.clear();


        }
        private void changeSchedule()
        {
            if (d_check.Checked)
            {
                //顧客情報
                l_customer_code.Visible = false;
                l_customer_name.Visible = false;
                l_birthday.Visible = false;
                l_age.Visible = false;
                l_sex.Visible = false;
                l_postal_code.Visible = false;
                l_address1.Visible = false;
                l_address2.Visible = false;
                l_address3.Visible = false;
                l_phone_number1.Visible = false;
                l_phone_number2.Visible = false;
                l_phone_number3.Visible = false;
                l_mail_address.Visible = false;

                //施設予約
                d_tenpomei.Enabled = false;
                d_shisetumei.Enabled = false;
                d_satueisya.Enabled = false;
                d_select_name.Enabled = false;
                d_tasukukubun.Enabled = false;
                d_satsueimokuteki.Enabled = false;

                d_start_date.Enabled = true;
                d_start_time.Enabled = true;
                d_end_date.Enabled = true;
                d_end_time.Enabled = true;
                d_select_start_date.Enabled = false;
                d_select_start_time.Enabled = false;
                d_select_end_date.Enabled = false;
                d_select_end_time.Enabled = false;
                d_yoyakusya.Enabled = false;
                d_tyushi.Enabled = false;
                d_tekiyou.Enabled = true;

                d_select_staff_id.Enabled = false;
                d_satueisya_id.Enabled = false;

            }
            else
            {
                //顧客情報
                l_customer_code.Visible = true;
                l_customer_name.Visible = true;
                l_birthday.Visible = true;
                l_age.Visible = true;
                l_sex.Visible = true;
                l_postal_code.Visible = true;
                l_address1.Visible = true;
                l_address2.Visible = true;
                l_address3.Visible = true;
                l_phone_number1.Visible = true;
                l_phone_number2.Visible = true;
                l_phone_number3.Visible = true;
                l_mail_address.Visible = true;

                //施設予約
                d_tenpomei.Enabled = true;
                d_shisetumei.Enabled = true;
                d_satueisya.Enabled = true;
                d_select_name.Enabled = true;
                d_tasukukubun.Enabled = true;
                d_satsueimokuteki.Enabled = true;

                d_start_date.Enabled = true;
                d_start_time.Enabled = true;
                d_end_date.Enabled = true;
                d_end_time.Enabled = true;
                d_select_start_date.Enabled = true;
                d_select_start_time.Enabled = true;
                d_select_end_date.Enabled = true;
                d_select_end_time.Enabled = true;
                d_yoyakusya.Enabled = true;
                d_tyushi.Enabled = true;
                d_tekiyou.Enabled = true;

                d_select_staff_id.Enabled = true;
                d_satueisya_id.Enabled = true;
            }
        }
        private void setYoyakuTabList(string reception_code)
        {
            //予約一覧設定
            d_yoyaku_list.Rows.Clear();
            yoyakuFrList = new List<string>();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT fa.facility_name" +
                    ", to_char(fr.start_date,'yyyy/MM/dd') as start_date" +
                    ", to_char(fr.start_date,'yyyy/MM/dd') || to_char(fr.start_time, ' hh24:mi') || ' ～ ' || to_char(fr.end_date, 'yyyy/MM/dd') || to_char(fr.end_time, ' hh24:mi') as start_time" +
                    ", fr.shooting_purpose, cus.surname || cus.\"name\" as name" +
                    ", cus.sex " +
                    ", fr.facility_reservation_code ");
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
                sb.Append("where @reception_code = res.reception_code ");
                sb.Append("and res.reception_code is not NULL ");
                sb.Append("order by fa.facility_name, fr.start_date, fr.start_time, fr.end_date, fr.end_time, fr.shooting_purpose, cus.surname, cus.\"name\", cus.sex ");

                NpgsqlCommand command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@reception_code", reception_code));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    d_yoyaku_list.Rows.Add(
                        dataReader["facility_name"],
                        dataReader["name"],
                        (Utile.Data.性別)(int.Parse(dataReader["sex"].ToString())),
                        dataReader["start_date"],
                        dataReader["start_time"],
                        dataReader["shooting_purpose"]
                    );
                    yoyakuFrList.Add(dataReader["facility_reservation_code"].ToString());
                }
            }
        }

        private void sescheduleTabList(DateTime selectDate, string selectStore)
        {
            //スケジュール一覧設定
            d_schedule_list.Rows.Clear();
            sescheduleFrList = new List<string>();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT to_char(fr.start_date,'yyyy/MM/dd') || to_char(fr.start_time, ' hh24:mi') || ' ～ ' || to_char(fr.end_date, 'yyyy/MM/dd') || to_char(fr.end_time, ' hh24:mi') as datetime ");
                sb.Append(", fr.remarks ");
                sb.Append(", fr.facility_reservation_code ");
                sb.Append("from t_facility_reservation as fr ");
                sb.Append("left join t_reservation as res ");
                sb.Append("on res.facility_reservation_code = fr.facility_reservation_code ");
                sb.Append("where @date BETWEEN fr.start_date and fr.end_date ");
                sb.Append("and @store_code = fr.store_code ");
                sb.Append("and res.reception_code is NULL ");
                sb.Append("order by fr.start_date,fr.start_time,fr.end_date,fr.end_time,fr.remarks ");

                NpgsqlCommand command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@date", selectDate));
                command.Parameters.Add(new NpgsqlParameter("@store_code", selectStore));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    d_schedule_list.Rows.Add(
                        dataReader["datetime"],
                        dataReader["remarks"]
                    );
                    sescheduleFrList.Add(dataReader["facility_reservation_code"].ToString());
                }
            }
        }

        private static int GetAge(DateTime birthDate, DateTime today)
        {
            int age = today.Year - birthDate.Year;
            //誕生日がまだ来ていなければ、1引く
            if (today.Month < birthDate.Month ||
                (today.Month == birthDate.Month &&
                today.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void b_return_Click(object sender, EventArgs e)
        {
            if (mod.chackMessage("施設予約タイムテーブルに戻る処理") == false)
            {
                return;
            }
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void d_select_name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void b_regist_Click(object sender, EventArgs e)
        {

            if (d_check.Checked)
            {
                // 必須チェック
                chk.clear();
                chk.addControl(d_start_time);
                chk.addControl(d_end_time);
                if (chk.check("W00000", chk.checkControlImportant))
                    return;
                chk.clear();

                //フォーマットチェック
                chk.addControl(d_start_time);
                chk.addControl(d_end_time);
                if (chk.check("W00003", chk.checkTextboxFormat, @"^([0-9]|[0-1][0-9]|[2][0-3]):[0-5][0-9]$", "00:00"))
                    return;
                chk.clear();

                //桁数チェック
                chk.addControl(d_start_time);
                chk.addControl(d_end_time);
                if (chk.check("W00001", chk.checkTextboxLength, 5))
                    return;
                chk.clear();
                chk.addControl(d_tekiyou);
                if (chk.check("W00001", chk.checkTextboxLength, 256))
                    return;
                chk.clear();

                //施設予約登録処理（スケジュール）
                if (facility_reservation.facility_reservation_code == null)
                    facility_reservation.facility_reservation_code = DB.t_facility_reservation.getNewFacility_reservation_code();
                facility_reservation.start_date = d_start_date.Value;
                facility_reservation.start_time = TimeSpan.Parse(d_start_time.Text);
                facility_reservation.end_date = d_end_date.Value;
                facility_reservation.end_time = TimeSpan.Parse(d_end_time.Text);
                facility_reservation.reservator = null;
                facility_reservation.remarks = d_tekiyou.Text;
                facility_reservation.cancellation_date = null;
                facility_reservation.shooting_purpose = null;
                facility_reservation.photographer = null;
                facility_reservation.task_class = null;
                facility_reservation.selection_start_date = null;
                facility_reservation.selection_start_time = null;
                facility_reservation.selection_end_date = null;
                facility_reservation.selection_end_time = null;
                facility_reservation.selector = null;
                facility_reservation.store_code = DB.m_store.getSingleName(d_tenpomei.SelectedItem.ToString()).store_code;
                facility_reservation.facility_code = MainForm.Reservation_timetable.scheduleLabel;
                facility_reservation.order_code = null; //DOTO:特に入力するものが無いため取りあえずNULLを入れる 
                //重複チェック
                using (var dbc = new DB.DBConnect())
                {
                    var frStart = new DateTime(facility_reservation.start_date.Year, facility_reservation.start_date.Month, facility_reservation.start_date.Day,
                        facility_reservation.start_time.Hours, facility_reservation.start_time.Minutes, 0);
                    var frEnd = new DateTime(facility_reservation.end_date.Year, facility_reservation.end_date.Month, facility_reservation.end_date.Day,
                        facility_reservation.end_time.Hours, facility_reservation.end_time.Minutes, 0);

                    var q = from t in dbc.t_facility_reservation
                            select t;
                    foreach (var data in q)
                    {
                        var dStart = new DateTime(data.start_date.Year, data.start_date.Month, data.start_date.Day, data.start_time.Hours, data.start_time.Minutes, 0);
                        var dEnd = new DateTime(data.end_date.Year, data.end_date.Month, data.end_date.Day, data.end_time.Hours, data.end_time.Minutes, 0);
                        if (data.facility_code == facility_reservation.facility_code
                            && data.store_code == facility_reservation.store_code
                            && !(dEnd <= frStart || dStart >= frEnd))
                        {
                            Utile.Message.showMessageOK("I03009");
                            return;
                        }
                    }
                }
                facility_reservation.Command();

                //リスト更新
                if (MainForm.session_t_reception != null)
                    setYoyakuTabList(MainForm.session_t_reception.reception_code);
                sescheduleTabList(facility_reservation.start_date, facility_reservation.store_code);

                Utile.Message.showMessageOK("I03003");

            }
            else
            {

                // 必須チェック
                chk.clear();
                chk.addControl(d_tenpomei);
                chk.addControl(d_shisetumei);
                chk.addControl(d_satueisya);
                chk.addControl(d_select_name);
                chk.addControl(d_tasukukubun);
                chk.addControl(d_satsueimokuteki);
                chk.addControl(d_start_time);
                chk.addControl(d_end_time);
                chk.addControl(d_yoyakusya);
                if (chk.check("W00000", chk.checkControlImportant))
                    return;
                chk.clear();

                //フォーマットチェック
                chk.addControl(d_start_time);
                chk.addControl(d_end_time);
                if (d_select_start_time.Text != "")
                    chk.addControl(d_select_start_time);
                if (d_select_end_time.Text != "")
                    chk.addControl(d_select_end_time);
                if (chk.check("W00003", chk.checkTextboxFormat, @"^([0-9]|[0-1][0-9]|[2][0-3]):[0-5][0-9]$", "00:00"))
                    return;
                chk.clear();

                //桁数チェック
                chk.addControl(d_start_time);
                chk.addControl(d_end_time);
                if (d_select_start_time.Text != "")
                    chk.addControl(d_select_start_time);
                if (d_select_end_time.Text != "")
                    chk.addControl(d_select_end_time);
                if (chk.check("W00001", chk.checkTextboxLength, 5))
                    return;
                chk.clear();
                chk.addControl(d_yoyakusya);
                if (chk.check("W00001", chk.checkTextboxLength, 20))
                    return;
                chk.clear();
                chk.addControl(d_tekiyou);
                if (chk.check("W00001", chk.checkTextboxLength, 256))
                    return;
                chk.clear();

                //施設予約登録処理
                if (facility_reservation.facility_reservation_code == null)
                    facility_reservation.facility_reservation_code = DB.t_facility_reservation.getNewFacility_reservation_code();
                facility_reservation.start_date = d_start_date.Value;
                facility_reservation.start_time = TimeSpan.Parse(d_start_time.Text);
                facility_reservation.end_date = d_end_date.Value;
                facility_reservation.end_time = TimeSpan.Parse(d_end_time.Text);
                facility_reservation.reservator = d_yoyakusya.Text;
                facility_reservation.remarks = d_tekiyou.Text;
                if(d_tyushi.Checked)
                    facility_reservation.cancellation_date = d_tyushi.Value;
                else
                    facility_reservation.cancellation_date = null;
                facility_reservation.shooting_purpose = ((Utile.Data.撮影目的)(d_satsueimokuteki.SelectedIndex)).ToString();
                facility_reservation.photographer = d_satueisya.Text;
                facility_reservation.task_class = DB.m_task.getSingleName(d_tasukukubun.SelectedItem.ToString()).task_class;
                if (d_select_start_time.Text == "")
                {
                    facility_reservation.selection_start_date = null;
                    facility_reservation.selection_start_time = null;
                }
                else
                {
                    facility_reservation.selection_start_date = d_select_start_date.Value;
                    facility_reservation.selection_start_time = TimeSpan.Parse(d_select_start_time.Text);
                }
                if (d_select_end_time.Text == "")
                {
                    facility_reservation.selection_end_date = null;
                    facility_reservation.selection_end_time = null;
                }
                else
                {
                    facility_reservation.selection_end_date = d_select_end_date.Value;
                    facility_reservation.selection_end_time = TimeSpan.Parse(d_select_end_time.Text);
                }
                facility_reservation.selector = d_select_name.SelectedItem.ToString();
                facility_reservation.store_code = DB.m_store.getSingleName(d_tenpomei.SelectedItem.ToString()).store_code;
                facility_reservation.facility_code = DB.m_facility.getSingleName(facility_reservation.store_code, d_shisetumei.SelectedItem.ToString()).facility_code;
                facility_reservation.order_code = null; //DOTO:特に入力するものが無いため取りあえずNULLを入れる 

                //重複チェック
                using (var dbc = new DB.DBConnect())
                {
                    var frStart = new DateTime(facility_reservation.start_date.Year, facility_reservation.start_date.Month, facility_reservation.start_date.Day,
                        facility_reservation.start_time.Hours, facility_reservation.start_time.Minutes, 0);
                    var frEnd = new DateTime(facility_reservation.end_date.Year, facility_reservation.end_date.Month, facility_reservation.end_date.Day,
                        facility_reservation.end_time.Hours, facility_reservation.end_time.Minutes, 0);

                    var q = from t in dbc.t_facility_reservation
                            select t;
                    foreach(var data in q)
                    {
                        var dStart = new DateTime(data.start_date.Year, data.start_date.Month, data.start_date.Day,data.start_time.Hours, data.start_time.Minutes, 0);
                        var dEnd = new DateTime(data.end_date.Year, data.end_date.Month, data.end_date.Day,data.end_time.Hours, data.end_time.Minutes, 0);
                        if(data.facility_code == facility_reservation.facility_code 
                            && data.store_code == facility_reservation.store_code
                            && !(dEnd <= frStart || dStart >= frEnd))
                        {
                            Utile.Message.showMessageOK("I03009");
                            return;
                        }
                    }
                }
                facility_reservation.Command();



                //予約登録処理
                DB.t_reservation reservation = new DB.t_reservation();
                reservation.reservation_code = MainForm.session_t_reception.reception_code;
                reservation.facility_reservation_code = facility_reservation.facility_reservation_code;
                reservation.costume_reservation_code = "        ";
                reservation.Command();

                //撮影データ登録処理
                DB.t_shooting_data shooting_data = DB.t_shooting_data.getSingle(MainForm.session_t_reception.customer_code,
                                                                                d_start_date.Value,
                                                                                MainForm.session_t_reception.reception_code);
                if(shooting_data == null) {
                    shooting_data = new DB.t_shooting_data();
                    int index = 1;
                    string folder = null;
                    while (true)
                    {
                        folder = d_start_date.Value.ToString("yyyyMMdd") + "-" + index.ToString() + "-" + DB.m_customer.getSingle(MainForm.session_t_reception.customer_code).surname;
                        if (DB.t_shooting_data.chkFolder(folder))
                            break;
                        index++;
                    }
                    shooting_data.customer_code = MainForm.session_t_reception.customer_code;
                    shooting_data.shooting_date = d_start_date.Value;
                    shooting_data.folder = folder;
                    shooting_data.select_class = "2";
                    shooting_data.images = 0;
                    shooting_data.reception_code = MainForm.session_t_reception.reception_code;
                    shooting_data.Command();

                    //　フォルダ作成
                    var photo_root = System.Configuration.ConfigurationManager.AppSettings["photo_root"];
                    var Photographer_Select = System.Configuration.ConfigurationManager.AppSettings["Photographer_Select"];
                    var Photographer_Select_dir = System.IO.Path.Combine(photo_root, Photographer_Select);

                    var folderPath = System.IO.Path.Combine(Photographer_Select_dir, folder);
                    folderPath = System.IO.Path.GetFullPath(folderPath);
                    if (System.IO.Directory.Exists(folderPath))
                    {
                        Utile.Message.showMessageOK("I03008");
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                }

                //リスト更新
                if (MainForm.session_t_reception != null)
                    setYoyakuTabList(MainForm.session_t_reception.reception_code);
                sescheduleTabList(facility_reservation.start_date, facility_reservation.store_code);

                Utile.Message.showMessageOK("I03001");
            }

            //更新チェックリセット
            mod.reset();

        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (mod.chackMessage("削除") == false)
            {
                return;
            }
            if (facility_reservation.facility_reservation_code != null)
            {
                DB.t_facility_reservation.getSingle(facility_reservation.facility_reservation_code).Command(delete: true);
                var t = DB.t_reservation.getSingleFacility_reservation_code(facility_reservation.facility_reservation_code);
                if (t != null)
                    t.Command(delete: true);

                pageParent.PageRefresh();
                MainForm.backPage(this);

                if(d_check.Checked)
                    Utile.Message.showMessageOK("I03005");
                else
                    Utile.Message.showMessageOK("I03004");
            }
            else
            {
                Utile.Message.showMessageOK("W03001");
            }
        }

        private void d_check_CheckedChanged(object sender, EventArgs e)
        {
            changeSchedule();
        }

        private void d_select_staff_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var staff = DB.m_staff.getSingle(d_select_staff_id.Text);
                if(staff != null)
                {
                    d_select_name.SelectedIndex = d_select_name.FindStringExact(staff.staff_name);
                }
                else
                {
                    d_select_name.SelectedIndex = -1;
                }
            }
        }

        private void d_satueisya_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var staff = DB.m_staff.getSingle(d_satueisya_id.Text);
                if (staff != null)
                {
                    d_satueisya.SelectedIndex = d_satueisya.FindStringExact(staff.staff_name);
                }
                else
                {
                    d_satueisya.SelectedIndex = -1;
                }
            }
        }
        
        private void d_yoyaku_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!mod.chackMessage("選択行の編集"))
            {
                return;
            }
            else
            {
                DialogResult result = Utile.Message.showMessageOKCancel("I03006");
                if (result == DialogResult.Cancel)
                    return;
            }

            //ヘッダー行を選択した場合
            if(e.RowIndex == -1)
                return;

            facility_reservation = DB.t_facility_reservation.getSingle(yoyakuFrList[e.RowIndex]);
            PageRefresh();

        }
        private void d_schedule_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (!mod.chackMessage("選択行の編集"))
            {
                return;
            }
            else
            {
                DialogResult result = Utile.Message.showMessageOKCancel("I03006");
                if (result == DialogResult.Cancel)
                    return;
            }

            //ヘッダー行を選択した場合
            if (e.RowIndex == -1)
                return;

            facility_reservation = DB.t_facility_reservation.getSingle(sescheduleFrList[e.RowIndex]);
            PageRefresh();

        }
        private void d_start_date_Leave(object sender, EventArgs e)
        {
            MainForm.Reservation_timetable.c1Calendar1.SelectedDates = new DateTime[] { d_start_date.Value.Date };
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

    }
}
