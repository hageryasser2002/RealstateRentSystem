using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public static class SearchFormLauncher
    {
        private static Thread searchThread;
        private static SearchForm runningSearchForm;

        public static void StartSearchForm()
        {
            if (searchThread == null || !searchThread.IsAlive)
            {
                searchThread = new Thread(() =>
                {
                    runningSearchForm = new SearchForm();
                    runningSearchForm.StartFollowingMainForm();
                    //runningSearchForm.SetMainForm(Application.OpenForms["MainForm"]);

                    Application.Run(runningSearchForm);
                });

                searchThread.SetApartmentState(ApartmentState.STA); // STA = Single Threaded Apartment (required for UI)
                searchThread.IsBackground = true; // So it closes with main app
                searchThread.Start();
            }
        }

        public static void HideSearchForm()
        {
            if (runningSearchForm != null && !runningSearchForm.IsDisposed)
            {
                //runningSearchForm.Invoke(() =>
                //{
                //    runningSearchForm.Hide();
                //});

                runningSearchForm.Invoke((MethodInvoker)(() => runningSearchForm.Hide()));

            }
        }

        public static void ShowSearchForm()
        {
            if (runningSearchForm != null && !runningSearchForm.IsDisposed)
            {
                runningSearchForm.Invoke((MethodInvoker)(() => runningSearchForm.Show()));
            }
        }

        public static void CloseSearchForm()
        {
            if (runningSearchForm != null && !runningSearchForm.IsDisposed)
            {
                runningSearchForm.Invoke((MethodInvoker)(() => runningSearchForm.Close()));
            }
        }

        public static void UpdateSearchFormPosition(Point location, Size size)
        {
            if (runningSearchForm != null && !runningSearchForm.IsDisposed)
            {
                runningSearchForm.Invoke(new Action(() =>
                {
                    //runningSearchForm.StartFollowingMainForm();
                    runningSearchForm.Location = location;//.StartFollowingMainForm();

                    //runningSearchForm.SetMainForm(Application.OpenForms["MainForm"]);
                }));
            }
        }

    }

    public static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]

        static void Main()
        {
           
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show("حدث خطأ: " + args.Exception.Message);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Exception ex = args.ExceptionObject as Exception;
                MessageBox.Show("خطأ غير متوقع: " + ex?.Message);
            };


            bool ok;
            System.Threading.Mutex m = new System.Threading.Mutex(true, "YourNameHere", out ok);

            if (!ok)
            {
                MessageBox.Show("Another instance is already running");
                return;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                string result = "";
                try
                {
                    Utils.getsetting();


                    result = LoginMsg.ShowMe();
                    if (result == "ok")
                    {
                        Application.Run(new MainForm());
                    }
                    else if (result == "wrong")
                    {
                        Application.Exit();
                    }
                    else
                    {
                        Application.Exit();
                    }


                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    if (ex.ErrorCode == -2147467259)
                    {
                        MessageBox.Show(
                                       "لا يوجد مسار للمشروع الرجاء تحديد مسار مناسب",
                                       "خطأ",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error,
                                       MessageBoxDefaultButton.Button3,
                                       MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                   );

                        string FilePath = CustomPath.GetPath();
                        if (FilePath != null)
                        {
                            Utils.project(FilePath);
                            MessageBox.Show(
                                           "لن يتم إعادة تشغيل البرنامج الآن. الرجاء إعادة التشغيل يدويًا .",
                                           "معلومة",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information,
                                           MessageBoxDefaultButton.Button3,
                                           MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                       );
                            Application.Exit();
                        }
                        else
                        {
                            //MessageBox.Show(" الملف غير صالح");
                            Application.Exit();

                        }

                    }
                    else {
                        MessageBox.Show(
                                       ex.Message,
                                       "Error",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error
                                   );
                    }
                  
                }
            }

        } //of another instance




    }

}

