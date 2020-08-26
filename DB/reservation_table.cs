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
    [Table("t_reservation", Schema = "public")]

    public class t_reservation : base_table
    {
        [Key] // 主キーを設定。
        //受付コード
        [Column("reception_code", Order = 0)]
        //[MaxLength(8)]
        public String reservation_code { get; set; }
        
        [Key] // 主キーを設定。
        //施設予約コード
        [Column("facility_reservation_code", Order = 1)]
        //[MaxLength(8)]
        public String facility_reservation_code { get; set; }

        [Key] // 主キーを設定。
            //衣裳予costume_reservation_code約コード
        [Column("costume_reservation_code", Order = 2)]
        //[MaxLength(8)] 
        public String costume_reservation_code { get; set; }

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
        //public virtual ICollection<t_costume_reservation> Costume_Reservations{ get; set; }
        //public virtual ICollection<t_facility_reservation> Facility_Reservations { get; set; }

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                if (delete)
                {
                    //削除
                    dbc.t_reservation.Attach(this);
                    dbc.t_reservation.Remove(this);
                }
                else
                {
                    //更新情報
                    this.update_date = DateTime.Now.Date;
                    this.update_staff = MainForm.session_m_staff.staff_name;

                    var data = dbc.t_reservation.SingleOrDefault(x => x.reservation_code == this.reservation_code
                                                          & x.facility_reservation_code == this.facility_reservation_code
                                                          & x.costume_reservation_code == this.costume_reservation_code);

                    if (data == null)
                    {
                        //新規登録
                        this.registration_date = DateTime.Now.Date;
                        this.registration_staff = MainForm.session_m_staff.staff_name;
                        dbc.t_reservation.Add(this);
                    }
                    else
                    {
                        data.costume_reservation_code = this.costume_reservation_code;
                        data.facility_reservation_code = this.facility_reservation_code;
                        data.reservation_code = this.reservation_code;
                        data.update_date = this.update_date;
                        data.update_staff = this.update_staff;
                    }
                }

                dbc.SaveChanges();
            }

        }

        public static t_reservation getSingleFacility_reservation_code(string facility_reservation_code)
        {
            t_reservation res = null;
            using (var dbc = new DBConnect())
            {
                res = dbc.t_reservation.SingleOrDefault(x => x.facility_reservation_code == facility_reservation_code);
            }
            return res;
        }

        public static t_reservation getSingleCostume_reservation_code(string costume_reservation_code)
        {
            t_reservation res = null;
            using (var dbc = new DBConnect())
            {
                res = dbc.t_reservation.SingleOrDefault(x => x.costume_reservation_code == costume_reservation_code);
            }
            return res;
        }
    }
}
