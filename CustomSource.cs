using RealStateRentSystem;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using System.ComponentModel;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("EAC04BC0-3791-11d2-BB95-0060977B464C")]
[SuppressUnmanagedCodeSecurity]
public interface IAutoComplete2
{
    int Init([In] HandleRef hwndEdit, [In] IEnumString punkACL, [In] string pwszRegKeyPath, [In] string pwszQuickComplete);
    void Enable([In] bool fEnable);
    int SetOptions([In] int dwFlag);
    void GetOptions([Out] IntPtr pdwFlag);

}


internal class CustomSource : BindingSource, IEnumString
{
    // Fields
    private static Guid autoCompleteClsid = new Guid("{00BB2763-6A77-11D0-A535-00C04FD7D062}");
    private IAutoComplete2 autoCompleteObject2;
    private int current;
    private int size;
    private string[] strings;

    public void Bind(TextBox textBox)
    {
        if (textBox == null || autoCompleteObject2 == null)
            return; // لو الـ TextBox أو الـ AutoComplete مش موجودين، نخرج بدون أي مشاكل

        try
        {
            autoCompleteObject2.SetOptions((int)textBox.AutoCompleteMode);
            autoCompleteObject2.Init(new HandleRef(textBox, textBox.Handle),
                this, string.Empty, string.Empty);
        }
        catch
        {
            // لو حصل أي استثناء، نعمل ignore تمامًا
        }
    

        // try
        //{
        //  this.autoCompleteObject2.SetOptions((int)textBox.AutoCompleteMode);
        //this.autoCompleteObject2.Init(new HandleRef(textBox, textBox.Handle),
        //  this, string.Empty, string.Empty);
        //}
        //catch
        //{

        //}
        //this.autoCompleteObject2.SetOptions((int)textBox.AutoCompleteMode);
        //this.autoCompleteObject2.Init(new HandleRef(textBox, textBox.Handle),
        //    this, string.Empty, string.Empty);
    }

    // Methods
    public CustomSource(string[] strings)
    {
        Array.Clear(strings, 0, this.size);
        if (strings != null)
        {
            this.strings = strings;
        }
        this.current = 0;
        this.size = (strings == null) ? 0 : strings.Length;
        Guid gUID = typeof(IAutoComplete2).GUID;
        object obj2 = Activator.CreateInstance(Type.GetTypeFromCLSID(autoCompleteClsid));
        try
        {
           this.autoCompleteObject2 = (IAutoComplete2)obj2;
        }
        catch (Exception)
        {

        }
       
    }

    public bool Bind(HandleRef edit, int options)
    {
        bool flag = false;
        if (this.autoCompleteObject2 == null)
        {
            return flag;
        }
        try
        {
            this.autoCompleteObject2.SetOptions(options);
            this.autoCompleteObject2.Init(edit, this, null, null);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void RefreshList(string[] newSource)
    {
        Array.Clear(this.strings, 0, this.size);
        if (this.strings != null)
        {
            this.strings = newSource;
        }
        this.current = 0;
        this.size = (this.strings == null) ? 0 : this.strings.Length;
    }

    public void ReleaseAutoComplete()
    {
        if (this.autoCompleteObject2 != null)
        {
            Marshal.ReleaseComObject(this.autoCompleteObject2);
            this.autoCompleteObject2 = null;
        }
    }

    void IEnumString.Clone(out IEnumString ppenum)
    {
        ppenum = new CustomSource(this.strings);
    }

    public string DisplayMember { get; set; }

    int IEnumString.Next(int celt, string[] rgelt, IntPtr pceltFetched)
    {
        if (celt < 0)
        {
            return -2147024809;
        }

        int index = 0;

        while ((this.current < this.size) && (celt > 0))
        {
            object item = this.strings[this.current];
            bool useDisplayMember = false;
            if (string.IsNullOrEmpty(DisplayMember))
            {
                ICustomTypeDescriptor customTypeDescriptor = item as CustomTypeDescriptor;
                if (customTypeDescriptor != null)
                {
                    PropertyDescriptorCollection descriptorCollection =
                        customTypeDescriptor.GetProperties();
                    if (descriptorCollection != null)
                    {
                        PropertyDescriptor propertyDescriptor = descriptorCollection[DisplayMember];
                        if (propertyDescriptor != null)
                        {
                            rgelt[index] = propertyDescriptor.GetValue(item).ToString();
                            useDisplayMember = true;
                        }
                    }
                }

                if (!useDisplayMember)
                {
                    if (item != null)
                        rgelt[index] = item.ToString();
                }
            }

            current++;
            index++;
            celt--;
        }

        if (pceltFetched != IntPtr.Zero)
        {
            Marshal.WriteInt32(pceltFetched, index);
        }
        if (celt != 0)
        {
            return 1;
        }

        return 0;
    }

    void IEnumString.Reset()
    {
        this.current = 0;
    }

    int IEnumString.Skip(int celt)
    {
        this.current += celt;
        if (this.current >= this.size)
        {
            return 1;
        }
        return 0;
    }
}
