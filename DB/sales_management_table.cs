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
    [Table("t_sales_management", Schema = "public")]
    public class t_sales_management : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //発注コード
        [Column("order_code")] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String order_code { get; set; }

        //店舗コード
        [Column("store")] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String store { get; set; }

        //スタッフコード
        [Column("staff")] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String staff { get; set; }

        //注文・申込日
        [Column("order_date")] // データベース上のカラム名を入力。
        public DateTime order_date { get; set; }

        //売上日
        [Column("sales_date")] // データベース上のカラム名を入力。
        public DateTime sales_date { get; set; }

        //売上金額
        [Column("sales_amount")] // データベース上のカラム名を入力。
        public int sales_amount { get; set; }

        //割引金額
        [Column("discount_amount")] // データベース上のカラム名を入力。
        public int discount_amount { get; set; }

        //顧客コード
        [Column("customer_code")] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String customer_code { get; set; }

        //備考
        [Column("remarks")] // データベース上のカラム名を入力。
        //[MaxLength(255)]
        public String remarks { get; set; }

        //預かりアルバム
        [Column("keeping_album")] // データベース上のカラム名を入力。
        //[MaxLength(45)]
        public String keeping_album { get; set; }

        //施設コード
        [Column("facility_code")] // データベース上のカラム名を入力。
        //[MaxLength(45)]
        public String facility_code { get; set; }

        //仕上り連絡先
        [Column("contacts")] // データベース上のカラム名を入力。
        //[MaxLength(45)]
        public String contacts { get; set; }

        //仕上り連絡先電話番号
        [Column("phone_number")] // データベース上のカラム名を入力。
        //[MaxLength(13)]
        public String phone_number { get; set; }

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
        //public virtual m_store Store { get; set; }
        //public virtual m_facility Facility { get; set; }
        //public virtual ICollection<t_sales_statement> Sales_Statement { get; set; }
        //public virtual ICollection<t_facility_reservation>Facility_Reservation { get; set; }
        //public virtual ICollection<t_selection> Selection { get; set; }
        //public virtual ICollection<t_payment_management> _Payment_Management { get; set; }
        //public virtual ICollection<t_progress> Progress { get; set; }
        
        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;

                var data = dbc.t_sales_management.SingleOrDefault(x => x.order_code == this.order_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.t_sales_management.Add(this);
                }
                else
                {
                    data.contacts = this.contacts;
                    data.customer_code = this.customer_code;
                    data.discount_amount = this.discount_amount;
                    data.facility_code = this.facility_code;
                    data.keeping_album = this.keeping_album;
                    data.order_code = this.order_code;
                    data.order_date = this.order_date;
                    data.phone_number = this.phone_number;
                    data.remarks = this.remarks;
                    data.sales_amount = this.sales_amount;
                    data.sales_date = this.sales_date;
                    data.staff = this.staff;
                    data.store = this.store;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
    }
}
