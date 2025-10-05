using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class SearchForm : Form
    {

        private System.Windows.Forms.Timer followTimer;
        private Point mainFormLocation;
        private Size mainFormSize;
        private MainForm mainForm;

        public static string numberold;
        protected override bool ShowWithoutActivation => true;

        public SearchForm()
        {
            InitializeComponent();
            StartFollowingMainForm();

        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteSearch();
                e.Handled = true;
                e.SuppressKeyPress = true; // يمنع صوت التنبيه عند الضغط على Enter
            }
        }

        private void ExecuteSearch()
        {
            string input = textBoxSearch.Text.Trim();
            numberold = input.Replace("*", "");

            string name = ""; // مش موجود اسم في الفورم الجديدة
            string extra = ""; // ما فيش TextBox1 برضو
            //string mode = checkBoxSearch.Checked ? "1" : "0";
            Form1 f = new Form1(name, input, extra, "0");
           

            if (f.yes)
            {
                f.ShowDialog();
                //ShowModalExcept(f, MainForm.searchForm);
            }


            textBoxSearch.Clear();
            textBoxSearch.Focus();

        }

        public void SetMainFormInfo(Point location, Size size)
        {
            mainFormLocation = location;
            mainFormSize = size;


        }



        public void StartFollowingMainForm()
        {
            followTimer = new System.Windows.Forms.Timer();
            followTimer.Interval = 100; // Update every 100ms
            followTimer.Tick += (s, e) =>
            {
                // Example: Position to the right of MainForm
                //this.Location = new Point(mainFormLocation.X + mainFormSize.Width + 1000, mainFormLocation.Y + 35);
                this.Location = new Point(mainFormLocation.X + mainFormSize.Width + 1000, mainFormLocation.Y + 35);

            };
            followTimer.Start();
        }




    }

}

