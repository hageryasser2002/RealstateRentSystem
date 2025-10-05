using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class activesetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(activesetting));
            this.pCinfoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.pCinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSsetting = new RealStateRentSystem.DSTables.DSsetting();
            this.pCinfoBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.alertCheckBox = new System.Windows.Forms.CheckBox();
            this.backupCheckBox = new System.Windows.Forms.CheckBox();
            this.pCinfoTableAdapter1 = new RealStateRentSystem.DSTables.DSsettingTableAdapters.PCinfoTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager();
            this.mACAddressTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pCinfoBindingNavigator)).BeginInit();
            this.pCinfoBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pCinfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).BeginInit();
            this.SuspendLayout();
            // 
            // pCinfoBindingNavigator
            // 
            this.pCinfoBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.pCinfoBindingNavigator.BindingSource = this.pCinfoBindingSource;
            this.pCinfoBindingNavigator.CountItem = null;
            this.pCinfoBindingNavigator.DeleteItem = null;
            this.pCinfoBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.pCinfoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pCinfoBindingNavigatorSaveItem,
            this.bindingNavigatorAddNewItem});
            this.pCinfoBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.pCinfoBindingNavigator.MoveFirstItem = null;
            this.pCinfoBindingNavigator.MoveLastItem = null;
            this.pCinfoBindingNavigator.MoveNextItem = null;
            this.pCinfoBindingNavigator.MovePreviousItem = null;
            this.pCinfoBindingNavigator.Name = "pCinfoBindingNavigator";
            this.pCinfoBindingNavigator.PositionItem = null;
            this.pCinfoBindingNavigator.Size = new System.Drawing.Size(231, 27);
            this.pCinfoBindingNavigator.TabIndex = 3;
            this.pCinfoBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.AutoToolTip = false;
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Enabled = false;
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // pCinfoBindingSource
            // 
            this.pCinfoBindingSource.DataMember = "PCinfo";
            this.pCinfoBindingSource.DataSource = this.dSsetting;
            // 
            // dSsetting
            // 
            this.dSsetting.DataSetName = "DSsetting";
            this.dSsetting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pCinfoBindingNavigatorSaveItem
            // 
            this.pCinfoBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pCinfoBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("pCinfoBindingNavigatorSaveItem.Image")));
            this.pCinfoBindingNavigatorSaveItem.Name = "pCinfoBindingNavigatorSaveItem";
            this.pCinfoBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.pCinfoBindingNavigatorSaveItem.Text = "Save Data";
            this.pCinfoBindingNavigatorSaveItem.Click += new System.EventHandler(this.pCinfoBindingNavigatorSaveItem_Click);
            // 
            // alertCheckBox
            // 
            this.alertCheckBox.Checked = true;
            this.alertCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alertCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.pCinfoBindingSource, "alert", true));
            this.alertCheckBox.Location = new System.Drawing.Point(-74, 34);
            this.alertCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.alertCheckBox.Name = "alertCheckBox";
            this.alertCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.alertCheckBox.Size = new System.Drawing.Size(296, 30);
            this.alertCheckBox.TabIndex = 12;
            this.alertCheckBox.Text = "تفعيل التنبيه على الجهاز";
            this.alertCheckBox.UseVisualStyleBackColor = true;
            // 
            // backupCheckBox
            // 
            this.backupCheckBox.Checked = true;
            this.backupCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backupCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.pCinfoBindingSource, "backup", true));
            this.backupCheckBox.Location = new System.Drawing.Point(0, 71);
            this.backupCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.backupCheckBox.Name = "backupCheckBox";
            this.backupCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.backupCheckBox.Size = new System.Drawing.Size(223, 30);
            this.backupCheckBox.TabIndex = 14;
            this.backupCheckBox.Text = "تفعيل النسخة الاحتياطية على الجهاز ";
            this.backupCheckBox.UseVisualStyleBackColor = true;
            this.backupCheckBox.CheckedChanged += new System.EventHandler(this.backupCheckBox_CheckedChanged);
            // 
            // pCinfoTableAdapter1
            // 
            this.pCinfoTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PCinfoTableAdapter = this.pCinfoTableAdapter1;
            this.tableAdapterManager.RealStaticTableAdapter = null;
            this.tableAdapterManager.SettingTableAdapter = null;
            this.tableAdapterManager.ShorCutKeysTableAdapter = null;
            this.tableAdapterManager.StaticTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // mACAddressTextBox
            // 
            this.mACAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pCinfoBindingSource, "MACAddress", true));
            this.mACAddressTextBox.Location = new System.Drawing.Point(391, 4);
            this.mACAddressTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.mACAddressTextBox.Name = "mACAddressTextBox";
            this.mACAddressTextBox.Size = new System.Drawing.Size(116, 24);
            this.mACAddressTextBox.TabIndex = 15;
            // 
            // activesetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(231, 106);
            this.Controls.Add(this.mACAddressTextBox);
            this.Controls.Add(this.alertCheckBox);
            this.Controls.Add(this.backupCheckBox);
            this.Controls.Add(this.pCinfoBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(249, 153);
            this.MinimumSize = new System.Drawing.Size(249, 153);
            this.Name = "activesetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعدادت التفعيل";
            this.Load += new System.EventHandler(this.activesetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pCinfoBindingNavigator)).EndInit();
            this.pCinfoBindingNavigator.ResumeLayout(false);
            this.pCinfoBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pCinfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSsetting dSsetting;
        private System.Windows.Forms.BindingSource pCinfoBindingSource;
        private DSTables.DSsettingTableAdapters.PCinfoTableAdapter pCinfoTableAdapter1;
        private DSTables.DSsettingTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator pCinfoBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton pCinfoBindingNavigatorSaveItem;
        private System.Windows.Forms.CheckBox alertCheckBox;
        private System.Windows.Forms.CheckBox backupCheckBox;
        private System.Windows.Forms.TextBox mACAddressTextBox;
    }
}