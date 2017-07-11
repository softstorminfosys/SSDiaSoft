using DevExpress.XtraEditors;
using Param_Hospital.BLL.Property_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondPro.Search
{
    public partial class FrmSearch : Form
    {
        public bool FlagExit = true;
        string searchfields = string.Empty;
        string FormNameSpace = string.Empty;
        DataTable dtDetail = new DataTable();
        FrmSearchProperty searchproperty = new FrmSearchProperty();
               
        private DataGridViewRow _dr;       
        public DataGridViewRow Dr
        {
            get { return _dr; }
            set { _dr = value; }
        }

        private string _ColumnsToHide;

        public string ColumnsToHide
        {
            get { return _ColumnsToHide; }
            set { _ColumnsToHide = value; }
        }

        private bool _isAdd = false;

        public bool IsAdd
        {
            get { return _isAdd; }
            set { _isAdd = value; }
        }

        #region Constructor
        public FrmSearch()
        {
            InitializeComponent();
        }
               
        public FrmSearch(FrmSearchProperty search,string FormName)
        {
            InitializeComponent();
            dtDetail = search.dtTable;
            searchfields = search.serachfield.ToString();
            FormNameSpace = FormName;
            
        }
        #endregion

        #region Main Event
        private void FrmSearch_Load(object sender, EventArgs e)
        {
            FillGrid();
            if (FormNameSpace == "")
            {
                BtnSave.Enabled = false;
            }
            else
            {
                BtnSave.Enabled = true;
            }

            foreach (DataGridViewColumn dCol in dataGridView1.Columns)
            {
                if (_ColumnsToHide.Contains(dCol.Name))
                {
                    dataGridView1.Columns[dCol.Name].Visible = false;
                }
                else
                {
                    dataGridView1.Columns[dCol.Name].Visible = true;
                }
            }
        }

        private void FrmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FlagExit = true;
            _isAdd = false;
        }

        private void FrmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    FlagExit = true;
                    this.Close();
                }

                if (e.KeyCode == Keys.Enter)
                {
                    SelectRow();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Double Click
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SelectRow();
                FlagExit = false;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Double Click",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SelectRow();
                    this.Close();
                }
                if (e.KeyCode == Keys.Up)
                {
                    int i = dataGridView1.SelectedRows[0].Index;
                    if (i > 0)
                    {
                        dataGridView1.Rows[i - 1].Selected = true;
                    }
                }

                if (e.KeyCode == Keys.Down)
                {
                    int i = dataGridView1.SelectedRows[0].Index;
                    if (i + 1 == dataGridView1.RowCount + 1)
                    {
                        dataGridView1.Rows[i + 1].Selected = true;
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region User Function
        private void FillGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dtDetail;
            //dataGridView1.BestFitColumns();
            dataGridView1.Columns[0].Visible = false;
        }

        private DataGridViewRow SelectRow()
        {            
            searchproperty.Row = dataGridView1.SelectedRows[0];
            Dr = searchproperty.Row;
            FlagExit = false;
            return Dr;
        }

        private void ChangeData()
        {
            try
            {
                DataView dtView = dtDetail.DefaultView;

                dtView.RowFilter = "Convert([" + searchfields + "],System.String) LIKE '" + txtSearch.Text + "%'";
                //DataTable dt = dtView.ToTable();
                dataGridView1.DataSource = dtView;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TextBox Event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Search",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Button Event
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _isAdd = true;
                var frm = (Form)Activator.CreateInstance(Type.GetType(FormNameSpace.ToString()));
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Add Records",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}