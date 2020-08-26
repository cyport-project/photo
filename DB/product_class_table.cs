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
    [Table("m_product_class", Schema = "public")]

    public class m_product_class : base_table
    {

        //商品区分
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("product_class")] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String product_class { get; set; }

        //商品区分名
        [Column("product_class_name")] // データベース上のカラム名を入力。
        //[MaxLength(40)]
        public String product_class_name { get; set; }

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


        //リレーションシップ
        //public virtual ICollection<m_product> Product { get; set; }
        //public virtual ICollection<t_sales_statement> Sales_Statements { get; set; }

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

                var data = dbc.m_product_class.SingleOrDefault(x => x.product_class == this.product_class);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_product_class.Add(this);
                }
                else
                {
                    if(delete_flag == "0")
                    {
                        data.product_class = this.product_class;
                        data.product_class_name = this.product_class_name;
                    }
                    data.delete_flag = this.delete_flag;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
    }
}
