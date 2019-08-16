using B2BService.ViewModels.Product;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B2BService.ViewModels.MainPage;
using Newtonsoft.Json;

namespace CodeGenarator
{
    public partial class MegaMenuTes : Form
    {
        public readonly IDbConnection Conn;
        public MegaMenuTes()
        {
            InitializeComponent();

            Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SysConn"].ConnectionString);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var valx = LoadMenues();
            var json = JsonConvert.SerializeObject(valx);


        }

        private List<Item> LoadMenues()         {
            try
            {
                Item outpro = new Item();
                using (IDbConnection db = Conn)
                {

                    var sql = @"SELECT L2.Id as 'L2ID' , l2.Level2Name as 'label1',l2.Url as 'url1', l3.ID as 'Id' , l3.level3Name as 'label' , L3.Url as 'url'    FROM Level2 as L2 inner join" + 
                              " Level3 as L3 on L2.ID = L3.Level12d";

                    var orderDictionary = new Dictionary<int, Item>();
                    var list = db.Query<Item, Item2, Item>(
                        sql,
                        (Pro, Fe) =>
                        {
                            Item orderEntry;

                            if (!orderDictionary.TryGetValue(Pro.L2ID, out orderEntry))
                            {
                                orderEntry = Pro;
                                orderEntry.items = new List<Item2>();
                                orderDictionary.Add(orderEntry.L2ID, orderEntry);
                            }

                            orderEntry.items.Add(Fe);
                            return orderEntry;
                        },
                        splitOn: "Id")
                    .Distinct()
                    .ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
