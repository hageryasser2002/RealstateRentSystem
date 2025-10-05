using RealStateRentSystem.DSTables.DSsettingTableAdapters;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class LoginMsg : Form
    {
        static LoginMsg newMessageBox;
        static string Button_Clicked;
        static PCinfoTableAdapter PCinfoTableAdapter = new PCinfoTableAdapter();

        public LoginMsg()
        {
            InitializeComponent();
            ChangeLan();
            LoadUsersButtons();
        }


   

        public static string ShowMe()
        {
            Utils.getsetting();
            Utils.getMacaddres();
            Utils.IsAdmin = false; // Reset admin flag

            DataTable pcinfo = PCinfoTableAdapter.GetDataByexist(Utils.macaddreass);
            if (pcinfo.Rows.Count > 0 && Convert.ToBoolean(pcinfo.Rows[0]["backup"]))
            {
                BackUp.startbackup();
                SBackUp.startbackup();
                CallArchive.startbackup();
                Utils.update_auto();
            }

            Utils.SetPath();
            Utils.CreateDataTableAnswers();
            //clsUser.ResetAllLoginStatus(); // Reset login states

            //_cachedUsers = clsUser.GetAllActiveUsers();
            if (Utils.cachedUsers == null || Utils.cachedUsers.Count == 0)
                Utils.cachedUsers = clsUser.GetAllActiveUsers();


            newMessageBox = new LoginMsg();
            newMessageBox.ShowDialog();
            return Button_Clicked;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = name.Text.Trim();
            string password = pass.Text.Trim();

            // Prevent login if same user already logged in
            if (Utils.current_user == username)
                return;

            var user = Utils.cachedUsers.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                Utils.current_user = username;
                clsUser.Login(username, password);
                Button_Clicked = "ok";
                Utils.cachedUsers = clsUser.GetAllActiveUsers();
                LoadUsersButtons();
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            var admin = clsUser.GetAdminUsers().FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (admin != null)
            {
                Utils.current_user = username;
                Utils.IsAdmin = true;
                clsUser.Login(username, password);
                Button_Clicked = "ok";
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            MessageBox.Show("الرجاء التأكد من اسم المستخدم وكلمة المرور");
        }

        private void LoadUsersButtons()
        {
            flowLayoutPanelUsers.Controls.Clear();

            int btnWidth = 100;
            int btnHeight = 50;
            int spacing = 10;
            int panelWidth = flowLayoutPanelUsers.ClientSize.Width;

            var filteredUsers = Utils.cachedUsers
                .Where(u => u.UserName != Utils.current_user)
                .ToList();

            int totalWidth = (filteredUsers.Count * btnWidth) + ((filteredUsers.Count - 1) * spacing);
            int marginLeft = Math.Max((panelWidth - totalWidth) / 2, 0);

            for (int i = 0; i < filteredUsers.Count; i++)
            {
                var user = filteredUsers[i];
                Button btn = new Button
                {
                    Text = user.UserName,
                    Width = btnWidth,
                    Height = btnHeight,
                    Tag = user,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = System.Drawing.SystemColors.Highlight,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                btn.FlatAppearance.BorderSize = 0;
                btn.Margin = i == 0 ? new Padding(marginLeft, 10, spacing, 10) : new Padding(0, 10, spacing, 10);
                btn.Click += UserButton_Click;

                flowLayoutPanelUsers.Controls.Add(btn);
            }
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var user = btn.Tag as clsUser;

            if (user != null && user.UserName != Utils.current_user)
            {
                name.Text = user.UserName;
                pass.Text = user.Password;
                Login_Click(sender, EventArgs.Empty);
            }
        }

        private void LoginMsg_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 6))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void LoginMsg_SizeChanged(object sender, EventArgs e)
        {
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            Button_Clicked = "Cancel";
            newMessageBox.Dispose();
        }




        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {


            //char lastChar = e.KeyChar;
            //
            //if (e.KeyChar != 32 && e.KeyChar != 8) //allows space and backspace
            //{
            //    if (char.IsControl(lastChar) || char.IsDigit(lastChar) || char.IsNumber(lastChar) || char.IsPunctuation(lastChar))
            //        e.Handled = true;
            //    else if (lastChar < 1569)//the start of ascii codes for Arabic chars.
            //        e.Handled = true;
            //}
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Login.PerformClick();
            }
        }

        private InputLanguage GetArabicLang()
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.TwoLetterISOLanguageName == "ar")
                    return lang;
            }
            return null;
        }

        public void ChangeLan()
        {
            InputLanguage lang = GetArabicLang();
            if (lang == null)
                throw new NotSupportedException("Arabic Language keyboard is not installed.");

            InputLanguage.CurrentInputLanguage = lang;
        }
    }
}


