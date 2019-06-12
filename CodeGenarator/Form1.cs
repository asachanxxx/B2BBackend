using B2BService.Domain.Inventory;
using B2BService.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenarator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_genarate_Click(object sender, EventArgs e)
        {
            CreateFolderStructure();
            var props = ExtractProperties<CateglogProducts>(new CateglogProducts());
            var returnxx = GenarateForSQLXMLExtraction(props);
            richTextBox1.Text = returnxx;
        }

        //objectVM.value('(IpAddress/text())[1]','nvarchar') as Level1Name,
        public string GenarateForSQLXMLExtraction(List<DoubleString> PassingList) {
            string pass = "";

            foreach (var item in PassingList)
            {
                pass += "objectVM.value('("+ item.str1 + "/text())[1]','"+ GetNameFromType (item.str2)+ "') as " + item.str1 + "," + Environment.NewLine;
            }

            return pass;
        }

        public List<DoubleString> ExtractProperties<T>(T obj) where T : class
        {
            List<DoubleString> PropList = new List<DoubleString>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                PropList.Add(new DoubleString {  str1 = property.Name , str2 =property.PropertyType.Name });
            }
            return PropList;
        }

        private string GetNameFromType(string Type)
        {
            string retstr = "";
            switch (Type)
            {
                case "String":
                    retstr = "[nvarchar](max)";
                    break;
                case "Int32":
                    retstr = "[int]";
                    break;
                case "DateTime":
                    retstr = "[datetime]";
                    break;
                case "Decimal":
                    retstr = "[decimal](18, 2)";
                    break;
                case "Int64":
                    retstr = " [BIGINT]";
                    break;
                case "Int16":
                    retstr = " [smallint]";
                    break;
                case "Single":
                    retstr = " [real]";
                    break;
            }
            return retstr;
        }


        private void CreateFolderStructure()
        {
            if (textBox1.Text.Trim() != "")
            {
                if (Directory.Exists(textBox1.Text.Trim()))
                {
                }
                else
                {
                    var donex = Directory.CreateDirectory(textBox1.Text.Trim());
                }
            }


        }



    }
}
