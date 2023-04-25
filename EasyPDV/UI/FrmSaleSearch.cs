using EasyPDV.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPDV.UI
{
    public partial class FrmSaleSearch : Form
    {
        NpgsqlDataAdapter _adpt;
        DataTable _dt;
        SaleDAO saleDAO = new SaleDAO();
        IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
        public FrmSaleSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
        public void ShowSales(int id)
        {
            _adpt = new NpgsqlDataAdapter(individualSaleDAO.ReadBySaleId(id));
            _dt = new DataTable();
            _adpt.Fill(_dt);
            salesGridView1.DataSource = _dt;
            salesGridView1.MultiSelect = true;
            for (int i = 0; i <= 3; i++)
            {
                salesGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if(txtValue.Text != "")
            ShowSales(int.Parse(txtValue.Text));
        }
    }
}
