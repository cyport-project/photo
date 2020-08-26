using Npgsql;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using 写真館システム.DB;

namespace 写真館システム
{
    public partial class Staff_master : UserControlExp
    {
        //変更フラグ
        private Boolean changeValue;
        //現在ページ
        private int currentPage;
        //総ページ
        private int totalPage;
        //入力チェック初期化
        private checkOperation chk;

        //接続する為のインスタンスを生成
        NpgsqlConnection conn = new NpgsqlConnection();


        //構造体の生成
        public struct StaffArray
        {
            public string tenpo;
            public string staff_store_code;
            public string staff_code;
            public string staff_name;
            public string staff_name_kana;
            public string login_id;
            public string password;
            public string hash_password;
            public string kengen;
            public string employment;
            public string status;
            public string seibetu;
            public string staff_index;
        }

        //リスト型の生成
        private List<StaffArray> StaffList = new List<StaffArray>();

        //構造体の生成(データ移動用)
        public struct StaffDBArray
        {
            public string tenpo;
            public string staff_store_code;
            public string staff_code;
            public string staff_name;
            public string staff_name_kana;
            public string login_id;
            public string password;
            public string hash_password;
            public string kengen;
            public string employment;
            public string status;
            public string seibetu;
            public DateTime registration_date;
            public string registration_staff;
            public DateTime update_date;
            public string update_staff;
            public string delete_flag;
        }

        //リスト型の生成（データ移動用）
        private List<StaffDBArray> StaffDBList = new List<StaffDBArray>();

        //構造体の生成（店舗）
        public struct storeCodeArray
        {
            public string store_code;
            public string store_name;
        }
        //店舗リストの生成
        private List<storeCodeArray> storeCodeList = new List<storeCodeArray>();

        //テキストデータの取り出し
        public string staff_tenpo = null;
        public string staff_store_code = null;
        public string staff_code = null;
        public string staff_name = null;
        public string staff_name_kana = null;
        public string staff_login_id = null;
        public string staff_password = null;
        public string staff_Hash_password = null;
        public string staff_kengen = null;
        public string staff_employment = null;
        public string staff_seibetu = null;
        public string staff_status = null;
        public DateTime staff_registration_date;
        public string staff_registration_staff = null;
        public DateTime staff_update_date;
        public string staff_update_staff = null;
        public string staff_delete_flag = "0";

        //selectデータ用変数
        public string m_StaffStaff_store_code = null;
        public string m_StaffStaff_code = null;
        public string m_StaffStaff_name = null;
        public string m_StaffStaff_name_kana = null;
        public string m_StaffStaff_login_id = null;
        public string m_StaffStaff_password = null;
        public string m_StaffStaff_Hash_passwprd = null;
        public string m_StaffStaff_kengen = null;
        public string m_StaffStaff_employment = null;
        public string m_StaffStaff_seibetu = null;
        public string m_StaffStaff_status = null;
        public DateTime m_StaffStaff_registration_date;
        public string m_StaffStaff_registration_staff = null;
        public DateTime m_StaffStaff_update_date;
        public string m_StaffStaff_update_staff = null;
        public string m_StaffStaff_delete_flag = "0";

        //日付取得用変数
        DateTime nowToday =  DateTime.Now.Date;

        //データ遷移用カウンター
        public int index = 0;
        public int max_index = 0;

        //削除フラグ対象コード
        public string deleteStaffCode = null;
        public string deleteStoreCode = null;
        //更新用対象コード
        public string updateStaffCode = null;
        public string updateStoreCode = null;

        //店舗名セレクトボックス生成用カウンタ
        public int storeIndex = 0;

        //初期化フラグ
        public bool init_flag = false;

        //d_tenpo用インデックス変数
        public int storeNameIndex = 0;

        //データ存在確認フラグ
        public bool data_flag = false;
        public bool update_flag = false;
        public bool newData_flag = false;

        public Staff_master()
        {
            InitializeComponent();

            //入力チェック初期化
            chk = new checkOperation(this);
            chk.addControl(d_tenpo);
            chk.addControl(t_staff_code);
            chk.addControl(t_staff);
            chk.addControl(t_staff_kana);
            chk.addControl(t_login_id);
            chk.addControl(t_password);
            chk.addControl(d_kengen);
            chk.addControl(d_employment);
            chk.addControl(d_seibetsu);
            chk.addControl(d_status);


        }

        public override void PageRefresh()
        {
            d_tenpo.Enabled = false;
            t_staff_code.Enabled = false;

            ListArrayStaff();
            if(data_flag == false)
            {
                //データが存在しない場合
                currentPage = 1;
                totalPage = 1;
                Set_initialDisplay();

            }else if(data_flag == true)
            {
                //データが存在する場合
                Set_initialDisplay();
                currentPage = 1;
                Listshow();
                Set_currentDisplay();

            }


        }

        //ハッシュ化プログラム
        public static string GetHashString<T>(string text) where T : HashAlgorithm, new()
        {
            // 文字列をバイト型配列に変換する
            byte[] data = Encoding.UTF8.GetBytes(text);

            // ハッシュアルゴリズム生成
            T algorithm = new T();

            // ハッシュ値を計算する
            byte[] bs = algorithm.ComputeHash(data);

            // リソースを解放する
            algorithm.Clear();

            // バイト型配列を16進数文字列に変換
            StringBuilder result = new StringBuilder();
            foreach (byte b in bs)
            {
                result.Append(b.ToString("x2"));
            }
            return result.ToString();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            ListArrayStaff();

            if(data_flag == false)
            {
                //データが存在しない場合
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

        //初期表示の設定
        private void Set_initialDisplay()
        {
            if(init_flag == false)
            {
                //storeCodeListの初期化
                storeCodeList.Clear();
                NpgsqlDataReader dataReader = null;
                var dbc = new DB.DBConnect();
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select store_code, store_name ");
                sb.Append(@"from m_store ");
                sb.Append(@"where m_store.delete_flag = '0' order by m_store.store_code");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    //storeCodeListの生成
                    storeCodeList.Add(new storeCodeArray
                    {
                        store_code = dataReader["store_code"].ToString(),
                        store_name = dataReader["store_name"].ToString()
                    });

                }

                dbc.npg.Close();

                //店舗名の生成
                d_tenpo.Items.Clear();
                for (int i = 0; i < storeCodeList.Count; i++)
                {
                    d_tenpo.Items.Add(storeCodeList[i].store_name);
                }
                //初期化フラグを初期化済みにする
                //init_flag = true;
            }
            d_tenpo.SelectedIndex = 0;

            t_staff_code.Text = null;

            t_current_page.Text = (string)currentPage.ToString("0");
            t_total_page.Text = (string)totalPage.ToString("0");

            t_staff.Text = null;
            t_staff_kana.Text = null;
            t_login_id.Text = null;
            t_password.Text = null;
            d_kengen.DataSource = Enum.GetValues(typeof(Utile.Data.権限区分));
            d_kengen.SelectedIndex = 0;
            d_employment.DataSource = Enum.GetValues(typeof(Utile.Data.社員区分));
            d_employment.SelectedIndex = 0;
            d_status.DataSource = Enum.GetValues(typeof(Utile.Data.スタッフステータス));
            d_status.SelectedIndex = 0;
            d_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_seibetsu.SelectedIndex = 0;

            //変更フラグの初期化
            changeValue = false;

            //新規データフラグを初期化
            if(data_flag == true)
            {
                newData_flag = false;
            }

            //エラー表示の初期化
            chk.clear();

        }



        //list登録（画面遷移用）
        public void ListArrayStaff()
        {
            //データ取得領域のクリア
            StaffDBList.Clear();;
            //データ取得
            StaffDBList = DB.m_staff.GetAllTable();
            totalPage = StaffDBList.Count;
            if(totalPage == 0)
            {
                data_flag = false;
                update_flag = false;
                newData_flag = true;
            }
            else
            {
                data_flag = true;
            }
        }

        //リストにデータを登録する
        public void StaffListStore()
        {           
            //selectedIndexの取得
            storeNameIndex = this.d_tenpo.SelectedIndex;
            //データ取得
            staff_tenpo = this.d_tenpo.Text;
            staff_store_code = storeCodeList[storeNameIndex].store_code;
            staff_code = this.t_staff_code.Text;
            staff_name = this.t_staff.Text;
            staff_name_kana = this.t_staff_kana.Text;
            staff_login_id = this.t_login_id.Text;
            staff_password = this.t_password.Text;
            staff_Hash_password = GetHashString<SHA256CryptoServiceProvider>(this.t_password.Text);
            staff_kengen = this.d_kengen.SelectedIndex.ToString();
            staff_employment = this.d_employment.SelectedIndex.ToString();
            staff_status = this.d_status.SelectedIndex.ToString();
            staff_seibetu = this.d_seibetsu.SelectedIndex.ToString();
            staff_registration_date = DateTime.Now.Date;
            staff_registration_staff = MainForm.session_m_staff.staff_name;
            staff_update_date = DateTime.Now.Date;
            staff_update_staff = MainForm.session_m_staff.staff_name;
            staff_delete_flag = "0";
        }

        //リスト表示
        //list表示
        public void Listshow()
        {
            //カレントページからListデータを取得する
            if (currentPage >= 1 && StaffDBList.Count > currentPage - 1)
            {
                index = currentPage - 1;
                var staffData = StaffDBList[index];
                for(int i = 0; i < storeCodeList.Count; i++)
                {
                    if(staffData.staff_store_code == storeCodeList[i].store_code)
                    {
                        staffData.tenpo = storeCodeList[i].store_name;
                    }
                }
                this.d_tenpo.Text = staffData.tenpo;
                this.t_staff_code.Text = staffData.staff_code;
                this.t_staff.Text = staffData.staff_name;
                this.t_staff_kana.Text = staffData.staff_name_kana;
                this.t_login_id.Text = staffData.login_id;
                this.t_password.Text = null;
                this.d_kengen.SelectedIndex = int.Parse(staffData.kengen);
                this.d_employment.SelectedIndex = int.Parse(staffData.employment);
                this.d_status.SelectedIndex = int.Parse(staffData.status);
                this.d_seibetsu.SelectedIndex = int.Parse(staffData.seibetu);
            }
            else
            {
                d_tenpo.SelectedIndex = 0;
                t_staff_code.Text = null;
                t_staff.Text = null;
                t_staff_kana.Text = null;
                t_login_id.Text = null;
                t_password.Text = null;
                d_kengen.DataSource = Enum.GetValues(typeof(Utile.Data.権限区分));
                d_kengen.SelectedIndex = 0;
                d_employment.DataSource = Enum.GetValues(typeof(Utile.Data.社員区分));
                d_employment.SelectedIndex = 0;
                d_status.DataSource = Enum.GetValues(typeof(Utile.Data.スタッフステータス));
                d_status.SelectedIndex = 0;
                d_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
                d_seibetsu.SelectedIndex = 0;

            }
        }

        //現在ページ表示の設定
        private void Set_currentDisplay()
        {
            t_current_page.Text = (string)currentPage.ToString("0");
            t_total_page.Text = (string)totalPage.ToString("0");

            //変更フラグの初期化
            changeValue = false;

            //エラー表示の初期化
            chk.clear();
        }


        private void t_staff_code_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        private void t_staff_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        private void t_staff_kana_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        private void t_login_id_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        private void t_password_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        private void d_kengen_SelectIndexChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        private void d_tenpo_SelectIndexChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        private void d_employment_SelectIndexChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        private void d_status_SelectIndexChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        private void d_seibetsu_SelectIndexChanged(object sender, EventArgs e)
        {
            changeValue = true;
            if (data_flag == true && currentPage <= totalPage && newData_flag == false)
            {
                update_flag = true;
            }
            else if (data_flag == true && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
            else if (data_flag == false && currentPage == totalPage && newData_flag == true)
            {
                update_flag = false;
            }
        }

        //新規登録
        private void b_new_regist_Click(object sender, EventArgs e)
        {
            d_tenpo.Enabled = true;
            t_staff_code.Enabled = true;
 
            //初期化
            if (changeValue == false)
            {
                if(data_flag == false)
                {
                    currentPage++;
                    totalPage++;
                    Set_initialDisplay();
                    newData_flag = true;
                }else if(data_flag == true)
                {
                    currentPage = StaffDBList.Count + 1;
                    totalPage = StaffDBList.Count + 1;
                    Set_initialDisplay();
                    newData_flag = true;
                }

            }
            else
            {
                DialogResult result = MessageBox.Show("変更が保存されていません。\n" +
                    "変更を破棄して次の処理へ進みますか？", "",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if(data_flag == false)
                    {
                        currentPage++;
                        totalPage++;
                        Set_initialDisplay();
                        newData_flag = true;
                    }
                    else if(data_flag == true)
                    {
                        currentPage = StaffDBList.Count + 1;
                        totalPage = StaffDBList.Count + 1;
                        Set_initialDisplay();
                        newData_flag = true;
                    }
                }
            }
        }

        //削除
        private void b_delete_Click(object sender, EventArgs e)
        {
            //削除フラグ対象のスタッフコードを取得する
            deleteStaffCode = this.t_staff_code.Text;
            storeIndex = this.d_tenpo.SelectedIndex;
            deleteStoreCode = storeCodeList[storeIndex].store_code;

            m_staff m_staff = DB.m_staff.getSingle2(deleteStoreCode,deleteStaffCode);
            m_staff.Command(true);

            //削除後、データの再取得し削除データの後データを読み込む
            MainForm.Staff_master.PageRefresh();
            ListArrayStaff();
            if (totalPage <= 0)
            {
                currentPage = 1;
                t_current_page.Text = "1";
                totalPage = 1;
                Set_initialDisplay();
            }
            else if(totalPage > 0)
            {
                totalPage = StaffDBList.Count;
                Listshow();
                Set_currentDisplay();
            }

            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        //登録
        private void b_regist_Click(object sender, EventArgs e)
        {

            //入力チェック
            chk.clear();
            chk.addControl(d_tenpo);
            chk.addControl(t_staff_code);
            chk.addControl(t_staff);
            chk.addControl(t_staff_kana);
            chk.addControl(t_login_id);
            chk.addControl(t_password);
            chk.addControl(d_kengen);
            chk.addControl(d_employment);
            chk.addControl(d_seibetsu);
            chk.addControl(d_status);
            if (chk.check("W00000", chk.checkControlImportant))
                return;

            //桁数チェック
            chk.clear();
            chk.addControl(t_staff_code);
            if (chk.check("W00001", chk.checkTextboxLength, 8))
                return;

            chk.clear();
            chk.addControl(t_login_id);
            chk.addControl(t_staff);
            if (chk.check("W00001", chk.checkTextboxLength, 20))
                return;

            chk.clear();
            chk.addControl(t_staff_kana);
            if (chk.check("W00001", chk.checkTextboxLength, 40))
                return;

            chk.clear();
            chk.addControl(t_password);
            if (chk.check("W00001", chk.checkTextboxLength, 256))
                return;

            //データベース更新処理
            //データの取得
            StaffListStore();

            if (update_flag == false || newData_flag == true)
            {
                //1店舗にスタッフは、25名まで
                if(DB.m_staff.getStaffNameList(staff_store_code).Count >= 25)
                {
                    Utile.Message.showMessageOK("E14002");
                    return;
                }
                // 接続インスタンスを作成。
                var dbc = new DB.DBConnect();


                // 登録する新規データの入れ物を作成(スタッフマスターに対して実行する)。
                DB.m_staff data = dbc.m_staff.Create();
                //データの投入
                data.store_code = staff_store_code;
                data.staff_code = staff_code;
                data.staff_name = staff_name;
                data.staff_name_kana = staff_name_kana;
                data.login_id = staff_login_id;
                data.password = staff_Hash_password;
                data.permission_class = staff_kengen;
                data.work_class = staff_employment;
                data.status = staff_status;
                data.sex = staff_seibetu;


                data.registration_date = staff_registration_date;
                data.registration_staff = staff_registration_staff;
                data.update_date = staff_update_date;
                data.update_staff = staff_update_staff;
                data.delete_flag = staff_delete_flag;


                // レコードををテーブルに登録。
                dbc.m_staff.Add(data);

                try
                {
                    dbc.SaveChanges();
                }
                catch (Exception)
                {
                    Utile.Message.showMessageOK("E14000");
                    return;
                }
                finally
                {
                    dbc.npg.Close();
                }
            }
            else if (update_flag == true || newData_flag == false)
            {
                // 接続インスタンスを作成。
                var dbc2 = new DB.DBConnect();
                //更新用スタッフコードの取得
                index = currentPage - 1;
                updateStaffCode = StaffDBList[index].staff_code;
                //更新前データの取り込み
                var filterData = StaffDBList[index];
                storeIndex = this.d_tenpo.SelectedIndex;


                //更新前データの取り込み
                m_StaffStaff_store_code = filterData.staff_store_code;
                m_StaffStaff_code = filterData.staff_code;
                m_StaffStaff_name = filterData.staff_name;
                m_StaffStaff_name_kana = filterData.staff_name_kana;
                m_StaffStaff_login_id = filterData.login_id;
                m_StaffStaff_password = filterData.password;
                m_StaffStaff_kengen = filterData.kengen;
                m_StaffStaff_status = filterData.status;
                m_StaffStaff_employment = filterData.employment;
                m_StaffStaff_seibetu = filterData.seibetu;
                m_StaffStaff_registration_date = filterData.registration_date;
                m_StaffStaff_registration_staff = filterData.registration_staff;
                m_StaffStaff_update_date = filterData.update_date;
                m_StaffStaff_update_staff = filterData.update_staff;
                m_StaffStaff_delete_flag = filterData.delete_flag;

                //更新用スタッフコードの取得
                index = currentPage - 1;
                updateStaffCode = StaffDBList[index].staff_code;
                storeIndex = this.d_tenpo.SelectedIndex;
                updateStoreCode = storeCodeList[storeIndex].store_code;
                // 接続インスタンスを作成。
                var dbc = new DB.DBConnect();
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                using (var transaction = dbc.npg.BeginTransaction())
                {
                    sb.Append("update m_staff set ");
                    if (staff_store_code != m_StaffStaff_store_code)
                    {
                        sb.Append("store_code = '" + staff_store_code +"', ");
                    }
                    if (staff_code != m_StaffStaff_code)
                    {
                        sb.Append("staff_code = '" + staff_code + "', ");
                    }
                    if (staff_name != m_StaffStaff_name)
                    {
                        sb.Append("staff_name = '" + staff_name + "', ");
                    }
                    if (staff_name_kana != m_StaffStaff_name_kana)
                    {
                        sb.Append("staff_name_kana = '" + staff_name_kana + "', ");
                    }
                    if (staff_login_id != m_StaffStaff_login_id)
                    {
                        sb.Append("login_id = '" + staff_login_id + "', "); 
                    }
                    if (staff_Hash_password != m_StaffStaff_password)
                    {
                        sb.Append("password = '" +staff_Hash_password + "', ");
                    }
                    if (staff_kengen != m_StaffStaff_kengen)
                    {
                        sb.Append("permission_class = '" + staff_kengen + "', ");
                    }
                    if (staff_employment != m_StaffStaff_employment)
                    {
                        sb.Append("work_class = '" + staff_employment + "', ");
                    }
                    if (staff_status  != m_StaffStaff_status) 
                    {
                        sb.Append("status = '" + staff_status + "', ");
                    }
                    if (staff_seibetu != m_StaffStaff_seibetu)
                    {
                        sb.Append("sex = '" + staff_seibetu + "', ");
                    }
                    sb.Append("update_date = '" + nowToday + "', ");
                    sb.Append("update_staff = '" + MainForm.session_m_staff.staff_name + "', ");
                    sb.Append("delete_flag = '" + staff_delete_flag + "' ");
                    sb.Append("where store_code = '" + staff_store_code + "' AND ");
                    sb.Append("staff_code = '" + staff_code + "';");

                    string strsql = sb.ToString();

                    var command = new NpgsqlCommand(strsql, dbc.npg);
                    try
                    {
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (NpgsqlException)
                    {
                        transaction.Rollback();
                        Utile.Message.showMessageOK("E14001");
                        return;
                    }
                    finally
                    {
                        dbc.npg.Close();
                    }
                }

            }

            //登録後画面初期化し次の登録を始める
            MainForm.Staff_master.PageRefresh();
            //MainForm.backPage(this);
            if(data_flag == false && update_flag == false)
            {
                currentPage++;
                totalPage++;
            }
            else if(data_flag == true && update_flag == false)
            {
                currentPage = StaffDBList.Count + 1;
                totalPage = StaffDBList.Count + 1;
            }else if(data_flag == true && update_flag == true)
            {
                currentPage = StaffDBList.Count;
                totalPage = StaffDBList.Count;
            }
            //新規データフラグを立てる
            newData_flag = true;
            //データ取得
            ListArrayStaff();
            init_flag = false;
            update_flag = false;
            Set_initialDisplay();
            t_current_page.Text = (string)currentPage.ToString("0");
            t_total_page.Text = (string)totalPage.ToString("0");

            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        //戻る
        private void b_return_Click(object sender, EventArgs e)
        {
            if (changeValue == false)
            {
                //ひとつ前の画面に戻る
                pageParent.PageRefresh();
                MainForm.backPage(this);

            }
            else
            {
                DialogResult result = MessageBox.Show("変更が保存されていません。\n" +
                    "変更を破棄して次の処理へ進みますか？", "",
                    MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    //ひとつ前の画面に戻る
                    pageParent.PageRefresh();
                    MainForm.backPage(this);
                }
            }

        }

        //◀ボタン[クリック]処理
        private void b_decrease_Click(object sender, EventArgs e)
        {
            d_tenpo.Enabled = false;
            t_staff_code.Enabled = false;

            using(var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_staff
                        where t.delete_flag == "0"
                        select t;
                totalPage = q.Count();
            }
            //初期化
            if (currentPage > 1)
            {
                if (changeValue == false)
                {
                    currentPage--;
                    Listshow();
                    Set_currentDisplay();
                    
                }
                else
                {
                    DialogResult result = MessageBox.Show("変更が保存されていません。\n" +
                        "変更を破棄して次の処理へ進みますか？", "",
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
            //初期化
            if(currentPage < totalPage)
            {
                if (changeValue == false)
                {
                    currentPage++;
                    Listshow();
                    Set_currentDisplay();
                }
                else
                {
                    DialogResult result = MessageBox.Show("変更が保存されていません。\n" +
                        "変更を破棄して次の処理へ進みますか？", "",
                        MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        currentPage++;
                        Listshow();
                        Set_currentDisplay();
                    }
                }
            }
        }

        private void b_decrease_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void t_current_page_Leave(object sender, EventArgs e)
        {
            using (var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_staff
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

            d_tenpo.Enabled = false;
            t_staff_code.Enabled = false;
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
                Utile.Message.showMessageOK("I14001");
            }
        }
    }
}
