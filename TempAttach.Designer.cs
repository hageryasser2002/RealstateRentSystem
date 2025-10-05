using RealStateRentSystem.DSTables;
namespace RealStateRentSystem
{
    partial class TempAttach
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
            System.Windows.Forms.Label template_NameLabel;
            System.Windows.Forms.Label fileNameLabel;
            System.Windows.Forms.Label dateOFAttashLabel;
            System.Windows.Forms.Label regionLabel;
            System.Windows.Forms.Label subregionLabel;
            System.Windows.Forms.Label buildingLabel;
            System.Windows.Forms.Label pathLabel;
            System.Windows.Forms.Label commentLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TempAttach));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button3 = new System.Windows.Forms.Button();
            this.dSTempAttch = new RealStateRentSystem.DSTables.DSTempAttch();
            this.tempAttachmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tempAttachmentTableAdapter = new RealStateRentSystem.DSTables.DSTempAttchTableAdapters.TempAttachmentTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSTempAttchTableAdapters.TableAdapterManager();
            this.tempAttachmentBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.tempAttachmentBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.template_NameTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.dateOFAttashDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.subregionTextBox = new System.Windows.Forms.TextBox();
            this.buildingTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.regionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSregion = new RealStateRentSystem.DSTables.DSregion();
            this.regionTableAdapter = new RealStateRentSystem.DSTables.DSregionTableAdapters.RegionTableAdapter();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.tempAttachmentDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            template_NameLabel = new System.Windows.Forms.Label();
            fileNameLabel = new System.Windows.Forms.Label();
            dateOFAttashLabel = new System.Windows.Forms.Label();
            regionLabel = new System.Windows.Forms.Label();
            subregionLabel = new System.Windows.Forms.Label();
            buildingLabel = new System.Windows.Forms.Label();
            pathLabel = new System.Windows.Forms.Label();
            commentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSTempAttch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempAttachmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempAttachmentBindingNavigator)).BeginInit();
            this.tempAttachmentBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSregion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempAttachmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // template_NameLabel
            // 
            template_NameLabel.AutoSize = true;
            template_NameLabel.Location = new System.Drawing.Point(337, 51);
            template_NameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            template_NameLabel.Name = "template_NameLabel";
            template_NameLabel.Size = new System.Drawing.Size(105, 19);
            template_NameLabel.TabIndex = 30;
            template_NameLabel.Text = "اسم النموذج :";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new System.Drawing.Point(707, 122);
            fileNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new System.Drawing.Size(60, 19);
            fileNameLabel.TabIndex = 32;
            fileNameLabel.Text = "الملف :";
            // 
            // dateOFAttashLabel
            // 
            dateOFAttashLabel.AutoSize = true;
            dateOFAttashLabel.Location = new System.Drawing.Point(282, 405);
            dateOFAttashLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dateOFAttashLabel.Name = "dateOFAttashLabel";
            dateOFAttashLabel.Size = new System.Drawing.Size(101, 19);
            dateOFAttashLabel.TabIndex = 36;
            dateOFAttashLabel.Text = "تاريخ الارفاق :";
            // 
            // regionLabel
            // 
            regionLabel.AutoSize = true;
            regionLabel.Location = new System.Drawing.Point(693, 51);
            regionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            regionLabel.Name = "regionLabel";
            regionLabel.Size = new System.Drawing.Size(73, 19);
            regionLabel.TabIndex = 38;
            regionLabel.Text = "المنطقة :";
            // 
            // subregionLabel
            // 
            subregionLabel.AutoSize = true;
            subregionLabel.Location = new System.Drawing.Point(316, 87);
            subregionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            subregionLabel.Name = "subregionLabel";
            subregionLabel.Size = new System.Drawing.Size(129, 19);
            subregionLabel.TabIndex = 40;
            subregionLabel.Text = "الجزيرة \\ الشارع :";
            // 
            // buildingLabel
            // 
            buildingLabel.AutoSize = true;
            buildingLabel.Location = new System.Drawing.Point(717, 88);
            buildingLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            buildingLabel.Name = "buildingLabel";
            buildingLabel.Size = new System.Drawing.Size(52, 19);
            buildingLabel.TabIndex = 42;
            buildingLabel.Text = "البناء :";
            // 
            // pathLabel
            // 
            pathLabel.AutoSize = true;
            pathLabel.Location = new System.Drawing.Point(557, 374);
            pathLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new System.Drawing.Size(46, 19);
            pathLabel.TabIndex = 44;
            pathLabel.Text = "path:";
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.Location = new System.Drawing.Point(375, 121);
            commentLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new System.Drawing.Size(69, 19);
            commentLabel.TabIndex = 47;
            commentLabel.Text = "التعليق :";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1017, 115);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 33);
            this.button3.TabIndex = 6;
            this.button3.Text = "استعراض";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dSTempAttch
            // 
            this.dSTempAttch.DataSetName = "DSTempAttch";
            this.dSTempAttch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tempAttachmentBindingSource
            // 
            this.tempAttachmentBindingSource.DataMember = "TempAttachment";
            this.tempAttachmentBindingSource.DataSource = this.dSTempAttch;
            // 
            // tempAttachmentTableAdapter
            // 
            this.tempAttachmentTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TempAttachmentTableAdapter = this.tempAttachmentTableAdapter;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSTempAttchTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tempAttachmentBindingNavigator
            // 
            this.tempAttachmentBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tempAttachmentBindingNavigator.BindingSource = this.tempAttachmentBindingSource;
            this.tempAttachmentBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tempAttachmentBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tempAttachmentBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tempAttachmentBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tempAttachmentBindingNavigatorSaveItem});
            this.tempAttachmentBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tempAttachmentBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tempAttachmentBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tempAttachmentBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tempAttachmentBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tempAttachmentBindingNavigator.Name = "tempAttachmentBindingNavigator";
            this.tempAttachmentBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tempAttachmentBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tempAttachmentBindingNavigator.Size = new System.Drawing.Size(1446, 31);
            this.tempAttachmentBindingNavigator.TabIndex = 28;
            this.tempAttachmentBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 26);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bindingNavigatorDeleteItem_MouseDown);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tempAttachmentBindingNavigatorSaveItem
            // 
            this.tempAttachmentBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tempAttachmentBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tempAttachmentBindingNavigatorSaveItem.Image")));
            this.tempAttachmentBindingNavigatorSaveItem.Name = "tempAttachmentBindingNavigatorSaveItem";
            this.tempAttachmentBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 26);
            this.tempAttachmentBindingNavigatorSaveItem.Text = "Save Data";
            this.tempAttachmentBindingNavigatorSaveItem.Click += new System.EventHandler(this.tempAttachmentBindingNavigatorSaveItem_Click);
            // 
            // template_NameTextBox
            // 
            this.template_NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tempAttachmentBindingSource, "Template_Name", true));
            this.template_NameTextBox.Location = new System.Drawing.Point(450, 46);
            this.template_NameTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.template_NameTextBox.Name = "template_NameTextBox";
            this.template_NameTextBox.Size = new System.Drawing.Size(237, 27);
            this.template_NameTextBox.TabIndex = 0;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tempAttachmentBindingSource, "FileName", true));
            this.fileNameTextBox.Enabled = false;
            this.fileNameTextBox.ForeColor = System.Drawing.Color.Red;
            this.fileNameTextBox.Location = new System.Drawing.Point(773, 116);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fileNameTextBox.Size = new System.Drawing.Size(237, 27);
            this.fileNameTextBox.TabIndex = 5;
            // 
            // dateOFAttashDateTimePicker
            // 
            this.dateOFAttashDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tempAttachmentBindingSource, "DateOFAttash", true));
            this.dateOFAttashDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOFAttashDateTimePicker.Location = new System.Drawing.Point(391, 399);
            this.dateOFAttashDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.dateOFAttashDateTimePicker.Name = "dateOFAttashDateTimePicker";
            this.dateOFAttashDateTimePicker.RightToLeftLayout = true;
            this.dateOFAttashDateTimePicker.Size = new System.Drawing.Size(140, 27);
            this.dateOFAttashDateTimePicker.TabIndex = 5;
            // 
            // subregionTextBox
            // 
            this.subregionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tempAttachmentBindingSource, "subregion", true));
            this.subregionTextBox.Location = new System.Drawing.Point(450, 82);
            this.subregionTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.subregionTextBox.Name = "subregionTextBox";
            this.subregionTextBox.Size = new System.Drawing.Size(237, 27);
            this.subregionTextBox.TabIndex = 2;
            this.subregionTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.subregionTextBox_MouseClick);
            this.subregionTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.subregionTextBox_KeyUp);
            this.subregionTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.subregionTextBox_MouseDown);
            // 
            // buildingTextBox
            // 
            this.buildingTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tempAttachmentBindingSource, "building", true));
            this.buildingTextBox.Location = new System.Drawing.Point(773, 82);
            this.buildingTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.buildingTextBox.Name = "buildingTextBox";
            this.buildingTextBox.Size = new System.Drawing.Size(237, 27);
            this.buildingTextBox.TabIndex = 3;
            this.buildingTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.subregionTextBox_MouseClick);
            this.buildingTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.subregionTextBox_KeyUp);
            this.buildingTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.subregionTextBox_MouseDown);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tempAttachmentBindingSource, "Region", true));
            this.comboBox1.DataSource = this.regionBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(774, 46);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 27);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "Name";
            this.comboBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.subregionTextBox_KeyUp);
            // 
            // regionBindingSource
            // 
            this.regionBindingSource.DataMember = "Region";
            this.regionBindingSource.DataSource = this.dSregion;
            // 
            // dSregion
            // 
            this.dSregion.DataSetName = "DSregion";
            this.dSregion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // regionTableAdapter
            // 
            this.regionTableAdapter.ClearBeforeFill = true;
            // 
            // pathTextBox
            // 
            this.pathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tempAttachmentBindingSource, "path", true));
            this.pathTextBox.Location = new System.Drawing.Point(615, 369);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(148, 27);
            this.pathTextBox.TabIndex = 45;
            // 
            // tempAttachmentDataGridView
            // 
            this.tempAttachmentDataGridView.AllowUserToAddRows = false;
            this.tempAttachmentDataGridView.AllowUserToDeleteRows = false;
            this.tempAttachmentDataGridView.AutoGenerateColumns = false;
            this.tempAttachmentDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.tempAttachmentDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tempAttachmentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tempAttachmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tempAttachmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.comment});
            this.tempAttachmentDataGridView.DataSource = this.tempAttachmentBindingSource;
            this.tempAttachmentDataGridView.Location = new System.Drawing.Point(0, 169);
            this.tempAttachmentDataGridView.Margin = new System.Windows.Forms.Padding(5);
            this.tempAttachmentDataGridView.Name = "tempAttachmentDataGridView";
            this.tempAttachmentDataGridView.ReadOnly = true;
            this.tempAttachmentDataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tempAttachmentDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tempAttachmentDataGridView.Size = new System.Drawing.Size(1446, 813);
            this.tempAttachmentDataGridView.TabIndex = 45;
            this.tempAttachmentDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tempAttachmentDataGridView_CellContentClick);
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Template_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "اسم النموذج";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FileName";
            this.dataGridViewTextBoxColumn3.HeaderText = "الملف";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DateOFAttash";
            this.dataGridViewTextBoxColumn4.HeaderText = "DateOFAttash";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Region";
            this.dataGridViewTextBoxColumn5.HeaderText = "المنطقه";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "subregion";
            this.dataGridViewTextBoxColumn6.HeaderText = "الشارع\\الجزيرة";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "building";
            this.dataGridViewTextBoxColumn7.HeaderText = "البناء";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 75;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "path";
            this.dataGridViewTextBoxColumn8.HeaderText = "path";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // comment
            // 
            this.comment.DataPropertyName = "comment";
            this.comment.HeaderText = "التعليق";
            this.comment.MinimumWidth = 6;
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.Width = 320;
            // 
            // commentTextBox
            // 
            this.commentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tempAttachmentBindingSource, "comment", true));
            this.commentTextBox.Location = new System.Drawing.Point(450, 116);
            this.commentTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(237, 27);
            this.commentTextBox.TabIndex = 4;
            // 
            // TempAttach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1441, 973);
            this.Controls.Add(commentLabel);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.tempAttachmentDataGridView);
            this.Controls.Add(pathLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(template_NameLabel);
            this.Controls.Add(this.template_NameTextBox);
            this.Controls.Add(fileNameLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(dateOFAttashLabel);
            this.Controls.Add(this.dateOFAttashDateTimePicker);
            this.Controls.Add(regionLabel);
            this.Controls.Add(subregionLabel);
            this.Controls.Add(this.subregionTextBox);
            this.Controls.Add(buildingLabel);
            this.Controls.Add(this.buildingTextBox);
            this.Controls.Add(this.tempAttachmentBindingNavigator);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1463, 1029);
            this.MinimumSize = new System.Drawing.Size(1463, 1018);
            this.Name = "TempAttach";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نماذج مرفقه";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TempAttach_FormClosing);
            this.Load += new System.EventHandler(this.TempAttach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSTempAttch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempAttachmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempAttachmentBindingNavigator)).EndInit();
            this.tempAttachmentBindingNavigator.ResumeLayout(false);
            this.tempAttachmentBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSregion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempAttachmentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private DSTempAttch dSTempAttch;
        private System.Windows.Forms.BindingSource tempAttachmentBindingSource;
        private DSTables.DSTempAttchTableAdapters.TempAttachmentTableAdapter tempAttachmentTableAdapter;
        private DSTables.DSTempAttchTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tempAttachmentBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton tempAttachmentBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox template_NameTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.DateTimePicker dateOFAttashDateTimePicker;
        private System.Windows.Forms.TextBox subregionTextBox;
        private System.Windows.Forms.TextBox buildingTextBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private DSregion dSregion;
        private System.Windows.Forms.BindingSource regionBindingSource;
        private DSTables.DSregionTableAdapters.RegionTableAdapter regionTableAdapter;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.DataGridView tempAttachmentDataGridView;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
    }
}