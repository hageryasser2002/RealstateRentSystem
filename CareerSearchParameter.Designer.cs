using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class CareerSearchParameter
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.realStateDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.careerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dScareersearch = new RealStateRentSystem.DSTables.DScareersearch();
            this.dsrealsearchown = new RealStateRentSystem.DSTables.DSrealsearchown();
            this.realStateTableAdapter = new RealStateRentSystem.DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter();
            this.careerTableAdapter = new RealStateRentSystem.DSTables.DScareersearchTableAdapters.careerTableAdapter();
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel_right = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_closing = new System.Windows.Forms.Panel();
            this.header_lbl = new System.Windows.Forms.Label();
            this.Close_btn = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.careertypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataofchangedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.realStateDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.careerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dScareersearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsrealsearchown)).BeginInit();
            this.panel_closing.SuspendLayout();
            this.SuspendLayout();
            // 
            // realStateDataGridView
            // 
            this.realStateDataGridView.AllowUserToAddRows = false;
            this.realStateDataGridView.AllowUserToDeleteRows = false;
            this.realStateDataGridView.AllowUserToOrderColumns = true;
            this.realStateDataGridView.AutoGenerateColumns = false;
            this.realStateDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.realStateDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.realStateDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.realStateDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.realStateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.realStateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.Column1,
            this.nameDataGridViewTextBoxColumn,
            this.careertypeDataGridViewTextBoxColumn,
            this.pDataGridViewTextBoxColumn,
            this.mDataGridViewTextBoxColumn,
            this.otherDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.dataofchangedDataGridViewTextBoxColumn,
            this.userDataGridViewTextBoxColumn});
            this.realStateDataGridView.DataSource = this.careerBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.realStateDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.realStateDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.realStateDataGridView.Location = new System.Drawing.Point(5, 41);
            this.realStateDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.realStateDataGridView.Name = "realStateDataGridView";
            this.realStateDataGridView.ReadOnly = true;
            this.realStateDataGridView.RowHeadersWidth = 51;
            this.realStateDataGridView.Size = new System.Drawing.Size(1405, 689);
            this.realStateDataGridView.TabIndex = 61;
            this.realStateDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.realStateDataGridView_CellContentClick);
            this.realStateDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.realStateDataGridView_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // careerBindingSource
            // 
            this.careerBindingSource.DataMember = "career";
            this.careerBindingSource.DataSource = this.dScareersearch;
            // 
            // dScareersearch
            // 
            this.dScareersearch.DataSetName = "DScareersearch";
            this.dScareersearch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsrealsearchown
            // 
            this.dsrealsearchown.DataSetName = "dsrealsearchown";
            this.dsrealsearchown.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // realStateTableAdapter
            // 
            this.realStateTableAdapter.ClearBeforeFill = true;
            // 
            // careerTableAdapter
            // 
            this.careerTableAdapter.ClearBeforeFill = true;
            // 
            // panel_top
            // 
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1413, 5);
            this.panel_top.TabIndex = 62;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(1410, 5);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(3, 730);
            this.panel_right.TabIndex = 63;
            // 
            // panel_left
            // 
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 5);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(5, 730);
            this.panel_left.TabIndex = 64;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(5, 730);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(1405, 5);
            this.panel_bottom.TabIndex = 65;
            // 
            // panel_closing
            // 
            this.panel_closing.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_closing.Controls.Add(this.header_lbl);
            this.panel_closing.Controls.Add(this.Close_btn);
            this.panel_closing.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_closing.Location = new System.Drawing.Point(5, 5);
            this.panel_closing.Name = "panel_closing";
            this.panel_closing.Size = new System.Drawing.Size(1405, 36);
            this.panel_closing.TabIndex = 66;
            // 
            // header_lbl
            // 
            this.header_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.header_lbl.AutoSize = true;
            this.header_lbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.header_lbl.Location = new System.Drawing.Point(1290, 12);
            this.header_lbl.Name = "header_lbl";
            this.header_lbl.Size = new System.Drawing.Size(108, 17);
            this.header_lbl.TabIndex = 1;
            this.header_lbl.Text = "بحث في المهن";
            // 
            // Close_btn
            // 
            this.Close_btn.BackColor = System.Drawing.Color.Brown;
            this.Close_btn.Font = new System.Drawing.Font("Source Sans Pro Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Close_btn.ForeColor = System.Drawing.Color.White;
            this.Close_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Close_btn.Location = new System.Drawing.Point(3, 2);
            this.Close_btn.Margin = new System.Windows.Forms.Padding(0);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(30, 30);
            this.Close_btn.TabIndex = 0;
            this.Close_btn.Text = "x";
            this.Close_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Close_btn.UseVisualStyleBackColor = false;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "الاسم";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 73;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "careertype";
            this.dataGridViewTextBoxColumn3.HeaderText = "المهنة";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 74;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "p";
            this.dataGridViewTextBoxColumn4.HeaderText = "هاتف";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 67;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "m";
            this.dataGridViewTextBoxColumn5.HeaderText = "موبايل";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 72;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "other";
            this.dataGridViewTextBoxColumn6.HeaderText = "اخر";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 55;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "notes";
            this.dataGridViewTextBoxColumn7.HeaderText = "ملاحظات";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 88;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "category";
            this.dataGridViewTextBoxColumn8.HeaderText = "التصنيف";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 83;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "dataofchanged";
            this.dataGridViewTextBoxColumn9.HeaderText = "dataofchanged";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "user";
            this.dataGridViewTextBoxColumn10.HeaderText = "user";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "الاسم";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // careertypeDataGridViewTextBoxColumn
            // 
            this.careertypeDataGridViewTextBoxColumn.DataPropertyName = "careertype";
            this.careertypeDataGridViewTextBoxColumn.HeaderText = "المهنة";
            this.careertypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.careertypeDataGridViewTextBoxColumn.Name = "careertypeDataGridViewTextBoxColumn";
            this.careertypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pDataGridViewTextBoxColumn
            // 
            this.pDataGridViewTextBoxColumn.DataPropertyName = "p";
            this.pDataGridViewTextBoxColumn.HeaderText = "هاتف";
            this.pDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pDataGridViewTextBoxColumn.Name = "pDataGridViewTextBoxColumn";
            this.pDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mDataGridViewTextBoxColumn
            // 
            this.mDataGridViewTextBoxColumn.DataPropertyName = "m";
            this.mDataGridViewTextBoxColumn.HeaderText = "موبايل";
            this.mDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mDataGridViewTextBoxColumn.Name = "mDataGridViewTextBoxColumn";
            this.mDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // otherDataGridViewTextBoxColumn
            // 
            this.otherDataGridViewTextBoxColumn.DataPropertyName = "other";
            this.otherDataGridViewTextBoxColumn.HeaderText = "اخر";
            this.otherDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.otherDataGridViewTextBoxColumn.Name = "otherDataGridViewTextBoxColumn";
            this.otherDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "ملاحظات";
            this.notesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "التصنيف";
            this.categoryDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataofchangedDataGridViewTextBoxColumn
            // 
            this.dataofchangedDataGridViewTextBoxColumn.DataPropertyName = "dataofchanged";
            this.dataofchangedDataGridViewTextBoxColumn.HeaderText = "dataofchanged";
            this.dataofchangedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataofchangedDataGridViewTextBoxColumn.Name = "dataofchangedDataGridViewTextBoxColumn";
            this.dataofchangedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataofchangedDataGridViewTextBoxColumn.Visible = false;
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.DataPropertyName = "user";
            this.userDataGridViewTextBoxColumn.HeaderText = "user";
            this.userDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            this.userDataGridViewTextBoxColumn.ReadOnly = true;
            this.userDataGridViewTextBoxColumn.Visible = false;
            // 
            // CareerSearchParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1413, 735);
            this.Controls.Add(this.realStateDataGridView);
            this.Controls.Add(this.panel_closing);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CareerSearchParameter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "بحث";
            this.Load += new System.EventHandler(this.Realstate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.realStateDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.careerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dScareersearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsrealsearchown)).EndInit();
            this.panel_closing.ResumeLayout(false);
            this.panel_closing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DSrealsearchown dsrealsearchown;
        private DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter realStateTableAdapter;
        private System.Windows.Forms.DataGridView realStateDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private DScareersearch dScareersearch;
        private System.Windows.Forms.BindingSource careerBindingSource;
        private DSTables.DScareersearchTableAdapters.careerTableAdapter careerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn careertypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataofchangedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_closing;
        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.Label header_lbl;
    }
}