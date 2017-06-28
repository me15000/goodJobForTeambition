namespace goodJob
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dropPanel = new System.Windows.Forms.Panel();
            this.labelPanel = new System.Windows.Forms.Label();
            this.dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonAn = new System.Windows.Forms.Button();
            this.textBoxPaths = new System.Windows.Forms.TextBox();
            this.buttonEx = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonCurr = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.radioButtonComp = new System.Windows.Forms.RadioButton();
            this.groupBoxComp = new System.Windows.Forms.GroupBox();
            this.radioButtonCompAll = new System.Windows.Forms.RadioButton();
            this.radioButtonNotComp = new System.Windows.Forms.RadioButton();
            this.checkBoxType = new System.Windows.Forms.CheckBox();
            this.dropPanel.SuspendLayout();
            this.groupBoxComp.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropPanel
            // 
            this.dropPanel.AllowDrop = true;
            this.dropPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dropPanel.Controls.Add(this.labelPanel);
            this.dropPanel.Location = new System.Drawing.Point(12, 12);
            this.dropPanel.Name = "dropPanel";
            this.dropPanel.Size = new System.Drawing.Size(1160, 69);
            this.dropPanel.TabIndex = 0;
            this.dropPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropPanel_DragDrop);
            this.dropPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.dropPanel_DragEnter);
            this.dropPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.dropPanel_Paint);
            // 
            // labelPanel
            // 
            this.labelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPanel.AutoSize = true;
            this.labelPanel.Location = new System.Drawing.Point(402, 31);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(89, 12);
            this.labelPanel.TabIndex = 0;
            this.labelPanel.Text = "把文件拖入这里";
            this.labelPanel.Click += new System.EventHandler(this.labelPanel_Click);
            // 
            // dateTimePickerBegin
            // 
            this.dateTimePickerBegin.Location = new System.Drawing.Point(12, 114);
            this.dateTimePickerBegin.Name = "dateTimePickerBegin";
            this.dateTimePickerBegin.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerBegin.TabIndex = 1;
            this.dateTimePickerBegin.ValueChanged += new System.EventHandler(this.dateTimePickerBegin_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(218, 114);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerEnd.TabIndex = 2;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // buttonAn
            // 
            this.buttonAn.Location = new System.Drawing.Point(542, 113);
            this.buttonAn.Name = "buttonAn";
            this.buttonAn.Size = new System.Drawing.Size(100, 23);
            this.buttonAn.TabIndex = 4;
            this.buttonAn.Text = "分析数据";
            this.buttonAn.UseVisualStyleBackColor = true;
            this.buttonAn.Click += new System.EventHandler(this.buttonAn_Click);
            // 
            // textBoxPaths
            // 
            this.textBoxPaths.Location = new System.Drawing.Point(12, 87);
            this.textBoxPaths.Name = "textBoxPaths";
            this.textBoxPaths.Size = new System.Drawing.Size(817, 21);
            this.textBoxPaths.TabIndex = 5;
            // 
            // buttonEx
            // 
            this.buttonEx.Location = new System.Drawing.Point(648, 113);
            this.buttonEx.Name = "buttonEx";
            this.buttonEx.Size = new System.Drawing.Size(100, 23);
            this.buttonEx.TabIndex = 6;
            this.buttonEx.Text = "导出数据";
            this.buttonEx.UseVisualStyleBackColor = true;
            this.buttonEx.Click += new System.EventHandler(this.buttonEx_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Location = new System.Drawing.Point(12, 142);
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(1160, 449);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(430, 113);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(50, 23);
            this.buttonPrev.TabIndex = 8;
            this.buttonPrev.Text = "上月";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonCurr
            // 
            this.buttonCurr.Location = new System.Drawing.Point(486, 113);
            this.buttonCurr.Name = "buttonCurr";
            this.buttonCurr.Size = new System.Drawing.Size(50, 23);
            this.buttonCurr.TabIndex = 9;
            this.buttonCurr.Text = "本月";
            this.buttonCurr.UseVisualStyleBackColor = true;
            this.buttonCurr.Click += new System.EventHandler(this.buttonCurr_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(754, 113);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "清空数据";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // radioButtonComp
            // 
            this.radioButtonComp.AutoSize = true;
            this.radioButtonComp.Location = new System.Drawing.Point(6, 13);
            this.radioButtonComp.Name = "radioButtonComp";
            this.radioButtonComp.Size = new System.Drawing.Size(59, 16);
            this.radioButtonComp.TabIndex = 13;
            this.radioButtonComp.Text = "已完成";
            this.radioButtonComp.UseVisualStyleBackColor = true;
            this.radioButtonComp.CheckedChanged += new System.EventHandler(this.radioButtonComp_CheckedChanged);
            // 
            // groupBoxComp
            // 
            this.groupBoxComp.Controls.Add(this.radioButtonCompAll);
            this.groupBoxComp.Controls.Add(this.radioButtonNotComp);
            this.groupBoxComp.Controls.Add(this.radioButtonComp);
            this.groupBoxComp.Location = new System.Drawing.Point(835, 101);
            this.groupBoxComp.Name = "groupBoxComp";
            this.groupBoxComp.Size = new System.Drawing.Size(195, 35);
            this.groupBoxComp.TabIndex = 14;
            this.groupBoxComp.TabStop = false;
            this.groupBoxComp.Text = "完成";
            // 
            // radioButtonCompAll
            // 
            this.radioButtonCompAll.AutoSize = true;
            this.radioButtonCompAll.Checked = true;
            this.radioButtonCompAll.Location = new System.Drawing.Point(136, 13);
            this.radioButtonCompAll.Name = "radioButtonCompAll";
            this.radioButtonCompAll.Size = new System.Drawing.Size(47, 16);
            this.radioButtonCompAll.TabIndex = 15;
            this.radioButtonCompAll.TabStop = true;
            this.radioButtonCompAll.Text = "全部";
            this.radioButtonCompAll.UseVisualStyleBackColor = true;
            this.radioButtonCompAll.CheckedChanged += new System.EventHandler(this.radioButtonCompAll_CheckedChanged);
            // 
            // radioButtonNotComp
            // 
            this.radioButtonNotComp.AutoSize = true;
            this.radioButtonNotComp.Location = new System.Drawing.Point(71, 13);
            this.radioButtonNotComp.Name = "radioButtonNotComp";
            this.radioButtonNotComp.Size = new System.Drawing.Size(59, 16);
            this.radioButtonNotComp.TabIndex = 14;
            this.radioButtonNotComp.Text = "未完成";
            this.radioButtonNotComp.UseVisualStyleBackColor = true;
            this.radioButtonNotComp.CheckedChanged += new System.EventHandler(this.radioButtonNotComp_CheckedChanged);
            // 
            // checkBoxType
            // 
            this.checkBoxType.AutoSize = true;
            this.checkBoxType.Location = new System.Drawing.Point(1036, 115);
            this.checkBoxType.Name = "checkBoxType";
            this.checkBoxType.Size = new System.Drawing.Size(132, 16);
            this.checkBoxType.TabIndex = 15;
            this.checkBoxType.Text = "根据任务创建者分析";
            this.checkBoxType.UseVisualStyleBackColor = true;
            this.checkBoxType.CheckedChanged += new System.EventHandler(this.checkBoxType_CheckedChanged);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 602);
            this.Controls.Add(this.checkBoxType);
            this.Controls.Add(this.groupBoxComp);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonCurr);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.buttonEx);
            this.Controls.Add(this.textBoxPaths);
            this.Controls.Add(this.buttonAn);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerBegin);
            this.Controls.Add(this.dropPanel);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "GoodJob";
            this.dropPanel.ResumeLayout(false);
            this.dropPanel.PerformLayout();
            this.groupBoxComp.ResumeLayout(false);
            this.groupBoxComp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel dropPanel;
        private System.Windows.Forms.Label labelPanel;
        private System.Windows.Forms.DateTimePicker dateTimePickerBegin;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button buttonAn;
        private System.Windows.Forms.TextBox textBoxPaths;
        private System.Windows.Forms.Button buttonEx;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonCurr;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RadioButton radioButtonComp;
        private System.Windows.Forms.GroupBox groupBoxComp;
        private System.Windows.Forms.RadioButton radioButtonCompAll;
        private System.Windows.Forms.RadioButton radioButtonNotComp;
        private System.Windows.Forms.CheckBox checkBoxType;
    }
}

