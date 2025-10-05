
using RealStateRentSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;


namespace RealStateRentSystem
{
    class CustomPath
    {
        public CustomPath() { }

        public static string GetPath()
        {

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Attach file";
            fdlg.InitialDirectory = Directory.GetCurrentDirectory();
            fdlg.Filter = "DateBase (*.accdb)|*.accdb";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(fdlg.FileName) != ".accdb")
                {
                    MessageBox.Show("رجاء اختر المسار بشكل صحيح");
                    return null;
                }

                return fdlg.FileName;
            }

            return null;
        }

        public static string GetDBName()
        {
            string conn = Properties.Settings.Default.db1ConnectionString;
            var builder = new OleDbConnectionStringBuilder(conn);
            string dataSource = builder.DataSource;
            return Path.GetFileName(dataSource);
        }

        public static string GetDBFullPath()
        {
            string conn = Properties.Settings.Default.db1ConnectionString;
            var builder = new OleDbConnectionStringBuilder(conn);
            return builder.DataSource;
        }
        public static void DownloadFileToFolder(string fileName, string targetFolder, int recordNumber)
        {
            string extension = Path.GetExtension(fileName);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

            string path;
            if (File.Exists(Path.Combine(Utils.ProjectName, "TempAttachment", fileName)))
            {
                path = Path.Combine(Utils.ProjectName, "TempAttachment", fileName);
            }
            else
            {
                path = Path.Combine(Utils.ProjectName, fileName);
            }

            if (!File.Exists(path))
            {
                MessageBox.Show($"⚠ الملف {fileName} غير موجود", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            // اسم الملف النهائي
            string newFileName = $"{fileNameWithoutExt}_{recordNumber}{extension}";
            string destPath = Path.Combine(targetFolder, newFileName);

            if (extension == ".rar" || extension == ".zip")
            {
                string extractPath = Path.Combine(targetFolder, Path.GetFileNameWithoutExtension(newFileName));
                if (!Directory.Exists(extractPath))
                    Directory.CreateDirectory(extractPath);

                try
                {
                    using (var archive = System.IO.Compression.ZipFile.OpenRead(path))
                    {
                        foreach (var entry in archive.Entries)
                        {
                            string destinationPath = Path.Combine(extractPath, entry.FullName);

                            // تأكد إن الفولدر موجود
                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                            // لو الملف موجود هيمسحه الأول (overwrite)
                            if (File.Exists(destinationPath))
                            {
                                File.Delete(destinationPath);
                            }

                            if (!string.IsNullOrEmpty(entry.Name)) // نتجنب الفولدرات الفاضية
                            {
                                entry.ExtractToFile(destinationPath);
                            }
                        }
                    }

                }
                catch
                {
                    File.Copy(path, destPath, true); // fallback لو الملف مش Zip حقيقي
                }
            }
            else
            {
                File.Copy(path, destPath, true);
            }
        }

        public static void DownloadFileToFolderOwn(string fileName, string targetFolder, int recordNumber)
        {
            string extension = Path.GetExtension(fileName);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

            // البحث عن الملف
            string path;
            if (File.Exists(Path.Combine(Utils.ProjectName, "TempAttachment", fileName)))
            {
                path = Path.Combine(Utils.ProjectName, "TempAttachment", fileName);
            }
            else
            {
                path = Path.Combine(Utils.ProjectName, "OwAttach", fileName);
            }

            if (!File.Exists(path))
            {
                MessageBox.Show($"⚠ الملف {fileName} غير موجود", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            // اسم الملف الجديد
            string newFileName = $"{fileNameWithoutExt}_{recordNumber}{extension}";
            string destPath = Path.Combine(targetFolder, newFileName);

            if (extension == ".zip")
            {
                string extractPath = Path.Combine(targetFolder, Path.GetFileNameWithoutExtension(newFileName));
                if (!Directory.Exists(extractPath))
                    Directory.CreateDirectory(extractPath);

                try
                {
                    using (var archive = System.IO.Compression.ZipFile.OpenRead(path))
                    {
                        foreach (var entry in archive.Entries)
                        {
                            string destinationPath = Path.Combine(extractPath, entry.FullName);

                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                            if (File.Exists(destinationPath))
                                File.Delete(destinationPath);

                            if (!string.IsNullOrEmpty(entry.Name))
                                entry.ExtractToFile(destinationPath);
                        }
                    }
                }
                catch
                {
                    File.Copy(path, destPath, true); // fallback لو الملف مش zip حقيقي
                }
            }
            else
            {
                // باقي الملفات (بما فيها rar) نسخ عادي
                File.Copy(path, destPath, true);
            }
        }

        //public static void DownloadFile(string filename, string FolderName)
        //{
        //    string extension = Path.GetExtension(filename);
        //    string FilePath = Path.Combine(Utils.ProjectName, FolderName, filename);
        //    //if (extension != ".rar" && extension != ".zip")
        //    //{
        //    //    IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
        //    //    IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(FilePath + ".lnk");

        //    //    FilePath = shortcut.TargetPath;
        //    //}


        //    if (File.Exists(FilePath))
        //    {
        //        SaveFileDialog saveFileDialog = new SaveFileDialog()
        //        {
        //            Title = "Save your file",
        //            Filter = "All Files (*.*)|*.*",
        //            FilterIndex = 1,
        //            DefaultExt = extension,
        //            FileName = filename
        //        };

        //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            if (extension == ".rar" || extension == ".zip") {
        //                string path = Path.Combine(
        //                    Path.GetDirectoryName(saveFileDialog.FileName), 
        //                    Path.GetFileNameWithoutExtension(saveFileDialog.FileName));
        //                ZipFile.ExtractToDirectory(FilePath,path );
        //            }
        //            else
        //                File.Copy(FilePath, saveFileDialog.FileName, true);

        //            MessageBox.Show(
        //                                 "تم تنزيل الملف بنجاح",
        //                                 "معلومة",
        //                                 MessageBoxButtons.OK,
        //                                 MessageBoxIcon.Information,
        //                                 MessageBoxDefaultButton.Button3,
        //                                 MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
        //                             );
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show(
        //                        "الملف غير موجود",
        //                         "خطأ",
        //                         MessageBoxButtons.OK,
        //                         MessageBoxIcon.Error,
        //                         MessageBoxDefaultButton.Button3,
        //                         MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
        //                     );
        //    }

        //}

        public static bool IsValidFileName(string fileName)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();

            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            if (fileName.StartsWith(","))
                return false;

            return !fileName.Any(c => invalidChars.Contains(c));
        }

        //public static string UniqueFileName(string FileName, int Realstateid)
        //{
        //    string originalName = FileName;
        //    string extension = Path.GetExtension(originalName);
        //    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(originalName);
        //    string uniqueFileName = $"{fileNameWithoutExt}{Realstateid}{extension}";

        //    return uniqueFileName;

        //}

        public static string UniqueFileName(string FileName, int Realstateid)
        {
            string extension = Path.GetExtension(FileName);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(FileName);

            // نولّد قيمة فريدة (ممكن Guid أو Ticks)
            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 6);
            // أو: DateTime.Now.Ticks.ToString()

            string uniqueFileName = $"{fileNameWithoutExt}_{Realstateid}_{uniquePart}{extension}";
            return uniqueFileName;
        }


        public static bool CreateAttachment(string FullPath, string FileName, string FolderName, int Id)
        {

            if (!IsValidFileName(FileName))
            {
                MessageBox.Show(
                            "اسم الملف غير مسموح به.",
                               "خطأ",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button3,
                               MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                           );
                return false;
            }


            string TempPath = Path.Combine(Utils.ProjectName, FolderName, FileName);
            try
            {
                // System.IO.File.Move(FullPath, TempPath);

                System.IO.File.Move(FullPath, TempPath);


            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show("ليس لديك صلاحية لحذف الملف: " + uaEx.Message);
                return false;
            }


            // نحاول نحذف الفولدر المفكوك
            try
            {
                string fullPathWithoutExtension = Path.Combine(
                    Path.GetDirectoryName(FullPath),
                    Path.GetFileNameWithoutExtension(FullPath));

                if (Directory.Exists(fullPathWithoutExtension))
                {
                    Directory.Delete(fullPathWithoutExtension, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل في حذف المجلد المفكوك: " + ex.Message);
            }

            return true;

            //if (!IsValidFileName(FileName))
            //{
            //    MessageBox.Show(
            //                "اسم الملف غير مسموح به.",
            //                   "خطأ",
            //                   MessageBoxButtons.OK,
            //                   MessageBoxIcon.Error,
            //                   MessageBoxDefaultButton.Button3,
            //                   MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
            //               );
            //    return false;
            //}

            //string TempPath = Path.Combine(Utils.ProjectName, FolderName, FileName);
            //try
            //{
            //    // System.IO.File.Move(FullPath, TempPath);
            //    System.IO.File.Move(FullPath, TempPath);

            //}
            //catch (UnauthorizedAccessException uaEx)
            //{
            //    MessageBox.Show("ليس لديك صلاحية لحذف الملف: " + uaEx.Message);
            //    return false;
            //}
            //// نحاول نحذف الفولدر المفكوك
            //try
            //{
            //    string fullPathWithoutExtension = Path.Combine(
            //        Path.GetDirectoryName(FullPath),
            //        Path.GetFileNameWithoutExtension(FullPath));

            //    if (Directory.Exists(fullPathWithoutExtension))
            //    {
            //        Directory.Delete(fullPathWithoutExtension, true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("فشل في حذف المجلد المفكوك: " + ex.Message);
            //}


            //return true;
        }


        public static bool OpenAttachmentShortcut(string shortcutName, string FolderName)
        {
            try
            {
                string shortcutPath = Path.Combine(Utils.ProjectName, FolderName, shortcutName) + ".lnk";

                shortcutPath = shortcutPath.Replace("بناء", "");
                // التحقق من وجود الاختصار
                if (!System.IO.File.Exists(shortcutPath))
                {
                    MessageBox.Show(
                               "اختصار الملف غير موجود",
                                 "خطأ",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button3,
                                 MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                             );

                    return false;
                }

                // قراءة الهدف الحقيقي للاختصار
                IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);

                // التحقق من وجود الملف الأصلي
                string TargetFileName = Path.GetFileName(shortcut.TargetPath);
                shortcut.TargetPath = Path.Combine(Utils.ProjectName, "TempAttachment", TargetFileName);
                if (System.IO.File.Exists(shortcut.TargetPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = shortcut.TargetPath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show(
                             $"الملف الأصلي غير موجود في المسار: {shortcutPath}",
                               "خطأ",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button3,
                               MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                           );
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                            $"خطأ في فتح المرفق: {ex.Message}",
                              "خطأ",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button3,
                              MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                          );
                return false;
            }

            return true;
        }

        public static bool OpenAttachment(string FileName, string FolderName, string fileNameWithID="")
        {
            try
            {
                string TargetPath = Utils.ProjectName+ "\\TempAttachment\\"+ FileName;
                string TargetPath2 = Utils.ProjectName + "\\" + fileNameWithID;
                string TargetPath3 = Utils.ProjectName + "\\OwAttach\\" + fileNameWithID;


                //TargetPath = TargetPath.Replace("بناء", "");
                if (System.IO.File.Exists(TargetPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = TargetPath,
                        UseShellExecute = true
                    });
                }
                else if (System.IO.File.Exists(TargetPath2))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = TargetPath2,
                        UseShellExecute = true
                    });
                }
                else if (System.IO.File.Exists(TargetPath3))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = TargetPath3,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show(
                                  $"الملف غير موجود في المسار: {TargetPath}",
                                   "خطأ",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button3,
                                   MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                               );

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                                $"خطأ في فتح المرفق: {ex.Message}",
                                  "خطأ",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error,
                                  MessageBoxDefaultButton.Button3,
                                  MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                              );

                return false;
            }

            return true;
        }
    }


}
