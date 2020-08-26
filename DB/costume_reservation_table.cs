using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace 写真館システム.DB
{
    // テーブルの名前とスキーマ名を入力。
    //テーブルごとに生成する
    [Table("t_costume_reservation", Schema = "public")]

    public class t_costume_reservation : base_table
    { 
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        //衣装予約コード
        [Column("costume_reservation_code")]
       // [MaxLength(8)]
        public String costume_reservation_code { get; set; }

        ////開始年月日
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
        [Column("memo")]
        //[MaxLength(254)]
        public String memo { get; set; }

        //中止年月日 
        [Column("cancellation_date")]
        public DateTime? cancellation_date { get; set; }

        //撮影目的
        [Column("shooting_purpose")]
        //[MaxLength(20)]
         public String shooting_purpose { get; set; }

        //店舗コード
        [Column("store_code")]
        //[MaxLength(8)]
        public String store_code { get; set; }

        //衣装コード
        [Column("costume_code")]
        //[MaxLength(8)]
        public String costume_code { get; set; }

        //施設名
        [Column("facility")]
        //[MaxLength(20)]
        public String facility { get; set; }

        //お名前
        [Column("name")]
        //[MaxLength(20)]
        public String name { get; set; }

        //お名前カナ
        [Column("name_kana")]
        //[MaxLength(40)]
        public String name_kana { get; set; }

        //性別
        [Column("sex")]
        //[MaxLength(1)]
        public String sex { get; set; }

        //生年月日
        [Column("birthday")]
        public DateTime? birthday { get; set; }

        //身長
        [Column("height")]
        public int? height { get; set; }

        //足サイズ
        [Column("foot")]
        public int? foot { get; set; }

        //裄丈
        [Column("sleeve")]
        public int? sleeve { get; set; }

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

        //リレーション
        //public virtual t_reservation Reservation { get; set; }
        //public virtual m_store Store { get; set; }
        //public virtual m_customer Customer { get; set; }
        //public virtual m_costume Costume { get; set; }

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                if (delete)
                {
                    //削除
                    dbc.t_costume_reservation.Attach(this);
                    dbc.t_costume_reservation.Remove(this);
                }
                else
                {
                    //更新情報
                    this.update_date = DateTime.Now.Date;

                    this.update_staff = MainForm.session_m_staff.staff_name;
                    var data = dbc.t_costume_reservation.SingleOrDefault(x => x.costume_reservation_code == this.costume_reservation_code);

                    if (data == null)
                    {
                        //新規登録
                        this.registration_date = DateTime.Now.Date;
                        this.registration_staff = MainForm.session_m_staff.staff_name;
                        dbc.t_costume_reservation.Add(this);
                    }
                    else
                    {
                        data.birthday = this.birthday;
                        data.cancellation_date = this.cancellation_date;
                        data.costume_code = this.costume_code;
                        data.end_date = this.end_date;
                        data.end_time = this.end_time;
                        data.facility = this.facility;
                        data.foot = this.foot;
                        data.height = this.height;
                        data.memo = this.memo;
                        data.name = this.name;
                        data.name_kana = this.name_kana;
                        data.costume_reservation_code = this.costume_reservation_code;
                        data.reservator = this.reservator;
                        data.sex = this.sex;
                        data.shooting_purpose = this.shooting_purpose;
                        data.sleeve = this.sleeve;
                        data.start_date = this.start_date;
                        data.start_time = this.start_time;
                        data.store_code = this.store_code;
                        data.update_staff = this.update_staff;
                        data.update_date = this.update_date;
                    }
                }

                dbc.SaveChanges();
            }

        }

        public static string getNewcostume_reservation_code() {

            string res = null;
            using(var dbc = new DBConnect())
            {
                var q = from t in dbc.t_costume_reservation
                        select t.costume_reservation_code;
                var str = q.ToList().Max();
                int i;
                if (!int.TryParse(str, out i))
                    i = 0;
                else
                    i++;
                res = $"{i:00000000}";
            }
            return res;
        }

        public static t_costume_reservation getSingle(string costume_reservation_code)
        {
            t_costume_reservation s = null;
            using (var dbc = new DBConnect())
            {
                s = dbc.t_costume_reservation.SingleOrDefault(x => x.costume_reservation_code == costume_reservation_code);
            }
            return s;
        }
    }

}
