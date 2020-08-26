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
    [Table("m_constant", Schema = "public")]
    public class m_constant : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //消費税率
        [Column("sales_tax_rate")] // データベース上のカラム名を入力。
        public float sales_tax_rate { get; set; }

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

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                //更新情報
                this.update_date = DateTime.Now.Date;

                this.update_staff = MainForm.session_m_staff.staff_name;
                var data = dbc.m_constant.SingleOrDefault(x => x.sales_tax_rate == this.sales_tax_rate);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;

                    dbc.m_constant.Add(this);
                }
                else
                {
                    data.sales_tax_rate = this.sales_tax_rate;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
    }
}
