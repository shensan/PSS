namespace Insigma.Eyes.PSS.WinUI.Controls
{
    partial class ProductManage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManage));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tsProductManage = new System.Windows.Forms.ToolStrip();
            this.tsbFind = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.tbLine = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tsProductManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 558);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvProduct);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(772, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "管理商品";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "addProduct_24.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUnit);
            this.groupBox1.Controls.Add(this.cbManufacturer);
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Controls.Add(this.tbLine);
            this.groupBox1.Controls.Add(this.tbPrice);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.tsProductManage);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "维护商品";
            // 
            // tsProductManage
            // 
            this.tsProductManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFind,
            this.tsbAdd,
            this.tsbDel});
            this.tsProductManage.Location = new System.Drawing.Point(3, 17);
            this.tsProductManage.Name = "tsProductManage";
            this.tsProductManage.Size = new System.Drawing.Size(757, 25);
            this.tsProductManage.TabIndex = 0;
            this.tsProductManage.Text = "tsProductManage";
            // 
            // tsbFind
            // 
            this.tsbFind.Image = ((System.Drawing.Image)(resources.GetObject("tsbFind.Image")));
            this.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.Size = new System.Drawing.Size(52, 22);
            this.tsbFind.Text = "查询";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(52, 22);
            this.tsbAdd.Text = "添加";
            // 
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(52, 22);
            this.tsbDel.Text = "删除";
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AllowUserToOrderColumns = true;
            this.dgvProduct.AllowUserToResizeRows = false;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colTypeId,
            this.colType,
            this.colManId,
            this.colMName,
            this.colPrice,
            this.colUnitId,
            this.colUnit,
            this.colStatus,
            this.colLine});
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProduct.Location = new System.Drawing.Point(3, 103);
            this.dgvProduct.MultiSelect = false;
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.RowTemplate.Height = 23;
            this.dgvProduct.Size = new System.Drawing.Size(766, 425);
            this.dgvProduct.TabIndex = 1;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Width = 50;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "name";
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            this.colName.Width = 200;
            // 
            // colTypeId
            // 
            this.colTypeId.DataPropertyName = "typeId";
            this.colTypeId.HeaderText = "TypeId";
            this.colTypeId.Name = "colTypeId";
            this.colTypeId.Visible = false;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "typeName";
            this.colType.HeaderText = "类型";
            this.colType.Name = "colType";
            this.colType.Width = 80;
            // 
            // colManId
            // 
            this.colManId.DataPropertyName = "MId";
            this.colManId.HeaderText = "ManufacturerId";
            this.colManId.Name = "colManId";
            this.colManId.Visible = false;
            // 
            // colMName
            // 
            this.colMName.DataPropertyName = "MName";
            this.colMName.HeaderText = "供货商";
            this.colMName.Name = "colMName";
            this.colMName.Width = 80;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "price";
            this.colPrice.HeaderText = "定价";
            this.colPrice.Name = "colPrice";
            // 
            // colUnitId
            // 
            this.colUnitId.DataPropertyName = "UId";
            this.colUnitId.HeaderText = "UnitId";
            this.colUnitId.Name = "colUnitId";
            this.colUnitId.Visible = false;
            // 
            // colUnit
            // 
            this.colUnit.DataPropertyName = "UName";
            this.colUnit.HeaderText = "单位";
            this.colUnit.Name = "colUnit";
            this.colUnit.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "status";
            this.colStatus.HeaderText = "状态";
            this.colStatus.Name = "colStatus";
            // 
            // colLine
            // 
            this.colLine.DataPropertyName = "line";
            this.colLine.HeaderText = "序号";
            this.colLine.Name = "colLine";
            this.colLine.Width = 60;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("宋体", 11F);
            this.tbName.Location = new System.Drawing.Point(3, 54);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(224, 24);
            this.tbName.TabIndex = 1;
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("宋体", 11F);
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(233, 54);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(95, 23);
            this.cbType.TabIndex = 2;
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbManufacturer.Font = new System.Drawing.Font("宋体", 11F);
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.Location = new System.Drawing.Point(334, 54);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(95, 23);
            this.cbManufacturer.TabIndex = 3;
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("宋体", 11F);
            this.tbPrice.Location = new System.Drawing.Point(435, 54);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(90, 24);
            this.tbPrice.TabIndex = 4;
            // 
            // cbUnit
            // 
            this.cbUnit.Font = new System.Drawing.Font("宋体", 11F);
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(531, 54);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(99, 23);
            this.cbUnit.TabIndex = 5;
            // 
            // tbLine
            // 
            this.tbLine.Font = new System.Drawing.Font("宋体", 11F);
            this.tbLine.Location = new System.Drawing.Point(644, 54);
            this.tbLine.Name = "tbLine";
            this.tbLine.Size = new System.Drawing.Size(113, 24);
            this.tbLine.TabIndex = 6;
            // 
            // ProductManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ProductManage";
            this.Size = new System.Drawing.Size(780, 558);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tsProductManage.ResumeLayout(false);
            this.tsProductManage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip tsProductManage;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLine;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox tbLine;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ToolStripButton tsbFind;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbDel;
    }
}
