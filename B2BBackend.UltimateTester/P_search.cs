using B2BService.Domain;
using B2BService.Domain.Coparate;
using B2BService.Repository;
using B2BService.Repository.SystemRepositories;
using B2BService.Unitilities;
using B2BService.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                //var task = repo.GetDataForSubCategoryView(int.Parse(comboBox1.SelectedValue.ToString())).Result.ToList();
                //foreach (var item in task)
                //{
                  
                //    TreeNode node = new TreeNode();
                //    node.Text = item.Subcategory1Name;
                //    node.Name = item.Subcategory1Id.ToString();
                //    foreach (var item1 in item.Details)
                //    {
                //        node.Nodes.Add(item1.Subcategory2Id.ToString(),  item1.Subcategory2Name);
                //    }

                //    treeView1.Nodes.Add(node);
                //}
            });

            
            
        }

        private void P_search_Load(object sender, EventArgs e)
        {
            backgroundWorker2Startup.RunWorkerAsync();

           
        }

        private void backgroundWorker2Startup_DoWork(object sender, DoWorkEventArgs e)
        {            //var lvl1s = repolevel1.FindALL().Result.ToList();

            //this.Invoke((MethodInvoker)delegate ()
            //{
            //    comboBox1.DataSource = lvl1s;
            //    comboBox1.DisplayMember = "Level1Name";
            //    comboBox1.ValueMember = "Id";

            //    // Do stuff on ANY control on the form.
            //});


            var retList = ReadTextAsync<BussinessTypesJson>("myobjects.json");

            var retList2 = ReadTextAsync<DistrictJson>("myobjects2.json");

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(e.Node.Name + " - " + e.Node.Text); 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            JsonEngine jengine = new JsonEngine();

            var str = jengine.ConvertFromList<BussinessTypesJson>(
                new List<BussinessTypesJson>() {
                    new BussinessTypesJson(){Id=1, Name = "Business - 1-19 Employees" , Description = "Business - 1-19 Employees" },
                    new BussinessTypesJson(){Id=1, Name = "Business - 20-249 Employees" , Description = "Business - 20-249 Employees" },
                    new BussinessTypesJson(){Id=1, Name = "Business - 250-499 Employees" , Description = "Business - 250-499 Employees" }
             });
            File.WriteAllText("BussinessTypesJson.json", str);

            var str2 = jengine.ConvertFromList<DistrictJson>(
             new List<DistrictJson>() {
                    new DistrictJson(){Id=1, DName = "Ampara" },
                    new DistrictJson(){Id=2, DName = "Anuradhapura" },
                    new DistrictJson(){Id=3, DName = "Badulla"  },
                    new DistrictJson(){Id=4, DName = "Batticaloa"  },
                    new DistrictJson(){Id=5, DName = "Colombo"  },
                    new DistrictJson(){Id=6, DName = "Galle"  },
                    new DistrictJson(){Id=7, DName = "Gampaha"  },
                    new DistrictJson(){Id=8, DName = "Hambantota"  },
                    new DistrictJson(){Id=9, DName = "Jaffna"  },
                    new DistrictJson(){Id=10, DName = "Kalutara"  },
                    new DistrictJson(){Id=11, DName = "Kandy"  },
                    new DistrictJson(){Id=12, DName = "Kegalle"  },
                    new DistrictJson(){Id=13, DName = "Kilinochchi"  },
                    new DistrictJson(){Id=14, DName = "Kurunegala"  },
                    new DistrictJson(){Id=15, DName = "Mannar"  },
                    new DistrictJson(){Id=16, DName = "Matara"  },
                    new DistrictJson(){Id=17, DName = "Moneragala"  },
                    new DistrictJson(){Id=18, DName = "Nuwara Eliya"  },
                    new DistrictJson(){Id=19, DName = "Polonnaruwa"  },
                    new DistrictJson(){Id=20, DName = "Puttalam"  },
                    new DistrictJson(){Id=21, DName = "Ratnapura"  },
                    new DistrictJson(){Id=22, DName = "Trincomalee"  },
                    new DistrictJson(){Id=23, DName = "Vavuniya"  }
          });

            File.WriteAllText("DistrictJson.json", str2);

        }

        private async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };

            //Task theTask = sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            //await theTask;
        }

        private async Task<List<T>> ReadTextAsync<T>(string filePath) where T : class
        {
            try
            {
                JsonEngine jengine = new JsonEngine();

                using (FileStream sourceStream = new FileStream(filePath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true))
                {
                    StringBuilder sb = new StringBuilder();

                    byte[] buffer = new byte[0x1000];
                    int numRead;
                    while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        string text = Encoding.ASCII.GetString(buffer, 0, numRead);
                        sb.Append(text);
                    }

                    var listback = jengine.ConvertFromJson<T>(sb.ToString());

                    return listback;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

    }
}
