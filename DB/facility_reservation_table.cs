using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace 写真館システム.DB
{
 

        // テーブルの名前とスキーマ名を入力。
        //テーブルごとに生成する
        [Table("t_facility_reservation", Schema = "public")]

        public class t_facility_reservation : base_table
        {
            [Key] // 主キーを設定。
            //施設予約コード
            [Column("facility_reservation_code")]
            //[MaxLength(8)]
            public String facility_reservation_code { get; set; }

            //開始年月日
            [Column("start_date")]
            public DateTime start_date { get; set; }

            //開始時分
            [Column("start_time")]
            public TimeSpan start_time { get; set; }

            //終了年月日
            [Column("end_date")]
            public DateTime end_date { get; set; }

            //終了時分
            [Column("end_time")]
            public TimeSpan end_time { get; set; }

            //予約者名
            [Column("reservator")]
            //[MaxLength(20)]
            public String reservator { get; set; }

            //摘要
            [Column("remarks")]
            //[MaxLength(254)]
            public String remarks { get; set; }

            //中止年月日 
            [Column("cancellation_date")]
            public DateTime? cancellation_date { get; set; }

            //撮影目的
            [Column("shooting_purpose")]
            //[MaxLength(20)]
            public String shooting_purpose { get; set; }

            //撮影者
            [Column("photographer")]
            //[MaxLength(40)]
            public String photographer { get; set; }

            //タスク区分
            [Column("task_class")]
            //[MaxLength(1)]
            public String task_class { get; set; }

            //セレクト開始年月日
            [Column("selection_start_date")]
            public DateTime? selection_start_date { get; set; }

            //セレクト開始時分
            [Column("selection_start_time")]
            public TimeSpan? selection_start_time { get; set; }

            //セレクト終了年月日
            [Column("selection_end_date")]
            public DateTime? selection_end_date { get; set; }

            //セレクト終了時分
            [Column("selection_end_time")]
            public TimeSpan? selection_end_time { get; set; }

            //セレクト者
            [Column("selector")]
            //[MaxLength(20)]
            public String selector { get; set; }

            //店舗コード
            [Column("store_code")]
            //[MaxLength(8)]
            public String store_code { get; set; }

            //施設コード
            [Column("facility_code")]
            //[MaxLength(8)]
            public String facility_code { get; set; }

            //発注コード
            [Column("order_code")]
            //[MaxLength(8)]
            public String order_code { get; set; }
        
            //登録日
            [Column("registration_date")]
            public DateTime? registration_date { get; set; }

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

            //施設テーブル
            //public virtual m_facility facility { get; set; }
            //public virtual t_reservation Reservation { get; set; }
            //public virtual m_store Store { get; set; }
            //public virtual t_sales_management Sales_Management { get; set; }

        public void Command(bool delete = false)
        {
            using (var dbc = new DB.DBConnect())
            {
                if (delete)
                {
                    //削除
                    dbc.t_facility_reservation.Attach(this);
                    dbc.t_facility_reservation.Remove(this);
                }
                else
                {
                    //更新情報
                    this.update_date = DateTime.Now.Date;
                    this.update_staff = MainForm.session_m_staff.staff_name;

                    var data = dbc.t_facility_reservation.SingleOrDefault(x => x.facility_reservation_code == this.facility_reservation_code);

                    if (data == null)
                    {
                        //新規登録
                        this.registration_date = DateTime.Now.Date;
                        this.registration_staff = MainForm.session_m_staff.staff_name;
                        dbc.t_facility_reservation.Add(this);
                    }
                    else
                    {
                        data.cancellation_date = this.cancellation_date;
                        data.end_date = this.end_date;
                        data.end_time = this.end_time;
                        data.facility_code = this.facility_code;
                        data.facility_reservation_code = this.facility_reservation_code;
                        data.order_code = this.order_code;
                        data.photographer = this.photographer;
                        data.remarks = this.remarks;
                        data.reservator = this.reservator;
                        data.selection_end_date = this.selection_end_date;
                        data.selection_end_time = this.selection_end_time;
                        data.selection_start_date = this.selection_start_date;
                        data.selection_start_time = this.selection_start_time;
                        data.selector = this.selector;
                        data.shooting_purpose = this.shooting_purpose;
                        data.start_date = this.start_date;
                        data.start_time = this.start_time;
                        data.store_code = this.store_code;
                        data.task_class = this.task_class;
                        data.update_date = this.update_date;
                        data.update_staff = this.update_staff;
                    }
                }

                dbc.SaveChanges();
            }

        }
        public static string getNewFacility_reservation_code()
        {
            string res = null;
            using(var dbc = new DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"SELECT max(t.facility_reservation_code) as facility_reservation_code_max ");
                sb.Append(@"FROM public.t_facility_reservation as t ");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int i;
                    if (!int.TryParse(dataReader["facility_reservation_code_max"].ToString(), out i))
                        i = 0;
                    else
                        i++;
                    res = $"{i:00000000}";
                }

            }
            return res;
        }

        public static t_facility_reservation getSingle(string code)
        {
            t_facility_reservation res = new t_facility_reservation();
            using (var dbc = new DBConnect())
            {
                res = dbc.t_facility_reservation.SingleOrDefault(x => x.facility_reservation_code == code);
            }
            return res;
        }
    }
    
}
