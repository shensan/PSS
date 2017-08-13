﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Insigma.Eyes.PSS.WinUI.BLLPurchaseOrders;
using System.ServiceModel;
using Insigma.Eyes.PSS.Model;

//采购管理：采购管理员管理采购订单，每个订单中包含多个商品信息，订单之后在提交后才能入库
namespace Insigma.Eyes.PSS.WinUI.Controls
{
    public partial class Purchase : UserControl
    {
        public Purchase()
        {
            InitializeComponent();
            dataGridViewPurchaseList.AutoGenerateColumns = false;
            clearShowOrderItmList();
        }
        private void GetPurchaseOrdersList()
        {
            PurchaseManagerServiceClient client = WCFServiceBLL.GetPurchaseService();
            List<Model.PurchaseOrdersModel> listPurchaseOrders = client.GetPurchaseOrders(textBoxNumber.Text, textBoxdateStart.Text, textBoxdateEnd.Text, comboBoxStatus.Text).ToList();
            listViewOrders.Items.Clear();
            foreach (Model.PurchaseOrdersModel onePurchaseOrder in listPurchaseOrders)
            {
                ListViewItem item = new ListViewItem();
                item.Text = onePurchaseOrder.OrderNumber;
                item.Tag = onePurchaseOrder;
                listViewOrders.Items.Add(item);
            }
            clearShowOrderItmList();
        }
        private void clearShowOrderItmList()
        {
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
            toolStripButton6.Enabled = false;
            toolStripButton8.Enabled = false;
            dataGridViewPurchaseList.DataSource = null;
        }
        private void btnFindOrderList_Click(object sender, EventArgs e)
        {
            GetPurchaseOrdersList();
        }
        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddPurchaseOrder oneOrder = new AddPurchaseOrder();
            if (oneOrder.ShowDialog() == DialogResult.OK)
            {
                orderID = oneOrder.AddSalesID;
                GetPurchaseOrdersList();
                GetUpdateOrderDetail();
            }

        }
        Model.PurchaseOrdersModel selectOrder;

        /// <summary>
        /// 展示订单详情
        /// </summary>
        private void GetOrderDetail()
        {
            if (listViewOrders.SelectedItems.Count > 0)
            {
                toolStripButton4.Enabled = true;
                toolStripButton5.Enabled = true;
                toolStripButton6.Enabled = true;
                toolStripButton8.Enabled = true;
                ListViewItem item = listViewOrders.SelectedItems[0];
                selectOrder = (Model.PurchaseOrdersModel)item.Tag;
                labelOrderNumber.Text = "[" + selectOrder.OrderNumber + "]";
                labelOrderDate.Text = "[" + selectOrder.OrderDate.ToString("yyyy-MM-dd HH:mm:ss") + "]";
                labelContract.Text = "[" + selectOrder.Contract + "]";
                //labelStatus.Text = "[" + selectOrder.Status + "]";
                //if (selectOrder.Status.Equals("已入库"))
                //{
                //    toolStripButton4.Enabled = false;
                //    toolStripButton5.Enabled = false;
                //    toolStripButton6.Enabled = false;
                //}
                labelSupplierName.Text = "[" + selectOrder.SupplierName + "]";
                labelTel.Text = "[" + selectOrder.Person + "||" + selectOrder.Tel + "]";
                labelAddress.Text = "[" + selectOrder.Address + "]";
                BLLPurchaseOrders.PurchaseManagerServiceClient purchaseClient = WCFServiceBLL.GetPurchaseService();
                dataGridViewPurchaseList.DataSource = purchaseClient.GetPurchaseCommoditiesByID(selectOrder.ID);
            }
            else
            {
                clearShowOrderItmList();
            }
        }

        //private void TextChange(object sender, EventArgs e)
        //{
        //    GetPurchaseOrdersList();
        //}

        private void Purchase_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            textBoxdateStart.Text = today.AddMonths(-1).ToShortDateString();
            textBoxdateEnd.Text = today.ToShortDateString();
            GetPurchaseOrdersList();
        }

        private void listViewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOrderDetail();
        }
        /// <summary>
        /// 订单中新增商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (selectOrder == null)
            {
                MessageBox.Show("请选择一个订单");
                return;
            }
            AddPurchaseCommodities purchaseCommodityForm = new AddPurchaseCommodities();
            purchaseCommodityForm.PurchaseOrderID = selectOrder.ID;
            if (purchaseCommodityForm.ShowDialog() == DialogResult.OK)
            {
                BLLPurchaseOrders.PurchaseManagerServiceClient purchaseClient = WCFServiceBLL.GetPurchaseService();
                dataGridViewPurchaseList.DataSource = purchaseClient.GetPurchaseCommoditiesByID(selectOrder.ID);
            }

        }
        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (selectOrder == null)
            {
                MessageBox.Show("请选择一个订单提交");
                return;
            }
            if (MessageBox.Show("确定要提交订单了", "提交", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    BLLPurchaseOrders.PurchaseManagerServiceClient purchaseClient = WCFServiceBLL.GetPurchaseService();
                    if (purchaseClient.PostPurchaseOrder(selectOrder.ID))
                    {
                        listViewOrders.SelectedItems[0].Tag = purchaseClient.GetOnePurchaseOrder(selectOrder.ID);
                        GetOrderDetail();
                    }
                }
                catch (FaultException<Exception> ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 修改订单中产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //订单已经提交的情况下，不能修改产品
            if (dataGridViewPurchaseList.SelectedRows.Count > 0)
            {
                int cID = int.Parse(dataGridViewPurchaseList.SelectedRows[0].Cells["ColumnID"].Value.ToString());//31
                AddPurchaseCommodities updatePurchaseCommodity = new AddPurchaseCommodities(cID);
                //updatePurchaseCommodity.PurchaseOrderID = selectOrder.ID;//3
                if (updatePurchaseCommodity.ShowDialog() == DialogResult.OK)
                {
                    BLLPurchaseOrders.PurchaseManagerServiceClient client = WCFServiceBLL.GetPurchaseService();
                    dataGridViewPurchaseList.DataSource = client.GetPurchaseCommoditiesByID(selectOrder.ID);
                }
            }
            else
            {
                MessageBox.Show("请选择要修改的商品");
                return;
            }
        }
        private int orderID = -1;
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count > 0)
            {
                Model.PurchaseOrdersModel onePurchase = (Model.PurchaseOrdersModel)listViewOrders.SelectedItems[0].Tag;
                orderID = onePurchase.ID;
                AddPurchaseOrder updatePurchaseOrder = new AddPurchaseOrder(onePurchase.ID);
                if (updatePurchaseOrder.ShowDialog() == DialogResult.OK)
                {
                    GetPurchaseOrdersList();
                    //修改中ListView失去焦点
                    GetUpdateOrderDetail();
                }
            }
        }

        private void GetUpdateOrderDetail()
        {
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton6.Enabled = true;
            toolStripButton8.Enabled = true;

            //ListViewItem item = listViewOrders.SelectedItems[0];
            //selectOrder = (Model.SalesOrdersModel)item.Tag;
            BLLPurchaseOrders.PurchaseManagerServiceClient purchaseClient = WCFServiceBLL.GetPurchaseService();
            selectOrder = purchaseClient.GetOnePurchaseOrder(orderID);
            labelOrderNumber.Text = "[" + selectOrder.OrderNumber + "]";
            labelOrderDate.Text = "[" + selectOrder.OrderDate.ToString("yyyy-MM-dd HH:mm:ss") + "]";
            labelContract.Text = "[" + selectOrder.Contract + "]";
            labelSupplierName.Text = "[" + selectOrder.SupplierName + "]";
            labelAddress.Text = "[" + selectOrder.Address + "]";
            labelTel.Text = "[" + selectOrder.Person + "||" + selectOrder.Tel + "]";

            BLLPurchaseOrders.PurchaseManagerServiceClient client = WCFServiceBLL.GetPurchaseService();

            List<Model.PurchaseCommodityModel> purchaseCommoditiesList = client.GetPurchaseCommoditiesByID(selectOrder.ID).ToList();
            dataGridViewPurchaseList.DataSource = purchaseCommoditiesList;
        }
        /// <summary>
        /// 删除订单中商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //订单已经提交的情况下，不能删除 

            if (dataGridViewPurchaseList.SelectedRows.Count > 0)
            {
                int cID = int.Parse(dataGridViewPurchaseList.SelectedRows[0].Cells["ColumnID"].Value.ToString());
                if (MessageBox.Show("确定要删除吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    BLLPurchaseOrders.PurchaseManagerServiceClient purchaseClient = WCFServiceBLL.GetPurchaseService();
                    if (purchaseClient.DeletePurchaseCommodity(cID))
                    {
                        BLLPurchaseOrders.PurchaseManagerServiceClient client = WCFServiceBLL.GetPurchaseService();
                        dataGridViewPurchaseList.DataSource = client.GetPurchaseCommoditiesByID(selectOrder.ID);
                    }
                }
                else
                {
                    MessageBox.Show("请选择一条记录");
                }
            }
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            BLLPurchaseOrders.PurchaseManagerServiceClient purchaseClient = WCFServiceBLL.GetPurchaseService();
            //删除多条数据注意回滚
            if (listViewOrders.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    orderID = (listViewOrders.SelectedItems[0].Tag as Model.PurchaseOrdersModel).ID;
                    if (purchaseClient.GetPurchaseCommoditiesByID(orderID).Length == 0 || purchaseClient.DeletePurchaseCommoditiesByPurchaseOrderID(orderID))
                    {
                        if (purchaseClient.DeleteOrderID(orderID))
                        {
                            MessageBox.Show("删除成功");
                            //dataGridViewCommoditiesList.Rows.Clear();
                            dataGridViewPurchaseList.DataSource = null;
                            labelOrderNumber.Text = "[]";
                            labelOrderDate.Text = "[]";
                            labelStatus.Text = "[]";
                            labelTel.Text = "[]";
                            labelSupplierName.Text = "[]";
                            labelAddress.Text = "[]";
                            GetPurchaseOrdersList();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择一条订单");
            }
        }

        /// <summary>
        /// 更新订单的总价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            BLLPurchaseOrders.PurchaseManagerServiceClient purchaseClient = WCFServiceBLL.GetPurchaseService();
            if (listViewOrders.SelectedItems.Count > 0)
            {
                decimal refreshTotalPrice = 0.0M;
                PurchaseOrdersModel selectedPurchaseOrder = listViewOrders.SelectedItems[0].Tag as Model.PurchaseOrdersModel;
                List<Model.PurchaseCommodityModel> listPurchaseCommoditys = purchaseClient.GetPurchaseCommoditiesByID(selectedPurchaseOrder.ID).ToList();
                foreach (PurchaseCommodityModel orderItem in listPurchaseCommoditys)
                {
                    refreshTotalPrice += orderItem.TotalPrice;
                }
                selectedPurchaseOrder.Contract = refreshTotalPrice.ToString();
                if (purchaseClient.UpdatePurchaseOrder(selectedPurchaseOrder))
                {
                    labelContract.Text = selectedPurchaseOrder.Contract;
                }
                else
                {
                    MessageBox.Show("更新订单总价失败！");
                }
            }
            else
            {
                MessageBox.Show("请选择一条订单");
            }
        }


    }
}
