using RealStateRentSystem.DSTables;
namespace RealStateRentSystem
{
    partial class ownerSetting
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
            System.Windows.Forms.Label enterPeriodToStaicLabel;
            System.Windows.Forms.Label enterPeriodToHousesLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ownerSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enterPeriodToStaicTextBox = new System.Windows.Forms.TextBox();
            this.ownSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSrealowner = new RealStateRentSystem.DSTables.DSrealowner();
            this.enterPeriodToHousesTextBox = new System.Windows.Forms.TextBox();
            this.enterPeriodToEventsTextBox = new System.Windows.Forms.TextBox();
            this.ownSettingTableAdapter = new RealStateRentSystem.DSTables.DSrealownerTableAdapters.OwnSettingTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSrealownerTableAdapters.TableAdapterManager();
            this.ownSettingBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.ownSettingBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            enterPeriodToStaicLabel = new System.Windows.Forms.Label();
            enterPeriodToHousesLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ownSettingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealowner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownSettingBindingNavigator)).BeginInit();
            this.ownSettingBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterPeriodToStaicLabel
            // 
            enterPeriodToStaicLabel.AutoSize = true;
            enterPeriodToStaicLabel.Location = new System.Drawing.Point(370, 32);
            enterPeriodToStaicLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            enterPeriodToStaicLabel.Name = "enterPeriodToStaicLabel";
            enterPeriodToStaicLabel.Size = new System.Drawing.Size(161, 19);
            enterPeriodToStaicLabel.TabIndex = 4;
            enterPeriodToStaicLabel.Text = "مدة الدخول للاحصاء  : ";
            // 
            // enterPeriodToHousesLabel
            // 
            enterPeriodToHousesLabel.AutoSize = true;
            enterPeriodToHousesLabel.Location = new System.Drawing.Point(375, 70);
            enterPeriodToHousesLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            enterPeriodToHousesLabel.Name = "enterPeriodToHousesLabel";
            enterPeriodToHousesLabel.Size = new System.Drawing.Size(140, 19);
            enterPeriodToHousesLabel.TabIndex = 6;
            enterPeriodToHousesLabel.Text = "المنازل التي بقيت :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(42, 70);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(171, 19);
            label1.TabIndex = 10;
            label1.Text = " يوما لم يتم البحث عليها";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 109);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(200, 19);
            label2.TabIndex = 12;
            label2.Text = "يوما لم يتم اضافه حدث عليها";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(375, 109);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(140, 19);
            label3.TabIndex = 11;
            label3.Text = "المنازل التي بقيت :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(181, 32);
            label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(29, 19);
            label4.TabIndex = 13;
            label4.Text = "يوم";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.enterPeriodToStaicTextBox);
            this.groupBox1.Controls.Add(this.enterPeriodToHousesTextBox);
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Controls.Add(this.enterPeriodToEventsTextBox);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(enterPeriodToStaicLabel);
            this.groupBox1.Controls.Add(enterPeriodToHousesLabel);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(18, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(541, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الأعدادات الأوليه للنظام";
            // 
            // enterPeriodToStaicTextBox
            // 
            this.enterPeriodToStaicTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ownSettingBindingSource, "EnterPeriodToStaic", true));
            this.enterPeriodToStaicTextBox.Location = new System.Drawing.Point(219, 31);
            this.enterPeriodToStaicTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.enterPeriodToStaicTextBox.Name = "enterPeriodToStaicTextBox";
            this.enterPeriodToStaicTextBox.Size = new System.Drawing.Size(148, 27);
            this.enterPeriodToStaicTextBox.TabIndex = 5;
            // 
            // ownSettingBindingSource
            // 
            this.ownSettingBindingSource.DataMember = "OwnSetting";
            this.ownSettingBindingSource.DataSource = this.dSrealowner;
            // 
            // dSrealowner
            // 
            this.dSrealowner.DataSetName = "DSrealowner";
            this.dSrealowner.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // enterPeriodToHousesTextBox
            // 
            this.enterPeriodToHousesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ownSettingBindingSource, "EnterPeriodToHouses", true));
            this.enterPeriodToHousesTextBox.Location = new System.Drawing.Point(219, 69);
            this.enterPeriodToHousesTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.enterPeriodToHousesTextBox.Name = "enterPeriodToHousesTextBox";
            this.enterPeriodToHousesTextBox.Size = new System.Drawing.Size(148, 27);
            this.enterPeriodToHousesTextBox.TabIndex = 7;
            // 
            // enterPeriodToEventsTextBox
            // 
            this.enterPeriodToEventsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ownSettingBindingSource, "EnterPeriodToEvents", true));
            this.enterPeriodToEventsTextBox.Location = new System.Drawing.Point(219, 107);
            this.enterPeriodToEventsTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.enterPeriodToEventsTextBox.Name = "enterPeriodToEventsTextBox";
            this.enterPeriodToEventsTextBox.Size = new System.Drawing.Size(148, 27);
            this.enterPeriodToEventsTextBox.TabIndex = 9;
            // 
            // ownSettingTableAdapter
            // 
            this.ownSettingTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.attachmentOwnTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BuildingTypeTableAdapter = null;
            this.tableAdapterManager.eventownTableAdapter = null;
            this.tableAdapterManager.OwnInvestitureTableAdapter = null;
            this.tableAdapterManager.OwnSettingTableAdapter = this.ownSettingTableAdapter;
            this.tableAdapterManager.RealstateOwneTableAdapter = null;
            this.tableAdapterManager.RegionTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSrealownerTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WayOFOwnerTableAdapter = null;
            // 
            // ownSettingBindingNavigator
            // 
            this.ownSettingBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.ownSettingBindingNavigator.BindingSource = this.ownSettingBindingSource;
            this.ownSettingBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.ownSettingBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.ownSettingBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ownSettingBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.ownSettingBindingNavigatorSaveItem});
            this.ownSettingBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.ownSettingBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.ownSettingBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.ownSettingBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.ownSettingBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.ownSettingBindingNavigator.Name = "ownSettingBindingNavigator";
            this.ownSettingBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ownSettingBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.ownSettingBindingNavigator.Size = new System.Drawing.Size(566, 29);
            this.ownSettingBindingNavigator.TabIndex = 1;
            this.ownSettingBindingNavigator.Text = "bindingNavigator1";
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
            // 
            // ownSettingBindingNavigatorSaveItem
            // 
            this.ownSettingBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ownSettingBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("ownSettingBindingNavigatorSaveItem.Image")));
            this.ownSettingBindingNavigatorSaveItem.Name = "ownSettingBindingNavigatorSaveItem";
            this.ownSettingBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 24);
            this.ownSettingBindingNavigatorSaveItem.Text = "Save Data";
            this.ownSettingBindingNavigatorSaveItem.Click += new System.EventHandler(this.ownSettingBindingNavigatorSaveItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 251);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(282, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "اصلاح ملفات الارفاق الاّلي";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ownerSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(566, 347);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ownSettingBindingNavigator);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ownerSetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعدادت نظام البيع";
            this.Load += new System.EventHandler(this.ownerSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ownSettingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealowner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownSettingBindingNavigator)).EndInit();
            this.ownSettingBindingNavigator.ResumeLayout(false);
            this.ownSettingBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DSrealowner dSrealowner;
        private System.Windows.Forms.BindingSource ownSettingBindingSource;
        private DSTables.DSrealownerTableAdapters.OwnSettingTableAdapter ownSettingTableAdapter;
        private DSTables.DSrealownerTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator ownSettingBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton ownSettingBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox enterPeriodToStaicTextBox;
        private System.Windows.Forms.TextBox enterPeriodToHousesTextBox;
        private System.Windows.Forms.TextBox enterPeriodToEventsTextBox;
        private System.Windows.Forms.Button button1;
    }
}