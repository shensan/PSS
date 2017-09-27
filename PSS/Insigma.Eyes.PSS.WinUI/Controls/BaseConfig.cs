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
            CommodityManagerServiceClient client = WCFServiceBLL.GetCommodityService();
            List<Model.UnitModel> listUnits = client.GetCommdityUnits().ToList();

            dgvUnit.Rows.Clear();
            dgvUnit.DataSource = listUnits;
            dgvUnit.ClearSelection();
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
            CommodityManagerServiceClient client = WCFServiceBLL.GetCommodityService();
            List<Model.TypeModel> listTypes = client.GetCommdityTypes().ToList();

            dgvType.Rows.Clear();
            dgvType.DataSource = listTypes;
            dgvType.ClearSelection();
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

        


        
    }
}
