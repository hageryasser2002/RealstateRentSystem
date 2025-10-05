using RealStateRentSystem.DSTables;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealStateRentSystem.FollowUp
{
    public partial class FollowUp : Form
    {
        public class Customer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Mobile1 { get; set; }
            public string Mobile2 { get; set; }
            public string Request { get; set; }
            public string Via { get; set; }
            public int Days { get; set; }
            public bool IsArchived { get; set; }
        }

        private bool isShowingDetails = false;
        private List<Customer> customers;

        public FollowUp()
        {
            InitializeComponent();
        }

        private void FollowUp_Load(object sender, EventArgs e)
        {
            LoadFakeCustomerCards();
        }

        private void LoadFakeCustomerCards()
        {
            customers = new List<Customer>
            {
                new Customer {
                    ID = 1,
                    Name = "أحمد محمد",
                    Phone = "01012345678",
                    Mobile1 = "01111111111",
                    Mobile2 = "01222222222",
                    Request = "شراء شقة",
                    Via = "الإنترنت",
                    Days = 2,
                    IsArchived = false
                },
                new Customer {
                    ID = 2,
                    Name = "منى علي",
                    Phone = "01198765432",
                    Mobile1 = "01133333333",
                    Mobile2 = "01244444444",
                    Request = "إيجار محل",
                    Via = "صديق",
                    Days = 35,
                    IsArchived = false
                },
                new Customer {
                    ID = 3,
                    Name = "سارة محمود",
                    Phone = "01222223333",
                    Mobile1 = "01155555555",
                    Mobile2 = "01266666666",
                    Request = "تشطيب شقة",
                    Via = "إعلان",
                    Days = 20,
                    IsArchived = false
                },
                new Customer {
                    ID = 4,
                    Name = "سارة محمود",
                    Phone = "01222223333",
                    Mobile1 = "01155555555",
                    Mobile2 = "01266666666",
                    Request = "تشطيب شقة",
                    Via = "إعلان",
                    Days = 15,
                    IsArchived = false
                },
                new Customer {
                    ID = 5,
                    Name = "أحمد محمد",
                    Phone = "01012345678",
                    Mobile1 = "01111111111",
                    Mobile2 = "01222222222",
                    Request = "شراء شقة",
                    Via = "الإنترنت",
                    Days = 17,
                    IsArchived = false
                },
                new Customer {
                    ID = 6,
                    Name = "سارة محمود",
                    Phone = "01222223333",
                    Mobile1 = "01155555555",
                    Mobile2 = "01266666666",
                    Request = "تشطيب شقة",
                    Via = "إعلان",
                    Days = 30,
                    IsArchived = false
                }
            };

            LoadCustomerCards(customers);
        }

        private void LoadCustomerCards(List<Customer> customersToLoad)
        {
            if (flowLayoutPanelCards == null) return;

            flowLayoutPanelCards.Controls.Clear();

            foreach (var customer in customersToLoad)
            {
                if (customer.IsArchived && !IsArchiveFilterEnabled())
                    continue;

                CreateCustomerCard(customer);
            }
        }

        private void CreateCustomerCard(Customer customer)
        {
            Color borderColor = GetColorByDays(customer.Days);

            Panel card = new Panel();
            card.Width = flowLayoutPanelCards.Width - flowLayoutPanelCards.Padding.Left - flowLayoutPanelCards.Padding.Right - 20;
            card.Height = 120;
            card.BackColor = Color.White;
            card.Margin = new Padding(10, 10, 10, 10);
            card.Padding = new Padding(15);
            card.BorderStyle = BorderStyle.FixedSingle;
            card.RightToLeft = RightToLeft.Yes;
            card.Tag = customer;

            card.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    borderColor, 5, ButtonBorderStyle.Solid,
                    borderColor, 5, ButtonBorderStyle.Solid,
                    borderColor, 50, ButtonBorderStyle.Solid,
                    borderColor, 5, ButtonBorderStyle.Solid);
            };

            // Name - with fixed height and TopRight alignment
            Label lblName = new Label();
            lblName.Text = "👤 " + customer.Name;
            lblName.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(50, 50, 50);
            lblName.AutoSize = false;
            lblName.Width = 180;
            lblName.Height = 25;
            lblName.Location = new Point(card.Width + 400, 15);
            lblName.RightToLeft = RightToLeft.Yes;
            lblName.TextAlign = ContentAlignment.TopRight; // Force top alignment

            // Phone - with fixed height and TopRight alignment
            Label lblPhone = new Label();
            lblPhone.Text = "📞 " + customer.Phone;
            lblPhone.Font = new Font("Tahoma", 10);
            lblPhone.ForeColor = Color.FromArgb(80, 80, 80);
            lblPhone.AutoSize = false;
            lblPhone.Width = 180;
            lblPhone.Height = 25;
            lblPhone.Location = new Point(card.Width + 400, 45);
            lblPhone.RightToLeft = RightToLeft.Yes;
            lblPhone.TextAlign = ContentAlignment.TopRight; // Force top alignment

            // Request - with fixed height and TopRight alignment
            Label lblRequest = new Label();
            lblRequest.Text = "📌 " + customer.Request;
            lblRequest.Font = new Font("Tahoma", 10);
            lblRequest.ForeColor = Color.FromArgb(80, 80, 80);
            lblRequest.AutoSize = false;
            lblRequest.Width = 180;
            lblRequest.Height = 25;
            lblRequest.Location = new Point(card.Width + 400, 75);
            lblRequest.RightToLeft = RightToLeft.Yes;
            lblRequest.TextAlign = ContentAlignment.TopRight; // Force top alignment

            // Days
            Label lblDays = new Label();
            lblDays.Text = $"🕐 {customer.Days} يوم";
            lblDays.Font = new Font("Tahoma", 9, FontStyle.Bold);
            lblDays.ForeColor = borderColor;
            lblDays.AutoSize = true;
            lblDays.Location = new Point(100, 15);
            lblDays.RightToLeft = RightToLeft.Yes;
            lblDays.TextAlign = ContentAlignment.MiddleRight;

            // Details Button
            Button btnDetails = new Button();
            btnDetails.Text = "📄 تفاصيل";
            btnDetails.BackColor = Color.FromArgb(0, 120, 215);
            btnDetails.ForeColor = Color.White;
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.Width = 100;
            btnDetails.Height = 30;
            btnDetails.Location = new Point(100, 75);
            btnDetails.Font = new Font("Tahoma", 9);
            btnDetails.Cursor = Cursors.Hand;
            btnDetails.RightToLeft = RightToLeft.Yes;
            btnDetails.Tag = customer;
            btnDetails.Click += new EventHandler(this.btnDetails_Click);

            // Archive Button
            Button btnArchive = new Button();
            btnArchive.Text = customer.IsArchived ? "📂 استعادة" : "🗑️ أرشيف";
            btnArchive.BackColor = customer.IsArchived ? Color.FromArgb(40, 167, 69) : Color.FromArgb(220, 53, 69);
            btnArchive.ForeColor = Color.White;
            btnArchive.FlatStyle = FlatStyle.Flat;
            btnArchive.FlatAppearance.BorderSize = 0;
            btnArchive.Width = 80;
            btnArchive.Height = 30;
            btnArchive.Location = new Point(120, 75);
            btnArchive.Font = new Font("Tahoma", 8);
            btnArchive.Cursor = Cursors.Hand;
            btnArchive.RightToLeft = RightToLeft.Yes;
            btnArchive.Tag = customer;
            btnArchive.Click += new EventHandler(this.btnArchive_Click);

            card.Controls.Add(lblName);
            card.Controls.Add(lblPhone);
            card.Controls.Add(lblRequest);
            card.Controls.Add(lblDays);
            card.Controls.Add(btnDetails);
            card.Controls.Add(btnArchive);

            flowLayoutPanelCards.Controls.Add(card);
        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                var customer = btn.Tag as Customer;
                ShowCustomerDetails(customer);
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                var customer = btn.Tag as Customer;
                string message = customer.IsArchived ?
                    "هل تريد استعادة هذا العميل من الأرشيف؟" :
                    "هل تريد نقل هذا العميل إلى الأرشيف؟";

                DialogResult result = MessageBox.Show(
                    message,
                    "تأكيد",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.Yes)
                {
                    customer.IsArchived = !customer.IsArchived;
                    LoadCustomerCards(customers);

                    string successMessage = customer.IsArchived ?
                        "تم نقل العميل إلى الأرشيف بنجاح" :
                        "تم استعادة العميل بنجاح";

                    MessageBox.Show(successMessage, "تم",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ShowCustomerDetails(Customer customer)
        {
            if (customer == null) return;

            // Hide cards, show details
            if (panelMainContainer != null)
            {
                foreach (Control control in panelMainContainer.Controls)
                {
                    control.Visible = false;
                }
            }

            if (panelCustomerDetailsContainer != null)
            {
                panelCustomerDetailsContainer.Visible = true;
                panelCustomerDetailsContainer.BringToFront();

                // Populate data
                PopulateCustomerDetails(customer);
                isShowingDetails = true;
            }
        }

        private void PopulateCustomerDetails(Customer customer)
        {
            // Populate all the fields with customer data
            txtOwner.Text = customer.Name;
            txtPhoneOne.Text = customer.Phone;
            txtMobile.Text = customer.Mobile1;
            txtMobile2.Text = customer.Mobile2;
            txtVia.Text = customer.Via;
            txtRequest.Text = customer.Request;

            // Set request type checkboxes
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                string itemText = checkedListBox2.Items[i].ToString();
                if (itemText.Contains(customer.Request) || customer.Request.Contains(itemText.Replace(":", "").Trim()))
                {
                    checkedListBox2.SetItemChecked(i, true);
                }
            }

            // Clear other fields or set default values
            txtOther.Text = "---";
            txtCompanyReference.Text = "---";
        }

        private void CustomerDetailsPanel_BackButtonClicked(object sender, EventArgs e)
        {
            if (panelMainContainer != null)
            {
                foreach (Control control in panelMainContainer.Controls)
                {
                    control.Visible = true;
                }
            }

            if (panelCustomerDetailsContainer != null)
            {
                panelCustomerDetailsContainer.Visible = false;
            }

            isShowingDetails = false;
        }
        private Color GetColorByDays(int days)
        {
            if (days <= 15)
                return Color.FromArgb(76, 175, 80);
            else if (days > 15 && days < 30)
                return Color.FromArgb(255, 152, 0);
            else
                return Color.FromArgb(244, 67, 54);
        }

        private void btnDischarge_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCompanyReference.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            LoadFakeCustomerCards();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFakeCustomerCards();
        }

        private void FollowUp_Resize(object sender, EventArgs e)
        {
            AdjustCardWidths();
        }

        private void flowLayoutPanelCards_Resize(object sender, EventArgs e)
        {
            AdjustCardWidths();
        }

        private void AdjustCardWidths()
        {
            if (flowLayoutPanelCards == null) return;

            foreach (Control control in flowLayoutPanelCards.Controls)
            {
                if (control is Panel card)
                {
                    card.Width = flowLayoutPanelCards.Width - flowLayoutPanelCards.Padding.Left - flowLayoutPanelCards.Padding.Right - 20;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && isShowingDetails)
            {
                CustomerDetailsPanel_BackButtonClicked(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void chkShowArchived_CheckedChanged(object sender, EventArgs e)
        {
            LoadCustomerCards(customers);
        }

        private bool IsArchiveFilterEnabled()
        {
            return chkShowArchived != null && chkShowArchived.Checked;
        }

        private void btnGreetings_Click(object sender, EventArgs e)
        {
            // Send greeting logic here
            MessageBox.Show("تم إرسال التحية بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAddAppointment_Click_1(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = dtpAppointment.Value;

                // التحقق من عدم وجود موعد مكرر - الطريقة الصحيحة لـ DataGridView
                foreach (DataGridViewRow row in dgvAppointments.Rows)
                {
                    // تأكد من وجود البيانات في الخلية
                    if (row.Cells["DateTime"]?.Value != null &&
                        DateTime.TryParse(row.Cells["DateTime"].Value.ToString(), out DateTime existingDate))
                    {
                        if (existingDate.Date == selectedDate.Date &&
                            existingDate.Hour == selectedDate.Hour &&
                            existingDate.Minute == selectedDate.Minute)
                        {
                            MessageBox.Show("هذا الموعد موجود مسبقاً", "تنبيه",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // إضافة الموعد الجديد - الطريقة الصحيحة لـ DataGridView
                int newId = dgvAppointments.Rows.Count + 1;

                // أضف صف جديد باستخدام مصفوفة من القيم
                dgvAppointments.Rows.Add(
                    newId,
                    selectedDate.ToString("yyyy/MM/dd"),
                    selectedDate.ToString("HH:mm"),
                    "موعد مع العميل",
                    selectedDate
                );

                // ترتيب المواعيد حسب التاريخ
                dgvAppointments.Sort(dgvAppointments.Columns["DateTime"], System.ComponentModel.ListSortDirection.Ascending);

                MessageBox.Show("تم إضافة الموعد بنجاح", "تم",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في إضافة الموعد: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAppointment_Click_1(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null && !dgvAppointments.CurrentRow.IsNewRow)
            {
                DialogResult result = MessageBox.Show("هل تريد حذف الموعد المحدد؟",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = dgvAppointments.CurrentRow.Index;
                    dgvAppointments.Rows.RemoveAt(rowIndex);

                    // إعادة ترقيم الصفوف
                    for (int i = 0; i < dgvAppointments.Rows.Count; i++)
                    {
                        if (!dgvAppointments.Rows[i].IsNewRow) // تأكد أنه ليس صف جديد فارغ
                        {
                            dgvAppointments.Rows[i].Cells["ID"].Value = i + 1;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("يرجى تحديد موعد للحذف", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}