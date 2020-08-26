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
    [Table("t_sales_statement", Schema = "public")]

    public class t_sales_statement : base_table
    {
        [Key] // 主キーを設定。
        //発注コード
        [Column("order_code", Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String order_code { get; set; }

        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //枝番
        [Column("branch_number", Order = 1)] // データベース上のカラム名を入力。
        public int branch_number { get; set; }

        //商品区分
        [Column("product_class")] // データベース上のカラム名を入力。
        // [ForeignKey("product_class")]
        //[MaxLength(1)]
        public String product_class { get; set; }

        //商品コード
        [Column("product_code")] // データベース上のカラム名を入力。
        //[ForeignKey("product_code")]
        //[MaxLength(8)]
        public String product_code { get; set; }

        //摘要
        [Column("remarks")] // データベース上のカラム名を入力。
        //[MaxLength(255)]
        public String remarks { get; set; }

        //金額
        [Column("amount")] // データベース上のカラム名を入力。
        public int amount { get; set; }

        //売上日
        [Column("sales_date")] // データベース上のカラム名を入力。
        public DateTime sales_date { get; set; }

        //数量
        [Column("quantity")] // データベース上のカラム名を入力。
        public int quantity { get; set; }

        //税
        [Column("tax")] // データベース上のカラム名を入力。
        public int tax { get; set; }

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
        //public virtual m_product Product { get; set; }
        //public virtual m_product_class Product_Class { get; set; }

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;

                var data = dbc.t_sales_statement.SingleOrDefault(x => x.order_code == this.order_code 
                                                          & x.branch_number == this.branch_number);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.t_sales_statement.Add(this);
                }
                else
                {
                    data.amount = this.amount;
                    data.branch_number = this.branch_number;
                    data.order_code = this.order_code;
                    data.product_class = this.product_class;
                    data.product_code = this.product_code;
                    data.quantity = this.quantity;
                    data.remarks = this.remarks;
                    data.sales_date = this.sales_date;
                    data.tax = this.tax;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
    }
}
