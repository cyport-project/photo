using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;        // 参照を追加。
using System.ComponentModel.DataAnnotations.Schema; // 参照を追加。

namespace 写真館システム.DB
{
    // テーブルの名前とスキーマ名を入力。
    //テーブルごとに生成する
    [Table("m_staff_shift", Schema = "public")]
    public class m_staff_shift : base_table
    {
        //店舗コード
        [Key]
        [Column("store_code", Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String store_code { get; set; }

        //スタッフコード
        [Key]
        [Column("staff_code", Order = 1)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String staff_code { get; set; }

        //勤務日
        [Key]
        [Column("work_day", Order = 2)] // データベース上のカラム名を入力。
        public DateTime work_day { get; set; }

        //開始時分
        [Column("start_time")] // データベース上のカラム名を入力。
        public TimeSpan start_time { get; set; }

        //終了時分
        [Column("end_time")] // データベース上のカラム名を入力。
        public TimeSpan end_time { get; set; }

        //就業区分
        [Column("work_class")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public string work_class { get; set; }

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

        //リレショーン
        //public virtual m_store Store { get; set; }
        //public virtual m_staff Staff { get; set; }

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

                var data = dbc.m_staff_shift.SingleOrDefault(x => x.store_code == this.store_code 
                                                                & x.staff_code == this.staff_code 
                                                                & x.work_day == this.work_day);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_staff_shift.Add(this);
                }
                else
                {
                    if(delete_flag == "0")
                    {

                        data.end_time = this.end_time;
                        data.staff_code = this.staff_code;
                        data.start_time = this.start_time;
                        data.store_code = this.store_code;
                        data.work_class = this.work_class;
                        data.work_day = this.work_day;
                    }
                    data.delete_flag = this.delete_flag;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
        public static m_staff_shift getSingle(string code, DateTime date)
        {
            m_staff_shift s;
            using (var dbc = new DBConnect())
            { 
                s = dbc.m_staff_shift.SingleOrDefault(x => x.staff_code == code & x.work_day == date);

            }
            return s;
        }
        public static m_staff_shift getSingle2(string store,string code, DateTime date)
        {
            m_staff_shift s;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_staff_shift.SingleOrDefault(x => x.store_code== store & x.staff_code == code & x.work_day == date);

            }
            return s;
        }


        public static List<m_staff_shift> GetlistTable(DateTime date,string store)
        {
            
            List<m_staff_shift> res = new List<m_staff_shift>();
            using (var data = new DBConnect())
            {
                var q = from t in data.m_staff_shift
                        where t.store_code == store & t.work_day == date
                        select t;
                foreach(var d in q)
                {
                    res.Add(d);
                }
            }
            return res;
        }

        public static List<DateTime> getDateList(string code)
        {
            List<DateTime> res = new List<DateTime>();
            using(var dbc = new DBConnect())
            {
                var q = from t in dbc.m_staff_shift
                        where t.staff_code == code & t.delete_flag == "0"
                        select t;
                foreach(var data in q)
                {
                    res.Add(data.work_day);
                }
                return res;
            }
        }
    }
}
