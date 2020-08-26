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
    [Table("t_progress", Schema = "public")]
    public class t_progress : base_table
    {
        //発注コード
        [Key]
        [Column("order_code",Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String order_code { get; set; }

        //行程区分
        [Key]
        [Column("process_class", Order = 1)] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String process_class { get; set; }

        //年月日
        [Column("date")] // データベース上のカラム名を入力。
        public DateTime date { get; set; }

        //担当者
        [Column("staff")] // データベース上のカラム名を入力。
        //[MaxLength(40)]
        public String staff { get; set; }

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

                var data = dbc.t_progress.SingleOrDefault(x => x.order_code == this.order_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.t_progress.Add(this);
                }
                else
                {
                    data.date = this.date;
                    data.order_code = this.order_code;
                    data.process_class = this.process_class;
                    data.staff = this.staff;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
    }
}
