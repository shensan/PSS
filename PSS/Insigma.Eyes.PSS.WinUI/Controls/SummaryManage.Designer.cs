namespace Insigma.Eyes.PSS.WinUI.Controls
{
    partial class SummaryManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryManage));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labInNum = new System.Windows.Forms.Label();
            this.labAllMonery = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labInMonery = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labOutNum = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labOutMonery = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvProductOut = new System.Windows.Forms.DataGridView();
            this.dgvProductIn = new System.Windows.Forms.DataGridView();
            this.dgvInOrder = new System.Windows.Forms.DataGridView();
            this.dgvOutOrder = new System.Windows.Forms.DataGridView();
            this.colInOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInProductNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutProductNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(772, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "汇总";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "huizong_24.ico");
            this.imageList1.Images.SetKeyName(1, "order_162_16px.ico");
            this.imageList1.Images.SetKeyName(2, "order_162_24px.ico");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "对比";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "未完成，敬请期待！";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时间段查询";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(106, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(145, 16);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(105, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "至";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "全部查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "进销查询";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(418, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "排名查询";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(499, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "进货排名";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(580, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "销量排名";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Location = new System.Drawing.Point(389, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 470);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.labAllMonery);
            this.groupBox3.Controls.Add(this.labOutMonery);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.labInMonery);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.labOutNum);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.labInNum);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(6, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(377, 470);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvProductIn);
            this.groupBox4.Location = new System.Drawing.Point(0, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(185, 402);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "进货";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvProductOut);
            this.groupBox5.Location = new System.Drawing.Point(189, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(185, 402);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "销售";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "共";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "总毛利润：";
            // 
            // labInNum
            // 
            this.labInNum.AutoSize = true;
            this.labInNum.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labInNum.Location = new System.Drawing.Point(13, 415);
            this.labInNum.Name = "labInNum";
            this.labInNum.Size = new System.Drawing.Size(34, 21);
            this.labInNum.TabIndex = 1;
            this.labInNum.Text = "55";
            // 
            // labAllMonery
            // 
            this.labAllMonery.AutoSize = true;
            this.labAllMonery.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAllMonery.Location = new System.Drawing.Point(71, 440);
            this.labAllMonery.Name = "labAllMonery";
            this.labAllMonery.Size = new System.Drawing.Size(94, 21);
            this.labAllMonery.TabIndex = 1;
            this.labAllMonery.Text = "1234.67";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "笔";
            // 
            // labInMonery
            // 
            this.labInMonery.AutoSize = true;
            this.labInMonery.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labInMonery.Location = new System.Drawing.Point(63, 415);
            this.labInMonery.Name = "labInMonery";
            this.labInMonery.Size = new System.Drawing.Size(94, 21);
            this.labInMonery.TabIndex = 1;
            this.labInMonery.Text = "1234.56";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "元";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "共";
            // 
            // labOutNum
            // 
            this.labOutNum.AutoSize = true;
            this.labOutNum.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labOutNum.Location = new System.Drawing.Point(202, 415);
            this.labOutNum.Name = "labOutNum";
            this.labOutNum.Size = new System.Drawing.Size(34, 21);
            this.labOutNum.TabIndex = 1;
            this.labOutNum.Text = "55";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(239, 420);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "笔";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(352, 420);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "元";
            // 
            // labOutMonery
            // 
            this.labOutMonery.AutoSize = true;
            this.labOutMonery.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labOutMonery.Location = new System.Drawing.Point(252, 415);
            this.labOutMonery.Name = "labOutMonery";
            this.labOutMonery.Size = new System.Drawing.Size(94, 21);
            this.labOutMonery.TabIndex = 1;
            this.labOutMonery.Text = "1234.56";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvOutOrder);
            this.groupBox6.Location = new System.Drawing.Point(190, 11);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(185, 453);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "销售排名";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dgvInOrder);
            this.groupBox7.Location = new System.Drawing.Point(1, 11);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(185, 453);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "进货排名";
            // 
            // dgvProductOut
            // 
            this.dgvProductOut.AllowUserToAddRows = false;
            this.dgvProductOut.AllowUserToDeleteRows = false;
            this.dgvProductOut.AllowUserToOrderColumns = true;
            this.dgvProductOut.AllowUserToResizeRows = false;
            this.dgvProductOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOutNumber,
            this.colOutPrice,
            this.colOutDate});
            this.dgvProductOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductOut.Location = new System.Drawing.Point(3, 17);
            this.dgvProductOut.MultiSelect = false;
            this.dgvProductOut.Name = "dgvProductOut";
            this.dgvProductOut.RowHeadersVisible = false;
            this.dgvProductOut.RowTemplate.Height = 23;
            this.dgvProductOut.Size = new System.Drawing.Size(179, 382);
            this.dgvProductOut.TabIndex = 0;
            // 
            // dgvProductIn
            // 
            this.dgvProductIn.AllowUserToAddRows = false;
            this.dgvProductIn.AllowUserToDeleteRows = false;
            this.dgvProductIn.AllowUserToOrderColumns = true;
            this.dgvProductIn.AllowUserToResizeRows = false;
            this.dgvProductIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInOrderNumber,
            this.colInPrice,
            this.colInDate});
            this.dgvProductIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductIn.Location = new System.Drawing.Point(3, 17);
            this.dgvProductIn.MultiSelect = false;
            this.dgvProductIn.Name = "dgvProductIn";
            this.dgvProductIn.RowHeadersVisible = false;
            this.dgvProductIn.RowTemplate.Height = 23;
            this.dgvProductIn.Size = new System.Drawing.Size(179, 382);
            this.dgvProductIn.TabIndex = 1;
            // 
            // dgvInOrder
            // 
            this.dgvInOrder.AllowUserToAddRows = false;
            this.dgvInOrder.AllowUserToDeleteRows = false;
            this.dgvInOrder.AllowUserToResizeRows = false;
            this.dgvInOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInProduct,
            this.colInProductPrice,
            this.colInProductNum});
            this.dgvInOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInOrder.Location = new System.Drawing.Point(3, 17);
            this.dgvInOrder.MultiSelect = false;
            this.dgvInOrder.Name = "dgvInOrder";
            this.dgvInOrder.RowHeadersWidth = 25;
            this.dgvInOrder.RowTemplate.Height = 23;
            this.dgvInOrder.Size = new System.Drawing.Size(179, 433);
            this.dgvInOrder.TabIndex = 1;
            // 
            // dgvOutOrder
            // 
            this.dgvOutOrder.AllowUserToAddRows = false;
            this.dgvOutOrder.AllowUserToDeleteRows = false;
            this.dgvOutOrder.AllowUserToResizeRows = false;
            this.dgvOutOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOutProduct,
            this.colOutProductPrice,
            this.colOutProductNum});
            this.dgvOutOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutOrder.Location = new System.Drawing.Point(3, 17);
            this.dgvOutOrder.MultiSelect = false;
            this.dgvOutOrder.Name = "dgvOutOrder";
            this.dgvOutOrder.RowHeadersWidth = 25;
            this.dgvOutOrder.RowTemplate.Height = 23;
            this.dgvOutOrder.Size = new System.Drawing.Size(179, 433);
            this.dgvOutOrder.TabIndex = 1;
            // 
            // colInOrderNumber
            // 
            this.colInOrderNumber.HeaderText = "进货单";
            this.colInOrderNumber.Name = "colInOrderNumber";
            this.colInOrderNumber.Width = 80;
            // 
            // colInPrice
            // 
            this.colInPrice.HeaderText = "费用";
            this.colInPrice.Name = "colInPrice";
            this.colInPrice.Width = 60;
            // 
            // colInDate
            // 
            this.colInDate.HeaderText = "时间";
            this.colInDate.Name = "colInDate";
            this.colInDate.Width = 80;
            // 
            // colOutNumber
            // 
            this.colOutNumber.HeaderText = "销售单";
            this.colOutNumber.Name = "colOutNumber";
            this.colOutNumber.Width = 80;
            // 
            // colOutPrice
            // 
            this.colOutPrice.HeaderText = "费用";
            this.colOutPrice.Name = "colOutPrice";
            this.colOutPrice.Width = 60;
            // 
            // colOutDate
            // 
            this.colOutDate.HeaderText = "时间";
            this.colOutDate.Name = "colOutDate";
            this.colOutDate.Width = 80;
            // 
            // colInProduct
            // 
            this.colInProduct.HeaderText = "名称";
            this.colInProduct.Name = "colInProduct";
            this.colInProduct.Width = 80;
            // 
            // colInProductPrice
            // 
            this.colInProductPrice.HeaderText = "费用";
            this.colInProductPrice.Name = "colInProductPrice";
            this.colInProductPrice.Width = 58;
            // 
            // colInProductNum
            // 
            this.colInProductNum.HeaderText = "数量";
            this.colInProductNum.Name = "colInProductNum";
            this.colInProductNum.Width = 58;
            // 
            // colOutProduct
            // 
            this.colOutProduct.HeaderText = "名称";
            this.colOutProduct.Name = "colOutProduct";
            this.colOutProduct.Width = 80;
            // 
            // colOutProductPrice
            // 
            this.colOutProductPrice.HeaderText = "费用";
            this.colOutProductPrice.Name = "colOutProductPrice";
            this.colOutProductPrice.Width = 58;
            // 
            // colOutProductNum
            // 
            this.colOutProductNum.HeaderText = "数量";
            this.colOutProductNum.Name = "colOutProductNum";
            this.colOutProductNum.Width = 58;
            // 
            // SummaryManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "SummaryManage";
            this.Size = new System.Drawing.Size(780, 558);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labAllMonery;
        private System.Windows.Forms.Label labOutMonery;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labInMonery;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labOutNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labInNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvProductOut;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dgvProductIn;
        private System.Windows.Forms.DataGridView dgvOutOrder;
        private System.Windows.Forms.DataGridView dgvInOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutProductNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInProductNum;
    }
}
