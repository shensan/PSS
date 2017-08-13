using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Insigma.Eyes.PSS.WinUI.Controls
{
    public partial class SelectCustomer : Form
    {
        public int SelectedCustomerID;
        public SelectCustomer()
        {
            InitializeComponent();
        }

        private void textBoxConditons_TextChanged(object sender, EventArgs e)
        {
            GetCustomers();
        }

        private void dataGridCustomerView_DoubleClick(object sender, EventArgs e)
        {
            SelectOneCustomer();     
        }
        private void SelectOneCustomer()
        {
            if (dataGridCustomerView.SelectedRows.Count > 0)
            {
                SelectedCustomerID = int.Parse(dataGridCustomerView.SelectedRows[0].Cells["ColumnId"].Value.ToString());
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择一条记录");
                this.DialogResult = DialogResult.None;
            }
        }
        private void GetCustomers()
        {
            dataGridCustomerView.DataSource = new BLLCustomer.CustomerManagerServiceClient().GetCustomersByCondition(textBoxConditons.Text.Trim()).ToList();
        }

        private void SelectCustomer_Load(object sender, EventArgs e)
        {
            GetCustomers();
        }
    }
}
