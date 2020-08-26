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
    [Table("m_product", Schema = "public")]

    public class m_product : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //商品区分
        [Column("product_class",Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String product_class { get; set; }

        [Key] // 主キーを設定。
        //商品コード
        [Column("product_code", Order = 1)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String product_code { get; set; }

        //商品名
        [Column("product_name")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String product_name { get; set; }

        //販売単位
        [Column("sales_unit")] // データベース上のカラム名を入力。
        public int sales_unit { get; set; }

        //大ジャンル
        [Column("large_genre")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String large_genre { get; set; }

        //小ジャンル
        [Column("small_genre")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String small_genre { get; set; }

        //ページ数
        [Column("page")] // データベース上のカラム名を入力。
        public int page { get; set; }

        //メーカー
        [Column("maker")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String maker { get; set; }

        //単価
        [Column("price")] // データベース上のカラム名を入力。
        public int price { get; set; }

        //割引可否区分
        [Column("discount_class")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String discount_class { get; set; }

        //課税区分
        [Column("tax_class")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String tax_class { get; set; }

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
        //public virtual ICollection<t_sales_statement> Sales_Statement { get; set; }
        //public virtual m_product_class Product_Class { get; set; }

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

                var data = dbc.m_product.SingleOrDefault(x => x.product_class == this.product_class
                                                  & x.product_code == this.product_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_product.Add(this);
                }
                else
                {
                    if(delete_flag == "0")
                    {
                        data.discount_class = this.discount_class;
                        data.large_genre = this.large_genre;
                        data.maker = this.maker;
                        data.page = this.page;
                        data.price = this.price;
                        data.product_class = this.product_class;
                        data.product_code = this.product_code;
                        data.product_name = this.product_name;
                        data.sales_unit = this.sales_unit;
                        data.small_genre = this.small_genre;
                        data.tax_class = this.tax_class;
                    }
                    data.delete_flag = this.delete_flag;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
        public static Dictionary<string, string> getProductList()
        {
            Dictionary<string,string> productList = new Dictionary<string, string>();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"SELECT product_code,product_name ");
                sb.Append(@"FROM public.m_product ");
                sb.Append(@"where delete_flag = '0' ");
                sb.Append(@"order by product_code asc ");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    productList.Add((string)dataReader["product_code"], (string)dataReader["product_name"]);
                }
            }
            return productList;
        }
    }
}
