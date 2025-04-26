using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EasyPDV.Entities;
using EasyPDV.Model;
using Npgsql;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EasyPDV.UI
{
    public partial class FrmCancellSelected : Form
    {
        private List<string> _itemsToLoad;
        NpgsqlDataAdapter _adpt;
        DataTable _dt;
        ProductDAO _productDAO = new ProductDAO();
        public FrmCancellSelected(List<string> itemsToLoad)
        {
            InitializeComponent();
            btnRemoverSelecionados.Cursor = Cursors.Hand;
            _itemsToLoad = itemsToLoad;
            FillList();
        }

        private void FrmCancellSelected_Load(object sender, EventArgs e)
        {

        }
        private void FillList()
        {
            _adpt = new NpgsqlDataAdapter(_productDAO.ReadList(_itemsToLoad));
            _dt = new DataTable();
            _adpt.Fill(_dt);
            siticoneDataGridView1.DataSource = _dt;
            siticoneDataGridView1.MultiSelect = true;
            for (int i = 0; i <= 5; i++)
            {
                siticoneDataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }
    }
}
