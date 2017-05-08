using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class AddressHelp : IAddressHelp
    {
        public string GetAddressInfo(string intput)
        {
            using (DaumAddressSearchForm form = new DaumAddressSearchForm())
            {
                string output = null;
                form.SetInput(intput);
                if (form.ShowDialog() == DialogResult.OK)
                    output = form.GetOutput();
                return output;
            }
        }
    }
}
