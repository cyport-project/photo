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
    public partial class Reception_search : UserControlExp

    {
        //日付データの格納変数
        static DateTime? t_start_time_from;　//datepickerでは、nullが使えないので変数を用意
        static DateTime? t_start_time_to;　　//datepickerでは、nullが使えないので変数を用意　

        //SQLWHERE格納用変数
        public String strSQLWHERE = "";

        //受付テーブルのリスト
        List<DB.t_reception> receptions; 

        public Reception_search()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public override void PageRefresh()
        {
            //日付の検索条件クリア
            t_start_time_from = null;
            t_start_time_to = null;
            Set_d_start_time_from(t_start_time_from);
            Set_d_start_time_to(t_start_time_from);

            //名前の検索条件クリア
            t_customer.Text = null;

            // DataGridView初期化（データクリア）
            dataGridView1.Rows.Clear();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void User_Control1_Load(object sender, EventArgs e)
        {
            //日付の検索条件クリア
            t_start_time_from = null;
            t_start_time_to = null;
            Set_d_start_time_from(t_start_time_from);
            Set_d_start_time_to(t_start_time_from);

            //名前の検索条件クリア
            t_customer.Text = null;

            // DataGridView初期化（データクリア）
            dataGridView1.Rows.Clear();

        }

        //印刷ボタンが押されて場合に、やりとり履歴一覧出力をCALLする。
        private void b_print_Click(object sender, EventArgs e)
        {
            //TODO 印刷用DBを更新
            //受付情報を帳票DBへ登録
            
            string table = "Exchange_history";
            Utile.RepoerDB rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();

            DB.t_reception reception;
            DateTime.TryParse(t_start_time_from.ToString() , out DateTime start_date);
            DateTime.TryParse(t_start_time_to.ToString(),out DateTime end_date);
            String title = "";
            if (t_start_time_to == null && t_start_time_from != null)
            {
                title = start_date.ToString("yyyy年MM月dd日") + "からの対応履歴";

            }else if (t_start_time_to != null && t_start_time_from == null) {
                title = end_date.ToString("yyyy年MM月dd日") + "までの対応履歴";

            }
            else if(t_start_time_from == null && t_start_time_to == null)
            {
                title = "                              対応履歴";
            }
            else
            {
                title = start_date.ToString("yyyy年MM月dd日") + "～" +
                    end_date.ToString("yyyy年MM月dd日") + "間の対応履歴";

            }


            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (!(bool)dataGridView1.Rows[i].Cells[0].Value)
                {
                    Dictionary<string, string> dataitem = new Dictionary<string, string>();
                    reception = DB.t_reception.getSingle(dataGridView1.Rows[i].Cells[1].Value.ToString());

                    dataitem.Add("reportTiTLE", title);
                    dataitem.Add("receiptDate", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    dataitem.Add("receiptTime", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    dataitem.Add("receiptStore", dataGridView1.Rows[i].Cells[4].Value.ToString());
                    dataitem.Add("receiptStaff", dataGridView1.Rows[i].Cells[5].Value.ToString());
                    dataitem.Add("receiptCustomername", dataGridView1.Rows[i].Cells[6].Value.ToString());
                    dataitem.Add("receiptStatus", dataGridView1.Rows[i].Cells[7].Value.ToString());
                    dataitem.Add("receiptMemo", dataGridView1.Rows[i].Cells[8].Value.ToString());
                    dataitem.Add("receiptClaim", reception.claim);

                    rdb.insert(dataitem);
                }
                
            }
            

            //印刷処理
            PrintForm p = new PrintForm();
            p.PrintReport.Load(@"./Asset/Format/Exchange_history.flxr", "対応履歴一覧表 レポート");
            p.c1FlexViewer.DocumentSource = p.PrintReport;
            p.Show();

            //他のボタンを活性に戻す。
            b_print_exclusion.Enabled = true;
            b_print.Enabled = true;
            b_return.Enabled = true;

        }

        //検索ボタンをクリックしたときに、条件を設定して受付情報を
        //検索して一覧表にセットする。
        private void b_search_Click(object sender, EventArgs e)
        {
            //where句の編集
            strSQLWHERE = "";

            //日付の編集
            strSQLWHERE += t_start_time_from != null ?"receipt_date >=" + "'" + t_start_time_from + "'":"";

            strSQLWHERE += t_start_time_to != null && strSQLWHERE.Length > 0 ? " and " : "";
            strSQLWHERE += t_start_time_to != null ? " receipt_date <=" + "'" + t_start_time_to + "'" : "";


            //名前検索条件の編集
            strSQLWHERE += t_customer.Text != null && strSQLWHERE.Length > 0? " and " : "";
            strSQLWHERE += t_customer.Text != null ? " (c.surname || c.name LIKE " + "'%" + t_customer.Text + "%')": "";
            

            strSQLWHERE = strSQLWHERE.Length > 0 ? "WHERE " + strSQLWHERE : "";


            //テーブルにアクセスするメソッドの呼び出し。
            // DataGridView初期化（データクリア）
            dataGridView1.Rows.Clear();
            
            //結果格納クエリーの初期化
            NpgsqlDataReader dataReader = null;

            //データベースアクセス処理
            using (var db = new DB.DBConnect())
            {
                //オープン処理がないと怒られる。
                db.npg.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append(@"select 
                            r.reception_code as reception_code,
                            r.receipt_date as receipt_date,
                            r.receipt_time as receipt_time,
                            r.store as store,
                            r.staff as staff,
                            r.customer_code,
                            c.surname || c.name as name,
                            r.status as status,
                            r.photographers as photographers,
                            r.coming_store_category,
                            r.memo as memo,
                            r.noprint as noprint,
                            r.claim,
                            r.motivation  
                            ");
                sb.Append(@"from
                            t_reception r 
                            LEFT JOIN m_customer c ON 
                            r.customer_code = c.customer_code
                            ");
                sb.Append(@strSQLWHERE);
                sb.Append(@"order by reception_code");

                var command = new NpgsqlCommand(sb.ToString(), db.npg);

                dataReader = command.ExecuteReader();
                receptions = new List<DB.t_reception>();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //チェックボックスの編集
                        var cb = dataReader["noprint"].ToString() == "1" ? true : false;

                        //ステータスを変換
                        int intVal = int.Parse(dataReader["status"].ToString());
                        var status = (Utile.Data.受付ステータス)Enum.ToObject(typeof(Utile.Data.受付ステータス), intVal);

                        //日付編集
                        DateTime receipt_date;
                        DateTime.TryParse(dataReader["receipt_date"].ToString(), out receipt_date);

                        //時刻編集
                        DateTime receipt_time;
                        DateTime.TryParse(dataReader["receipt_time"].ToString(), out receipt_time);

                        dataGridView1.Rows.Add(
                            cb,
                            dataReader["reception_code"],
                            receipt_date.ToShortDateString(),
                            receipt_time.ToShortTimeString(),
                            dataReader["store"],
                            dataReader["staff"],
                            dataReader["name"],
                            status,
                            dataReader["memo"]
                        );

                        DB.t_reception _Reception = new DB.t_reception();
                        _Reception.reception_code = dataReader["reception_code"].ToString();
                        _Reception.receipt_date = DateTime.Parse(dataReader["receipt_date"].ToString());
                        _Reception.receipt_time = TimeSpan.Parse(dataReader["receipt_time"].ToString());
                        _Reception.status = dataReader["status"].ToString();
                        _Reception.photographers = int.Parse(dataReader["photographers"].ToString());
                        _Reception.coming_store_category = dataReader["coming_store_category"].ToString();
                        _Reception.customer_code = dataReader["customer_code"].ToString();
                        _Reception.store = dataReader["store"].ToString();
                        _Reception.staff = dataReader["staff"].ToString();
                        _Reception.memo = dataReader["memo"].ToString();
                        _Reception.claim = dataReader["claim"].ToString();
                        _Reception.motivation = dataReader["motivation"].ToString();
                        _Reception.noprint = dataReader["noprint"].ToString();

                        receptions.Add(_Reception);
                    }
                }
                else
                {
                    MessageBox.Show("検索結果が0件でした。", "お知らせ", MessageBoxButtons.OK);
                }

            }

        }


        //明細表示ボタンが押されたときに、明細表示画面を表示させる。
        private void b_display_detail_Click(object sender, EventArgs e)
        {

        }
        //戻るボタンをクリックしたときに、一個前の画面に戻る。
        private void b_return_Click(object sender, EventArgs e)
        {
            pageParent.PageRefresh();
            MainForm.backPage(this);
            

        }
        //引数がnullなら、Customモードにして、空欄にする。
        private void Set_d_start_time_from(DateTime? Datetime)
        {
            if(Datetime == null)
            {
                d_start_date_from.Format = DateTimePickerFormat.Custom;
                d_start_date_from.CustomFormat = " ";
            }
            else
            {
                d_start_date_from.Format = DateTimePickerFormat.Long;
                d_start_date_from.Value = (DateTime)Datetime;
            }
        }
        //引数がnullなら、Customモードにして、空欄にする。
        private void Set_d_start_time_to(DateTime? Datetime)
        {
            if (Datetime == null)
            {
                d_start_date_to.Format = DateTimePickerFormat.Custom;
                d_start_date_to.CustomFormat = " ";
            }
            else
            {
                d_start_date_to.Format = DateTimePickerFormat.Long;
                d_start_date_to.Value = (DateTime)Datetime;
            }
        }

        // 削除キーが押されたら、空欄にする。
        private void d_start_date_from_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                t_start_time_from = null;
                Set_d_start_time_from(t_start_time_from);
            }
        }
        //削除キーが押されたら空欄にする。
        private void d_start_date_to_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                t_start_time_to = null;
                Set_d_start_time_to(t_start_time_to);
            }

        }
        //値が選択された場合には、値をセットする。
        private void d_start_date_from_ValueChanged(object sender, EventArgs e)
        {
            t_start_time_from = d_start_date_from.Value;
            Set_d_start_time_from(t_start_time_from);
        }

        private void d_start_date_to_ValueChanged(object sender, EventArgs e)
        {
            t_start_time_to = d_start_date_to.Value;
            Set_d_start_time_to(t_start_time_to);
        }
        //キー操作をするとカレンダが消えてしまうので、再描画
        private void d_start_date_from_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_start_date_from.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void d_start_date_to_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_start_date_to.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }

        }

        private void b_print_exclusion_Click(object sender, EventArgs e)
        {
            //印刷除外フラグを更新する。
            using (var db = new DB.DBConnect())
            {
                ;

                 //オープン処理がないと怒られる。
                 db.npg.Open();
                 //StringBuilder sb = new StringBuilder();

                for(int i=0; i < dataGridView1.RowCount; i++)
                {
                    string code = (string)dataGridView1.Rows[i].Cells[1].Value;
                    bool noprint = (bool) dataGridView1.Rows[i].Cells[0].Value;
                    var reception=db.t_reception.Single(x => x.reception_code == code );
                    if (noprint)
                    {
                        reception.noprint =  "1";
                    }
                    else
                    {
                        reception.noprint = "0";

                    }

                    reception.update_date = DateTime.Now;
                    reception.update_staff = MainForm.session_m_staff != null? MainForm.session_m_staff.staff_name:"" ;
                    db.SaveChanges();
                }
            }
        }

 
        private void dataGridView1_CellDoubleClicl(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void dataGridView1_CellCLICK(object sender, DataGridViewCellEventArgs e)
        {
            //受付コードセット
            string reception_code = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            //セッション情報の生成コードの設定
            if (MainForm.session_t_reception == null)
            {
                MainForm.session_t_reception = new DB.t_reception();
            }

            MainForm.session_t_reception.reception_code = reception_code.ToString();
            MainForm.session_t_reception.receipt_date=receptions.Find(x => x.reception_code == reception_code).receipt_date;
            MainForm.session_t_reception.receipt_time= receptions.Find(x => x.reception_code == reception_code).receipt_time;
            MainForm.session_t_reception.status = receptions.Find(x => x.reception_code == reception_code).status;
            MainForm.session_t_reception.photographers = receptions.Find(x => x.reception_code == reception_code).photographers;
            MainForm.session_t_reception.coming_store_category = receptions.Find(x => x.reception_code == reception_code).coming_store_category;
            MainForm.session_t_reception.customer_code = receptions.Find(x => x.reception_code == reception_code).customer_code;
            MainForm.session_t_reception.store = receptions.Find(x => x.reception_code == reception_code).store;
            MainForm.session_t_reception.staff = receptions.Find(x => x.reception_code == reception_code).staff;
            MainForm.session_t_reception.memo = receptions.Find(x => x.reception_code == reception_code).memo;
            MainForm.session_t_reception.claim = receptions.Find(x => x.reception_code == reception_code).claim;
            MainForm.session_t_reception.motivation = receptions.Find(x => x.reception_code == reception_code).motivation;
            MainForm.session_t_reception.noprint = receptions.Find(x => x.reception_code == reception_code).noprint;

            //ヘッダメニュー更新
            MainForm.Header_Menu.LabelReWrite();
            
        }

        //セルをダブルクリックしたら、受付明細へ遷移する。
        private void dataGridView1_CellDoubleClicl(object sender, DataGridViewCellMouseEventArgs e)
        {
            MainForm.Reception_details.PageRefresh();
            MainForm.sendPage(this, MainForm.Reception_details);
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
