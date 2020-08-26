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
    public partial class Store_calender : UserControlExp
    {
        //構造体の生成
        public struct storeCodeArray
        {
            public string store_code;
            public string store_name;
        }
        //店舗リスト生成
        List<storeCodeArray> storeCodeList = new List<storeCodeArray>();
  
        public Store_calender()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            //初期化
            t_oshirashe.Text = null;
            d_kyujitsukubun.DataSource = Enum.GetValues(typeof(Utile.Data.休日区分));
            d_kurikaeshi.DataSource = Enum.GetValues(typeof(Utile.Data.繰り返し));
            
            //SetIntialDisp();

        }

        public override void PageRefresh()
        {
            //店舗データ読み込み
            var m_storeList = DB.m_store.getStoreList();
            storeCodeList.Clear();

            foreach(var store in m_storeList)
            {
                storeCodeList.Add(new storeCodeArray
                {
                    store_code = store["store_code"].ToString(),
                    store_name = store["store_name"].ToString()
                });
            }
          

            //初期化
            SetIntialDisp();
        }

        public void SetIntialDisp()
        {
            //店舗設定
            d_tenpo.Items.Clear();
            for (int i = 0; i < storeCodeList.Count; i++)
            {
                d_tenpo.Items.Add(storeCodeList[i].store_name);
            }

            //セッション情報取得(自店舗)
            var own_storecode = MainForm.session_m_staff != null ?MainForm.session_m_staff.store_code :"";
            var own_storename = storeCodeList.Find(x => x.store_code == own_storecode).store_name;
            var index = d_tenpo.FindStringExact(own_storename);
            d_tenpo.SelectedIndex = index;

            //カレンダーの初期化            
            monthCalendar1.SetDate(DateTime.Now);

            //日付の初期化
            l_year.Text = (string)monthCalendar1.SelectionStart.Year.ToString("0000") + "年";








            l_date.Text = (string)monthCalendar1.SelectionStart.Month.ToString("0") + "月" +
                monthCalendar1.SelectionStart.Day.ToString("0") + "日" +"(" +
                monthCalendar1.SelectionStart.Date.ToString("dddd") +")";

            t_oshirashe.Text = null;
            d_kyujitsukubun.DataSource = Enum.GetValues(typeof(Utile.Data.休日区分));
            d_kurikaeshi.DataSource = Enum.GetValues(typeof(Utile.Data.繰り返し));

            //データがすでに存在していれば、値をセット
            //存在していない場合は、初期化
            var calender_info = DB.t_calendar_information.getSingle(own_storecode, DateTime.Now.Date);

            if (calender_info != null)
            {
                t_oshirashe.Text = calender_info.notice;
                var IntVal1 = int.Parse(calender_info.holiday_class);
                d_kyujitsukubun.SelectedIndex = IntVal1;
            }
            else
            {
                t_oshirashe.Text = null;
                d_kyujitsukubun.SelectedIndex = 0;
            }


            //非活性化
            n_kankaku.Enabled = false;
            n_kankaku.Value = 1;

            c_monday.Checked = false;
            c_monday.Enabled = false;

            c_tuseday.Checked = false;
            c_tuseday.Enabled = false;

            c_wednesday.Checked = false;
            c_wednesday.Enabled = false;

            c_thursday.Checked = false;
            c_thursday.Enabled = false;

            c_friday.Checked = false;
            c_friday.Enabled = false;

            c_saturday.Checked = false;
            c_saturday.Enabled = false;

            c_sunday.Checked = false;
            c_sunday.Enabled = false;

            d_kaishibi.Enabled = false;
            d_kaishibi.Text = DateTime.Now.ToString();

            r_nashi.Checked = false;
            r_nashi.Enabled = false;

            r_kai.Checked = true;
            r_kai.Enabled = false;

            r_hiduke.Checked = false;
            r_hiduke.Enabled = false;

            t_kaisu.Enabled = false;
            t_kai.Enabled = false;
            t_kaisu.Text = "1";

            d_syuryoubi.Enabled = false;
            d_syuryoubi.Text = DateTime.Now.ToString();
        }

        private void d_kurikaeshi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (d_kurikaeshi.Text == "なし")
            {
                //活性化
                n_kankaku.Enabled = false;
                c_monday.Enabled = false;
                c_tuseday.Enabled = false;
                c_wednesday.Enabled = false;
                c_thursday.Enabled = false;
                c_friday.Enabled = false;
                c_saturday.Enabled = false;
                c_sunday.Enabled = false;
                d_kaishibi.Enabled = false;
                r_nashi.Enabled = false;
                r_kai.Enabled = false;
                r_hiduke.Enabled = false;
                t_kaisu.Enabled = false;
                t_kai.Enabled = false;
                d_syuryoubi.Enabled = false;
            }
            else if(d_kurikaeshi.Text == "毎月")
            {
                //活性化
                n_kankaku.Enabled = true;
                c_monday.Enabled = false;
                c_tuseday.Enabled = false;
                c_wednesday.Enabled = false;
                c_thursday.Enabled = false;
                c_friday.Enabled = false;
                c_saturday.Enabled = false;
                c_sunday.Enabled = false;
                d_kaishibi.Enabled = true;
                r_nashi.Enabled = true;
                r_kai.Enabled = true;
                r_hiduke.Enabled = true;
                t_kaisu.Enabled = true;
                t_kai.Enabled = true;
                d_syuryoubi.Enabled = true;

            }
            else
            {
                //非活性化
                n_kankaku.Enabled = true;
                c_monday.Enabled = true;
                c_tuseday.Enabled = true;
                c_wednesday.Enabled = true;
                c_thursday.Enabled = true;
                c_friday.Enabled = true;
                c_saturday.Enabled = true;
                c_sunday.Enabled = true;
                d_kaishibi.Enabled = true;
                r_nashi.Enabled = true;
                r_kai.Enabled = true;
                r_hiduke.Enabled = true;
                t_kaisu.Enabled = true;
                t_kai.Enabled = true;
                d_syuryoubi.Enabled = true;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            l_year.Text = (string)e.Start.Year.ToString("0000") + "年";

            l_date.Text = (string)e.Start.Month.ToString("0") + "月"+
                  e.Start.Day.ToString("0") + "日" + "(" +
                  e.Start.Date.ToString("dddd") + ")";

            //データがすでに存在していれば、値をセット
            //存在していない場合は、初期化
            var current_store = d_tenpo.Text;
            var current_storecode = storeCodeList.Find(x => x.store_name == current_store).store_code;

            var calender_info = DB.t_calendar_information.getSingle(current_storecode, e.Start.Date);

            if(calender_info != null)
            {
                t_oshirashe.Text = calender_info.notice;
                var IntVal1 = int.Parse(calender_info.holiday_class);
                d_kyujitsukubun.SelectedIndex = IntVal1;
            }
            else
            {
                t_oshirashe.Text = null;
                d_kyujitsukubun.SelectedIndex = 0;
            }
            

        }

        private void b_return_Click(object sender, EventArgs e)
        {
            //ひとつ前に戻る
            MainForm.Store_calender.PageRefresh();
            MainForm.backPage(this);
        }

        private void b_regist_Click(object sender, EventArgs e)
        {
            //登録処理
            //日付の特定
            List<DateTime>  dates = new List<DateTime>() ;
            var interval = int.Parse(n_kankaku.Value.ToString());
            var enddate = d_syuryoubi.Text.ToString() != "" ? DateTime.Parse(d_syuryoubi.Text.ToString()) : DateTime.MaxValue;  

            //繰り返し方法により分岐
            if (d_kurikaeshi.Text == "なし")
            {
                dates.Add(monthCalendar1.SelectionStart);
            }
            else if(d_kurikaeshi.Text == "毎週")
            {
                List<int> week = new List<int>();


                if(c_monday.Checked == true)
                {
                    week.Add(1);
                }
                if(c_tuseday.Checked == true)
                {
                    week.Add(2);
                }
                if (c_wednesday.Checked == true)
                {
                    week.Add(3);
                }
                if (c_thursday.Checked == true)
                {
                    week.Add(4);
                }
                if (c_friday.Checked == true)
                {
                    week.Add(5);
                }
                if (c_saturday.Checked == true)
                {
                    week.Add(6);
                }
                if (c_sunday.Checked == true)
                {
                    week.Add(0);
                }
                //日付指定、回数指定
                if(r_kai.Checked ==true && t_kaisu.ToString() !="")
                {
                    int.TryParse(t_kaisu.Text.ToString(), out int count);
                     dates = GetWeeks(DateTime.Parse(d_kaishibi.Text), count, week,interval);
                }
                else
                {
                    dates = GetWeeks(DateTime.Parse(d_kaishibi.Text), enddate, week,interval);
                }
                if(week.Count == 0)
                {
                    MessageBox.Show("曜日を選択してください。");
                    return;
                }

            }
            else if (d_kurikaeshi.Text == "毎月")
            {
                //日付指定、回数指定
                if(r_kai.Checked == true && t_kaisu.ToString() != "")
                {
                    int.TryParse(t_kaisu.Text.ToString(), out int count);
                    dates = GetDays(DateTime.Parse(d_kaishibi.Text),count,interval);
                }
                else
                {
                    dates = GetDays(DateTime.Parse(d_kaishibi.Text), enddate,interval);
                }


            }

            var storecode = storeCodeList.Find(x => x.store_name == d_tenpo.Text.ToString()).store_code;
            foreach(DateTime d in dates)
            {
                DB.t_calendar_information calendar_Information = new DB.t_calendar_information();
                using (var dbc = new DB.DBConnect())
                {
                    dbc.npg.Open();
                    using (var transaction = dbc.npg.BeginTransaction())
                    {
                        var holiday_class = d_kyujitsukubun.Text.ToString() == "営業日" ? (int)Utile.Data.休日区分.営業日 : 
                            d_kyujitsukubun.Text.ToString() == "定休日" ?
                            (int)Utile.Data.休日区分.定休日 : (int)Utile.Data.休日区分.臨時休業;


                        //登録処理
                        var data = dbc.t_calendar_information.FirstOrDefault(x => x.store_code == storecode &  x.date == d.Date);

                        if (data == null)
                        {
                            //新規登録
                            calendar_Information.store_code = storecode;
                            calendar_Information.date = d.Date;
                            calendar_Information.notice = t_oshirashe.Text.ToString();
                            calendar_Information.holiday_class = holiday_class.ToString();
                            calendar_Information.registration_date = DateTime.Now.Date;
                            calendar_Information.registration_staff = MainForm.session_m_staff.staff_name;

                            dbc.t_calendar_information.Add(calendar_Information);
                        }
                        else
                        {
                            //更新情報
                            data.notice = t_oshirashe.Text.ToString();
                            data.store_code = storecode;
                            data.holiday_class = holiday_class.ToString();
                            data.update_date = DateTime.Now.Date;
                            data.update_staff = MainForm.session_m_staff.staff_name;

                        }

                        try
                        {
                            dbc.SaveChanges();
                            transaction.Commit();
                        }
                        catch(Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    
                }


           }

            //ひとつ前に戻る
            MainForm.Store_calender.PageRefresh();
            MainForm.backPage(this);
        }

        private void d_increase_Click(object sender, EventArgs e)
        {
            //カレンダー日付けを+1する。
            monthCalendar1.SetDate(monthCalendar1.SelectionStart.AddDays(1));

        }

        private void d_decrease_Click(object sender, EventArgs e)
        {
            //カレンダー日宇付けを-1する。
            monthCalendar1.SetDate(monthCalendar1.SelectionStart.AddDays(-1));

        }

        private void r_nashi_ChecjedChaged(object sender, EventArgs e)
        {
            t_kaisu.Enabled = false;
            t_kai.Enabled = false;
            d_syuryoubi.Enabled = false;
        }

        private void r_kai_CheckedChanged(object sender, EventArgs e)
        {
            t_kaisu.Enabled = true;
            t_kai.Enabled = true;
            d_syuryoubi.Enabled = false;

        }

        private void r_hiduke_CheckedChanged(object sender, EventArgs e)
        {
            t_kaisu.Enabled = false;
            t_kai.Enabled = false;
            d_syuryoubi.Enabled = true;
        }

        private void d_tenpo_KeyDown(object sender, KeyEventArgs e)
        {
 
        }

        //期間の曜日を取得
        private List<DateTime> GetWeeks(DateTime from_date, DateTime to_date,List<int> week,int interval )
        {

            List<DateTime> days = new List<DateTime>();

            DateTime d = from_date;
            int j = 1;
            int weekly = 0;

            while (d <= to_date)
            {
                if (j == 1)
                {
                    // DayOfWeekを使う
                    DayOfWeek dow = d.DayOfWeek; // 日曜=0～土曜=6
                    foreach (int w in week)
                    {
                        if (w == (int)dow)
                        {
                            days.Add(d);
                        }

                    }
                }
                
                d = d.AddDays(1);
                weekly = (int)(d.Date - from_date.Date).TotalDays % 7;

                if (weekly == 0)
                {
                    j = j >= interval ? 1 : j + 1;
                }
            }
            return days;
        }
        //期間の曜日を回数分取得
        private List<DateTime> GetWeeks(DateTime from_date, int count, List<int> week,int interval)
        {

            List<DateTime> days = new List<DateTime>();

            DateTime d = from_date;
            int i = 0;
            int j = 1;
            int weekly = 0;

            while (i <= count )
            {
                if (j==1)
                {
                    // DayOfWeekを使う
                    DayOfWeek dow = d.DayOfWeek; // 日曜=0～土曜=6

                    foreach (int w in week)
                    {
                        if (w == (int)dow)
                        {
                            days.Add(d);

                        }
                        
                    }

                    if (weekly == 0)
                    {
                        i++;
                    }

                }

                d = d.AddDays(1);

                weekly = (int)(d.Date - from_date.Date).TotalDays % 7;

                if (weekly == 0)
                {
                    j = j >= interval ? 1 : j + 1;
                }

            }
            return days;
        }

        //毎月の指定日を取得
        private List<DateTime> GetDays(DateTime from_date, DateTime to_date,int interval)
        {

            List<DateTime> days = new List<DateTime>();
            DateTime d = from_date;
            int i = 0;
            int j = 1;

            while(d <= to_date)
            {
                if (j == 1)
                {
                    // 日付を取得
                    days.Add(d);

                }

                d = d.AddMonths(1);
                j = j >= interval ? 1 : j + 1;
            }

            return days;
        }

        //毎月の指定日の回数分取得
        private List<DateTime> GetDays(DateTime from_date, int count, int interval)
        {

            List<DateTime> days = new List<DateTime>();

            // 日付を取得
            DateTime d = from_date;
            int i = 0;
            int j = 1;
            
            while(i < count)
            {
                if(j == 1)
                {
                    days.Add(d);
                    i++;
                }

                d= d.AddMonths(1);
                j = j >= interval ? 1 : j + 1;
            }
            return days;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void d_tenpo_IndexChanged(object sender, EventArgs e)
        {
            //データがすでに存在していれば、値をセット
            //存在していない場合は、初期化
            var current_store = d_tenpo.Text;
            var current_storecode = storeCodeList.Find(x => x.store_name == current_store).store_code;

            var calender_info = DB.t_calendar_information.getSingle(current_storecode, monthCalendar1.SelectionStart.Date);
            if (calender_info!=null)
            {
                t_oshirashe.Text = calender_info.notice;
                var IntVal1 = int.Parse(calender_info.holiday_class);
                d_kyujitsukubun.SelectedIndex = IntVal1;
            }
            else
            {
                t_oshirashe.Text = null;
                d_kyujitsukubun.SelectedIndex = 0;
            }
        }
    }
}
