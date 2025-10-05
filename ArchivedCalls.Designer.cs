using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class ArchivedCalls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchivedCalls));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dSCalls = new RealStateRentSystem.DSTables.DSCalls();
            this.callsRegistrayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSCallsTableAdapters.TableAdapterManager();
            this.archiveCallRegistrayTableAdapter = new RealStateRentSystem.DSTables.DSCallsTableAdapters.ArchiveCallRegistrayTableAdapter();
            this.callsRegistrayBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.callsRegistrayBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.st2 = new System.Windows.Forms.Label();
            this.st1 = new System.Windows.Forms.Label();
            this.sn1 = new System.Windows.Forms.Label();
            this.sn2 = new System.Windows.Forms.Label();
            this.mo1 = new System.Windows.Forms.Label();
            this.mo2 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.Label();
            this.we1 = new System.Windows.Forms.Label();
            this.we2 = new System.Windows.Forms.Label();
            this.k1 = new System.Windows.Forms.Label();
            this.k2 = new System.Windows.Forms.Label();
            this.f1 = new System.Windows.Forms.Label();
            this.f2 = new System.Windows.Forms.Label();
            this.callsRegistrayDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.callsRegistrayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.callsRegistrayBindingNavigator)).BeginInit();
            this.callsRegistrayBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callsRegistrayDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSCalls
            // 
            this.dSCalls.DataSetName = "DSCalls";
            this.dSCalls.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // callsRegistrayBindingSource
            // 
            this.callsRegistrayBindingSource.DataMember = "ArchiveCallRegistray";
            this.callsRegistrayBindingSource.DataSource = this.dSCalls;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ArchiveCallRegistrayTableAdapter = this.archiveCallRegistrayTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CallsRegistrayTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSCallsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // archiveCallRegistrayTableAdapter
            // 
            this.archiveCallRegistrayTableAdapter.ClearBeforeFill = true;
            // 
            // callsRegistrayBindingNavigator
            // 
            this.callsRegistrayBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.callsRegistrayBindingNavigator.BackColor = System.Drawing.Color.White;
            this.callsRegistrayBindingNavigator.BindingSource = this.callsRegistrayBindingSource;
            this.callsRegistrayBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.callsRegistrayBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.callsRegistrayBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.callsRegistrayBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.callsRegistrayBindingNavigatorSaveItem});
            this.callsRegistrayBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.callsRegistrayBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.callsRegistrayBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.callsRegistrayBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.callsRegistrayBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.callsRegistrayBindingNavigator.Name = "callsRegistrayBindingNavigator";
            this.callsRegistrayBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.callsRegistrayBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.callsRegistrayBindingNavigator.Size = new System.Drawing.Size(1413, 25);
            this.callsRegistrayBindingNavigator.TabIndex = 0;
            this.callsRegistrayBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 25);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            this.bindingNavigatorCountItem.Visible = false;
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Visible = false;
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Visible = false;
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            this.bindingNavigatorSeparator.Visible = false;
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
            this.bindingNavigatorPositionItem.Visible = false;
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 29);
            this.bindingNavigatorSeparator1.Visible = false;
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Visible = false;
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Visible = false;
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 29);
            this.bindingNavigatorSeparator2.Visible = false;
            // 
            // callsRegistrayBindingNavigatorSaveItem
            // 
            this.callsRegistrayBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.callsRegistrayBindingNavigatorSaveItem.Name = "callsRegistrayBindingNavigatorSaveItem";
            this.callsRegistrayBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 20);
            this.callsRegistrayBindingNavigatorSaveItem.Text = "Save Data";
            this.callsRegistrayBindingNavigatorSaveItem.Click += new System.EventHandler(this.callsRegistrayBindingNavigatorSaveItem_Click);
            // 
            // st2
            // 
            this.st2.AutoSize = true;
            this.st2.Location = new System.Drawing.Point(345, 11);
            this.st2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.st2.Name = "st2";
            this.st2.Size = new System.Drawing.Size(56, 19);
            this.st2.TabIndex = 3;
            this.st2.Text = "السبت";
            // 
            // st1
            // 
            this.st1.AutoSize = true;
            this.st1.ForeColor = System.Drawing.Color.Black;
            this.st1.Location = new System.Drawing.Point(305, 11);
            this.st1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.st1.Name = "st1";
            this.st1.Size = new System.Drawing.Size(56, 19);
            this.st1.TabIndex = 4;
            this.st1.Text = "السبت";
            // 
            // sn1
            // 
            this.sn1.AutoSize = true;
            this.sn1.ForeColor = System.Drawing.Color.Black;
            this.sn1.Location = new System.Drawing.Point(415, 11);
            this.sn1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sn1.Name = "sn1";
            this.sn1.Size = new System.Drawing.Size(43, 19);
            this.sn1.TabIndex = 6;
            this.sn1.Text = "الاحد";
            // 
            // sn2
            // 
            this.sn2.AutoSize = true;
            this.sn2.Location = new System.Drawing.Point(447, 11);
            this.sn2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sn2.Name = "sn2";
            this.sn2.Size = new System.Drawing.Size(56, 19);
            this.sn2.TabIndex = 5;
            this.sn2.Text = "السبت";
            // 
            // mo1
            // 
            this.mo1.AutoSize = true;
            this.mo1.ForeColor = System.Drawing.Color.Black;
            this.mo1.Location = new System.Drawing.Point(517, 11);
            this.mo1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.mo1.Name = "mo1";
            this.mo1.Size = new System.Drawing.Size(51, 19);
            this.mo1.TabIndex = 8;
            this.mo1.Text = "الاثنين";
            // 
            // mo2
            // 
            this.mo2.AutoSize = true;
            this.mo2.Location = new System.Drawing.Point(559, 11);
            this.mo2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.mo2.Name = "mo2";
            this.mo2.Size = new System.Drawing.Size(56, 19);
            this.mo2.TabIndex = 7;
            this.mo2.Text = "السبت";
            // 
            // t1
            // 
            this.t1.AutoSize = true;
            this.t1.ForeColor = System.Drawing.Color.Black;
            this.t1.Location = new System.Drawing.Point(629, 8);
            this.t1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(50, 19);
            this.t1.TabIndex = 10;
            this.t1.Text = "الثلاثاء";
            // 
            // t2
            // 
            this.t2.AutoSize = true;
            this.t2.Location = new System.Drawing.Point(675, 8);
            this.t2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(56, 19);
            this.t2.TabIndex = 9;
            this.t2.Text = "السبت";
            // 
            // we1
            // 
            this.we1.AutoSize = true;
            this.we1.ForeColor = System.Drawing.Color.Black;
            this.we1.Location = new System.Drawing.Point(741, 8);
            this.we1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.we1.Name = "we1";
            this.we1.Size = new System.Drawing.Size(52, 19);
            this.we1.TabIndex = 12;
            this.we1.Text = "الاربعاء";
            // 
            // we2
            // 
            this.we2.AutoSize = true;
            this.we2.Location = new System.Drawing.Point(792, 8);
            this.we2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.we2.Name = "we2";
            this.we2.Size = new System.Drawing.Size(56, 19);
            this.we2.TabIndex = 11;
            this.we2.Text = "السبت";
            // 
            // k1
            // 
            this.k1.AutoSize = true;
            this.k1.ForeColor = System.Drawing.Color.Black;
            this.k1.Location = new System.Drawing.Point(867, 8);
            this.k1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.k1.Name = "k1";
            this.k1.Size = new System.Drawing.Size(66, 19);
            this.k1.TabIndex = 14;
            this.k1.Text = "الخميس";
            // 
            // k2
            // 
            this.k2.AutoSize = true;
            this.k2.Location = new System.Drawing.Point(913, 8);
            this.k2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.k2.Name = "k2";
            this.k2.Size = new System.Drawing.Size(56, 19);
            this.k2.TabIndex = 13;
            this.k2.Text = "السبت";
            // 
            // f1
            // 
            this.f1.AutoSize = true;
            this.f1.ForeColor = System.Drawing.Color.Black;
            this.f1.Location = new System.Drawing.Point(993, 8);
            this.f1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(56, 19);
            this.f1.TabIndex = 16;
            this.f1.Text = "الجمعة";
            // 
            // f2
            // 
            this.f2.AutoSize = true;
            this.f2.Location = new System.Drawing.Point(1036, 8);
            this.f2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.f2.Name = "f2";
            this.f2.Size = new System.Drawing.Size(56, 19);
            this.f2.TabIndex = 15;
            this.f2.Text = "السبت";
            // 
            // callsRegistrayDataGridView
            // 
            this.callsRegistrayDataGridView.AllowUserToAddRows = false;
            this.callsRegistrayDataGridView.AllowUserToDeleteRows = false;
            this.callsRegistrayDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.callsRegistrayDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.callsRegistrayDataGridView.AutoGenerateColumns = false;
            this.callsRegistrayDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.callsRegistrayDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.callsRegistrayDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.callsRegistrayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.callsRegistrayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.Column2,
            this.dataGridViewTextBoxColumn7});
            this.callsRegistrayDataGridView.DataSource = this.callsRegistrayBindingSource;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.callsRegistrayDataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.callsRegistrayDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.callsRegistrayDataGridView.Location = new System.Drawing.Point(6, 40);
            this.callsRegistrayDataGridView.Margin = new System.Windows.Forms.Padding(5);
            this.callsRegistrayDataGridView.Name = "callsRegistrayDataGridView";
            this.callsRegistrayDataGridView.RowHeadersWidth = 51;
            this.callsRegistrayDataGridView.Size = new System.Drawing.Size(1425, 955);
            this.callsRegistrayDataGridView.TabIndex = 1;
            this.callsRegistrayDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.callsRegistrayDataGridView_CellBeginEdit_1);
            this.callsRegistrayDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.callsRegistrayDataGridView_CellContentClick);
            this.callsRegistrayDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.callsRegistrayDataGridView_DataBindingComplete);
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
            // Column1
            // 
            this.Column1.HeaderText = "فتح";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Text = "فتح";
            this.Column1.ToolTipText = "فتح";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "number";
            this.dataGridViewTextBoxColumn2.HeaderText = "الرقم";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "name";
            dataGridViewCellStyle3.Format = "T";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "الاسم";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "time";
            dataGridViewCellStyle4.Format = "T";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn9.HeaderText = "الوقت";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "date";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "التاريخ";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "place";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn5.HeaderText = "الموقع";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "placeID";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn6.HeaderText = "placeID";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "note";
            this.dataGridViewTextBoxColumn8.HeaderText = "الملاحظات";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 180;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "اضافة";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Text = "اضافة";
            this.Column2.ToolTipText = "اضافة";
            this.Column2.UseColumnTextForButtonValue = true;
            this.Column2.Width = 40;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "numbertype";
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn7.HeaderText = "numbertype";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "numbertype";
            this.dataGridViewTextBoxColumn10.HeaderText = "numbertype";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "note";
            this.dataGridViewTextBoxColumn11.HeaderText = "note";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 125;
            // 
            // ArchivedCalls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1413, 955);
            this.Controls.Add(this.f1);
            this.Controls.Add(this.f2);
            this.Controls.Add(this.k1);
            this.Controls.Add(this.k2);
            this.Controls.Add(this.we1);
            this.Controls.Add(this.we2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.mo1);
            this.Controls.Add(this.mo2);
            this.Controls.Add(this.sn1);
            this.Controls.Add(this.sn2);
            this.Controls.Add(this.st1);
            this.Controls.Add(this.st2);
            this.Controls.Add(this.callsRegistrayDataGridView);
            this.Controls.Add(this.callsRegistrayBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1435, 1011);
            this.MinimumSize = new System.Drawing.Size(1435, 1011);
            this.Name = "ArchivedCalls";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مكالمات قديمة";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calls_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Calls_FormClosed);
            this.Load += new System.EventHandler(this.Calls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.callsRegistrayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.callsRegistrayBindingNavigator)).EndInit();
            this.callsRegistrayBindingNavigator.ResumeLayout(false);
            this.callsRegistrayBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callsRegistrayDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSCalls dSCalls;
        private System.Windows.Forms.BindingSource callsRegistrayBindingSource;
        private DSTables.DSCallsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator callsRegistrayBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton callsRegistrayBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Label st2;
        private System.Windows.Forms.Label st1;
        private System.Windows.Forms.Label sn1;
        private System.Windows.Forms.Label sn2;
        private System.Windows.Forms.Label mo1;
        private System.Windows.Forms.Label mo2;
        private System.Windows.Forms.Label t1;
        private System.Windows.Forms.Label t2;
        private System.Windows.Forms.Label we1;
        private System.Windows.Forms.Label we2;
        private System.Windows.Forms.Label k1;
        private System.Windows.Forms.Label k2;
        private System.Windows.Forms.Label f1;
        private System.Windows.Forms.Label f2;
        private System.Windows.Forms.DataGridView callsRegistrayDataGridView;
        private DSTables.DSCallsTableAdapters.ArchiveCallRegistrayTableAdapter archiveCallRegistrayTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}