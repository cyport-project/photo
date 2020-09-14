using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 写真館システム
{
    using Utile;


    public partial class MainForm : Form
    {
        private enum ScreenMode
        {
            Full,
            Normal
        }

        public static MainForm form;
        public static UserControlExp dispPage;

        //画面宣言
        public static Header_Menu Header_Menu;
        public static Main_menu Main_menu;
        public static Facility_reservation Facility_reservation;
        public static Reservation_timetable Reservation_timetable;
        public static Photo_selection Photo_selection;
        public static Reception_search Reception_search;
        public static Reception_details Reception_details;
        public static Scheduled_search Scheduled_search;
        public static Customer_search Customer_search;
        public static Costume_reservation_search Costume_reservation_search;
        public static Costume_search Costume_search;
        public static Store_master Store_master;
        public static Staff_master Staff_master;
        public static Costume_master Costume_master;
        public static Facility_master Facility_master;
        public static Store_calender Store_calender;
        public static Staff_shift Staff_shift;
        public static Reception Reception;
        public static Costume_reservation Costume_reservation;
        public static Costume_timetable Costume_timetable;
        public static Login Login;
        public static Customer_information Customer_information;
        public static Order_entry Order_entry;
        public static rental rental;

        //セッション情報
        public static DB.m_staff session_m_staff = null;

        public static DB.t_reception session_t_reception = null;


        public MainForm()
        {
            InitializeComponent();

            //fullScreen mode
            String _ScreenMode = System.Configuration.ConfigurationManager.AppSettings["Screen Mode"];
            FullScreen fullScreen = new FullScreen();
            if((ScreenMode)Enum.Parse(typeof(ScreenMode), _ScreenMode) == ScreenMode.Full)
            {
                fullScreen.EnterFullScreenMode(this);
            }
            else
            {
                fullScreen.LeaveFullScreenMode(this);
            }
            //背景設定
            String root = System.Configuration.ConfigurationManager.AppSettings["photo_root"];
            String backImgage = System.Configuration.ConfigurationManager.AppSettings["Background Image"];
            String biPath = System.IO.Path.Combine(root, backImgage);
            if(System.IO.File.Exists(biPath))
                this.BackgroundImage = System.Drawing.Image.FromFile(biPath);
            else
            {
                //Message.showMessageOK("I99000");
            }

            //アイコンの設定
            this.Icon = new System.Drawing.Icon(@"Asset\フォト君.ico");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int marginHeight = 80;
            int marginWidth = 10;
            if (this.WindowState == FormWindowState.Maximized)
            {
                marginHeight = 40;
                marginWidth = 10;
            }

            form = this;

            
            //フォームに画面追加
            Header_Menu = new Header_Menu();
            MenuPanel.Controls.Add(Header_Menu);
            Header_Menu.Visible = false;
            Header_Menu.Height = 100;
            Header_Menu.Width = this.Width - marginWidth;
            Header_Menu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            

            Main_menu = new Main_menu();
            MainPanel.Controls.Add(Main_menu);
            Main_menu.pageName = "メインメニュー";
            Main_menu.Visible = false;
            Main_menu.Height = this.Height - marginHeight;
            Main_menu.Width = this.Width - marginWidth;
            Main_menu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Facility_reservation = new Facility_reservation();
            MainPanel.Controls.Add(Facility_reservation);
            Facility_reservation.pageName = "施設予約登録";
            Facility_reservation.Visible = false;
            Facility_reservation.Height = this.Height - marginHeight;
            Facility_reservation.Width = this.Width - marginWidth;
            Facility_reservation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Reservation_timetable = new Reservation_timetable();
            MainPanel.Controls.Add(Reservation_timetable);
            Reservation_timetable.pageName = "予約タイムテーブル";
            Reservation_timetable.Visible = false;
            Reservation_timetable.Height = this.Height - marginHeight;
            Reservation_timetable.Width = this.Width - marginWidth;
            Reservation_timetable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            
            Photo_selection = new Photo_selection();
            MainPanel.Controls.Add(Photo_selection);
            Photo_selection.pageName = "写真選択";
            Photo_selection.Visible = false;
            Photo_selection.Height = this.Height - marginHeight;
            Photo_selection.Width = this.Width - marginWidth;
            Photo_selection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Reception_search = new Reception_search();
            MainPanel.Controls.Add(Reception_search);
            Reception_search.pageName = "受付検索";
            Reception_search.Visible = false;
            Reception_search.Height = this.Height - marginHeight;
            Reception_search.Width = this.Width - marginWidth;
            Reception_search.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Reception_details = new Reception_details();
            MainPanel.Controls.Add(Reception_details);
            Reception_details.pageName = "受付詳細";
            Reception_details.Visible = false;
            Reception_details.Height = this.Height - marginHeight;
            Reception_details.Width = this.Width - marginWidth;
            Reception_details.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Scheduled_search = new Scheduled_search();
            MainPanel.Controls.Add(Scheduled_search);
            Scheduled_search.pageName = "施設予約検索";
            Scheduled_search.Visible = false;
            Scheduled_search.Height = this.Height - marginHeight;
            Scheduled_search.Width = this.Width - marginWidth;
            Scheduled_search.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Customer_search = new Customer_search();
            MainPanel.Controls.Add(Customer_search);
            Customer_search.pageName = "顧客検索";
            Customer_search.Visible = false;
            Customer_search.Height = this.Height - marginHeight;
            Customer_search.Width = this.Width - marginWidth;
            Customer_search.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Costume_reservation_search = new Costume_reservation_search();
            MainPanel.Controls.Add(Costume_reservation_search);
            Costume_reservation_search.pageName = "衣装予約検索";
            Costume_reservation_search.Visible = false;
            Costume_reservation_search.Height = this.Height - marginHeight;
            Costume_reservation_search.Width = this.Width - marginWidth;
            Costume_reservation_search.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Costume_search = new Costume_search();
            MainPanel.Controls.Add(Costume_search);
            Costume_search.pageName = "衣装検索";
            Costume_search.Visible = false;
            Costume_search.Height = this.Height - marginHeight;
            Costume_search.Width = this.Width - marginWidth;
            Costume_search.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Store_master = new Store_master();
            MainPanel.Controls.Add(Store_master);
            Store_master.pageName = "店舗マスタ";
            Store_master.Visible = false;
            Store_master.Height = this.Height - marginHeight;
            Store_master.Width = this.Width - marginWidth;
            Store_master.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Staff_master = new Staff_master();
            MainPanel.Controls.Add(Staff_master);
            Staff_master.pageName = "スタッフマスタ";
            Staff_master.Visible = false;
            Staff_master.Height = this.Height - marginHeight;
            Staff_master.Width = this.Width - marginWidth;
            Staff_master.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Costume_master = new Costume_master();
            MainPanel.Controls.Add(Costume_master);
            Costume_master.pageName = "衣装マスタ";
            Costume_master.Visible = false;
            Costume_master.Height = this.Height - marginHeight;
            Costume_master.Width = this.Width - marginWidth;
            Costume_master.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Facility_master = new Facility_master();
            MainPanel.Controls.Add(Facility_master);
            Facility_master.pageName = "施設マスタ";
            Facility_master.Visible = false;
            Facility_master.Height = this.Height - marginHeight;
            Facility_master.Width = this.Width - marginWidth;
            Facility_master.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Store_calender = new Store_calender();
            MainPanel.Controls.Add(Store_calender);
            Store_calender.pageName = "店舗カレンダー登録";
            Store_calender.Visible = false;
            Store_calender.Height = this.Height - marginHeight;
            Store_calender.Width = this.Width - marginWidth;
            Store_calender.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Staff_shift = new Staff_shift();
            MainPanel.Controls.Add(Staff_shift);
            Staff_shift.pageName = "スタッフシフト登録";
            Staff_shift.Visible = false;
            Staff_shift.Height = this.Height - marginHeight;
            Staff_shift.Width = this.Width - marginWidth;
            Staff_shift.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Reception = new Reception();
            MainPanel.Controls.Add(Reception);
            Reception.pageName = "受付登録";
            Reception.Visible = false;
            Reception.Height = this.Height - marginHeight;
            Reception.Width = this.Width - marginWidth;
            Reception.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Costume_reservation = new Costume_reservation();
            MainPanel.Controls.Add(Costume_reservation);
            Costume_reservation.pageName = "衣装予約";
            Costume_reservation.Visible = false;
            Costume_reservation.Height = this.Height - marginHeight;
            Costume_reservation.Width = this.Width - marginWidth;
            Costume_reservation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Costume_timetable = new Costume_timetable();
            MainPanel.Controls.Add(Costume_timetable);
            Costume_timetable.pageName = "衣装予約テーブル";
            Costume_timetable.Visible = false;
            Costume_timetable.Height = this.Height - marginHeight;
            Costume_timetable.Width = this.Width - marginWidth;
            Costume_timetable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            Customer_information = new Customer_information();
            MainPanel.Controls.Add(Customer_information);
            Customer_information.pageName = "顧客情報登録";
            Customer_information.Visible = false;
            Customer_information.Height = this.Height - marginHeight;
            Customer_information.Width = this.Width - marginWidth;
            Customer_information.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left; Login = new Login();
            /*
                        Order_entry = new Order_entry();
                        MainPanel.Controls.Add(Order_entry);
                        Order_entry.pageName = "発注入力";
                        Order_entry.Visible = false;
                        Order_entry.Height = this.Height - marginHeight;
                        Order_entry.Width = this.Width - marginWidth;
                        Order_entry.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left; Login = new Login();
            */
 /*           rental = new rental();
            MainPanel.Controls.Add(rental);
            rental.pageName = "一括貸出";
            rental.Visible = false;
            rental.Height = this.Height - marginHeight;
            rental.Width = this.Width - marginWidth;
            rental.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left; Login = new Login();
*/
            MainPanel.Controls.Add(Login);
            Login.pageName = "ログイン";
            Login.Visible = false;
            Login.Height = this.Height - marginHeight;
            Login.Width = this.Width - marginWidth;
            Login.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;


            //初期表示画面を表示
            Header_Menu.Visible = false;
            Login.Visible = true;
            Login.pageParent = Login;
            dispPage = Login;
            this.Text = Login.pageName;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public static void sendPage(UserControlExp parent, UserControlExp ctl)
        {
            dispPage = ctl;
            ctl.pageParent = parent;
            parent.Visible = false;
            ctl.Visible = true;
            form.Text = ctl.pageName;
        }
        public static void backPage(UserControlExp parent)
        {
            dispPage = parent.pageParent;
            parent.Visible = false;
            parent.pageParent.Visible = true;
            form.Text = parent.pageParent.pageName;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
