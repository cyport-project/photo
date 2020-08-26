using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 写真館システム
{
    public partial class Staff_shift : UserControlExp
    {
        //ローカル変数の宣言
        private DateTime l_calenderdata = DateTime.Now.Date;
        private string l_store = "";
        private string const_enddate = "00:00";
        private string const_startdate = "00:00";

        //入力チェック
        private checkOperation chk;

        //スタッフ構造体
        private Dictionary<string, string> m_staffList;

        //スタッフシフト構造体の生成
        public List<DB.m_staff_shift> staffshiftList = new List<DB.m_staff_shift>();

        //店舗構造体の生成
        public struct storeCodeArray
        {
            public string store_code;
            public string store_name;
        }
        //店舗リスト生成
        List<storeCodeArray> storeCodeList = new List<storeCodeArray>();
        List<Dictionary<string, object>> m_storeList;

        //就業区分カラムの生成
        public DataGridViewComboBoxColumn column_workclass = new DataGridViewComboBoxColumn();
        //就業区分コンボボックスコントロール用変数
        private DataGridViewComboBoxEditingControl workclassGridViewComboBox = null;

        //自画面より遷移
        public Boolean SelfViewing = false;

        //表のカレント行の確保
        private int current_index;

        //コンストラクタ
        public Staff_shift()
        {
            InitializeComponent();
            //datagridviewの枠生成
            GridViewInit();

        }

        //グリッドビューの枠設定
        private void GridViewInit()
        {
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
 
            //DataGridView1のカラムの幅をユーザーが変更できないようにする
            dataGridView1.AllowUserToResizeColumns = false;            
            //DataGridView1の行の高さをユーザーが変更できないようにする
            dataGridView1.AllowUserToResizeRows = false;



            dataGridView1.RowTemplate.Height = (dataGridView1.Size.Height - 20) / 25;
            
            //25行固定の表を作成
            for (var i = 0; i < 24; i++)
            {
                dataGridView1.Rows.Add();

            }
            //1列目を編集不可に設定
            dataGridView1.Columns[1].ReadOnly = true;
            //dataGridView1.SelectedColumns(1).ReadOnly = true;
        }

        public override void PageRefresh()
        {
            //入力チェック初期化
            chk = new checkOperation(this);
            //チェックリセット
            chk.clear();

            if (!SelfViewing)　//初期表示時に編集
            {
                //初期表示時、本日日付をセット
                l_calenderdata = DateTime.Now.Date;

                //初期表示時、ログインスタッフ情報をセット
                l_store = MainForm.session_m_staff.store_code;

                //初回データベース読み込み
                //storeマスタ読み込み
                m_storeList = DB.m_store.getStoreList();

                //店舗の設定
                StorecomboboxSet();

                //就業区分列を作成
                //まずは、カラムを作成
                WorkclassSet();

            }
            else
            {
                //シフト表の設定
                //初期化
                //(0, 0)を現在のセルにする
                dataGridView1.Rows[0].Visible = true;
                dataGridView1.CurrentCell = dataGridView1[0, 0];
                //行の初期化
                for (var i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    dataGridView1.Rows[i].Cells["No"].Value = "";
                    dataGridView1.Rows[i].Cells["Staff"].Value = "";
                    dataGridView1.Rows[i].Cells["WorkClass"].Value = "";
                    dataGridView1.Rows[i].Cells["StartTime"].Value = "";
                    dataGridView1.Rows[i].Cells["EndTime"].Value = "";
                }
            }

            //staffマスタ再読み込み
            m_staffList = DB.m_staff.getStaffList(l_store);

            //基準時間取得
            const_startdate = DB.m_store.getSingle(l_store).start_time.ToString(@"hh\:mm");
            const_enddate = DB.m_store.getSingle(l_store).end_time.ToString(@"hh\:mm");

            //カレンダーの設定
            monthCalendar1.SetDate(l_calenderdata);

            //年の設定
            t_year.Text = l_calenderdata.Year.ToString("0000") + "年";

            //月日の設定
            t_days.Text = l_calenderdata.Month.ToString("0") + "月" +
                l_calenderdata.Day.ToString("0") + "日" + "(" +
                l_calenderdata.Date.ToString("dddd") + ")";

            //スタッフ名列を作成
            //スタッフ名を表示して、データベースの内容か？
            //初期値をsっていするかを決定
            StaffSet();
        }
        //店舗コンボボックスの設定
        private void StorecomboboxSet()
        {
            storeCodeList.Clear();
            foreach ( var m_store in m_storeList )
            {
                storeCodeList.Add(new storeCodeArray
                {
                    store_code = m_store["store_code"].ToString(),
                    store_name = m_store["store_name"].ToString()
                });
            }

            // コンボボックス初期設定
            //店舗名
            co_store.Items.Clear();
            for (var i = 0; i < storeCodeList.Count; i++)
            {
                co_store.Items.Add(storeCodeList[i].store_name);
            }

            var index = storeCodeList.FindIndex(x => x.store_code == l_store);
            co_store.SelectedIndex = index ;
        }

        //スタッフ列の設定
        private void StaffSet()
        {
            var index = 0;
            foreach (KeyValuePair<string, string> kvp in m_staffList)
            {
                dataGridView1.Rows[index].Visible = true;
                dataGridView1.Rows[index].Cells["StaffCode"].Value = kvp.Key;
                dataGridView1.Rows[index].Cells["Staff"].Value = kvp.Value;
                dataGridView1.Rows[index].Cells["No"].Value = index + 1;
                //stafshift読み込み
                DB.m_staff_shift staff_shift = DB.m_staff_shift.getSingle2(l_store, kvp.Key, l_calenderdata);

                if(staff_shift != null)
                {
                    dataGridView1.Rows[index].Cells["WorkClass"].Value = staff_shift.work_class;
                    dataGridView1.Rows[index].Cells["StartTime"].Value = staff_shift.start_time.ToString(@"hh\:mm");
                    dataGridView1.Rows[index].Cells["EndTime"].Value = staff_shift.end_time.ToString(@"hh\:mm");
                }
                else
                {
                    dataGridView1.Rows[index].Cells["WorkClass"].Value = "0";
                    dataGridView1.Rows[index].Cells["StartTime"].Value = const_startdate;
                    dataGridView1.Rows[index].Cells["EndTime"].Value = const_enddate;
                }

                index ++;
            }
            //空白行表を削除
  //          for (var i = index; index < 24; index++)
  //          {
                //dataGridView1.Rows[index].Visible = false;
                //dataGridView1.Rows.RemoveAt(22);
  //          }
        }
        //就業区分の設定
        private void WorkclassSet()
        {
            DataTable WorkclassTable = new DataTable();
            WorkclassTable.Columns.Add("Display", typeof(string));
            WorkclassTable.Columns.Add("Value", typeof(string));

            foreach (Utile.Data.就業区分 kvp in Enum.GetValues(typeof(Utile.Data.就業区分)))
            {
                WorkclassTable.Rows.Add(Enum.GetName(typeof(Utile.Data.就業区分), (int)kvp),
                    (int)kvp);
            }


            column_workclass.DataSource = WorkclassTable;

            column_workclass.ValueMember = "Value";
            column_workclass.DisplayMember = "Display";


            column_workclass.Name = "WorkClass";
            column_workclass.DataPropertyName = dataGridView1.Columns["WorkClass"].DataPropertyName;

            column_workclass.HeaderText = "就業区分";
            
            dataGridView1.Columns.Remove("WorkClass");
            dataGridView1.Columns.Insert(2, column_workclass);

        }


        //カレンダーの日付[変更]処理
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            l_calenderdata = e.Start;

            if (l_calenderdata == null) return;

            //再描画
            SelfViewing = true;
            MainForm.Staff_shift.PageRefresh();

        }

        //店舗名変更時のイベント
        private void co_Store_TextChanged(object sender, EventArgs e)
        {
            if (co_store.Text == null) return;

            l_store = storeCodeList.Find(x => x.store_name == co_store.Text).store_code;

            //再描画
            SelfViewing = true;
            MainForm.Staff_shift.PageRefresh();

        }

        //◀ボタン[クリック]処理
        private void b_decrease_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.SetDate(monthCalendar1.SelectionStart.AddDays(-1));
        }

        //▶ボタン[クリック]処理
        private void b_increase_MouseClick(object sender, MouseEventArgs e)
        {
            monthCalendar1.SetDate(monthCalendar1.SelectionStart.AddDays(1));
        }

        //dataGridViewを選択したときのイベント
        //セルの編集用のコントロールが表示されているときに発生します。
        private void dataGridView1_EditingCntorlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            
            //表示されているコントロールがDataGridViewComboBoxEditingControlか調べる
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                //選択行の退避
                current_index = dgv.CurrentRow.Index;

                if (m_staffList.Count < 1) return;

                //該当する列が就業区分か調べる

                if (dgv.CurrentCell.OwningColumn.Name == "WorkClass")
                {
                    //編集のために表示されているコントロールを取得
                    this.workclassGridViewComboBox =
                        (DataGridViewComboBoxEditingControl)e.Control;
                    //SelectedIndexChangedイベントハンドラを追加
                    this.workclassGridViewComboBox.SelectedIndexChanged +=
                        new EventHandler(workclassGridViewComboBox_SelectedIndexChanged);
                }

            }
            else
            {
                if (dgv.CurrentCell.OwningColumn.Name == "No")
                {
                    //選択されたら、行選択にする
                    dataGridView1.Rows[dgv.CurrentRow.Index].Selected = true;
                }
            }

            SelfViewing = true;
        }

        //CellEndEditイベントハンドラ 
        //現在選択されているセルに対して編集モードが停止した場合に発生します。
        private void dataGridView1_CellEndEdit(object sender,
            DataGridViewCellEventArgs e)
        {
            //SelectedIndexChangedイベントハンドラを削除
            if (this.workclassGridViewComboBox != null)
            {
                this.workclassGridViewComboBox.SelectedIndexChanged -=
                    new EventHandler(workclassGridViewComboBox_SelectedIndexChanged);
                this.workclassGridViewComboBox = null;
            }
        }
        
        //DataGridViewに表示されているコンボボックスの
        //SelectedIndexChangedイベントハンドラ
        private void workclassGridViewComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            //dataGridViewのカラムを参照しては、nullになってしまう…
            ComboBox combobox = (ComboBox)sender;

            string selectWorkClass = (string)combobox.SelectedIndex.ToString();

            if (selectWorkClass.Equals("2")){
                dataGridView1.Rows[current_index].Cells["StartTime"].Value = "00:00";
                dataGridView1.Rows[current_index].Cells["EndTime"].Value = "00:00";
                dataGridView1.Rows[current_index].Cells["StartTime"].ReadOnly = true;
                dataGridView1.Rows[current_index].Cells["EndTime"].ReadOnly = true;
            }
            else
            {
                dataGridView1.Rows[current_index].Cells["StartTime"].Value = const_startdate;
                dataGridView1.Rows[current_index].Cells["EndTime"].Value = const_enddate;
                dataGridView1.Rows[current_index].Cells["StartTime"].ReadOnly = false;
                dataGridView1.Rows[current_index].Cells["EndTime"].ReadOnly = false;
            }



        }

        //DataGridView コントロールで現在のセルが変更されたとき、
        //またはこのコントロールが入力フォーカスを受け取ったときに発生します。
        /*
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;

            if ((dgv.Columns[e.ColumnIndex].Name == "Staff" ||
                 dgv.Columns[e.ColumnIndex].Name == "WorkClass")
                 &&
                 dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                SendKeys.Send("{F4}");
            }
        }
        */

        //予想しない入力があった場合の措置
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show(this,
                    string.Format("({0}, {1}) のセルでエラーが発生しました。\n\n説明: {2}",
                    e.ColumnIndex, e.RowIndex, e.Exception.Message),
                    "エラーが発生しました",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            //ひとつ前の画面に戻る
            SelfViewing = false;
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            chk.clear();

            //必須入力チェック（スタッフが選択時、他の項目がブランクの場合はエラー）
            //　必須チェック
            chk.addControl(co_store);
            if (chk.check("W00000", chk.checkControlImportant))
                return;

            for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Staff"].Value == null　||
                    dataGridView1.Rows[i].Cells["Staff"].Value.ToString() == "") break;

                if (dataGridView1.Rows[i].Cells["StartTime"].Value == null ||
                    dataGridView1.Rows[i].Cells["EndTime"].Value == null ||
                        dataGridView1.Rows[i].Cells["WorkClass"].Value == null)
                {
                    dataGridView1.Rows[i].Selected = true;
                    Utile.Message.showMessageOK("E11005");
                    return;
                }

            }


            //フォーマットチェック（日付: HH: MM）　HH：0～23MM：0~59
            for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Staff"].Value == null ||
                    dataGridView1.Rows[i].Cells["Staff"].Value.ToString() == "") break;

                if (!System.Text.RegularExpressions.Regex.IsMatch(
                   dataGridView1.Rows[i].Cells["StartTime"].Value.ToString(),
                      @"\A[0-2][0-9]:[0-5][0-9]\z"))
                {
                    dataGridView1.Rows[i].Selected = true;
                    var msg = Utile.Message.message["W00003"].Replace("@フォーマット",
                        dataGridView1.Rows[i].Cells["StartTime"].Value.ToString());
                    Utile.Message.showMessageOK("W00003", msg);

                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(
                    dataGridView1.Rows[i].Cells["EndTime"].Value.ToString(),
                       @"\A[0-2][0-9]:[0-5][0-9]\z"))
                {
                    dataGridView1.Rows[i].Selected = true;
                    var msg = Utile.Message.message["W00003"].Replace("@フォーマット",
                        dataGridView1.Rows[i].Cells["EndTime"].Value.ToString());
                    Utile.Message.showMessageOK("W00003", msg);
                    return;
                }

            }

            //開始時間 < 終了時間をチェック
            for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Staff"].Value == null ||
                    dataGridView1.Rows[i].Cells["Staff"].Value.ToString() == "") break;

                if (dataGridView1.Rows[i].Cells["WorkClass"].Value.ToString() == "2") break;

                var StartTime = int.Parse(dataGridView1.Rows[i].Cells["StartTime"].Value.ToString().Substring(0, 2) +
                    dataGridView1.Rows[i].Cells["StartTime"].Value.ToString().Substring(3, 2));
                var EndTime = int.Parse(dataGridView1.Rows[i].Cells["EndTime"].Value.ToString().Substring(0, 2) +
                    dataGridView1.Rows[i].Cells["EndTime"].Value.ToString().Substring(3, 2));

                if (dataGridView1.Rows[i].Cells[1].Value == null) break;

                if (StartTime > 2359)
                {
                    dataGridView1.Rows[i].Selected = true;
                    Utile.Message.showMessageOK("E11003");
                    return;
                }
                if (EndTime > 2359)
                {
                    dataGridView1.Rows[i].Selected = true;
                    Utile.Message.showMessageOK("E11003");
                    return;
                }


                if (StartTime >= EndTime)
                {
                    dataGridView1.Rows[i].Selected = true;
                    Utile.Message.showMessageOK("E11002");
                    return;
                }

            }
            //DB処理
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                using (var transaction = dbc.npg.BeginTransaction())
                {
                    try
                    {
                        //削除処理
                        var staff_shift = dbc.m_staff_shift;
                        //var delete_data = dbc.m_staff_shift.Where(x => x.work_day == l_calenderdata && x.store_code==l_store).Select(x=>x.work_day);

                        var delete_data = from ss in dbc.m_staff_shift
                                          where ss.work_day == l_calenderdata & ss.store_code == l_store
                                          select ss;
                        foreach (var data in delete_data)
                        {
                            dbc.m_staff_shift.Remove(data);
                        }

                        dbc.SaveChanges();

                        //登録処理
                        for (var i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells["Staff"].Value == null ||
                                dataGridView1.Rows[i].Cells["Staff"].Value.ToString() == "") break;

                            DB.m_staff_shift staff_Shift = new DB.m_staff_shift();

                            var l_staff_code = dataGridView1.Rows[i].Cells["StaffCode"].Value.ToString();
                            var register_data = staff_shift.FirstOrDefault(x => x.work_day == l_calenderdata
                                                                     && x.store_code == l_store
                                                                     && x.staff_code == l_staff_code);
                            if (register_data == null)
                            {
                                staff_Shift.work_day = l_calenderdata;
                                staff_Shift.store_code = l_store;
                                staff_Shift.staff_code = l_staff_code; 
                                staff_Shift.start_time = TimeSpan.Parse(dataGridView1.Rows[i].Cells["StartTime"].Value.ToString());
                                staff_Shift.end_time = TimeSpan.Parse(dataGridView1.Rows[i].Cells["EndTime"].Value.ToString());
                                staff_Shift.registration_date = DateTime.Now.Date;
                                staff_Shift.registration_staff = MainForm.session_m_staff.staff_name;
                                staff_Shift.update_date = DateTime.Now.Date;
                                staff_Shift.work_class = dataGridView1.Rows[i].Cells["WorkClass"].Value.ToString();
                                staff_Shift.update_staff = MainForm.session_m_staff.staff_name;
                                staff_Shift.delete_flag = "0";
                                dbc.m_staff_shift.Add(staff_Shift);
                                dbc.SaveChanges();
                            }
                            else
                            {
                                Utile.Message.showMessageOK("E11004");
                                transaction.Rollback();
                                return;
                            }

                        }

                        transaction.Commit();
                    }
                    catch (SqlCeException)
                    {
                        Utile.Message.showMessageOK("E11006");
                        transaction.Rollback();
                    }
                }
            }
            //ひとつ前の画面に戻る
            SelfViewing = false;
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        //削除ボタン押下自のイベント
        //削除ボタンが存在したが、いらなくなった…
        /*
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DataGridView1で選択されているすべての行を削除する
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dataGridView1.Rows.Remove(r);
                    dataGridView1.Rows.Add();

                }
            }
            for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Staff"].Value == null) break;

                if (dataGridView1.Rows[i].Cells["Staff"].Value.ToString().Length > 0)
                {
                    dataGridView1.Rows[i].Cells["No"].Value = i + 1;
                }
            }
        }
        */
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var table = "Staff_Shift";
            Utile.RepoerDB rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();
            Console.WriteLine(dataGridView1.RowCount);
            for (var i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value == null) break;
                //int data = -1;
                Dictionary<string, string> dataitem = new Dictionary<string, string>();
                dataitem.Add("NO", dataGridView1.Rows[i].Cells["No"].Value.ToString());
                dataitem.Add("STAFFNAME", dataGridView1.Rows[i].Cells["Staff"].Value.ToString());
                if (dataGridView1.Rows[i].Cells["WorkClass"].Value != null)
                //dataitem.Add("WORKSTYLE", Enum.GetName(typeof(Utile.Data.就業区分),
                {
                    if (dataGridView1.Rows[i].Cells["WorkClass"].Value.ToString() != "")
                    {
                        Console.WriteLine(dataGridView1.Rows[i].Cells["WorkClass"].Value.ToString());
                        dataitem.Add("WORKSTYLE", Enum.GetName(typeof(Utile.Data.就業区分),
                        int.Parse(dataGridView1.Rows[i].Cells["WorkClass"].Value.ToString())));
                    }
                }

                if (dataGridView1.Rows[i].Cells["StartTime"].Value != null)
                    dataitem.Add("STARTTIME", dataGridView1.Rows[i].Cells["StartTime"].Value.ToString());
                if(dataGridView1.Rows[i].Cells["EndTime"].Value != null)
                    dataitem.Add("ENDTIME", dataGridView1.Rows[i].Cells["EndTime"].Value.ToString());
                dataitem.Add("YMD", l_calenderdata.ToString("yyyy年MM月dd日"));
                dataitem.Add("STORE", co_store.SelectedItem.ToString());

                rdb.insert(dataitem);
            }

            PrintForm P = new PrintForm();
            P.PrintReport.Load(@"Asset/Format/StaffShift.flxr", "StaffShift");
            P.c1FlexViewer.DocumentSource = P.PrintReport;
            P.Show();
        }
    }
}
