using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C1.Win;

namespace 写真館システム
{
    public partial class Header_Menu : UserControl
    {
        public static String CustomerName;
        public static String StaffName;
        public static String ReceptionCode;
        public Header_Menu()
        {
            InitializeComponent();
            //TODO:デバック用　最終的にボタンは削除する
            Photo_selecton.Visible = false;

            //衣装予約モード
            String _crmode = System.Configuration.ConfigurationManager.AppSettings["Costume Reservation Mode"];
            var crmode = Enum.Parse(typeof(Utile.Data.衣装予約モード), _crmode);

            if ((Utile.Data.衣装予約モード)crmode == Utile.Data.衣装予約モード.ON)
            {
                this.Reservation_timetable.Visible = false;
            }
        }

        //メインメニューのPageRefresh実行されたらLabelを書き換える
        public void LabelReWrite()
        {
            //受付情報格納
            if(MainForm.session_t_reception != null)
            {
                var surname = DB.m_customer.getSingle(MainForm.session_t_reception.customer_code).surname;
                var name = DB.m_customer.getSingle(MainForm.session_t_reception.customer_code).name;
                CustomerName = surname + name;
                ReceptionCode = MainForm.session_t_reception.reception_code;
                this.l_customer.Text = "<b>"+ CustomerName + " 様<br>"+ ReceptionCode + "</b>";
                Costume_timetable.Enabled = true;
                Reservation_timetable.Enabled = true;
            }
            else
            {
                this.l_customer.Text = "未選択";
                Costume_timetable.Enabled = false;
                Reservation_timetable.Enabled = true;
            }
            this.l_customer.Update();

            //スタッフ情報格納
            StaffName = MainForm.session_m_staff.staff_name;
            this.l_staff.Text = "<b>"+ StaffName + "</b>";
            this.l_staff.Update();
        }


        private void Reservation_timetable_Click(object sender, EventArgs e)
        {
            MainForm.Reservation_timetable.c1Calendar1.SelectedDates = new DateTime[] { DateTime.Now.Date };
            MainForm.Reservation_timetable.PageRefresh();
            MainForm.sendPage(MainForm.dispPage, MainForm.Reservation_timetable);
        }

        private void Main_menu_Click(object sender, EventArgs e)
        {
            MainForm.Main_menu.PageRefresh();
            MainForm.sendPage(MainForm.dispPage, MainForm.Main_menu);
        }

        private void Photo_selecton_Click(object sender, EventArgs e)
        {
            if(MainForm.session_t_reception != null)
            {
                MainForm.sendPage(MainForm.dispPage, MainForm.Photo_selection);
                MainForm.Photo_selection.PageRefresh();
            }
            else
            {
                Utile.Message.showMessageOK("I12000");
            }
        }

        private void Costume_timetable_Click(object sender, EventArgs e)
        {
            MainForm.Costume_timetable.PageRefresh();
            MainForm.sendPage(MainForm.dispPage, MainForm.Costume_timetable);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            MainForm.session_t_reception = null;
            MainForm.Login.PageRefresh();
            MainForm.sendPage(MainForm.dispPage, MainForm.Login);
            MainForm.Header_Menu.Visible = false;
        }

        private void l_customer_Click(object sender, EventArgs e)
        {

        }

        private void l_staff_Click(object sender, EventArgs e)
        {

        }

        private void Customer_information_Click(object sender, EventArgs e)
        {
            MainForm.Customer_information.PageRefresh();
            MainForm.sendPage(MainForm.dispPage, MainForm.Customer_information);
        }

        private void Reception_Click(object sender, EventArgs e)
        {
            MainForm.Reception.PageRefresh();
            MainForm.sendPage(MainForm.dispPage, MainForm.Reception);
        }

        private void customer_search_Click(object sender, EventArgs e)
        {
            MainForm.Customer_search.PageRefresh();
            MainForm.sendPage(MainForm.dispPage, MainForm.Customer_search);
        }
    }
}
