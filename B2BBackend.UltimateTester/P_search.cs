using B2BService.Domain;
using B2BService.Repository;
using B2BService.Repository.SystemRepositories;
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

namespace B2BBackend.UltimateTester
{
    public partial class P_search : Form
    {
        CategoryRepository repo = new CategoryRepository();
        RepoBase<Level1> repolevel1 = new RepoBase<Level1>("Level1");
        public P_search()
        {
            repo = new CategoryRepository();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

          
           // var task = Task.Run(async () => await repo.GetDataForSubCategoryView(1));
           // var result = task.();
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                var task = repo.GetDataForSubCategoryView(int.Parse(comboBox1.SelectedValue.ToString())).Result.ToList();
                foreach (var item in task)
                {
                  
                    TreeNode node = new TreeNode();
                    node.Text = item.Subcategory1Name;
                    node.Name = item.Subcategory1Id.ToString();
                    foreach (var item1 in item.Details)
                    {
                        node.Nodes.Add(item1.Subcategory2Id.ToString(),  item1.Subcategory2Name);
                    }

                    treeView1.Nodes.Add(node);
                }
            });

            
            
        }

        private void P_search_Load(object sender, EventArgs e)
        {
            backgroundWorker2Startup.RunWorkerAsync();

           
        }

        private void backgroundWorker2Startup_DoWork(object sender, DoWorkEventArgs e)
        {
            var lvl1s = repolevel1.FindALL().Result.ToList();

            this.Invoke((MethodInvoker)delegate ()
            {
                comboBox1.DataSource = lvl1s;
                comboBox1.DisplayMember = "Level1Name";
                comboBox1.ValueMember = "Id";

                // Do stuff on ANY control on the form.
            });
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(e.Node.Name + " - " + e.Node.Text); 
        }
    }
}
