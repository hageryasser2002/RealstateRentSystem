using RealStateSystem_DataAccess;
using System;
using System.Linq;

namespace RealStateRentSystem_Buisness
{
    public class clsDeviceSettings
    {
        public static bool HasModem()
        {
            string addressOFDevice = GetAddressOfDevice();
            return clsDeviceSettingsData.GetHasModem(addressOFDevice);
        }

        public static string GetSlideShowPath()
        {
            string addressOFDevice = GetAddressOfDevice();
            return clsDeviceSettingsData.GetSlideShowPath(addressOFDevice);
        }
        public static bool CanSaveCalls()
        {
            string addressOFDevice = GetAddressOfDevice();
            return clsDeviceSettingsData.GetCanSaveCalls(addressOFDevice);
        }

        public static void SaveDeviceSetting(string deviceName, bool alert, bool backup, bool canSave, bool hasModem)
        {
            string addressOFDevice = GetAddressOfDevice();
            clsDeviceSettingsData.SaveOrUpdateDevice(deviceName, alert, backup , addressOFDevice, canSave, hasModem);
        }

        private static string GetAddressOfDevice()
        {
            var nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                .Where(nic =>
                    nic.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback &&
                    nic.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Tunnel &&
                    !nic.Description.ToLower().Contains("virtual") &&
                    !string.IsNullOrEmpty(nic.GetPhysicalAddress().ToString())
                )
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();

            return nics ?? "NO_MAC_FOUND";
        }

    }

}
