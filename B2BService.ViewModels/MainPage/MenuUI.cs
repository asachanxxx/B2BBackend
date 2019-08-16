using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.MainPage
{
    public class Item2
    {
        public int Id { get; set; }
        public string label { get; set; }
        public string url { get; set; }
    }

    public class Item
    {
        public int L2ID { get; set; }
        public string label1 { get; set; }
        public string url1 { get; set; }
        public List<Item2> items { get; set; }
    }

    public class Column
    {
        public int size { get; set; }
        public List<Item> items { get; set; }
    }

    public class Menu
    {
        public string type { get; set; }
        public string size { get; set; }
        public string image { get; set; }
        public List<Column> columns { get; set; }
    }

    public class RootObject
    {
        public string label { get; set; }
        public string url { get; set; }
        public string Id { get; set; }
        public Menu menu { get; set; }
    }
}
