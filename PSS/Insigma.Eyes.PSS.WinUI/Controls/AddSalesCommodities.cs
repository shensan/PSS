﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Insigma.Eyes.PSS.WinUI.Controls
{
    public partial class AddSalesCommodities : Form
    {
        public AddSalesCommodities()
        {
            InitializeComponent();
        }
        public int CID { get; set; }
        public bool IsUpdate = false;
        public AddSalesCommodities(int id)
        {
            InitializeComponent();
            this.CID = id;
            this.IsUpdate = true;
        }
        public int SalesOrderID { get; set; }
        public int SalesCommodityID { get; set; }
        private void buttonEditName_Click(object sender, EventArgs e)
        {
            SelectCommodity selectCommodityForm = new SelectCommodity();
            if (selectCommodityForm.ShowDialog() == DialogResult.OK)
            {
                SalesCommodityID = selectCommodityForm.SelectedCommodityID;
                if (SalesCommodityID < 1)
                {
                    MessageBox.Show("未选中商品！");
                    return;
                }
                BLLCommodity.CommodityManagerServiceClient client = WCFServiceBLL.GetCommodityService();
                Model.CommodityModel oneCommodity = client.GetOneCommodity(SalesCommodityID);
                textBoxName.Text = oneCommodity.Name;
                textBoxPrice.Text = oneCommodity.UnitPrice.ToString();
                labelManufacturer.Text = "[" + oneCommodity.Manufacturer + "]";
                labelPerson.Text = "[" + oneCommodity.Person + "||" + oneCommodity.Telphone + "]";
                labelAddress.Text = "[" + oneCommodity.Address;
                labelType.Text = "[" + oneCommodity.Type + "]";
                labelUnit.Text = "[" + oneCommodity.Unit + "]";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                int count = 0;
                decimal price = 0.0M;
                try
                {
                    count = int.Parse(textBoxCount.Text);
                    price = decimal.Parse(textBoxPrice.Text);
                }
                catch
                {
                    MessageBox.Show("数量或金额有误！");
                    return;
                }

                Model.SalesCommodityModel oneSalesCommodity = new Model.SalesCommodityModel();
                oneSalesCommodity.ID = UpdateID;
                oneSalesCommodity.SalesOrderID = SalesOrderID;
                oneSalesCommodity.CommodityID = SalesCommodityID;
                oneSalesCommodity.Count = count;
                oneSalesCommodity.SalesPrice = price;
                oneSalesCommodity.TotalPrice = count * price;//这儿是个业务
                BLLSalesOrders.SalesManagerServiceClient client = WCFServiceBLL.GetSalesService();
                if (client.UpdateCommodity(oneSalesCommodity))
                {
                    MessageBox.Show("更新成功!");
                }

            }
            else
            {
                if (SalesCommodityID == 0)
                {
                    MessageBox.Show("请选择一个产品");
                    return;
                }
                int count = 0;
                decimal price = 0.0M;
                try
                {
                    count = int.Parse(textBoxCount.Text);
                    price = decimal.Parse(textBoxPrice.Text);
                }
                catch
                {
                    MessageBox.Show("数量或金额有误！");
                    return;
                }
                Model.SalesCommodityModel oneSalesCommodity = new Model.SalesCommodityModel();
                oneSalesCommodity.SalesOrderID = SalesOrderID;
                oneSalesCommodity.CommodityID = SalesCommodityID;
                oneSalesCommodity.Count = count;
                oneSalesCommodity.SalesPrice = price;
                oneSalesCommodity.TotalPrice = count * price;//这儿是个业务
                BLLSalesOrders.SalesManagerServiceClient client = WCFServiceBLL.GetSalesService();
                oneSalesCommodity = client.AddSalesCommodity(oneSalesCommodity);
                if (oneSalesCommodity.Equals(null))
                {
                    MessageBox.Show("保存失败");
                    this.DialogResult = DialogResult.None;
                }
            }


        }
        private int UpdateID;
        private void AddSalesCommodities_Load(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                //加载页面
                BLLSalesOrders.SalesManagerServiceClient salesClinet = WCFServiceBLL.GetSalesService();
                Model.SalesCommodityModel salesCommodity = salesClinet.GetOneSalesCommodityByID(CID);
                UpdateID = salesCommodity.ID;
                SalesCommodityID = salesCommodity.CommodityID;
                textBoxName.Text = salesCommodity.CommodityName;
                labelManufacturer.Text = "[" + salesCommodity.CommodityManufacturer + "]";
                labelType.Text = "[" + salesCommodity.CommodityType + "]";

                textBoxCount.Text = salesCommodity.Count.ToString();
                textBoxPrice.Text = salesCommodity.SalesPrice.ToString();
                labelUnit.Text = "[" + salesCommodity.CommodityUnit + "]";
            }
        }
    }
}
