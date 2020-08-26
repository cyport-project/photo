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
    public partial class Reception : UserControlExp
    {
        DateTime? DateTimeToday;

        //入力チェック
        private checkOperation chkExist;

        //受付コードチェック
        private checkOperation chkreceptcode;

        //受付時間チェック
        private checkOperation chkrecepttime;

        //撮影人数チェック
        private checkOperation chkphotographers;

        //メモチェック
        private checkOperation chkmemo;

        //クレームチェック
        private checkOperation chkclaim;


        //スタッフ構造体
        private struct staffCodeArray
        {
            public string staff_code;
            public string staff_name;
        }
        //スタッフリスト生成
        List<staffCodeArray> staffCodeList = new List<staffCodeArray>();


        //店舗構造体の生成
        public struct storeCodeArray
        {
            public string store_code;
            public string store_name;
        }
        //店舗リスト生成
        List<storeCodeArray> storeCodeList = new List<storeCodeArray>();

        public Reception()
        {
            InitializeComponent();
            //チェックリストの生成
            chkExist = new checkOperation(this);
            chkreceptcode = new checkOperation(this);
            chkrecepttime = new checkOperation(this);
            chkphotographers = new checkOperation(this);
            chkmemo = new checkOperation(this);
            chkclaim = new checkOperation(this);
        }

        //
        //ページのロード
        //
        private void Reception_load(object sender, EventArgs e)
        {

        }

        //
        //ページの初期化
        //
        public override void PageRefresh()
        {
            //店舗リスト生成
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

            //スタッフリスト生成
            //スタッフデータ読み込み
            List<DB.m_staff> m_staffList = DB.m_staff.GetlistAllTable();
            staffCodeList.Clear();

            foreach (var m_staff in m_staffList)
            {
                staffCodeList.Add(new staffCodeArray
                {
                    staff_code = m_staff.staff_code.ToString(),
                    staff_name = m_staff.staff_name.ToString()
                });
            }



            //TextBox項目の初期化の初期化（受付コード・受付時間・概要）
            int reception_number = int.Parse(DB.t_reception.getMaxReceptioncode());
            reception_number++;
            t_reception_code.Text = reception_number.ToString("00000000");
            t_reception_time.Text = null;
            t_memo.Text = null;
            t_memo.ImeMode = ImeMode.Hiragana;
            t_photographers.Text = "1";

            //
            //   ComboBoxの初期化
            //

            //受付店舗の設定
            //セッション情報取得(自店舗)
            var own_storecode = MainForm.session_m_staff.store_code;
            var own_storename = storeCodeList.Find(x => x.store_code == own_storecode).store_name;

            //初期表示設定
            d_receipt_store.Items.Clear();
            for (int i = 0; i < storeCodeList.Count; i++)
            {
                d_receipt_store.Items.Add(storeCodeList[i].store_name);
            }

            //自店舗表示
            var index = d_receipt_store.FindStringExact(own_storename);
            d_receipt_store.SelectedIndex = index;

            //受付スタッフの設定
            //スタッフ名
            foreach (var staff in staffCodeList)
            {

                d_receipt_staff.Items.Add(staff.staff_name);
            }

            //セッション情報取得(自店舗)
            var own_staffname = MainForm.session_m_staff.staff_name;
            var index1 = d_receipt_staff.FindStringExact(own_staffname);
            d_receipt_staff.SelectedIndex = index1;

            //受付ステータス
            d_status.DataSource = Enum.GetValues(typeof(Utile.Data.受付ステータス));
            d_status.SelectedIndex = -1;

            //来店区分
            d_coming_store_category.DataSource = Enum.GetValues(typeof(Utile.Data.来店区分));
            d_coming_store_category.SelectedIndex = -1;

            //来店動機
            d_motivation.DataSource = Enum.GetValues(typeof(Utile.Data.来店動機));
            d_motivation.SelectedIndex = -1;


            //DatePickerの初期化
            //日付の初期化
            DateTimeToday = null;
            DateTimeToday = DateTime.Today;
            Set_d_receipt_date_from(DateTimeToday);

            //時刻の初期化
            t_reception_time.Text = DateTime.Now.ToString("HH:MM");



            /*
             * 顧客情報の編集
             * TODO　顧客登録時にコード追加
             *
             */

            if (this.pageParent.pageName == "顧客検索" && Customer_search.sex != null)
            {
                int intVal = -1;
                d_customer_code.Text = Customer_search.customer_code;
                d_customer_name.Text = Customer_search.surname + Customer_search.name;
                d_birthday.Text = Customer_search.birthday.ToShortDateString() + " " +
                    GetAge(Customer_search.birthday, DateTime.Now) + "歳";

                intVal = int.Parse(Customer_search.sex.ToString());

                var sex = (Utile.Data.性別)Enum.ToObject(typeof(Utile.Data.性別), intVal);
                d_sex.Text = Customer_search.sex.ToString();
                d_customer_postal_code.Text = Customer_search.postal_code;
                d_address1.Text = Customer_search.address1;
                d_address2.Text = Customer_search.address2;
                d_address3.Text = Customer_search.address3;
                d_phone_number.Text = Customer_search.phone_number1;
                d_mail_address.Text = Customer_search.mail_address;
            }
            else if (this.pageParent.pageName == "顧客情報登録")
            {
                d_customer_code.Text = Customer_information.customer_code != "" ? Customer_information.customer_code:"" ;
                d_customer_name.Text = Customer_information.surname != "" ? 
                    Customer_information.surname + Customer_information.name:"";
                d_birthday.Text = Customer_information.birthday != null ? 
                    Customer_information.birthday.Value.ToShortDateString() + " " +
                    GetAge(Customer_information.birthday.Value, DateTime.Now) + "歳": "";
                d_sex.Text = Customer_information.sex !=null?
                    Customer_information.sex.ToString():"";
                d_customer_postal_code.Text = Customer_information.postal_code != ""?
                    Customer_information.postal_code : "";
                d_address1.Text = Customer_information.address1 != "" ?
                    Customer_information.address1 : "";
                d_address2.Text = Customer_information.address2 != "" ? 
                    Customer_information.address2 : "";
                d_address3.Text = Customer_information.address3;
                d_phone_number.Text = Customer_information.phone_number1 != "" ?
                    Customer_information.phone_number1:"";
                d_mail_address.Text = Customer_information.mail_address != ""?
                    Customer_information.mail_address:"";
            }
            else
            {
                d_customer_code.Text = "";
                d_customer_name.Text = "";
                d_birthday.Text = "";
                d_sex.Text = "";
                d_customer_postal_code.Text = "";
                d_address1.Text = "";
                d_address2.Text = "";
                d_address3.Text = "";
                d_phone_number.Text = "";
                d_mail_address.Text = "";
            }


            //エラー表示の初期化
            chkExist.clear();
            chkreceptcode.clear();
            chkrecepttime.clear();
            chkphotographers.clear();
            chkmemo.clear();
            chkclaim.clear();

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

        //DatePickerが変動した時
        private void Set_d_receipt_date_from(DateTime? DateTimeToday)
        {
            if (DateTimeToday == null)
            {
                d_receipt_date.Format = DateTimePickerFormat.Custom;
                d_receipt_date.CustomFormat = " ";
            }
            else
            {
                d_receipt_date.Format = DateTimePickerFormat.Long;
                d_receipt_date.Value = (DateTime)DateTimeToday;
            }
        }

        private void d_reception_code_TextChanged(object sender, EventArgs e)
        {

        }

        private void d_receipt_store_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void d_receipt_staff_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d_siyoukahi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void t_memo_TextChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void l_coming_store_category_Click(object sender, EventArgs e)
        {

        }

        private void l_provision_class_Click(object sender, EventArgs e)
        {

        }

        private void l_receipt_date_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void d_customer_code_Click(object sender, EventArgs e)
        {

        }

        private void d_customer_name_Click(object sender, EventArgs e)
        {

        }

        private void l_address3_Click(object sender, EventArgs e)
        {

        }

        private void b_Customer_serach_Click(object sender, EventArgs e)
        {


        }

        private void d__receipt_store_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void b_regist_Click(object sender, EventArgs e)
        {
            //必須入力チェック
            //存在チェック項目の追加
            chkExist.addControl(t_reception_code);
            chkExist.addControl(d_receipt_date);
            chkExist.addControl(t_reception_time);
            chkExist.addControl(d_receipt_staff);
            chkExist.addControl(d_receipt_store);
            chkExist.addControl(d_status);
            chkExist.addControl(t_photographers);
            chkExist.addControl(d_coming_store_category);
            chkExist.addControl(d_motivation);
            chkExist.addControl(d_customer_code);
            if (chkExist.check("W00000", chkExist.checkControlImportant))
                return;

            //受付コードチェック
            chkreceptcode.addControl(t_reception_code);
            if (chkreceptcode.check("W00001", chkreceptcode.checkTextboxLength, 8))
                return;

            //受付時間チェック
            chkrecepttime.addControl(t_reception_time);
            if (chkrecepttime.check("W00001", chkrecepttime.checkTextboxLength, 5))
                return;
            if (chkrecepttime.check("W00003", chkrecepttime.checkTextboxFormat, @"^[0-2][0-9]:[0-5][0-9]$", @"HH:MM"))
                return;

            //撮影人数チェック
            chkphotographers.addControl(t_photographers);
            if (chkphotographers.check("W00001", chkphotographers.checkTextboxLength, 4))
                return;

            if (chkphotographers.check("W00003", chkphotographers.checkTextboxFormat, @"^\d+$", @"0～9999"))
                return;

            //メモチェック
            //メモチェック
            chkmemo.addControl(t_memo);
            if (chkmemo.check("W00001", chkmemo.checkTextboxLength, 255))
                return;

            //クレームチェック
            //クレームチェック
            chkclaim.addControl(d_claim);
            if (chkclaim.check("W00001", chkclaim.checkTextboxLength, 255))
                return;


            //登録処理
            //キーの設定
            string recept_code = t_reception_code.Text;

            //登録処理
            DB.t_reception reception = new DB.t_reception();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                using (var transaction = dbc.npg.BeginTransaction())
                {
                    //登録処理
                    var data = dbc.t_reception.FirstOrDefault(x => x.reception_code == recept_code);
                    if (data == null)
                    {
                        reception.reception_code = recept_code;
                        reception.receipt_date = d_receipt_date.Value;
                        reception.receipt_time = TimeSpan.Parse(t_reception_time.Text);
                        reception.status = (d_status.SelectedIndex + 1).ToString();
                        reception.photographers = int.Parse(t_photographers.Text);
                        reception.coming_store_category = (d_coming_store_category.SelectedIndex + 1).ToString();
                        reception.customer_code = d_customer_code.Text != "" ? d_customer_code.Text : "00000000";
                        reception.store = storeCodeList.Find(x => x.store_name == d_receipt_store.Text).store_name;
                        reception.staff = staffCodeList.Find(x => x.staff_name == d_receipt_staff.Text).staff_name;
                        reception.memo = t_memo.Text;
                        reception.claim = d_claim.Text;
                        reception.motivation = (d_motivation.SelectedIndex + 1).ToString();
                        reception.noprint = "0";
                        reception.registration_date = DateTime.Now.Date;
                        reception.registration_staff = MainForm.session_m_staff.staff_name;
                        dbc.t_reception.Add(reception);
                    }
                    else
                    {
                        MessageBox.Show("データがすでに存在してます。");
                        return;
                    }
                    try
                    {
                        dbc.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }

                }
            }
            if (d_customer_code.Text != "")
            {
                //セッション情報の追加
                MainForm.session_t_reception = reception;

                //ヘッダメニュー更新
                MainForm.Header_Menu.LabelReWrite();

            }

            MainForm.Main_menu.PageRefresh();
            MainForm.sendPage(this, MainForm.Main_menu);

        }

        private void b_return_Click(object sender, EventArgs e)
        {
            //一つ前に戻る
            pageParent.PageRefresh();
            MainForm.backPage(this);

        }

        private void d_receipt_date_ValueChanged(object sender, EventArgs e)
        {
            DateTimeToday = d_receipt_date.Value;
            Set_d_receipt_date_from(DateTimeToday);
        }

        private void d_staff_id_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void d_staff_id_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var staffname = staffCodeList.Find(x => x.staff_code == d_staff_id.Text).staff_name;
                var IntVal = d_receipt_staff.FindStringExact(staffname);
                d_receipt_staff.SelectedIndex = IntVal;
            }
        }
    }
}
