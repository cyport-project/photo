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
    [Table("t_selection", Schema = "public")]
    public class t_selection : base_table
    {
        [Key] // 主キーを設定。
        //予約コード
        [Column("reception_code",Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String reception_code { get; set; }

        [Key] // 主キーを設定。
        //色
        [Column("color", Order = 1)] // データベース上のカラム名を入力。
        public int color { get; set; }

        //商品名
        [Column("product_name")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String product_name { get; set; }

        //フォルダ名
        [Column("folder_name")] // データベース上のカラム名を入力。
        //[MaxLength(255)]
        public String folder_name { get; set; }

        //画像数
        [Column("images")] // データベース上のカラム名を入力。
        public int images { get; set; }

        //発注コード
        [Column("order_code")] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String order_code { get; set; }

        //店舗コード
        [Column("store_code")] // データベース上のカラム名を入力。
        //[ForeignKey("store_code")]
        //[MaxLength(8)]
        public String store_code { get; set; }

        //登録日
        [Column("registration_date")]
        public DateTime? registration_date { get; set; }

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
        //public virtual t_sales_management Sales_Management { get; set; }
        //public virtual t_reception Reception { get; set; }

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;

                var data = dbc.t_selection.SingleOrDefault(x => x.reception_code == this.reception_code 
                                                    & x.color == this.color);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.t_selection.Add(this);
                }
                else
                {
                    //更新
                    data.color = this.color;
                    data.folder_name = this.folder_name;
                    data.images = this.images;
                    data.order_code = this.order_code;
                    data.product_name = this.product_name;
                    data.reception_code = this.reception_code;
                    data.store_code = this.store_code;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }

        public static t_selection getFirst(string code)
        {
            t_selection s;
            using (var dbc = new DBConnect())
            {
                s = dbc.t_selection.FirstOrDefault(x => x.reception_code == code);

            }
            return s;
        }
    }
}
