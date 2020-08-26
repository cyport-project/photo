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
    public partial class Facility_master : UserControlExp
    {
        //  現在ページ
        private int currentPage;
        //  総ページ
        private int totalPage;
        //  変更フラグ
        private Boolean changeValue;
        //存在チェッククラス
        private checkOperation chkExist;
        private checkOperation chk;
        //桁数チェッククラス
        private checkOperation chk8Digit;
        private checkOperation chk20Digit;

        //施設クラスリスト
        private List<DB.m_facility> facilities = new List<DB.m_facility>();

        //構造体の生成
       public struct storeCodeArray
        {
            public string store_code;
            public string store_name;
        }
        //店舗リスト生成
        List<storeCodeArray> storeCodeList = new List<storeCodeArray>();

        //データ有無判定
        bool data_flag;

        public Facility_master()
        {
            InitializeComponent();

            //存在チェック項目の追加
            chkExist = new checkOperation(this);
            chkExist.addControl(d_tenpo);
            chkExist.addControl(t_facility);
            chkExist.addControl(t_facility_code);
            chk = new checkOperation(this);

            //桁数チェック
            chk8Digit = new checkOperation(this);
            chk8Digit.addControl(t_facility_code);

            chk20Digit = new checkOperation(this);
            chk20Digit.addControl(t_facility);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            currentPage = 1;
            totalPage = 1;
            d_tenpo.Items.Clear();
            t_facility_code.Text = null;
            t_facility.Text = null;
        }


        private void Set_initialDisplay()
        {
            //セッション情報取得(自店舗)
            var own_storecode= MainForm.session_m_staff.store_code;
            var own_storename = storeCodeList.Find(x => x.store_code == own_storecode).store_name;

            //初期表示設定
            d_tenpo.Items.Clear();
            for(int i=0; i < storeCodeList.Count ; i++ )
            {
                d_tenpo.Items.Add(storeCodeList[i].store_name);
            }

            //自店舗表示
            var index = d_tenpo.FindStringExact(own_storename);
            d_tenpo.SelectedIndex = index;
            d_tenpo.Enabled = true;

            t_facility_code.Text = null;
            t_facility_code.Enabled = true;

            t_facility.Text = null;

            t_current_page.Text = currentPage.ToString();
            t_total_page.Text = totalPage.ToString();

            // 変更フラグクリア
            changeValue = false;

            //エラー表示の初期化
            chkExist.clear();
            chk.clear();
            chk8Digit.clear();
            chk20Digit.clear();
        }
        private void set_currentDisplay()
        {
            //現在ページ設定
            t_current_page.Text = currentPage.ToString();
            t_total_page.Text = totalPage.ToString();

            d_tenpo.Items.Clear();
            d_tenpo.Items.Add(storeCodeList.Find(x=> x.store_code == facilities[currentPage - 1].store_code).store_name);
            d_tenpo.SelectedIndex = 0;
            d_tenpo.Enabled = false;

            t_facility_code.Text = facilities[currentPage-1].facility_code;
            t_facility_code.Enabled = false;

            t_facility .Text = facilities[currentPage-1].facility_name;

            // 変更フラグクリア
            changeValue = false;

            //エラー表示の初期化
            chkExist.clear();
            chk.clear();
            chk8Digit.clear();
            chk20Digit.clear();
        }

        public override void PageRefresh()
        {
            //店舗データ読み込み
            var m_storeList = DB.m_store.getStoreList();
            storeCodeList.Clear();
            foreach(var m_store in m_storeList)
            {
                storeCodeList.Add(new storeCodeArray
                {
                    store_code = m_store["store_code"].ToString(),
                    store_name = m_store["store_name"].ToString()
                });
            }

            //施設情報検索
            ListArrayFacility();
            
            //データが存在する            
            if (data_flag)
            {
                currentPage = 1;
                set_currentDisplay();
            }
            else
            {
                //データが存在しない場合
                currentPage = 1;
                totalPage = 1;
                Set_initialDisplay();
            }
        }

        public void ListArrayFacility()
        {
            facilities.Clear();
            facilities = DB.m_facility.getFacilityAllList();
 
            if (facilities.Count > 0)
            {
                data_flag = true;
                totalPage = facilities.Count();
            }
            else
            {
                //データが存在しない場合
                data_flag = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void d_tenpo_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_facility_code_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
        }

        private void t_facility_TextChanged(object sender, EventArgs e)
        {
            changeValue = true;
            
        }

        private void b_new_regist_Click(object sender, EventArgs e)
        {
            using(var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_facility
                        where t.delete_flag == "0"
                        select t;
                totalPage = q.Count();
            }
            if (changeValue == false)
            {
                totalPage++;
                currentPage = totalPage;
                Set_initialDisplay();
            }
            else
            {
                DialogResult result = MessageBox.Show("変更が保存されていません\n" +
                    "変更を破棄して次の処理へ進みますか", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    totalPage++;
                    currentPage = totalPage;
                    Set_initialDisplay();
                }
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
           
            //削除
            
            using (var db = new DB.DBConnect())
            {

                //キーの設定
                string store_code = storeCodeList.Find(x=>x.store_name == d_tenpo.Text).store_code;
                string facility_code = t_facility_code.Text;
                /*複合キーの場合には、正しく動かない。
                var facility = db.m_facility.Single(x => x.facility_code == facility_code && x.store_code == store_code);

                if (facility != null)
                {
                    //更新者・更新日・削除フラグの変更
                    facility.update_date = DateTime.Now.Date;
                    facility.update_staff = MainForm.session_m_staff.staff_name;
                    facility.delete_flag = "1";

                    db.SaveChanges();
                } 
                */
                
                using (var dbc = new DB.DBConnect())
                {
                    dbc.npg.Open();
                    using (var transaction = dbc.npg.BeginTransaction())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(@"update m_facility ");
                        sb.Append(@"set  update_date = " + "'" + DateTime.Now.Date + "' , " +
                                     "update_staff =" + "'" + MainForm.session_m_staff.staff_name + "' , " +
                                     "delete_flag = '1'"
                                     );
                        sb.Append(@" where store_code = " + "'" + store_code + "' and " +
                                      "facility_code =" + "'" + facility_code + "'");

                        var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                        try
                        {
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (NpgsqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            

            //削除後、ひとつ前の画面に戻る
            MainForm.Facility_master.PageRefresh();
            MainForm.backPage(this);
        }

        private void b_regist_Click(object sender, EventArgs e)
        {
            //必須入力チェック
            chkExist.addControl(d_tenpo);
            chkExist.addControl(t_facility);
            chkExist.addControl(t_facility_code);
            if (chkExist.check("W00000", chkExist.checkControlImportant))
                return;

            //8桁数チェック
            chk8Digit.addControl(t_facility_code);
            if (chk8Digit.check("W00001", chk8Digit.checkTextboxLength, 8))
                return;

            //20桁チェック
            chk20Digit.addControl(t_facility);
            if (chk20Digit.check("W00001", chk20Digit.checkTextboxLength, 20))
                return;

            //キーの設定
            string store_code = storeCodeList.Find(x => x.store_name == d_tenpo.Text).store_code;
            string facility_code = t_facility_code.Text;

            //登録処理
            bool toroku = false;
            for(var i=0; i < facilities.Count; i++)
            {
                if(facilities[i].store_code == store_code &&
                    facilities[i].facility_code == facility_code)
                {
                    toroku = true;
                    break;
                }                
            }

            if (!toroku)
            {
                //登録処理
                using (var dbc = new DB.DBConnect())
                {
                    dbc.npg.Open();
                    using (var transaction = dbc.npg.BeginTransaction())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(@"insert into m_facility values");
                        sb.Append(@"(" + 
                            "'" + store_code + "'," +
                            "'" + facility_code + "'," +
                            "'" + t_facility.Text + "'," +
                            "'" + DateTime.Now.Date + "'," +
                            "'" + MainForm.session_m_staff.staff_name + "')"
                            );
                        
                        var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                        try
                        {
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (NpgsqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            else
            {
                //更新処理
                using (var dbc = new DB.DBConnect())
                {
                    dbc.npg.Open();
                    using (var transaction = dbc.npg.BeginTransaction())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(@"update m_facility set ");
                        sb.Append(@"" +
                            "store_code = '" + store_code + "'," +
                            "facility_code = '" + facility_code + "'," +
                            "facility_name = '" + t_facility.Text + "'," +
                            "update_date = '" + DateTime.Now.Date + "'," +
                            "update_staff = '" + MainForm.session_m_staff.staff_name + "'"
                            );
                        sb.Append(@" where store_code = " + "'" + store_code + "' and " +
                                      "facility_code =" + "'" + facility_code + "'");

                        var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                        try
                        {
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (NpgsqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }

            //登録後、ひとつ前の画面に戻る
            MainForm.Facility_master.PageRefresh();
            MainForm.backPage(this);
        }

        private void b_return_Click(object sender, EventArgs e)
        {
            if (changeValue == false)
            {
                MainForm.Facility_master.PageRefresh();
                MainForm.backPage(this);

            }
            else
            {
                DialogResult result = MessageBox.Show("変更が保存されていません\n" +
                    "変更を破棄して次の処理へ進みますか", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MainForm.Facility_master.PageRefresh();
                    MainForm.backPage(this);
                }
            }            
        }

        private void b_decrease_Click(object sender, EventArgs e)
        {
            using(var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_facility
                        where t.delete_flag == "0"
                        select t;
                totalPage = q.Count();
            }

            if(currentPage > 1)
            {
                if (changeValue == false)
                {
                    currentPage--;
                    set_currentDisplay();
                }
                else
                {
                    DialogResult result = MessageBox.Show("変更が保存されていません\n" +
                        "変更を破棄して次の処理へ進みますか", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        currentPage--;
                        set_currentDisplay();
                    }                    
                }
            }
        }

        private void b_increase_Click(object sender, EventArgs e)
        {
            if(currentPage < totalPage)
            {
                if (changeValue == false)
                {
                    currentPage++;
                    set_currentDisplay();
                }
                else
                {
                    DialogResult result = MessageBox.Show("変更が保存されていません\n" +
                        "変更を破棄して次の処理へ進みますか", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        currentPage++;
                        set_currentDisplay();
                    }
                }
            }
        }

        private void t_current_page_TextChanged(object sender, EventArgs e)
        {

        }
        private void t_current_page_Leave(object sender, EventArgs e)
        {
            using (var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_facility
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
            t_facility_code.Enabled = false;
            currentPage = int.Parse(t_current_page.Text);

            if (currentPage > 0 && currentPage <= totalPage)
            {
                if (changeValue == false)
                {
                    set_currentDisplay();
                }
                else
                {
                    DialogResult result = MessageBox.Show("変更が保存されてません。\n" +
                        "処理を破棄して次の処理に進みますか？", "変更確認メッセージ",
                            MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        set_currentDisplay();
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
