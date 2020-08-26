using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;      
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 写真館システム.DB
{
    
    // テーブルの名前とスキーマ名を入力。
    //テーブルごとに生成する
    [Table("m_facility", Schema = "public")]

    //クラス名＝テーブル名
    public class m_facility : base_table
    {

        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //店舗コード
        [Column("store_code", Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String store_code { get; set; }

        [Key] // 主キーを設定。
        //施設コード
        //[Key] // 主キーを設定。    
        [Column("facility_code", Order = 1)]
        //[MaxLength(8)]
        public String facility_code { get; set; }

        //施設名
        [Column("facility_name")]
        //[MaxLength(20)]
        public String facility_name { get; set; }

        //登録日
        [Column("registration_date")]
        public DateTime registration_date { get; set; }

        //登録者
        [Column("registration_staff")]
        //[MaxLength(20)]
        public String registration_staff { get; set; }


        //更新日
        [Column("update_date")]
        public DateTime? update_date { get; set; }

        //更新者
        [Column("update_staff")]
        //[MaxLength(20)]
        public String update_staff { get; set; }

        //削除フラグ
        [Column("delete_flag")]
        public String delete_flag { get; set; }

        //リレーション
        //public virtual ICollection<t_facility_reservation> facility_Reservation { get; set; }
        //public virtual m_store Store { get; set; }

        public void Command(bool delete = false)
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

                var data = dbc.m_facility.SingleOrDefault(x => x.store_code == this.store_code
                                                   & x.facility_code == this.facility_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_facility.Add(this);
                }
                else
                {
                    if(delete_flag == "0")
                    {
                        data.facility_code = this.facility_code;
                        data.facility_name = this.facility_name;
                        data.store_code = this.store_code;
                    }
                    //更新者・更新日・削除フラグの変更
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                    data.delete_flag = this.delete_flag;
                }

                dbc.SaveChanges();
            }

        }

        public static m_facility getSingleName(string store_code, string name)
        {
            m_facility res = new m_facility();
            using (var dbc = new DBConnect())
            {
                res = dbc.m_facility.SingleOrDefault(x => x.store_code == store_code & x.facility_name == name);
            }
            return res;
        }

        public static m_facility getSingle(string store_code, string code)
        {
            m_facility res = new m_facility();
            using (var dbc = new DBConnect())
            {
                res = dbc.m_facility.SingleOrDefault(x => x.store_code == store_code & x.facility_code == code);
            }
            return res;
        }

        public static List<string> getFacilityNameList(string store_code)
        {
            List<string> res = new List<string>();
            using(var dbc = new DBConnect())
            {
                var q = from t in dbc.m_facility
                        where t.delete_flag == "0" & t.store_code == store_code
                        orderby t.facility_code
                        select t.facility_name;
                foreach(var item in q)
                {
                    res.Add(item);
                }
                return res;
            }
        }

        public static List<Dictionary<string,object>> getFacilityList(string store)
        {
            NpgsqlDataReader dataReader = null;
            var res = new List<Dictionary<string, object>>();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select facility_code, facility_name ");
                sb.Append(@"from m_facility ");
                sb.Append(@"where m_facility.delete_flag = '0' and
                                  m_facility.store_code = '@store'").Replace("@store", store);
                sb.Append(@"Order by store_code,facility_code ");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();
            
                 while (dataReader.Read())
                {
                    var item = new Dictionary<string, object>();
                    item.Add("facility_code", dataReader["facility_code"]);
                    item.Add("facility_name", dataReader["facility_name"]);

                    res.Add(item);
                }
            }
            return res;
        }

        public static List<m_facility> getFacilityAllList()
        {
            NpgsqlDataReader dataReader = null;
            var res = new List<m_facility>();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select store_code,facility_code, facility_name ");
                sb.Append(@"from m_facility ");
                sb.Append(@"where m_facility.delete_flag = '0' ");
                sb.Append(@"order by store_code,facility_code" );
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    m_facility facility = new m_facility();
                    facility.store_code = dataReader["store_code"].ToString();
                    facility.facility_code = dataReader["facility_code"].ToString();
                    facility.facility_name = dataReader["facility_name"].ToString();

                    res.Add(facility);
                }

            }
            return res;
        }
    }
    
}
