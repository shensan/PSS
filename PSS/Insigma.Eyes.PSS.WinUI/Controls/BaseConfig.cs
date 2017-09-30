using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Insigma.Eyes.PSS.WinUI.BLLCommodity;
using Insigma.Eyes.PSS.Model;

namespace Insigma.Eyes.PSS.WinUI.Controls
{
    public partial class BaseConfig : UserControl
    {
        private UnitModel curUnitObj;
        private TypeModel curTypeObj;
        private ManufacturerModel curManufacturerObj;
        CommodityManagerServiceClient client = WCFServiceBLL.GetCommodityService();

        public BaseConfig()
        {
            InitializeComponent();
        }

        #region 单位配置管理
        /// <summary>
        /// 单位配置-查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbUnitFind_Click(object sender, EventArgs e)
        {
            findUnit();
        }

        private void findUnit()
        {
            tbUnitName.Text = "";
            tbUnitLine.Text = "";
            curUnitObj = null;
            //CommodityManagerServiceClient client = WCFServiceBLL.GetCommodityService();
            List<Model.UnitModel> listUnits = client.GetCommdityUnits().ToList();

            //dgvUnit.Rows.Clear();
            dgvUnit.DataSource = listUnits;
            dgvUnit.ClearSelection();
        }

        private void tsbUnitAdd_Click(object sender, EventArgs e)
        {
            bool ret = false;
            if (curUnitObj != null)
            {
                curUnitObj.Name = tbUnitName.Text;
                curUnitObj.Line = Convert.ToInt32(tbUnitLine.Text);
                ret=client.UpdateCommdityUnit(curUnitObj);
            }
            else
            {
                curUnitObj = new UnitModel();
                curUnitObj.Name = tbUnitName.Text;
                curUnitObj.Line = Convert.ToInt32(tbUnitLine.Text);
                ret = client.AddCommdityUnit(curUnitObj);
            }
            if (ret)
            {
                MessageBox.Show("操作成功");
                findUnit();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }

        private void tsbUnitDel_Click(object sender, EventArgs e)
        {
            bool ret = false;
            if (curUnitObj != null)
            {
                if(curUnitObj.Status=="1")
                {
                    curUnitObj.Status="0";
                }
                else
                {
                    curUnitObj.Status = "1";
                }
                
                ret = client.UpdateCommdityUnit(curUnitObj);
            }
            else
            {
                MessageBox.Show("请选中要删除记录！");
                return;
            }
            if (ret)
            {
                MessageBox.Show("操作成功");
                findUnit();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
            
        }

        private void dgvUnit_Click(object sender, EventArgs e)
        {
            int selectRows = dgvUnit.SelectedRows.Count;
            if (selectRows > 0)
            {
                DataGridViewRow dr = dgvUnit.SelectedRows[0];
                int curID = Convert.ToInt32(dr.Cells["colId"].Value);   //Convert.ToInt32(dr.Cells["colId"]);
                string curName = dr.Cells["colName"].Value.ToString();
                string curStatus = dr.Cells["colStatus"].Value.ToString() == "激活" ? "1" : "0";
                int curLine = Convert.ToInt32(dr.Cells["colUnitLine"].Value);
                tbUnitName.Text = curName;
                tbUnitLine.Text = curLine.ToString();
                if (curUnitObj == null) { curUnitObj = new UnitModel(); }
                if (curUnitObj.ID == curID)
                {
                    dgvUnit.ClearSelection();
                    //dgvUnit.SelectedRows[0].Selected = false;
                    tbUnitName.Text = "";
                    tbUnitLine.Text = "";
                    curUnitObj = null;
                }
                else
                {
                    curUnitObj.ID = curID;
                    curUnitObj.Name = curName;
                    curUnitObj.Status = curStatus;
                    curUnitObj.Line = curLine;
                }
            }
            else
            {
                if (curUnitObj != null)
                {
                    curUnitObj = null;
                }
            }
        }

        #endregion 单位配置管理

        #region 商品类型配置管理
        private void tsbTypeFind_Click(object sender, EventArgs e)
        {
            findType();
        }

        private void findType()
        {
            tbTypeName.Text = "";
            tbTypeLine.Text = "";
            curTypeObj = null;
            //CommodityManagerServiceClient client = WCFServiceBLL.GetCommodityService();
            List<Model.TypeModel> listTypes = client.GetCommdityTypes().ToList();

            //dgvType.Rows.Clear();
            dgvType.DataSource = listTypes;
            dgvType.ClearSelection();
        }

        private void tsbTypeAdd_Click(object sender, EventArgs e)
        {
            bool ret = false;
            if (curTypeObj != null)
            {
                curTypeObj.Name = tbTypeName.Text;
                curTypeObj.Line = Convert.ToInt32(tbTypeLine.Text);
                ret = client.UpdateCommdityType(curTypeObj);
            }
            else
            {
                curTypeObj = new  TypeModel();
                curTypeObj.Name = tbTypeName.Text;
                curTypeObj.Line = Convert.ToInt32(tbTypeLine.Text);
                ret = client.AddCommdityType(curTypeObj);
            }
            if (ret)
            {
                MessageBox.Show("操作成功");
                findType();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }

        private void tsbTypeDel_Click(object sender, EventArgs e)
        {
            bool ret = false;
            if (curTypeObj != null)
            {
                if (curTypeObj.Status == "1")
                {
                    curTypeObj.Status = "0";
                }
                else
                {
                    curTypeObj.Status = "1";
                }

                ret = client.UpdateCommdityType(curTypeObj);
            }
            else
            {
                MessageBox.Show("请选中要删除记录！");
                return;
            }
            if (ret)
            {
                MessageBox.Show("操作成功");
                findType();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }


        private void dgvType_Click(object sender, EventArgs e)
        {
            int selectRows = dgvType.SelectedRows.Count;
            if (selectRows > 0)
            {
                DataGridViewRow dr = dgvType.SelectedRows[0];
                int curID = Convert.ToInt32(dr.Cells["colTypeId"].Value);   //Convert.ToInt32(dr.Cells["colId"]);
                string curName = dr.Cells["colTypeName"].Value.ToString();
                string curStatus = dr.Cells["colTypeStatus"].Value.ToString() == "激活" ? "1" : "0";
                int curLine = Convert.ToInt32(dr.Cells["colTypeLine"].Value);
                tbTypeName.Text = curName;
                tbTypeLine.Text = curLine.ToString();
                if (curTypeObj == null) { curTypeObj = new TypeModel(); }
                if (curTypeObj.ID == curID)
                {
                    dgvType.ClearSelection();
                    //dgvUnit.SelectedRows[0].Selected = false;
                    tbTypeName.Text = "";
                    tbTypeLine.Text = "";
                    curTypeObj = null;
                }
                else
                {
                    curTypeObj.ID = curID;
                    curTypeObj.Name = curName;
                    curTypeObj.Status = curStatus;
                    curTypeObj.Line = curLine;
                }
            }
            else
            {
                if (curTypeObj != null)
                {
                    curTypeObj = null;
                }
            }
        }

        #endregion 商品类型配置管理

        #region 供应商配置
        private void tsbMFind_Click(object sender, EventArgs e)
        {
            findManu();
        }

        private void findManu()
        {
            tbMName.Text = "";
            tbMPerson.Text = "";
            tbMTel.Text = "";
            tbMAddress.Text = "";
            curManufacturerObj = null;
            List<ManufacturerModel> listManufacturers = client.GetManufacturers("","","","","").ToList();

            dgvManu.DataSource = listManufacturers;
            dgvManu.ClearSelection();
        }

        private void tsbMAdd_Click(object sender, EventArgs e)
        {
            bool ret = false;
            if (curManufacturerObj != null)
            {
                curManufacturerObj.Name = tbMName.Text;
                curManufacturerObj.Person = tbMPerson.Text;
                curManufacturerObj.Telephone = tbMTel.Text;
                curManufacturerObj.Address = tbMAddress.Text;
                //curManufacturerObj.Line = Convert.ToInt32(tbManuLine.Text);
                ret = client.UpdateManufacturer(curManufacturerObj);
            }
            else
            {
                curManufacturerObj = new ManufacturerModel();
                curManufacturerObj.Name = tbMName.Text;
                curManufacturerObj.Person = tbMPerson.Text;
                curManufacturerObj.Telephone = tbMTel.Text;
                curManufacturerObj.Address = tbMAddress.Text;
                if (client.AddManufacturer(curManufacturerObj) != null) { ret = true; }
            }
            if (ret)
            {
                MessageBox.Show("操作成功");
                findManu();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }

        private void tsbMDel_Click(object sender, EventArgs e)
        {
            bool ret = false;
            if (curManufacturerObj != null)
            {
                if (curManufacturerObj.Status == "1")
                {
                    curManufacturerObj.Status = "0";
                }
                else
                {
                    curManufacturerObj.Status = "1";
                }

                ret = client.UpdateManufacturer(curManufacturerObj);
            }
            else
            {
                MessageBox.Show("请选中要删除记录！");
                return;
            }
            if (ret)
            {
                MessageBox.Show("操作成功");
                findManu();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }

        private void dgvManu_Click(object sender, EventArgs e)
        {
            int selectRows = dgvManu.SelectedRows.Count;
            if (selectRows > 0)
            {
                DataGridViewRow dr = dgvManu.SelectedRows[0];
                int curID = Convert.ToInt32(dr.Cells["ColMID"].Value);   //Convert.ToInt32(dr.Cells["colId"]);
                string curName = dr.Cells["ColMName"].Value.ToString();
                string curPerson = dr.Cells["ColMPerson"].Value == null ? "" : dr.Cells["ColMPerson"].Value.ToString();
                string curTel = dr.Cells["ColMTel"].Value == null ? "" : dr.Cells["ColMTel"].Value.ToString();
                string curAddress = dr.Cells["ColMAddress"].Value == null ? "" : dr.Cells["ColMAddress"].Value.ToString();
                int curLine = Convert.ToInt32(dr.Cells["ColMLine"].Value);
                string curStatus = dr.Cells["ColMStatus"].Value.ToString() == "激活" ? "1" : "0";

                tbMName.Text = curName;
                tbMPerson.Text = curPerson;
                tbMTel.Text = curTel;
                tbMAddress.Text = curAddress;
                if (curManufacturerObj == null) { curManufacturerObj = new ManufacturerModel(); }
                if (curManufacturerObj.ID == curID)
                {
                    dgvManu.ClearSelection();
                    //dgvUnit.SelectedRows[0].Selected = false;
                    tbMName.Text = "";
                    tbMPerson.Text = "";
                    tbMTel.Text = "";
                    tbMAddress.Text = "";
                    curManufacturerObj = null;
                }
                else
                {
                    curManufacturerObj.ID = curID;
                    curManufacturerObj.Name = curName;
                    curManufacturerObj.Person = curPerson;
                    curManufacturerObj.Address = curAddress;
                    curManufacturerObj.Telephone = curTel;
                    curManufacturerObj.Status = curStatus;
                    curManufacturerObj.Line = curLine;
                }
            }
            else
            {
                if (curManufacturerObj != null)
                {
                    curManufacturerObj = null;
                }
            }
        }

        #endregion 供应商配置

        
    }
}
