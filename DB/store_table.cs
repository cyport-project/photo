using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;        // 参照を追加。
using System.ComponentModel.DataAnnotations.Schema; // 参照を追加。
using System.Linq;
using System.Text;

namespace 写真館システム.DB
{
    // テーブルの名前とスキーマ名を入力。
    //テーブルごとに生成する
    [Table("m_store", Schema="public")] 

    //クラス名＝テーブル名
    public class m_store : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //店舗コード
        [Column("store_code",Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String store_code { get; set; }

        //会社名
        [Column("company_name")]
        //[MaxLength(30)]
        public String company_name { get; set; }

        //店舗名
        [Column("store_name")]
        //[MaxLength(30)]
        public String store_name { get; set; }

        //郵便番号
        [Column("postal_code")]
        //[MaxLength(8)]
        public String postal_code { get; set; }

        //県・市区町村名
        [Column("address1")]
        //[MaxLength(60)]
        public String address1 { get; set; }

        //番地
        [Column("address2")]
        //[MaxLength(60)]
        public String address2 { get; set; }

        //アパート・マンション
        [Column("address3")]
        //[MaxLength(60)]
        public String address3 { get; set; }

        //電話番号
        [Column("phone_number")]
        //[MaxLength(13)]
        public String phone_number { get; set; }

        //ステータス
        [Column("status")]
        //[MaxLength(1)]
        public string status { get; set; }

        //開店時間
        [Column("start_time")]
        public TimeSpan start_time { get; set; }

        //閉店時間
        [Column("end_time")]
        public TimeSpan end_time { get; set; }

        //休業日
        [Column("regular_holiday")]
        //[MaxLength(10)]
        public String regular_holiday { get; set; }

        //店舗区分
        [Column("store_category")]
        //[MaxLength(1)]
        public String store_category { get; set; }

        //登録日
        [Column("registration_date")]
        public DateTime registration_date { get; set; }

        //登録者
        [Column("registration_staff")]
        //[MaxLength(20)]
        public string registration_staff { get; set; }

        //更新日
        [Column("update_date")]
        public DateTime? update_date { get; set; }

        //更新者
        [Column("update_staff")]
        //[MaxLength(20)]
        public string update_staff { get; set; }

        //削除フラグ
        [Column("delete_flag")]
        //[MaxLength(20)]
        public string delete_flag { get; set; }


        //リレーション
        //public virtual ICollection<t_facility_reservation> Facility_Reservation { get; set; }
        //public virtual ICollection<m_facility> Facility { get; set; }
        //public virtual ICollection<t_calendar_information> Calendar_Information{ get; set; }
        //public virtual ICollection<m_staff> Staff { get; set; }
        //public virtual ICollection<t_costume_reservation> Costume_Reservation { get; set; }
        //public virtual ICollection<t_selection> Selection { get; set; }
        //public virtual ICollection<t_sales_management> Sales_Management { get; set; }
        //public virtual ICollection<m_costume> Costume { get; set; }
        //public virtual ICollection<m_staff_shift> Staff_Shift { get; set; }

        public struct storeDataArray
        {
            string storeCode;
            string storeName;
        }

         

        public void Command( bool delete = false)
        {
            using (var dbc = new DB.DBConnect())
            {
                //削除フラグ
                if (delete)
                    this.delete_flag = "1";
                else
                    this.delete_flag = "0";

                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;

                var data = dbc.m_store.SingleOrDefault(x => x.store_code == this.store_code);

                if(data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_store.Add(this);
                }
                else
                {
                    //更新
                    data.address1 = this.address1;
                    data.address2 = this.address2;
                    data.address3 = this.address3;
                    data.company_name = this.company_name;
                    data.end_time = this.end_time;
                    data.phone_number = this.phone_number;
                    data.postal_code = this.postal_code;
                    data.regular_holiday = this.regular_holiday;
                    data.start_time = this.start_time;
                    data.status = this.status;
                    data.store_category = this.store_category;
                    //data.store_code = this.store_code;
                    data.store_name = this.store_name;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                    data.delete_flag = this.delete_flag;
                }
                
                dbc.SaveChanges();
            }

        }
        public static m_store getSingle(string code)
        {
            m_store s;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_store.SingleOrDefault(x => x.store_code == code);

            }
            return s;
        }

        public static m_store getSingleName(string name)
        {
            m_store s;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_store.SingleOrDefault(x => x.store_name == name.Trim());

            }
            return s;
        }
        public static List<string> getStoreNameList()
        {
            List<string> res = new List<string>();
            using(var dbc = new DBConnect())
            {
                var q = from t in dbc.m_store
                        where t.delete_flag == "0"
                        orderby t.store_code
                        select t.store_name;
                foreach(var item in q)
                {
                    res.Add(item);
                }
            }
            return res;
        }

        public static List<Dictionary<string, object>> getStoreList()
        {
            var res = new List<Dictionary<string, object>>();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select store_code, store_name ");
                sb.Append(@"from m_store ");
                sb.Append(@"where m_store.delete_flag = '0' ");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var item = new Dictionary<string, object>();
                    item.Add("store_code", dataReader["store_code"]);
                    item.Add("store_name", dataReader["store_name"]);

                    res.Add(item);
                }
            }
            return res;
        }


        public static NpgsqlDataReader getStoreList2()
        {

            NpgsqlDataReader dataReader = null;
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select store_code, store_name ");
                sb.Append(@"from m_store ");
                sb.Append(@"where m_store.delete_flag = '0' order by m_store.store_code");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();
            }
            return dataReader;
        }

        public static List<Store_master.StoreDBArray> getStoreAllList()
        {
            List<Store_master.StoreDBArray> StoreDBList = new List<Store_master.StoreDBArray>();
            NpgsqlDataReader dataReader = null;
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select store_code,company_name,store_name,postal_code,address1,address2,address3,phone_number,status,start_time,end_time,regular_holiday,store_category ");
                sb.Append(@"from m_store ");
                sb.Append(@"where m_store.delete_flag = '0' order by m_store.store_code");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();

                while (dataReader.Read() == true)
                {

                    StoreDBList.Add(new Store_master.StoreDBArray
                    {
                        store_code = dataReader["store_code"].ToString(),
                        store_company = dataReader["company_name"].ToString(),
                        store_name = dataReader["store_name"].ToString(),
                        store_postal_code = dataReader["postal_code"].ToString(),
                        store_pref_city_town_district_village = dataReader["address1"].ToString(),
                        store_address = dataReader["address2"].ToString(),
                        store_apart = dataReader["address3"].ToString(),
                        store_phone_number = dataReader["phone_number"].ToString(),
                        store_status = dataReader["status"].ToString(),
                        store_start_time = TimeSpan.Parse(dataReader["start_time"].ToString()),
                        store_end_time = TimeSpan.Parse(dataReader["end_time"].ToString()),
                        store_classification = dataReader["store_category"].ToString(),
                        store_regular_hoiday = dataReader["regular_holiday"].ToString(),
                        store_index = dataReader.ToString()
                    });
                }

            }
            return StoreDBList;
        }

    }
}