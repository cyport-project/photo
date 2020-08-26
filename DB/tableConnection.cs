using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Npgsql;

namespace 写真館システム.DB
{


    public class DBConnect : DbContext , IDisposable
    {
        public NpgsqlConnection npg;

        #region 接続プロパティ

        /// <summary>
        /// テーブル接続情報。
        /// </summary>
        public DbSet<t_costume_reservation> t_costume_reservation { get; set; }
        public DbSet<m_customer> m_customer { get; set; }
        public DbSet<t_facility_reservation> t_facility_reservation { get; set; }
        public DbSet<m_facility> m_facility { get; set; }
        public DbSet<t_reception> t_reception { get; set; }
        public DbSet<t_reservation> t_reservation { get; set; }
        public DbSet<m_store> m_store { get; set; }
        public DbSet<m_constant>m_constant { get; set; }
        public DbSet<m_costume> m_costume { get; set; }
        public DbSet<m_family> m_family { get; set; }
        public DbSet<m_member> m_member { get; set; }
        public DbSet<m_product> m_product { get; set; }
        public DbSet<m_product_class> m_product_class { get; set; }
        public DbSet<m_staff> m_staff { get; set; }
        public DbSet<m_staff_shift> m_staff_shift { get; set; }
        public DbSet<m_task> m_task { get; set; }
        public DbSet<t_calendar_information> t_calendar_information { get; set; }
        public DbSet<t_payment_management> t_payment_management { get; set; }
        public DbSet<t_progress> t_progress { get; set; }
        public DbSet<t_sales_management> t_sales_management { get; set; }
        public DbSet<t_sales_statement> t_sales_statement { get; set; }
        public DbSet<t_selection> t_selection { get; set; }
        public DbSet<t_shooting_data> t_shooting_data { get; set; }
        #endregion



        #region メソッド

        /// <summary>
        /// コネクションの取得。
        /// </summary>
        /// 

        static NpgsqlConnection GetConnecting()
        {
            //接続用文字列生成（App.configを参照）
            string db_access = System.Configuration.ConfigurationManager.AppSettings["dbServer"];
            db_access += System.Configuration.ConfigurationManager.AppSettings["dbPort"];
            db_access += System.Configuration.ConfigurationManager.AppSettings["dbDatabase"];
            db_access += System.Configuration.ConfigurationManager.AppSettings["dbUser"];
            db_access += System.Configuration.ConfigurationManager.AppSettings["dbPassword"];
            return new NpgsqlConnection(db_access);
            
        }


        #endregion

        #region コンストラクタ。

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public DBConnect()
            : base(GetConnecting(), true)
        {
            npg = GetConnecting();
        }

        #endregion

        #region デストラクタ。

        /// <summary>
        /// デストラクタ。
        /// </summary>
        ~DBConnect()
        {
            if(npg.State == System.Data.ConnectionState.Open)
                npg.Close();
        }
        #endregion

        
        /// <summary>
        /// ディスペース。
        /// </summary>
        public void Dispose()
        {
            if (npg.State == System.Data.ConnectionState.Open)
                npg.Close();

        }
        

    }

}
