using B2BService.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenarator
{
    public partial class MegaMenuTes : Form
    {
        public MegaMenuTes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MegaMenuVm vm = new MegaMenuVm();
            vm.InitializeMenu2();
        }
    }
}
