using System;
using System.IO;
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
using 写真館システム.DB;

namespace 写真館システム
{
    public partial class Store_master : UserControlExp
    {
        //変更フラグ
        private Boolean changeValue;
        //現在ページ
        private int currentPage;
        //総ページ
        private int totalPage;
        //入力チェック
        private checkOperation chk;

        //接続する為のインスタンスを生成
        NpgsqlConnection conn = new NpgsqlConnection();

        //日付の取得用変数
        DateTime nowDay = DateTime.Now.Date;

        //データ格納配列を追加
        struct StoreArray
        {
            public String store_code;
            public String store_company;
            public String store_name;
            public String store_postal_code;
            public String store_pref_city_town_district_village;
            public String store_address;
            public String store_apart;
            public String store_phone_number;
            public String store_status;
            public TimeSpan store_start_time;
            public TimeSpan store_end_time;
            public String store_regular_hoiday;
            public String store_classification;
            public String store_index;
        }

        //データ格納配列を追加
        public struct StoreDBArray
        {
            public String store_code;
            public String store_company;
            public String store_name;
            public String store_postal_code;
            public String store_pref_city_town_district_village;
            public String store_address;
            public String store_apart;
            public String store_phone_number;
            public String store_status;
            public TimeSpan store_start_time;
            public TimeSpan store_end_time;
            public String store_regular_hoiday;
            public String store_classification;
            public String store_index;
        }

        //配列格納用データ変数
        public String StoreCode = "";
        public String StoreCompany = "";
        public String StoreName = "";
        public String StorePostalCode = "";
        public String StorePrefCityTownDistrictVillage = "";
        public String StoreAddress = "";
        public String StoreApart = "";
        public String StorePhoneNumber = "";
        public String StoreStatus = "";
        public TimeSpan StoreStartTime;
        public TimeSpan StoreEndTime;
        public String StoreRegularHoliday = "";
        public String StoreClassification = "";
        public DateTime StoreRegistrationDate;
        public String StoreRegistrationStaff = "";
        public DateTime StoreUpdateDate;
        public String StoreUpdateStaff = "";
        public String StoreDeleteFlag = "0";
        public String StoreIndex = "";

        //データベース更新時確認用変数
        public String m_storeStoreCode = "";
        public String m_storeStoreCompany = "";
        public String m_storeStoreName = "";
        public String m_storeStorePostalCode = "";
        public String m_storeStorePrefCityTownDistrictVillage = "";
        public String m_storeStoreAddress = "";
        public String m_storeStoreApart = "";
        public String m_storeStorePhoneNumber = "";
        public String m_storeStoreStatus = "";
        public TimeSpan m_storeStoreStartTime;
        public TimeSpan m_storeStoreEndTime;
        public String m_storeStoreRegularHoliday = "";
        public String m_storeStoreClassification = "";
        public String m_storeStoreRegistrationStaff = "";
        public DateTime m_storeStoreUpdateDate;
        public String m_storeStoreUpdateStaff = "";
        public String m_storeStoreDeleteFlag = "0";
        public String m_storeStoreIndex = "";

        //データベース接続用変数
        public String connectString = "";
        public String upStoreCode = "";
        public String delStoreCode = "";

        public int i = 0;
        public int max_index = 0;

        //SQL格納用変数
        public String strSQL = "";
        private List<StoreArray> StoreList = new List<StoreArray>();
        private List<StoreDBArray> StoreDBList = new List<StoreDBArray>();

        //配列インデックス
        public int index = 0;

        //データのあるなし
        public bool data_flag = false;

        public Store_master()
        {
            InitializeComponent();

            //追記：安達　入力チェック案
            //入力チェック初期化
            chk = new checkOperation(this);


        }

        public override void PageRefresh()
        {
            ListArrayStore();
            currentPage = 1;
            Set_currentDisplay();
            Listshow();
            changeValue = false;

            chk.clear();

            t_tenpo_code.Enabled = false;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            ListArrayStore();
            //データが存在しない場合
            if (data_flag == false){
                currentPage = 1;
                totalPage = 1;
                Set_initialDisplay();
            }
            else if(data_flag == true)
            {
                //データが存在する場合
                Set_initialDisplay();
                currentPage = 1;
                Listshow();
                Set_currentDisplay();
            }
        }

        //list登録
        public void ListArrayStore()
        {
            //データベースから持ってくるリストをクリア
            StoreDBList.Clear();
            //データ取得
            StoreDBList = DB.m_store.getStoreAllList();

            totalPage = StoreDBList.Count;
            if(totalPage == 0)
            {
                data_flag = false;
            }
            else
            {
                data_flag = true;
            }
        }

        //list表示
        public void Listshow()
        {
            //データ取得
            ListArrayStore();
            //カレントページからListデータを取得する
            if (currentPage >= 1 && StoreDBList.Count > currentPage - 1)
            {
                index = currentPage - 1;
                var storeData = StoreDBList[index];
                this.t_tenpo_code.Text = storeData.store_code;
                this.t_company.Text = storeData.store_company;
                this.t_tenpo.Text = storeData.store_name;
                this.t_postal_code.Text = storeData.store_postal_code;
                this.t_kensikuchouson.Text = storeData.store_pref_city_town_district_village;
                this.t_banchi.Text = storeData.store_address;
                this.t_apart.Text = storeData.store_apart;
                this.t_telephon_no.Text = storeData.store_phone_number;
                this.d_status.SelectedIndex = int.Parse(storeData.store_status);
                this.t_eigyou_start.Text = storeData.store_start_time.ToString(@"hh\:mm");
                this.t_eigyou_end.Text = storeData.store_end_time.ToString(@"hh\:mm");
                this.t_regular_holiday.Text = storeData.store_regular_hoiday;
                this.d_tenpo_kubun.SelectedIndex = int.Parse(storeData.store_classification);
            }
            else
            {
                Set_initialDisplay();
            }
        }

        //List保存
        public void ListStore()
        {
            //配列用データを取得する
            StoreCode = this.t_tenpo_code.Text;
            StoreCompany = this.t_company.Text;
            StoreName = this.t_tenpo.Text;
            StorePostalCode = this.t_postal_code.Text;
            StorePrefCityTownDistrictVillage = this.t_kensikuchouson.Text;
            StoreAddress = this.t_banchi.Text;
            StoreApart = this.t_apart.Text;
            StorePhoneNumber = this.t_telephon_no.Text;
            StoreStatus = this.d_status.SelectedIndex.ToString();
            StoreStartTime = TimeSpan.Parse(this.t_eigyou_start.Text);
            StoreEndTime = TimeSpan.Parse(this.t_eigyou_end.Text);
            StoreRegularHoliday = this.t_regular_holiday.Text;
            StoreClassification = this.d_tenpo_kubun.SelectedIndex.ToString();


            StoreList.Add(new StoreArray
            {
                store_code = StoreCode,
                store_company = StoreCompany,
                store_name = StoreName,
                store_postal_code = StorePostalCode,
                store_pref_city_town_district_village = StorePrefCityTownDistrictVillage,
                store_address = StoreAddress,
                store_apart = StoreApart,
                store_phone_number = StorePhoneNumber,
                store_status = StoreStatus,
                store_start_time = StoreStartTime,
                store_end_time = StoreEndTime,
                store_regular_hoiday = StoreRegularHoliday,
                store_classification = StoreClassification,
                store_index = currentPage.ToString()
            });
            index++;
            max_index = index;
        }




        //新規登録ボタン
        private void b_new_regist_Click(object sender, EventArgs e)
        {
            t_tenpo_code.Enabled = true;

            using(var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_store
                        where t.delete_flag == "0"
                        select t;
                totalPage = q.Count();
            }

            //初期化
            if (changeValue == false)
            {
                totalPage++;
                currentPage = totalPage;
                Set_initialDisplay();

            }
            else
            {
                DialogResult result = MessageBox.Show("変更が保存されていません。\n" +
                    "変更を破棄して次の処理へ進みますか？", "",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    totalPage++;
                    currentPage = totalPage;
                    Set_initialDisplay();
                }
            }


        }

        //初期表示設定
        private void Set_initialDisplay()
        {
            //項目の初期化
            t_tenpo_code.Text = null;
            t_current_page.Text = (string)currentPage.ToString("0");
            t_total_page.Text = (string)totalPage.ToString("0");
            t_company.Text = null;
            t_tenpo.Text = null;
            t_postal_code.Text = null;
            t_kensikuchouson.Text = null;
            t_banchi.Text = null;
            t_apart.Text = null;
            t_telephon_no.Text = null;
            t_eigyou_start.Text = null;
            t_eigyou_end.Text = null;
            t_regular_holiday.Text = null;

            d_status.DataSource = Enum.GetValues(typeof(Utile.Data.店舗ステータス));
            d_tenpo_kubun.DataSource = Enum.GetValues(typeof(Utile.Data.店舗区分));
            
            //変更フラグクリア
            changeValue = false;
        }

        //現在ページ設定
        private void Set_currentDisplay()
        {
            //現在ページの設定
            t_current_page.Text = (string)currentPage.ToString("0");
            t_total_page.Text = (string)totalPage.ToString("0");
            
            //変更フラグクリア
            changeValue = false;
        }


        //削除ボタン
        private void b_delete_Click(object sender, EventArgs e)
        {
            //データベース登録・更新処理
            //削除用データの店舗コードを取得する(現時点では店舗コード入力欄に店舗コードが入っているものを削除している)
            delStoreCode = this.t_tenpo_code.Text;

            //店舗使用中チェック
            using(var dbc = new DB.DBConnect())
            {
                //スタッフ
                var q1 = from t in dbc.m_staff
                        where t.store_code == delStoreCode & t.delete_flag == "0"
                        select t;
                if (q1.Count() != 0)
                {
                    Utile.Message.showMessageOK("I13003");
                    return;
                }
                //施設
                var q2 = from t in dbc.m_facility
                        where t.store_code == delStoreCode & t.delete_flag == "0"
                        select t;
                if (q2.Count() != 0)
                {
                    Utile.Message.showMessageOK("I13004");
                    return;
                }
                //衣装
                var q3 = from t in dbc.m_costume
                        where t.store_code == delStoreCode & t.delete_flag == "0"
                        select t;
                if (q3.Count() != 0)
                {
                    Utile.Message.showMessageOK("I13005");
                    return;
                }
            }

            // 接続インスタンスを作成。
            m_store m_store =  DB.m_store.getSingle(delStoreCode);
            if(m_store != null )
                m_store.Command(true);
            else
            {
                Utile.Message.showMessageOK("E13000");
                return;
            }

            //削除後、データの再取得し削除データの後データを読み込む
            MainForm.Store_master.PageRefresh();
            ListArrayStore();
            Listshow();
            Set_currentDisplay();

            pageParent.PageRefresh();
            MainForm.backPage(this);

        }

        //登録ボタン
        private void b_regist_Click(object sender, EventArgs e)
        {

            //必須入力チェック
            chk.clear();
            chk.addControl(t_tenpo_code);
            chk.addControl(t_company);
            chk.addControl(t_tenpo);
            chk.addControl(t_postal_code);
            chk.addControl(t_kensikuchouson);
            chk.addControl(t_banchi);
            chk.addControl(t_telephon_no);
            chk.addControl(t_eigyou_start);
            chk.addControl(t_eigyou_end);
            chk.addControl(t_regular_holiday);
            chk.addControl(d_status);
            chk.addControl(d_tenpo_kubun);
            if (chk.check("W00000", chk.checkControlImportant))
                return;

            //桁数
            //5
            chk.clear();
            chk.addControl(t_eigyou_start);
            chk.addControl(t_eigyou_end);
            if (chk.check("W00001", chk.checkTextboxLength, 5))
                return;
            //8
            chk.clear();
            chk.addControl(t_tenpo_code);
            if (chk.check("W00001", chk.checkTextboxLength, 8))
                return;
            //10
            chk.clear();
            chk.addControl(t_regular_holiday);
            if (chk.check("W00001", chk.checkTextboxLength, 10))
                return;
            //13
            chk.clear();
            chk.addControl(t_telephon_no);
            if (chk.check("W00001", chk.checkTextboxLength, 13))
                return;
            //60
            chk.clear();
            chk.addControl(t_company);
            chk.addControl(t_tenpo);
            if (chk.check("W00001", chk.checkTextboxLength, 60))
                return;
            //120
            chk.clear();
            chk.addControl(t_kensikuchouson);
            chk.addControl(t_banchi);
            chk.addControl(t_apart);
            if (chk.check("W00001", chk.checkTextboxLength, 120))
                return;

            //フォーマットチェック
            chk.clear();
            chk.addControl(t_eigyou_start);
            chk.addControl(t_eigyou_end);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^([0-9]|[0-1][0-9]|[2][0-3]):[0-5][0-9]$", "00:00"))
                return;

            chk.clear();
            chk.addControl(t_telephon_no);
            if (chk.check("W00003", chk.checkTextboxFormat, @"\A0\d{1,4}-\d{1,4}-\d{4}\z", "000-0000-0000"))
                return;

            chk.clear();
            chk.addControl(t_postal_code);
            if (chk.check("W00003", chk.checkTextboxFormat, @"\A\d\d\d-\d\d\d\d\z", "000-0000"))
                return;

            if (t_tenpo_code.Text == "")
            {
                Utile.Message.showMessageOK("E13001");
                return;
            }

            //内容保存
            //ListStore();


            StoreCode = this.t_tenpo_code.Text;
            StoreCompany = this.t_company.Text;
            StoreName = this.t_tenpo.Text;
            StorePostalCode = this.t_postal_code.Text;
            StorePrefCityTownDistrictVillage = this.t_kensikuchouson.Text;
            StoreAddress = this.t_banchi.Text;
            StoreApart = this.t_apart.Text;
            StorePhoneNumber = this.t_telephon_no.Text;
            StoreStatus = this.d_status.SelectedIndex.ToString();
            StoreStartTime = TimeSpan.Parse(this.t_eigyou_start.Text);
            StoreEndTime = TimeSpan.Parse(this.t_eigyou_end.Text);
            StoreRegularHoliday = this.t_regular_holiday.Text;
            StoreClassification = this.d_tenpo_kubun.SelectedIndex.ToString();


            using(var dbc = new DB.DBConnect())
            {
                var data = DB.m_store.getSingle(StoreCode);
                if (data == null)
                    data = new DB.m_store();

                data.store_code = StoreCode;
                data.company_name = StoreCompany;
                data.store_name = StoreName;
                data.postal_code = StorePostalCode;
                data.address1 = StorePrefCityTownDistrictVillage;
                data.address2 = StoreAddress;
                data.address3 = StoreApart;
                data.phone_number = StorePhoneNumber;
                data.status = StoreStatus;
                data.start_time = StoreStartTime;
                data.end_time = StoreEndTime;
                data.regular_holiday = StoreRegularHoliday;
                data.store_category = StoreClassification;

                data.Command();
            }

            var rootPath = System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString();
            var cosDir = System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString();
            string Cost_Path = System.IO.Path.Combine(rootPath, cosDir);
            string store_Path = System.IO.Path.Combine(Cost_Path, StoreName);
            if (!System.IO.Directory.Exists(store_Path));
            {
                Directory.CreateDirectory(store_Path);
            }
            /*
            max_index = StoreList.Count;

            // 接続インスタンスを作成。
            var dbc = new DB.DBConnect();

            //insert文の生成
            for (int i = 0; i < max_index; i++)            {
                // 登録する新規データの入れ物を作成(店舗マスターに対して実行する)。
                DB.m_store data = dbc.m_store.Create();
                //データの投入
                data.store_code = StoreList[i].store_code;
                data.company_name = StoreList[i].store_company;
                data.store_name = StoreList[i].store_name;
                data.postal_code = StoreList[i].store_postal_code;
                data.address1 = StoreList[i].store_pref_city_town_district_village;
                data.address2 = StoreList[i].store_address;
                data.address3 = StoreList[i].store_apart;
                data.phone_number = StoreList[i].store_phone_number;
                data.status = StoreList[i].store_status;
                data.start_time = StoreList[i].store_start_time;
                data.end_time = StoreList[i].store_end_time;
                data.regular_holiday = StoreList[i].store_regular_hoiday;
                data.store_category = StoreList[i].store_classification;
                data.registration_date = nowDay;
                data.registration_staff = MainForm.session_m_staff.staff_name;
                data.update_date = nowDay;
                data.update_staff = MainForm.session_m_staff.staff_name;
                data.delete_flag = "0";


                // レコードををテーブルに登録。
                dbc.m_store.Add(data);

                //INSERT文が問題ない場合は実行する
                try
                {
                    dbc.SaveChanges();
                }
                //エラーの場合はUPDATE文を生成し実行する
                catch (Exception)
                {
                    //データ確認用の店舗コードを取得する(現時点では店舗コード入力欄に店舗コードが入っているものを検索している)
                    //upStoreCode = this.t_tenpo_code.Text;

                    // 接続インスタンスを作成。
                    dbc = new DB.DBConnect();


                    // 絞り込んで取得。
                    var filterData = DB.m_store.getSingle(StoreList[i].store_code);

                    m_storeStoreCode = filterData.store_code;
                    m_storeStoreCompany = filterData.company_name;
                    m_storeStoreName = filterData.store_name;
                    m_storeStorePostalCode = filterData.postal_code;
                    m_storeStorePrefCityTownDistrictVillage = filterData.address1;
                    m_storeStoreAddress = filterData.address2;
                    m_storeStoreApart = filterData.address3;
                    m_storeStorePhoneNumber = filterData.phone_number;
                    m_storeStoreStatus = filterData.status;
                    m_storeStoreStartTime = filterData.start_time;
                    m_storeStoreEndTime = filterData.end_time;
                    m_storeStoreRegularHoliday = filterData.regular_holiday;
                    m_storeStoreClassification = filterData.store_category;


                    // 更新する新規データの入れ物を作成。
                    data = DB.m_store.getSingle(StoreList[i].store_code);

                    //データを比較しながらアップデート文を生成する
                    for (int j=0; j < max_index; j++)
                    {

                        //会社名が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStoreCompany != StoreList[j].store_company)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //企業名を変更
                            data.company_name = StoreList[j].store_company;
                        }

                        //店舗名が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStoreName != StoreList[j].store_name)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //店舗名を変更
                            data.store_name = StoreList[j].store_name;
                        }

                        //郵便番号が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStorePostalCode != StoreList[j].store_postal_code)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //郵便番号を変更
                            data.postal_code = StoreList[j].store_postal_code;
                        }

                        //県・市町区村が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStorePrefCityTownDistrictVillage != StoreList[j].store_pref_city_town_district_village)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //県・市区町村を変更
                            data.address1 = StoreList[j].store_pref_city_town_district_village;
                        }

                        //番地が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStoreAddress != StoreList[j].store_address)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //番地を変更
                            data.address2 = StoreList[j].store_address;
                        }

                        //アパート・マンションが変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStoreApart != StoreList[j].store_apart)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //アパート・マンションを変更
                            data.address3 = StoreList[j].store_apart;
                        }

                        //電話番号が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStorePhoneNumber != StoreList[j].store_phone_number)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //電話番号を変更
                            data.phone_number = StoreList[j].store_phone_number;
                        }

                        //ステータスが変わっていないかを確認。変わっていればデータベース更新
                        //開店中の場合
                        if (m_storeStoreStatus == StoreList[j].store_status)
                        {
                            data.status = StoreList[j].store_status;
                        }

                        //店舗開始時間が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStoreStartTime != StoreList[j].store_start_time)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //店舗開始時間を変更
                            data.start_time = StoreList[j].store_start_time;
                        }

                        //店舗終了時間が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStoreEndTime != StoreList[j].store_end_time)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //店舗終了時間を変更
                            data.end_time = StoreList[j].store_end_time;
                        }

                        //店舗休業日が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStoreRegularHoliday != StoreList[j].store_regular_hoiday)
                        {
                            //変更がかかっている場合はスキーマに設定した変数に直書き
                            //店舗休業日を変更
                            data.regular_holiday = StoreList[j].store_regular_hoiday;
                        }

                        //店舗区分が変わっていないかを確認。変わっていればデータベース更新
                        if (m_storeStoreClassification == StoreList[j].store_classification)
                        {
                            data.store_category = StoreList[i].store_classification;
                        }
                        
                        data.update_date = nowDay;
                        data.update_staff = MainForm.session_m_staff.staff_name;
                        data.delete_flag = "0";


                        // 更新内容を反映。
                        dbc.SaveChanges();
                    }
                }
            }
            */
            pageParent.PageRefresh();
            MainForm.backPage(this);

        }


        //戻るボタン
        private void b_return_Click(object sender, EventArgs e)
        {
            if (changeValue == false)
            {
                pageParent.PageRefresh();
                MainForm.backPage(this);
            }
            else
            {
                DialogResult result = MessageBox.Show("変更が保存されてません。\n" +
                    "処理を破棄して次の処理に進みますか？", "変更確認メッセージ",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    pageParent.PageRefresh();
                    MainForm.backPage(this);
                }
            }

        }

        //◀ボタン[クリック]処理
        private void b_decrease_Click(object sender, EventArgs e)
        {
            t_tenpo_code.Enabled = false;

            //変更途中か？チェック　TODO
            if(currentPage > 1)
            {
                if (changeValue == false)
                {
                    currentPage--;
                    Listshow();
                    Set_currentDisplay();
                }
                else
                {
                    DialogResult result = MessageBox.Show("変更が保存されてません。\n" +
                        "処理を破棄して次の処理に進みますか？", "変更確認メッセージ",
                            MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        currentPage--;
                        Listshow();
                        Set_currentDisplay();
 
                    }
                }
            }
        }

        //▶ボタン[クリック]処理
        private void b_increase_Click(object sender, EventArgs e)
        {
            //変更途中か？チェック　TODO
            if(totalPage > currentPage)
            {
                if (changeValue == false)
                {
                    //ページカウント
                    currentPage++;
                    Listshow();
                    Set_currentDisplay();

                }
                else
                {
                    DialogResult result = MessageBox.Show("変更が保存されてません。\n" +
                        "処理を破棄して次の処理に進みますか？", "変更確認メッセージ",
                            MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        //ページカウント
                        currentPage++;
                        Listshow();
                        Set_currentDisplay();
                    }
                }
            }
        }

        private void d_tenpo_code_TextChnged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void d_company_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void d_tenpo_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_postal_code_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_kensikuchouson_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_banchi_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_apart_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }
        
        private void t_telephon_no_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void d_status_SelectIndexChange(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_eigyou_start_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_eigyou_end_TextChaged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_regular_holiday_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void d_tenpo_kubun_SelectIndexChange(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_current_page_Leave(object sender, EventArgs e)
        {
            using (var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_store
                        where t.delete_flag == "0"
                        select t;
                totalPage = q.Count();
            }

            chk.clear();
            chk.addControl(t_current_page);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^\d{1,5}?\z", @"数値")
                || chk.check("W00000", chk.checkControlImportant))
            {
                return;
            }

            t_tenpo_code.Enabled = false;
            currentPage = int.Parse(t_current_page.Text);

            if (currentPage > 0 && currentPage <= totalPage)
            {
                if (changeValue == false)
                {
                    Listshow();
                }
                else
                {
                    DialogResult result = MessageBox.Show("変更が保存されてません。\n" +
                        "処理を破棄して次の処理に進みますか？", "変更確認メッセージ",
                            MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Listshow();
                    }
                }
            }
            else
            {
                Utile.Message.showMessageOK("I13002");
            }
        }
    }
}
