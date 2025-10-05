using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class ShortCutKeys
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
            System.Windows.Forms.Label textLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortCutKeys));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dSsetting = new RealStateRentSystem.DSTables.DSsetting();
            this.shorCutKeysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shorCutKeysTableAdapter = new RealStateRentSystem.DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager();
            this.shorCutKeysBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.shorCutKeysBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.key_OneTextBox = new System.Windows.Forms.TextBox();
            this.key_TwoTextBox = new System.Windows.Forms.TextBox();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.shorCutKeysDataGridView = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            textLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shorCutKeysBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shorCutKeysBindingNavigator)).BeginInit();
            this.shorCutKeysBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shorCutKeysDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            textLabel.Location = new System.Drawing.Point(396, 36);
            textLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            textLabel.Name = "textLabel";
            textLabel.Size = new System.Drawing.Size(74, 19);
            textLabel.TabIndex = 7;
            textLabel.Text = "الأختصار :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            label1.Location = new System.Drawing.Point(4, 36);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 19);
            label1.TabIndex = 11;
            label1.Text = "المفاتيح :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            label2.Location = new System.Drawing.Point(89, 37);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 19);
            label2.TabIndex = 12;
            label2.Text = "المفتاح الاول :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            label3.Location = new System.Drawing.Point(239, 37);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(113, 19);
            label3.TabIndex = 13;
            label3.Text = "المفتاح الثاني :";
            // 
            // dSsetting
            // 
            this.dSsetting.DataSetName = "DSsetting";
            this.dSsetting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // shorCutKeysBindingSource
            // 
            this.shorCutKeysBindingSource.DataMember = "ShorCutKeys";
            this.shorCutKeysBindingSource.DataSource = this.dSsetting;
            // 
            // shorCutKeysTableAdapter
            // 
            this.shorCutKeysTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PCinfoTableAdapter = null;
            this.tableAdapterManager.RealStaticTableAdapter = null;
            this.tableAdapterManager.SettingTableAdapter = null;
            this.tableAdapterManager.ShorCutKeysTableAdapter = this.shorCutKeysTableAdapter;
            this.tableAdapterManager.StaticTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // shorCutKeysBindingNavigator
            // 
            this.shorCutKeysBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.shorCutKeysBindingNavigator.BindingSource = this.shorCutKeysBindingSource;
            this.shorCutKeysBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.shorCutKeysBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.shorCutKeysBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.shorCutKeysBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.shorCutKeysBindingNavigatorSaveItem});
            this.shorCutKeysBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.shorCutKeysBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.shorCutKeysBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.shorCutKeysBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.shorCutKeysBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.shorCutKeysBindingNavigator.Name = "shorCutKeysBindingNavigator";
            this.shorCutKeysBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.shorCutKeysBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.shorCutKeysBindingNavigator.Size = new System.Drawing.Size(904, 38);
            this.shorCutKeysBindingNavigator.TabIndex = 0;
            this.shorCutKeysBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 33);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(73, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // shorCutKeysBindingNavigatorSaveItem
            // 
            this.shorCutKeysBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shorCutKeysBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("shorCutKeysBindingNavigatorSaveItem.Image")));
            this.shorCutKeysBindingNavigatorSaveItem.Name = "shorCutKeysBindingNavigatorSaveItem";
            this.shorCutKeysBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 33);
            this.shorCutKeysBindingNavigatorSaveItem.Text = "Save Data";
            this.shorCutKeysBindingNavigatorSaveItem.Click += new System.EventHandler(this.shorCutKeysBindingNavigatorSaveItem_Click);
            // 
            // key_OneTextBox
            // 
            this.key_OneTextBox.BackColor = System.Drawing.Color.White;
            this.key_OneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shorCutKeysBindingSource, "Key_One", true));
            this.key_OneTextBox.ForeColor = System.Drawing.Color.Red;
            this.key_OneTextBox.Location = new System.Drawing.Point(242, 46);
            this.key_OneTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.key_OneTextBox.Name = "key_OneTextBox";
            this.key_OneTextBox.ReadOnly = true;
            this.key_OneTextBox.Size = new System.Drawing.Size(89, 27);
            this.key_OneTextBox.TabIndex = 1;
            // 
            // key_TwoTextBox
            // 
            this.key_TwoTextBox.BackColor = System.Drawing.Color.White;
            this.key_TwoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shorCutKeysBindingSource, "Key_Two", true));
            this.key_TwoTextBox.ForeColor = System.Drawing.Color.Red;
            this.key_TwoTextBox.Location = new System.Drawing.Point(469, 46);
            this.key_TwoTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.key_TwoTextBox.Name = "key_TwoTextBox";
            this.key_TwoTextBox.ReadOnly = true;
            this.key_TwoTextBox.Size = new System.Drawing.Size(89, 27);
            this.key_TwoTextBox.TabIndex = 2;
            // 
            // textTextBox
            // 
            this.textTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shorCutKeysBindingSource, "Text", true));
            this.textTextBox.Location = new System.Drawing.Point(658, 45);
            this.textTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(246, 27);
            this.textTextBox.TabIndex = 3;
            this.textTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textTextBox_KeyUp);
            // 
            // shorCutKeysDataGridView
            // 
            this.shorCutKeysDataGridView.AllowUserToAddRows = false;
            this.shorCutKeysDataGridView.AutoGenerateColumns = false;
            this.shorCutKeysDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.shorCutKeysDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shorCutKeysDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.shorCutKeysDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shorCutKeysDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.shorCutKeysDataGridView.DataSource = this.shorCutKeysBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.shorCutKeysDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.shorCutKeysDataGridView.Location = new System.Drawing.Point(10, 82);
            this.shorCutKeysDataGridView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.shorCutKeysDataGridView.Name = "shorCutKeysDataGridView";
            this.shorCutKeysDataGridView.ReadOnly = true;
            this.shorCutKeysDataGridView.RowHeadersWidth = 51;
            this.shorCutKeysDataGridView.Size = new System.Drawing.Size(892, 628);
            this.shorCutKeysDataGridView.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(86, 46);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(37, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textTextBox_KeyUp);
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Key_One";
            this.dataGridViewTextBoxColumn2.HeaderText = "المفتاح الاول";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Key_Two";
            this.dataGridViewTextBoxColumn3.HeaderText = "المفتاح التاني";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Text";
            this.dataGridViewTextBoxColumn4.HeaderText = "الاختصار";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 350;
            // 
            // ShortCutKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(894, 679);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.shorCutKeysDataGridView);
            this.Controls.Add(textLabel);
            this.Controls.Add(this.textTextBox);
            this.Controls.Add(this.shorCutKeysBindingNavigator);
            this.Controls.Add(this.key_OneTextBox);
            this.Controls.Add(this.key_TwoTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(916, 735);
            this.MinimumSize = new System.Drawing.Size(916, 735);
            this.Name = "ShortCutKeys";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مفاتيح الاختصارات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShortCutKeys_FormClosing);
            this.Load += new System.EventHandler(this.ShortCutKeys_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shorCutKeysBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shorCutKeysBindingNavigator)).EndInit();
            this.shorCutKeysBindingNavigator.ResumeLayout(false);
            this.shorCutKeysBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shorCutKeysDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSsetting dSsetting;
        private System.Windows.Forms.BindingSource shorCutKeysBindingSource;
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter;
        private DSTables.DSsettingTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator shorCutKeysBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton shorCutKeysBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox key_OneTextBox;
        private System.Windows.Forms.TextBox key_TwoTextBox;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.DataGridView shorCutKeysDataGridView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

    }
}