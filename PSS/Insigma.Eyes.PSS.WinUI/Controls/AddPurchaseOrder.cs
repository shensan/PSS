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
    public partial class AddPurchaseOrder : Form
    {
        public int AddSalesID { get; set; }
        private bool isUpdate = false;
        private Dictionary<string, ManufacturerModel> combSupplierData = new Dictionary<string, ManufacturerModel>();
        public int orderID { get; set; }
        public AddPurchaseOrder()
        {
            InitializeComponent();
            textBoxOrderNumber.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            
        }
        public AddPurchaseOrder(int id)
        {
            InitializeComponent();
            this.Text = "修改订单";
            this.orderID = id;
            isUpdate = true;
        }
        
        private void showAllSuppliser()
        {
            BLLCommodity.CommodityManagerServiceClient commodityClient = WCFServiceBLL.GetCommodityService();
            List<Model.ManufacturerModel> listManufacturer = commodityClient.GetManufacturers("","","","","1").ToList();

            combSupplier.Items.Clear();
            //combSupplier.Items.Add();
            foreach (Model.ManufacturerModel oneManufacturer in listManufacturer)
            {
                string key=oneManufacturer.ID+"||"+oneManufacturer.Name;
                combSupplierData.Add(key,oneManufacturer);
                combSupplier.Items.Add(key);
            }
            combSupplier.Items.Insert(0,"请选择供应商");
            combSupplier.Text = "请选择供应商";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxOrderNumber.Text))
            {
                MessageBox.Show("订单编号不能为空");
                return;
            }
            Model.PurchaseOrdersModel purchaseOrder = new Model.PurchaseOrdersModel();
            purchaseOrder.OrderNumber = textBoxOrderNumber.Text;
            purchaseOrder.SupplierName = combSupplier.Text;
            purchaseOrder.Person = textBoxPerson.Text;
            purchaseOrder.Address = textBoxAddress.Text;
            purchaseOrder.Tel = textBoxTel.Text;
            purchaseOrder.Contract = textBoxContract.Text;           
            purchaseOrder.OrderDate = DateTime.Now;
            BLLPurchaseOrders.PurchaseManagerServiceClient purchaseClient = WCFServiceBLL.GetPurchaseService();
            if (isUpdate)
            {
                purchaseOrder.ID = orderID;
                if (!purchaseClient.UpdatePurchaseOrder(purchaseOrder))
                {
                    MessageBox.Show("订单更新失败");
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                var order = purchaseClient.AddPurchaseOrder(purchaseOrder);
                AddSalesID=order.ID;
                if (order == null)
                {
                    MessageBox.Show("新增订单失败");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                

            }
        }

        private void AddPurchaseOrder_Load(object sender, EventArgs e)
        {
            showAllSuppliser();
            if (isUpdate)
            {
                BLLPurchaseOrders.PurchaseManagerServiceClient purchaseClient = WCFServiceBLL.GetPurchaseService();
                var order = purchaseClient.GetOnePurchaseOrder(orderID);
                textBoxOrderNumber.Text = order.OrderNumber;
                combSupplier.Text = order.SupplierName;
                textBoxPerson.Text = order.Person;
                textBoxTel.Text = order.Tel;
                textBoxAddress.Text = order.Address;
                textBoxContract.Text = order.Contract;
            }
        }

        private void combSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combSupplier.SelectedIndex != 0)
            {
                string selectedText = combSupplier.Text;
                if (combSupplierData.ContainsKey(selectedText))
                {
                    ManufacturerModel selectedManufacure = combSupplierData[selectedText];
                    textBoxAddress.Text = selectedManufacure.Address;
                    textBoxTel.Text = selectedManufacure.Telphone;
                    textBoxPerson.Text = selectedManufacure.Person;
                }
            }
            else
            {
                textBoxAddress.Text = "";
                textBoxTel.Text = "";
                textBoxPerson.Text = "";
            }
        }
    }
}
