using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 写真館システム
{
    public partial class Main_menu : UserControlExp
    {
        private Utile.Data.衣装予約モード crmode;
        public Main_menu()
        {
            InitializeComponent();

            //衣装予約モード
            String _crmode = System.Configuration.ConfigurationManager.AppSettings["Costume Reservation Mode"];
            crmode = (Utile.Data.衣装予約モード)Enum.Parse(typeof(Utile.Data.衣装予約モード), _crmode);

        }

        public override void PageRefresh()
        {


            //ヘッダーメニュのラベルの書き換え
            MainForm.Header_Menu.LabelReWrite();
            if(MainForm.session_m_staff.permission_class == "0")
            {
                this.label1.Visible = true;
                this.Customer_information.Visible = true;
                this.Reservation_timetable.Visible = true;
                this.Costume_timetable.Visible = true;
                this.label4.Visible = true;
                this.Customer_search.Visible = true;
                this.Reception_Search.Visible = true;
                this.c1Button3.Visible = true;
                this.Costume_reservation_search.Visible = true;
                this.Costume_search.Visible = true;
                this.label5.Visible = true;
                this.Store_master.Visible = true;
                this.Staff_master.Visible = true;
                this.Facility_master.Visible = true;
                this.Costume_master.Visible = true;
                this.store_calendar.Visible = true;
                this.Staff_Shift2.Visible = true;
            }
            else if(MainForm.session_m_staff.permission_class == "1")
            {
                this.label1.Visible = true;
                this.Customer_information.Visible = true;
                this.Reservation_timetable.Visible = true;
                this.Costume_timetable.Visible = true;
                this.label4.Visible = true;
                this.Customer_search.Visible = true;
                this.Reception_Search.Visible = true;
                this.c1Button3.Visible = true;
                this.Costume_reservation_search.Visible = true;
                this.Costume_search.Visible = true;
                this.label5.Visible = false;
                this.Store_master.Visible = false;
                this.Staff_master.Visible = false;
                this.Facility_master.Visible = false;
                this.Costume_master.Visible = false;
                this.store_calendar.Visible = false;
                this.Staff_Shift2.Visible = false;
            }

            if (crmode == Utile.Data.衣装予約モード.ON)
            {
                this.Reservation_timetable.Visible = false;
                this.c1Button3.Visible = false;
                this.Facility_master.Visible = false;
            }

            //受付未選択時は衣装予約、施設予約は非活性

            if (MainForm.session_t_reception != null)
            {
                this.Reservation_timetable.Enabled = true;
                this.Costume_timetable.Enabled = true;
            }
            else
            {
                this.Reservation_timetable.Enabled = true;
                this.Costume_timetable.Enabled = false;
            }
        }
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reception_Search_Click(object sender, EventArgs e)
        {
            MainForm.Reception_search.PageRefresh();
            MainForm.sendPage(this, MainForm.Reception_search);
        }

        private void Reservation_timetable_Click(object sender, EventArgs e)
        {
            MainForm.Reservation_timetable.c1Calendar1.SelectedDates = new DateTime[] { DateTime.Now.Date };
            MainForm.Reservation_timetable.PageRefresh();
            MainForm.sendPage(this, MainForm.Reservation_timetable);
        }

        private void Scheduled_search_Click(object sender, EventArgs e)
        {
            MainForm.Scheduled_search.PageRefresh();
            MainForm.sendPage(this, MainForm.Scheduled_search);
        }

        private void Reception_Click(object sender, EventArgs e)
        {

            MainForm.Reception.pageParent = this;
            MainForm.sendPage(this, MainForm.Reception);
            MainForm.Reception.PageRefresh();
        }
        private void Customer_information_Click(object sender, EventArgs e)
        {
            MainForm.Customer_information.PageRefresh();
            MainForm.sendPage(this, MainForm.Customer_information);
        }

        private void Costume_timetable_Click(object sender, EventArgs e)
        {
            MainForm.Costume_timetable.PageRefresh();
            MainForm.sendPage(this, MainForm.Costume_timetable);
        }

        private void Photo_selection_Click(object sender, EventArgs e)
        {
            if (MainForm.session_t_reception != null)
            {
                MainForm.sendPage(this, MainForm.Photo_selection);
                MainForm.Photo_selection.PageRefresh();
            }
            else
            {
                MessageBox.Show(Utile.Message.message["I12000"]);
            }
        }

        private void Customer_search_Click(object sender, EventArgs e)
        {
            MainForm.Customer_search.PageRefresh();
            MainForm.sendPage(this, MainForm.Customer_search);
        }

        private void Costume_reservation_search_Click(object sender, EventArgs e)
        {
            MainForm.Costume_reservation_search.PageRefresh();
            MainForm.sendPage(this, MainForm.Costume_reservation_search);
        }

        private void Costume_search_Click(object sender, EventArgs e)
        {
            MainForm.Costume_search.PageRefresh();
            MainForm.sendPage(this, MainForm.Costume_search);
        }

        private void Store_master_Click(object sender, EventArgs e)
        {
            MainForm.Store_master.PageRefresh();
            MainForm.sendPage(this, MainForm.Store_master);
        }

        private void Staff_master_Click(object sender, EventArgs e)
        {
            MainForm.Staff_master.PageRefresh();
            MainForm.sendPage(this, MainForm.Staff_master);

        }

        private void Facility_master_Click(object sender, EventArgs e)
        {
            MainForm.Facility_master.PageRefresh();
            MainForm.sendPage(this, MainForm.Facility_master);
        }

        private void Costume_master_Click(object sender, EventArgs e)
        {
            MainForm.Costume_master.PageRefresh();
            MainForm.sendPage(this, MainForm.Costume_master);
        }

        private void store_calendar_Click(object sender, EventArgs e)
        {
            MainForm.Store_calender.PageRefresh();
            MainForm.sendPage(this, MainForm.Store_calender);
        }

        private void Staff_Shift_Click(object sender, EventArgs e)
        {
            MainForm.Staff_shift.PageRefresh();
            MainForm.sendPage(this, MainForm.Staff_shift);
        }

        private void Main_menu_Load(object sender, EventArgs e)
        {

        }

        private void Customer_search2_Click(object sender, EventArgs e)
        {
            MainForm.Customer_search.PageRefresh();
            MainForm.sendPage(this, MainForm.Customer_search);
        }
    }
}
