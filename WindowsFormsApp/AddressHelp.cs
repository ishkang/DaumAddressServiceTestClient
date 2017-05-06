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
        public string GetAddressInfo(string address)
        {
            using (AddressHelpForm form = new AddressHelpForm())
            {
                string addressInfo = null;
                if (form.ShowDialog(address) == DialogResult.OK)
                    addressInfo = form.GetAddressInfo();
                return addressInfo;
            }
        }
    }
}
