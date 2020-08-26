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
    public partial class Reception_details : UserControlExp
    {
        private string reception_code;
        public Reception_details()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            //初期表示
        }

        public override void PageRefresh()
        {
            try
            {
                reception_code = MainForm.session_t_reception.reception_code;
            }
            catch (NullReferenceException)
            {
                Console.Write("データが選択されていません。");
            }
            //結果格納クエリーの初期化
            NpgsqlDataReader dataReader = null;

            using (var db = new DB.DBConnect())
            {
                //オープン処理がないと怒られる。
                db.npg.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append(@"select 
                             *
                            ");
                sb.Append(@"from
                            t_reception r 
                            LEFT JOIN m_customer c ON 
                            r.customer_code = c.customer_code
                            ");
                sb.Append(@" where reception_code = '@reception_code'".Replace("@reception_code",reception_code));
                sb.Append(@"order by reception_code");

                var command = new NpgsqlCommand(sb.ToString(), db.npg);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    //受付コード
                    t_uketsuke_code.Text = dataReader["reception_code"].ToString();

                    //受付年月日
                    DateTime receipt_date;
                    DateTime.TryParse(dataReader["receipt_date"].ToString(), out receipt_date);
                    t_uketsuke_date.Text = receipt_date.ToLongDateString();

                    //受付時分
                    DateTime receipt_time;
                    DateTime.TryParse(dataReader["receipt_time"].ToString(), out receipt_time);
                    t_uketsuke_jihun.Text = receipt_time.ToShortTimeString();

                    //受付店舗
                    t_uketsuke_tenpo.Text = dataReader["store"].ToString();

                    //受付スタッフ
                    t_uketsuke_staff.Text = dataReader["staff"].ToString();

                    //受付ステータス
                    int intVal = int.Parse(dataReader["status"].ToString());
                    t_uketsuke_status.Text = Enum.ToObject(typeof(Utile.Data.受付ステータス), intVal - 1).ToString();

                    //撮影人数
                    t_uketsuke_ninzuu.Text = dataReader["photographers"].ToString();

                    //来店区分
                    int intVal1 = int.Parse(dataReader["coming_store_category"].ToString());
                    t_raiten_kubun.Text = Enum.ToObject(typeof(Utile.Data.来店区分), intVal1 - 1).ToString();

                    //メモ
                    t_taiou_naiyou.Text = dataReader["memo"].ToString();

                    //内規情報
                    t_naikinaiyou.Text = dataReader["claim"].ToString();

                    //顧客コード
                    t_kokyaku_code.Text = dataReader["customer_code"].ToString();

                    //お客様名
                    t_kokyakumei.Text = dataReader["surname"].ToString() + dataReader["name"].ToString();

                    //生年月日
                    DateTime birthday;
                    DateTime.TryParse(dataReader["birthday"].ToString(), out birthday);
                    t_seinengappi.Text = birthday.ToLongDateString();

                    //年齢
                    var age = getAge(birthday);
                    t_nenrei.Text = age.ToString() + "歳";

                    //性別
                    int index = int.Parse(dataReader["sex"].ToString());
                    t_seibetsu.Text = Enum.ToObject(typeof(Utile.Data.性別), index).ToString();

                    //郵便番号
                    t_postalcode.Text = dataReader["postal_code"].ToString();

                    //県・市区町村
                    t_sichouson.Text = dataReader["address1"].ToString();

                    //番地
                    t_banchi.Text = dataReader["address2"].ToString();

                    //アパート・マンション
                    t_apart.Text = dataReader["address3"].ToString();

                    //電話番号
                    t_denwabango.Text = dataReader["phone_number1"].ToString();

                    //メール
                    t_mail.Text = dataReader["mail_address"].ToString();

                }
            }
            //施設予約検索
            dataGridView1.Rows.Clear();
            dataReader = null;
            using (var db = new DB.DBConnect())
            {
                //オープン処理がないと怒られる。
                db.npg.Open();
                
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select
                             f.facility_name as name,
                             fr.start_date as start_date,
                             fr.start_time as start_time,   
                             fr.remarks as remarks   
                            ");
                sb.Append(@"from
                            t_reception r 
                            INNER JOIN t_reservation re ON 
                            r.reception_code = re.reception_code
                            INNER JOIN t_facility_reservation fr ON
                            re.facility_reservation_code = fr.facility_reservation_code
                            INNER JOIN m_facility f ON
                            fr.facility_code = f.facility_code
                            ");
                sb.Append(@" where r.reception_code = '@reception_code'".Replace("@reception_code",reception_code));
                sb.Append(@"order by fr.start_date");

                var command = new NpgsqlCommand(sb.ToString(), db.npg);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    DateTime startdate;
                    DateTime.TryParse(dataReader["start_date"].ToString(), out startdate);
                    DateTime start_time;
                    DateTime.TryParse(dataReader["start_time"].ToString(), out start_time);


                    dataGridView1.Rows.Add(
                        dataReader["name"].ToString(),
                        startdate.ToShortDateString() + " " + start_time.ToShortTimeString(),
                        dataReader["remarks"].ToString()

                    );
                }
            }

            //衣装予約検索
            dataGridView2.Rows.Clear();
            dataReader = null;
            using (var db = new DB.DBConnect())
            {
                    //オープン処理がないと怒られる。
                db.npg.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append(@"select
                             cr.facility as name,
                             cr.store_code as store_code,
                             cr.costume_code as costume_code,
                             cr.memo as memo   
                            ");
                sb.Append(@"from
                            t_reception r 
                            INNER JOIN t_reservation re ON 
                            r.reception_code = re.reception_code
                            INNER JOIN t_costume_reservation cr ON
                            re.costume_reservation_code = cr.costume_reservation_code
                            ");
                sb.Append(@" where r.reception_code = '@reception_code'".Replace("@reception_code", reception_code));
                sb.Append(@"order by cr.costume_code ");

                var command = new NpgsqlCommand(sb.ToString(), db.npg);

                dataReader = command.ExecuteReader();
                

                while (dataReader.Read())
                {
                    var store_name = DB.m_store.getSingle(dataReader["store_code"].ToString());

                    dataGridView2.Rows.Add(
                        dataReader["name"].ToString(),
                        store_name.store_name,
                        dataReader["costume_code"].ToString(),
                        dataReader["memo"].ToString()

                    );
                }

            }
        }

        //年齢計算
        private　int getAge(DateTime birthday)
        {
            int age = DateTime.Now.Year - birthday.Year;
            if (DateTime.Now.Month < birthday.Month ||
               (DateTime.Now.Month == birthday.Month &&
                DateTime.Now.Day < birthday.Day))
            {
                age--;
            }
            return  age;
        }



        //削除ボタン
        private void b_delete_Click(object sender, EventArgs e)
        {
            //予約テーブルに1件でもあれば、削除不可
            NpgsqlDataReader　dataReader = null;
            using (var db = new DB.DBConnect())
            {
                //オープン処理がないと怒られる。
                db.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select
                                *
                           "); 
                sb.Append(@"from
                            t_reservation 
                            ");
                sb.Append(@" where reception_code = '@reception_code'".Replace("@reception_code", reception_code));
                var command = new NpgsqlCommand(sb.ToString(), db.npg);
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    MessageBox.Show("予約がすでに入ってますので、受付情報は削除できません。", "お知らせ", MessageBoxButtons.OK);
                    return;
                }
            }
            //削除
            using (var db = new DB.DBConnect())
            {
                //データ取得
                var receptions = db.t_reception;
                var data = receptions.Single(x => x.reception_code == reception_code);
                //削除
                receptions.Remove(data);
                db.SaveChanges();

                MessageBox.Show("受付情報を削除しました。", "お知らせ", MessageBoxButtons.OK);
            }

            //セッション情報の削除
            if(MainForm.session_t_reception!= null) MainForm.session_t_reception = null;
            MainForm.Header_Menu.LabelReWrite();

            //一つ前のボタンに戻る。
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        //印刷ボタン
        private void b_print_Click(object sender, EventArgs e)
        {
            //顧客情報登録
            Dictionary<string, string> dataitem = new Dictionary<string, string>();
            dataitem.Add("ReceptionCode", t_uketsuke_code.Text.ToString());
            dataitem.Add("ReceptionDate", t_uketsuke_date.Text.ToString());
            dataitem.Add("CustomerCode", t_kokyaku_code.Text.ToString());
            var customer = DB.m_customer.getSingle(t_kokyaku_code.Text.ToString());
            dataitem.Add("CustomerNamekana", customer.surname_kana + customer.name_kana);
            dataitem.Add("CustomerName", t_kokyakumei.Text.ToString());
            dataitem.Add("CustomerBirthday", t_seinengappi.Text.ToString());
            dataitem.Add("CustomerAge", t_nenrei.Text.ToString());
            dataitem.Add("CustomerSex", t_seibetsu.Text.ToString());
            dataitem.Add("CustomerZipcode", t_postalcode.Text.ToString());
            dataitem.Add("CustomerAddress1", t_sichouson.Text.ToString());
            dataitem.Add("CustomerAddress2", t_banchi.Text.ToString() + t_apart.Text.ToString());
            dataitem.Add("CustomerPhonenumber1", t_denwabango.Text.ToString());
            dataitem.Add("CustomerPhonenumber2", customer.phone_number2);
            dataitem.Add("CustomerPhonenumber3", customer.phone_number3);
            dataitem.Add("CustomerFaxnumber1", customer.fax_number);
            dataitem.Add("CustomerMailaddress", t_mail.Text.ToString());

            string table = "Reception_card";
            Utile.RepoerDB rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();
            rdb.insert(dataitem);

            //名簿-家族情報登録
            List<DB.m_family> families = new List<DB.m_family>();
            families = DB.m_family.getOnlyCode(t_kokyaku_code.Text.ToString());

            table = "Reception_card_NameList";
            rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();

            foreach (DB.m_family family in families)
            {
                Dictionary<string, string> dataitem1 = new Dictionary<string, string>();
                dataitem1.Add("NameListNamekana", family.surname_kana + family.name_kana);
                dataitem1.Add("NameListName", family.surname + family.name);
                dataitem1.Add("NameListBirthday", family.birthday.Value.ToShortDateString());
                int age = getAge(family.birthday.Value);
                dataitem1.Add("NameListAge", age.ToString());
                dataitem1.Add("NameListSex", Enum.ToObject(typeof(Utile.Data.性別),int.Parse(family.sex)).ToString());
                dataitem1.Add("NameListRelationship", family.relationship);
                dataitem1.Add("NameListRemarks", family.remarks);
                rdb.insert(dataitem1);
            }

           
            //名簿-追加情報登録
            table = "Reception_card_NameListIncluding";
            rdb = new Utile.RepoerDB(table);

            Dictionary<string, string> dataitem2 = new Dictionary<string, string>();
            using (var db = new DB.DBConnect())
            {   //オープン処理がないと怒られる。
                db.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select distinct
                             fr.shooting_purpose as shooting_purpose
                            ");
                sb.Append(@"from
                            t_reception r 
                            INNER JOIN t_reservation re ON 
                            r.reception_code = re.reception_code
                            INNER JOIN t_facility_reservation fr ON
                            re.facility_reservation_code = fr.facility_reservation_code
                            INNER JOIN m_facility f ON
                            fr.facility_code = f.facility_code
                            ");
                sb.Append(@" where r.reception_code ='@reception_code'".Replace("@reception_code", reception_code));
                sb.Append(@"order by fr.shooting_purpose");

                var command = new NpgsqlCommand(sb.ToString(), db.npg);

                var dataReader = command.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    dataitem2.Add("NameListUseClassification", dataReader["shooting_purpose"].ToString());
                }

            }
            string d = DB.t_shooting_data.getShootingDate(t_kokyaku_code.Text.ToString());
            DateTime.TryParse(d, out DateTime Day);
            String secondDay = d != "" ? Day.ToShortDateString():"";
            dataitem2.Add("NameListShootingdate", secondDay);
            dataitem2.Add("NameListRemarks", t_taiou_naiyou.Text.ToString());

            rdb.deleteAll();
            rdb.insert(dataitem2);

            //施設予約
            table = "Reception_card_Reservation";
            rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();
            for(var i = 0; i < dataGridView1.RowCount ; i++)
            {
                Dictionary<string, string> dataitem3 = new Dictionary<string, string>();
                dataitem3.Add("ReservationFacility", dataGridView1.Rows[i].Cells[0].Value.ToString());
                dataitem3.Add("ReservationDate", dataGridView1.Rows[i].Cells[1].Value.ToString());
                dataitem3.Add("ReservationRemarks", dataGridView1.Rows[i].Cells[2].Value.ToString());
                rdb.insert(dataitem3);
            }

            //衣装予約登録
            table = "Reception_card_Costume";
            rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();
            for (var i = 0; i < dataGridView2.RowCount; i++)
            {
                Dictionary<string, string> dataitem4 = new Dictionary<string, string>();
                var store = DB.m_store.getSingleName(dataGridView2.Rows[i].Cells[1].Value.ToString());
                var costume = DB.m_costume.getSingle(store.store_code, dataGridView2.Rows[i].Cells[2].Value.ToString());
                var photo_root = System.Configuration.ConfigurationManager.AppSettings["photo_root"];
                var Costume_Image = System.Configuration.ConfigurationManager.AppSettings["Costume_Image"];
                var Costume_Image_Dir = System.IO.Path.Combine(photo_root, Costume_Image);
                string image1 = costume.image1;
                var path = System.IO.Path.Combine(Costume_Image_Dir, store.store_name, dataGridView2.Rows[i].Cells[2].Value.ToString(), image1);


                dataitem4.Add("CostumeThumbnail", System.IO.Path.GetFullPath(path));
                dataitem4.Add("CostumeFacility", dataGridView2.Rows[i].Cells[0].Value.ToString());
                dataitem4.Add("CostumeCode", dataGridView2.Rows[i].Cells[2].Value.ToString());
                dataitem4.Add("CostumeRemarks", dataGridView2.Rows[i].Cells[3].Value.ToString());
                rdb.insert(dataitem4);
            }


            PrintForm p = new PrintForm();
            p.PrintReport.Load(@"./Asset/Format/Reception_card.flxr", "Reception_card レポート");
            p.c1FlexViewer.DocumentSource = p.PrintReport;
            p.Show();
        }

        //戻るボタン
        private void b_return_Click(object sender, EventArgs e)
        {
            //一つ前のボタンに戻る。
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
