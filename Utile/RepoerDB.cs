using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace 写真館システム.Utile
{
    class RepoerDB
    {
        private string constr = @"Data Source = Asset/ReportData.sdf";
        private string table { get; set; }

        public RepoerDB(string _table)
        {
            table = _table;
        }

        public void deleteAll()
        {
            //全データ削除
            using (var con = new SqlCeConnection(constr))
            using (var command = con.CreateCommand())
            {
                try
                {

                    con.Open();
                    StringBuilder sbSql = new StringBuilder();

                    sbSql.Append(@"DELETE FROM [@table]".Replace("@table", table));
                    command.CommandText = sbSql.ToString();
                    command.ExecuteNonQuery();

                }
                catch (SqlCeException e)
                {
                    ShowErrors(e);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }

        public void insert(Dictionary<string,string> item)
        {

            //一つ登録
            using (var con = new SqlCeConnection(constr))
            using (var command = con.CreateCommand())
            {
                try
                {

                    con.Open();

                    StringBuilder sbSql = new StringBuilder();
                    StringBuilder sbColmun = new StringBuilder();
                    StringBuilder sbData = new StringBuilder();

                    foreach (var colmun in item)
                    {
                        sbColmun.Append(@"[@colmun]".Replace("@colmun", colmun.Key));
                        if (item.Keys.Last() != colmun.Key)
                        {
                            sbColmun.Append(@",");
                        }
                        sbData.Append(@"@@colmun".Replace("@colmun", colmun.Key));
                        if (item.Keys.Last() != colmun.Key)
                        {
                            sbData.Append(@",");
                        }
                        command.Parameters.Add(new SqlCeParameter("@@colmun".Replace("@colmun", colmun.Key), colmun.Value));
                    }

                    sbSql.Append(@"INSERT INTO[@table]".Replace("@table", table));
                    sbSql.Append(@"(");
                    sbSql.Append(sbColmun.ToString());
                    sbSql.Append(@")");
                    sbSql.Append(@"VALUES");
                    sbSql.Append(@"(");
                    sbSql.Append(sbData.ToString());
                    sbSql.Append(@")");
                    sbSql.Append(@";");

                    command.CommandText = sbSql.ToString();

                    command.ExecuteNonQuery();

                }
                catch (SqlCeException e)
                {
                    ShowErrors(e);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }

        }

        public static void ShowErrors(SqlCeException e)
        {
            SqlCeErrorCollection errorCollection = e.Errors;

            StringBuilder bld = new StringBuilder();
            Exception inner = e.InnerException;

            foreach (SqlCeError err in errorCollection)
            {
                bld.Append("\n Error Code: " + err.HResult.ToString("X"));
                bld.Append("\n Message   : " + err.Message);
                bld.Append("\n Minor Err.: " + err.NativeError);
                bld.Append("\n Source    : " + err.Source);

                foreach (int numPar in err.NumericErrorParameters)
                {
                    if (0 != numPar) bld.Append("\n Num. Par. : " + numPar);
                }

                foreach (string errPar in err.ErrorParameters)
                {
                    if (String.Empty != errPar) bld.Append("\n Err. Par. : " + errPar);
                }

                MessageBox.Show(bld.ToString());
                bld.Remove(0, bld.Length);
            }
        }
    }
}
