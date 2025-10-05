using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class CareerType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CareerType));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dScareer = new RealStateRentSystem.DSTables.DScareer();
            this.typeOfcarrerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.typeOfcarrerTableAdapter = new RealStateRentSystem.DSTables.DScareerTableAdapters.TypeOfcarrerTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DScareerTableAdapters.TableAdapterManager();
            this.typeOfcarrerBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.typeOfcarrerBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.typeOfcarrerDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dScareer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerBindingNavigator)).BeginInit();
            this.typeOfcarrerBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(15, 59);
            nameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(52, 19);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "النوع :";
            // 
            // dScareer
            // 
            this.dScareer.DataSetName = "DScareer";
            this.dScareer.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // typeOfcarrerBindingSource
            // 
            this.typeOfcarrerBindingSource.DataMember = "TypeOfcarrer";
            this.typeOfcarrerBindingSource.DataSource = this.dScareer;
            // 
            // typeOfcarrerTableAdapter
            // 
            this.typeOfcarrerTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.careerAttachTableAdapter = null;
            this.tableAdapterManager.careerCatogTableAdapter = null;
            this.tableAdapterManager.careerEventTableAdapter = null;
            this.tableAdapterManager.careerTableAdapter = null;
            this.tableAdapterManager.TypeOfcarrerTableAdapter = this.typeOfcarrerTableAdapter;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DScareerTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // typeOfcarrerBindingNavigator
            // 
            this.typeOfcarrerBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.typeOfcarrerBindingNavigator.BindingSource = this.typeOfcarrerBindingSource;
            this.typeOfcarrerBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.typeOfcarrerBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.typeOfcarrerBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.typeOfcarrerBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.typeOfcarrerBindingNavigatorSaveItem});
            this.typeOfcarrerBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.typeOfcarrerBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.typeOfcarrerBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.typeOfcarrerBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.typeOfcarrerBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.typeOfcarrerBindingNavigator.Name = "typeOfcarrerBindingNavigator";
            this.typeOfcarrerBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.typeOfcarrerBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.typeOfcarrerBindingNavigator.Size = new System.Drawing.Size(409, 38);
            this.typeOfcarrerBindingNavigator.TabIndex = 0;
            this.typeOfcarrerBindingNavigator.Text = "bindingNavigator1";
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
            // typeOfcarrerBindingNavigatorSaveItem
            // 
            this.typeOfcarrerBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.typeOfcarrerBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("typeOfcarrerBindingNavigatorSaveItem.Image")));
            this.typeOfcarrerBindingNavigatorSaveItem.Name = "typeOfcarrerBindingNavigatorSaveItem";
            this.typeOfcarrerBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 33);
            this.typeOfcarrerBindingNavigatorSaveItem.Text = "Save Data";
            this.typeOfcarrerBindingNavigatorSaveItem.Click += new System.EventHandler(this.typeOfcarrerBindingNavigatorSaveItem_Click);
            // 
            // typeOfcarrerDataGridView
            // 
            this.typeOfcarrerDataGridView.AutoGenerateColumns = false;
            this.typeOfcarrerDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.typeOfcarrerDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.typeOfcarrerDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.typeOfcarrerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.typeOfcarrerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.typeOfcarrerDataGridView.DataSource = this.typeOfcarrerBindingSource;
            this.typeOfcarrerDataGridView.Location = new System.Drawing.Point(15, 93);
            this.typeOfcarrerDataGridView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.typeOfcarrerDataGridView.Name = "typeOfcarrerDataGridView";
            this.typeOfcarrerDataGridView.RowHeadersWidth = 51;
            this.typeOfcarrerDataGridView.Size = new System.Drawing.Size(401, 594);
            this.typeOfcarrerDataGridView.TabIndex = 1;
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "النوع";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.typeOfcarrerBindingSource, "name", true));
            this.nameTextBox.Location = new System.Drawing.Point(78, 55);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(336, 27);
            this.nameTextBox.TabIndex = 3;
            // 
            // CareerType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(409, 659);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.typeOfcarrerDataGridView);
            this.Controls.Add(this.typeOfcarrerBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(431, 715);
            this.MinimumSize = new System.Drawing.Size(431, 715);
            this.Name = "CareerType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انواع المهن";
            this.Load += new System.EventHandler(this.wayofrent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dScareer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerBindingNavigator)).EndInit();
            this.typeOfcarrerBindingNavigator.ResumeLayout(false);
            this.typeOfcarrerBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DScareer dScareer;
        private System.Windows.Forms.BindingSource typeOfcarrerBindingSource;
        private DSTables.DScareerTableAdapters.TypeOfcarrerTableAdapter typeOfcarrerTableAdapter;
        private DSTables.DScareerTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator typeOfcarrerBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton typeOfcarrerBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView typeOfcarrerDataGridView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

    }
}