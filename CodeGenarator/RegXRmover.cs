using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenarator
{
    public partial class RegXRmover : Form
    {
        public RegXRmover()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = "<a href=\"http://www.amazon.com/dp/0596528124/\" class=\"someclass\">Mastering Regular Expressions</a>";
            string str2 = "< A href =\"http://cnn.com/\">CNN</a> <div><a href=\"http://blog.ysatech.com\">http://blog.ysatech.com</a></div>";

            string regx = @"<a [^>]*>(.*?)</a>";


            string inner = Regex.Match(str2, @"<a [^>]*>(.*?)</a>").Groups[1].Value;

            str1 = System.Text.RegularExpressions.Regex.Replace(str1, regx , "");
            str2 = System.Text.RegularExpressions.Regex.Replace(str2, "(<[a|A][^>]*>|)", "");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //string inner = Regex.Match(richTextBox1.Text, @"<a [^>]*>(.*?)</a>").Groups[1].Value;
            //richTextBox2.AppendText(inner + Environment.NewLine);
            richTextBox2.Text = "";
            foreach (var item in richTextBox1.Lines)
            {
                if (item != "")
                {
                    string inner = Regex.Match(item, @"<a [^>]*>(.*?)</a>").Groups[1].Value;
                    richTextBox2.AppendText(inner + Environment.NewLine);
                }
            }
        }
    }
}
