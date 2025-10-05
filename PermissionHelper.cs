using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace RealStateRentSystem.Classes
{
    
    public class PermissionHelper
    {
        public static bool TakeOwnershipAndGrantFullControl(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    FileSecurity fileSecurity = fileInfo.GetAccessControl();
                    var currentUser = WindowsIdentity.GetCurrent().User;
                    fileSecurity.SetOwner(currentUser);
                    fileSecurity.AddAccessRule(new FileSystemAccessRule(
                        WindowsIdentity.GetCurrent().Name,
                        FileSystemRights.FullControl,
                        AccessControlType.Allow));
                    fileInfo.SetAccessControl(fileSecurity);
                }
                else if (Directory.Exists(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    DirectorySecurity dirSecurity = dirInfo.GetAccessControl();
                    var currentUser = WindowsIdentity.GetCurrent().User;
                    dirSecurity.SetOwner(currentUser);
                    dirSecurity.AddAccessRule(new FileSystemAccessRule(
                        WindowsIdentity.GetCurrent().Name,
                        FileSystemRights.FullControl,
                        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                        PropagationFlags.None,
                        AccessControlType.Allow));
                    dirInfo.SetAccessControl(dirSecurity);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل في إعطاء الصلاحيات: " + ex.Message);
                return false;
            }
        }
    }

}
