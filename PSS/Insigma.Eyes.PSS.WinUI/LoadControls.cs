using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Insigma.Eyes.PSS.WinUI.Controls;

namespace Insigma.Eyes.PSS.WinUI
{
    public class LoadControls
    {
        /// <summary>
        /// 加载基础配置界面
        /// </summary>
        /// <param name="parent"></param>
        public static void LoadBaseConfig(Control parent)
        {
            parent.Controls.Clear();
            BaseConfig baseConfig = new BaseConfig();
            baseConfig.Dock = DockStyle.Fill;
            parent.Controls.Add(baseConfig);
        }
        /// <summary>
        /// 加载产品维护界面
        /// </summary>
        /// <param name="parent"></param>
        public static void LoadProductManage(Control parent)
        {
            parent.Controls.Clear();
            ProductManage productManage = new ProductManage();
            productManage.Dock = DockStyle.Fill;
            parent.Controls.Add(productManage);
        }
        /// <summary>
        /// 加载进货界面
        /// </summary>
        /// <param name="parent"></param>
        public static void LoadPurchase(Control parent)
        {
            parent.Controls.Clear();
            Purchase purchase = new Purchase();
            purchase.Dock = DockStyle.Fill;
            parent.Controls.Add(purchase);
        }
        /// <summary>
        /// 加载销售界面
        /// </summary>
        /// <param name="parent"></param>
        public static void LoadSales(Control parent)
        {
            parent.Controls.Clear();
            Sales sales = new Sales();
            sales.Dock = DockStyle.Fill;
            parent.Controls.Add(sales);
        }
        /// <summary>
        /// 加载数据汇总界面
        /// </summary>
        /// <param name="parent"></param>
        public static void LoadSummaryManage(Control parent)
        {
            parent.Controls.Clear();
            SummaryManage summaryManage = new SummaryManage();
            summaryManage.Dock = DockStyle.Fill;
            parent.Controls.Add(summaryManage);
        }
    }
}
