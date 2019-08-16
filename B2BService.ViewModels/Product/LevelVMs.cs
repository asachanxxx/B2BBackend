using B2BService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BService.ViewModels.Product
{
    public class Level1VM : BaseClass
    {
        public string Code { get; set; }
        public string Level1Name { get; set; }
    }
    public class Level2VM : BaseClass
    {
        public int Level1Id { get; set; }
        public string Code { get; set; }
        public string Level2Name { get; set; }
        public int SpecMasterId { get; set; }
    }
    public class Level3VM : BaseClass
    {
        public int Level1Id { get; set; }
        public int Level12d { get; set; }
        public string Code { get; set; }
        public string Level3Name { get; set; }
    }

    //  Level1Id Level2Id    Level2Name Level3Id    Level3Name

    public class Level1VMMega
    {
        public int Level1Id { get; set; }
        public string Level1Name { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public List<MegamenuColumnMega> Details { get; set; }
    }


    public class MegamenuColumnMega
    {
        public int size { get; set; }
        public List<Level2VMMega> items { get; set; }
    }

    public class Level2VMMega
    {
        public int Level1Id { get; set; }
        public int Level2Id { get; set; }
        public string Level2Name { get; set; }
        public string Url { get; set; }
        public string External1 { get; set; }
        public string Target { get; set; }
        public string ColumnNumber { get; set; }
        public List<Level3VMMega> Details { get; set; }
    }
    public class Level3VMMega
    {
        public int Level3Id { get; set; }
        public string Level3Name { get; set; }
        public string Url { get; set; }
        public string External2 { get; set; }
        public string Target { get; set; }
    }
}

