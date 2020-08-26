using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 写真館システム.DB;
using Npgsql;

namespace 写真館システム
{
    public partial class rental : Form
    {

        //店舗リスト
        public struct StoreArray
        {
            public string store_code;
            public string store_name;
        }

        //店舗リストの生成
        private List<StoreArray> storeList = new List<StoreArray>();

        public bool init_flag = false;

        public string rental_store_name = null;
        public string rental_store_code = null;

        public string[] costume_code;
        public string[] store_code;

        public rental()
        {
            InitializeComponent();

            if (init_flag == false)
            {
                //storeCodeListの初期化
                storeList.Clear();
                //dataReaderの初期化
                NpgsqlDataReader dataReader = null;
                //conectionの確立
                var dbc = new DB.DBConnect();
                //コネクションオープン
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select store_code, store_name ");
                sb.Append(@"from m_store ");
                sb.Append(@"where m_store.delete_flag = '0' order by m_store.store_code");
                //SQLの実行
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();
                //データからListの生成
                while (dataReader.Read())
                {

                    //storeCodeListの生成
                    storeList.Add(new StoreArray
                    {
                        store_code = dataReader["store_code"].ToString(),
                        store_name = dataReader["store_name"].ToString()
                    });

                }
                //コネクションクロース
                dbc.npg.Close();

                //店舗名の生成
                for (int i = 0; i < storeList.Count; i++)
                {
                    d_rental_store.Items.Add(storeList[i].store_name);
                }
                //初期化フラグを初期化済みにする
                init_flag = true;
                d_rental_store.SelectedIndex = 0;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            if(MainForm.Costume_timetable.costumeGridRentList.Count == 0)
            {
                Utile.Message.showMessageOK("I05001");
                return;
            }

            rental_store_name = d_rental_store.Text;
            rental_store_code = storeList[d_rental_store.SelectedIndex].store_code;
            List<string> costumeList = new List<string>();
            foreach (var costumeGridRent in MainForm.Costume_timetable.costumeGridRentList)
            {
                costumeList.Add(costumeGridRent.costume_code);
            }
            costume_code = costumeList.ToArray();

            List<string> store_list = new List<string>();
            foreach (var costumeGridRent in MainForm.Costume_timetable.costumeGridRentList)
            {
                store_list.Add(costumeGridRent.store_code);
            }
            store_code = store_list.ToArray();


 



                StringBuilder sb = new StringBuilder();
                rental_store_code = store_code[0];
                foreach (string costume in costume_code)
                {
                    // 接続インスタンスを作成。
                    var dbc = new DB.DBConnect();
                    dbc.npg.Open();
                    using (var transaction = dbc.npg.BeginTransaction())
                    {
                        sb.Clear();
                        sb.Append("update m_costume set ");
                        sb.Append("rental_store = '" + rental_store_name + "', ");
                        sb.Append(" status = '" + 2 +"'");
                        sb.Append(" where delete_flag = '" + 0 + "'");
                        sb.Append(" and store_code = '" + rental_store_code + "'");
                        sb.Append(" and costume_code = '" + costume + "'");

                        string strSQL = sb.ToString();
                        var command = new NpgsqlCommand(strSQL, dbc.npg);
                        try
                        {
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch(NpgsqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        finally
                        {
                            dbc.npg.Close();
                        }
                
                    }
                
            }
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
