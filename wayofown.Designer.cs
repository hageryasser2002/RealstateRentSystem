using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class wayofown
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
            System.Windows.Forms.Label nameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wayofown));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dSrealowner = new RealStateRentSystem.DSTables.DSrealowner();
            this.wayOFOwnerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wayOFOwnerTableAdapter = new RealStateRentSystem.DSTables.DSrealownerTableAdapters.WayOFOwnerTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSrealownerTableAdapters.TableAdapterManager();
            this.wayOFOwnerBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.wayOFOwnerBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.wayOFOwnerDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealowner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerBindingNavigator)).BeginInit();
            this.wayOFOwnerBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(10, 52);
            nameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(104, 19);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "اسم الطريقة :";
            // 
            // dSrealowner
            // 
            this.dSrealowner.DataSetName = "DSrealowner";
            this.dSrealowner.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wayOFOwnerBindingSource
            // 
            this.wayOFOwnerBindingSource.DataMember = "WayOFOwner";
            this.wayOFOwnerBindingSource.DataSource = this.dSrealowner;
            // 
            // wayOFOwnerTableAdapter
            // 
            this.wayOFOwnerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.attachmentOwnTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BuildingTypeTableAdapter = null;
            this.tableAdapterManager.eventownTableAdapter = null;
            this.tableAdapterManager.OwnInvestitureTableAdapter = null;
            this.tableAdapterManager.OwnSettingTableAdapter = null;
            this.tableAdapterManager.RealstateOwneTableAdapter = null;
            this.tableAdapterManager.RegionTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSrealownerTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WayOFOwnerTableAdapter = this.wayOFOwnerTableAdapter;
            // 
            // wayOFOwnerBindingNavigator
            // 
            this.wayOFOwnerBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.wayOFOwnerBindingNavigator.BindingSource = this.wayOFOwnerBindingSource;
            this.wayOFOwnerBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.wayOFOwnerBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.wayOFOwnerBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.wayOFOwnerBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.wayOFOwnerBindingNavigatorSaveItem});
            this.wayOFOwnerBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.wayOFOwnerBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.wayOFOwnerBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.wayOFOwnerBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.wayOFOwnerBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.wayOFOwnerBindingNavigator.Name = "wayOFOwnerBindingNavigator";
            this.wayOFOwnerBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.wayOFOwnerBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.wayOFOwnerBindingNavigator.Size = new System.Drawing.Size(400, 38);
            this.wayOFOwnerBindingNavigator.TabIndex = 0;
            this.wayOFOwnerBindingNavigator.Text = "bindingNavigator1";
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
            // wayOFOwnerBindingNavigatorSaveItem
            // 
            this.wayOFOwnerBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wayOFOwnerBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("wayOFOwnerBindingNavigatorSaveItem.Image")));
            this.wayOFOwnerBindingNavigatorSaveItem.Name = "wayOFOwnerBindingNavigatorSaveItem";
            this.wayOFOwnerBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 24);
            this.wayOFOwnerBindingNavigatorSaveItem.Text = "Save Data";
            this.wayOFOwnerBindingNavigatorSaveItem.Click += new System.EventHandler(this.wayOFOwnerBindingNavigatorSaveItem_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.wayOFOwnerBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(117, 49);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(293, 27);
            this.nameTextBox.TabIndex = 4;
            // 
            // wayOFOwnerDataGridView
            // 
            this.wayOFOwnerDataGridView.AutoGenerateColumns = false;
            this.wayOFOwnerDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.wayOFOwnerDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wayOFOwnerDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.wayOFOwnerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wayOFOwnerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.wayOFOwnerDataGridView.DataSource = this.wayOFOwnerBindingSource;
            this.wayOFOwnerDataGridView.Location = new System.Drawing.Point(18, 87);
            this.wayOFOwnerDataGridView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.wayOFOwnerDataGridView.Name = "wayOFOwnerDataGridView";
            this.wayOFOwnerDataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.wayOFOwnerDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.wayOFOwnerDataGridView.Size = new System.Drawing.Size(395, 347);
            this.wayOFOwnerDataGridView.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // wayofown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 413);
            this.Controls.Add(this.wayOFOwnerDataGridView);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.wayOFOwnerBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(422, 469);
            this.MinimumSize = new System.Drawing.Size(422, 469);
            this.Name = "wayofown";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طريقة البيع";
            this.Load += new System.EventHandler(this.wayofrent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSrealowner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerBindingNavigator)).EndInit();
            this.wayOFOwnerBindingNavigator.ResumeLayout(false);
            this.wayOFOwnerBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSrealowner dSrealowner;
        private System.Windows.Forms.BindingSource wayOFOwnerBindingSource;
        private DSTables.DSrealownerTableAdapters.WayOFOwnerTableAdapter wayOFOwnerTableAdapter;
        private DSTables.DSrealownerTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator wayOFOwnerBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton wayOFOwnerBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DataGridView wayOFOwnerDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}