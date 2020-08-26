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
    [Table("t_payment_management", Schema = "public")]
    public class t_payment_management : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //発注コード
        [Column("order_code")] // データベース上のカラム名を入力。
        //[ForeignKey("order_code")]
        //[MaxLength(8)]
        public String order_code { get; set; }

        //年月日
        [Column("date")] // データベース上のカラム名を入力。
        public DateTime date { get; set; }

        //時分
        [Column("time")] // データベース上のカラム名を入力。
        public DateTime time { get; set; }

        //担当者
        [Column("staff")] // データベース上のカラム名を入力。
        //[MaxLength(40)]
        public String staff { get; set; }

        //入金区分
        [Column("deposit_class")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String deposit_class { get; set; }

        //金額
        [Column("amount")] // データベース上のカラム名を入力。
        public int amount { get; set; }

        //備考
        [Column("reason")] // データベース上のカラム名を入力。
        //[MaxLength(255)]
        public String reason { get; set; }

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


        //リレーション
        //public virtual t_sales_management Sales_Management { get; set; }

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;

                var data = dbc.t_payment_management.SingleOrDefault(x => x.order_code == this.order_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.t_payment_management.Add(this);
                }
                else
                {
                    
                    data.amount = this.amount;
                    data.date = this.date;
                    data.deposit_class = this.deposit_class;
                    data.order_code = this.order_code;
                    data.reason = this.reason;
                    data.staff = this.staff;
                    data.time = this.time;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
    }
}
