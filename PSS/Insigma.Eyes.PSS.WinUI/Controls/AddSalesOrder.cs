using Insigma.Eyes.PSS.Model;
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
    public partial class AddSalesOrder : Form
    {
        public int AddSalesID { get; set; }
        public int orderID { get; set; }
        private bool isUpdate = false;
        private Dictionary<string, CustomerModel> combSupplierData = new Dictionary<string, CustomerModel>();

        public AddSalesOrder()
        {
            InitializeComponent();
            textBoxOrderNumber.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        
        public AddSalesOrder(int id)
        {
            InitializeComponent();
            this.Text = "修改订单";
            this.orderID = id;
            isUpdate = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxOrderNumber.Text))
            {
                MessageBox.Show("订单编号不能为空");
                return;
            }
            Model.SalesOrdersModel salesOrder = new Model.SalesOrdersModel();
            salesOrder.OrderNumber = textBoxOrderNumber.Text;
            salesOrder.CustomerId = string.IsNullOrWhiteSpace(labelCustomerId.Text) ? 0 : int.Parse(labelCustomerId.Text);
            salesOrder.CustomerName = textBoxCustomer.Text;
            salesOrder.Address = textBoxAddress.Text;
            salesOrder.Tel = textBoxTel.Text;
            salesOrder.Contract = textBoxContract.Text;           
            salesOrder.OrderDate = DateTime.Now;
            BLLSalesOrders.SalesManagerServiceClient salesClient = WCFServiceBLL.GetSalesService();
            if (isUpdate)
            {
                salesOrder.ID = orderID;
                if (!salesClient.UpdateSalesOrder(salesOrder))
                {
                    MessageBox.Show("订单更新失败");
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                var order = salesClient.AddSalesOrder(salesOrder);
                if (order == null)
                {
                    MessageBox.Show("新增订单失败");
                    this.DialogResult = DialogResult.None;
                }
                AddSalesID = order.ID;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void AddSalesOrder_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                //Model.SalesOrdersModel salesOrder =new  BLLSalesOrders.SalesManagerServiceClient()
                BLLSalesOrders.SalesManagerServiceClient salesClient = WCFServiceBLL.GetSalesService();
                SalesOrdersModel order=salesClient.GetOneSalesOrder(orderID);
                labelCustomerId.Text = order.CustomerId.ToString();
                textBoxOrderNumber.Text = order.OrderNumber;
                textBoxCustomer.Text = order.CustomerName;
                labelTotalMoney.Text = "[]";
                textBoxTel.Text = order.Tel;
                textBoxAddress.Text = order.Address;
                textBoxContract.Text = order.Contract;
            }
        }
        /// <summary>
        /// 选择顾客
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            SelectCustomer selectCustomerForm = new SelectCustomer();
            if (selectCustomerForm.ShowDialog() == DialogResult.OK)
            {
                int customerID = selectCustomerForm.SelectedCustomerID;
                BLLCustomer.CustomerManagerServiceClient customerClient = WCFServiceBLL.GetCustomerService();
                CustomerModel oneCustomer = customerClient.GetOneCustomer(customerID);
                labelCustomerId.Text = customerID.ToString();
                textBoxCustomer.Text = oneCustomer.Name;
                labelTotalMoney.Text = "[" + oneCustomer.TotalMoney.ToString()+ "]";
                textBoxTel.Text = oneCustomer.Telphone;
                textBoxAddress.Text = oneCustomer.Address;
            }
        }
    }
}
