namespace Insigma.Eyes.PSS.WinUI.Controls
{
    partial class SelectCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxConditons = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridCustomerView = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomerView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxConditons
            // 
            this.textBoxConditons.Location = new System.Drawing.Point(161, 25);
            this.textBoxConditons.Name = "textBoxConditons";
            this.textBoxConditons.Size = new System.Drawing.Size(252, 21);
            this.textBoxConditons.TabIndex = 3;
            this.textBoxConditons.TextChanged += new System.EventHandler(this.textBoxConditons_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "查询条件:";
            // 
            // dataGridCustomerView
            // 
            this.dataGridCustomerView.AllowUserToAddRows = false;
            this.dataGridCustomerView.AllowUserToDeleteRows = false;
            this.dataGridCustomerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCustomerView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnTotalMoney,
            this.ColumnBirthday,
            this.ColumnTel,
            this.ColumnAddress,
            this.ColumnMark});
            this.dataGridCustomerView.Location = new System.Drawing.Point(11, 65);
            this.dataGridCustomerView.MultiSelect = false;
            this.dataGridCustomerView.Name = "dataGridCustomerView";
            this.dataGridCustomerView.ReadOnly = true;
            this.dataGridCustomerView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridCustomerView.RowHeadersVisible = false;
            this.dataGridCustomerView.RowTemplate.Height = 23;
            this.dataGridCustomerView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCustomerView.Size = new System.Drawing.Size(481, 375);
            this.dataGridCustomerView.TabIndex = 4;
            this.dataGridCustomerView.DoubleClick += new System.EventHandler(this.dataGridCustomerView_DoubleClick);
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "ID";
            this.ColumnId.HeaderText = "顾客ID";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "Name";
            this.ColumnName.HeaderText = "顾客姓名";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnTotalMoney
            // 
            this.ColumnTotalMoney.DataPropertyName = "TotalMoney";
            this.ColumnTotalMoney.HeaderText = "历史消费";
            this.ColumnTotalMoney.Name = "ColumnTotalMoney";
            this.ColumnTotalMoney.ReadOnly = true;
            // 
            // ColumnBirthday
            // 
            this.ColumnBirthday.DataPropertyName = "Birthday";
            this.ColumnBirthday.HeaderText = "顾客生日";
            this.ColumnBirthday.Name = "ColumnBirthday";
            this.ColumnBirthday.ReadOnly = true;
            // 
            // ColumnTel
            // 
            this.ColumnTel.DataPropertyName = "Telphone";
            this.ColumnTel.HeaderText = "顾客电话";
            this.ColumnTel.Name = "ColumnTel";
            this.ColumnTel.ReadOnly = true;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.DataPropertyName = "Address";
            this.ColumnAddress.HeaderText = "顾客地址";
            this.ColumnAddress.Name = "ColumnAddress";
            this.ColumnAddress.ReadOnly = true;
            // 
            // ColumnMark
            // 
            this.ColumnMark.DataPropertyName = "Mark";
            this.ColumnMark.HeaderText = "备注";
            this.ColumnMark.Name = "ColumnMark";
            this.ColumnMark.ReadOnly = true;
            // 
            // SelectCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 452);
            this.Controls.Add(this.dataGridCustomerView);
            this.Controls.Add(this.textBoxConditons);
            this.Controls.Add(this.label1);
            this.Name = "SelectCustomer";
            this.Text = "顾客选择";
            this.Load += new System.EventHandler(this.SelectCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomerView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxConditons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridCustomerView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMark;
    }
}