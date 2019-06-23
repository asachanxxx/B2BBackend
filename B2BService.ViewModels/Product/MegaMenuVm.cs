using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace B2BService.ViewModels.Product
{
    public class MegaMenuVm
    {

        public MegaMenuVm()
        {

            

        }

        public void InitializeMenu2()
        {
            List<NavigationLink> nav = new List<NavigationLink>();
            nav.Add(GetNavMenu());
          

            var json = new JavaScriptSerializer().Serialize(nav);


        }

        private NavigationLink GetNavMenu()
        {
            NavigationLink nav = new NavigationLink();
            List<MegamenuColumn> submenuitems = new List<MegamenuColumn>();
            nav.label = "Power Tools";
            nav.url = "./shop";
            nav.menu = new List<Menu>();
            Menu menulevel1 = new Menu();
            menulevel1.type = "megamenu";
            menulevel1.size = "xl";
            menulevel1.image = "assets/images/megamenu/megamenu-1.jpg";
            menulevel1.items = null;
            menulevel1.columns = new List<MegamenuColumn>()
            {
                new MegamenuColumn {size = 3, items =  new List<NestedLink>()
                {
                    new NestedLink()  {
                    label = "Power Tools",
                    url = "/shop",
                    items = new List<NestedLink>() {
                    new NestedLink() { label= "Engravers", url= "./shop" },
                                        new NestedLink() { label= "Drills", url= "./Drills" },
                    new NestedLink() { label= "Wrenches", url= "./Wrenches" },
                    new NestedLink() { label= "Plumbing", url= "./Plumbing" },
                    new NestedLink() { label= "Pneumatic", url= "./Pneumatic" }

                     }

                    },
                     new NestedLink() {
                    label = "Power Tools",
                    url = "/shop",
                        items = new List<NestedLink>() {
                    new NestedLink() { label= "Screwdrivers", url= "./shop" },
                                        new NestedLink() { label= "Drills", url= "./Drills" },
                    new NestedLink() { label= "Handsaws", url= "./Wrenches" },
                    new NestedLink() { label= "Knives", url= "./Plumbing" },
                    new NestedLink() { label= "Axes", url= "./Pneumatic" }

                     }

                    }



                  }

                },
                //new MegamenuColumn {size = 3, items =  new List<NestedLink>()
                //{
                //    new NestedLink()  {
                //    label = "'Hand Tools",
                //    url = "/shop",
                //    items = new List<NestedLink>() {
                //    new NestedLink() { label= "Screwdrivers", url= "./shop" },
                //                        new NestedLink() { label= "Drills", url= "./Drills" },
                //    new NestedLink() { label= "Handsaws", url= "./Wrenches" },
                //    new NestedLink() { label= "Knives", url= "./Plumbing" },
                //    new NestedLink() { label= "Axes", url= "./Pneumatic" }

                //     }
                //    }
                //  }

                //}
            };

            nav.menu.Add(menulevel1);
            return nav;


        }


        private NavigationLink GetNavMenu2()
        {
            NavigationLink nav = new NavigationLink();
            List<MegamenuColumn> submenuitems = new List<MegamenuColumn>();
            nav.label = "Hand Tools";
            nav.url = "./shop";
            nav.menu = new List<Menu>();
            Menu menulevel1 = new Menu();
            menulevel1.type = "megamenu";
            menulevel1.size = "xl";
            menulevel1.image = "assets/images/megamenu/megamenu-1.jpg";
            menulevel1.items = null;
            menulevel1.columns = new List<MegamenuColumn>()
            {
                new MegamenuColumn {size = 3, items =  new List<NestedLink>()
                {  new NestedLink()  {
                    label = "Power Tools",
                    url = "/shop",
                    items = new List<NestedLink>() {
                    new NestedLink() { label= "Engravers", url= "./shop" },
                                        new NestedLink() { label= "Drills", url= "./Drills" },
                    new NestedLink() { label= "Wrenches", url= "./Wrenches" },
                    new NestedLink() { label= "Plumbing", url= "./Plumbing" },
                    new NestedLink() { label= "Pneumatic", url= "./Pneumatic" }

                     }
                    }
                    }
                }
            };
            nav.menu.Add(menulevel1);
            return nav;
        }

        public void InitializeMenu1()
        {

            NavigationLink nav = new NavigationLink();
            List<Menu> meuelist1 = new List<Menu>();
            List<MegamenuColumn> submenuitems = new List<MegamenuColumn>();

            nav.label = "Hand Tools";
            nav.url = "./shop";
            nav.menu = meuelist1;


            Menu menulevel1 = new Menu();
            menulevel1.type = "megamenu";
            menulevel1.size = "xl";
            menulevel1.image = "assets/images/megamenu/megamenu-1.jpg";
            menulevel1.columns = submenuitems;
            menulevel1.items = null;


            MegamenuColumn col1 = new MegamenuColumn();
            col1.size = 3;
            col1.items.Add(
                new NestedLink()
                {
                    label = "Power Tools",
                    url = "/shop",
                    items = new List<NestedLink>() {
                    new NestedLink() { label= "Engravers", url= "./shop" },
                    new NestedLink() { label= "Drills", url= "./Drills" },
                    new NestedLink() { label= "Wrenches", url= "./Wrenches" },
                    new NestedLink() { label= "Plumbing", url= "./Plumbing" },
                    new NestedLink() { label= "Pneumatic", url= "./Pneumatic" },
                }
                }

            );

            submenuitems.Add(col1);
            nav.menu = meuelist1;
        }



    }



    public class MegamenuColumn
    {
        public int size { get; set; }
        public List<NestedLink> items { get; set; }

    }

    public class NavigationLink : Link 
    {
        public List<Menu> menu { get; set; }
      

    }

    public class Menu: Megamenu
    {
        public string type { get; set; } = "menu";
        public List<NestedLink> items { get; set; }
        public string size { get; set; }
        public string image { get; set; }
        public List<MegamenuColumn> columns { get; set; }

    }


    public interface Megamenu
    {
        string type { get; set; }
        string size { get; set; }
        string image { get; set; }
        List<MegamenuColumn> columns { get; set; }
    }




    public class Link
    {
        public string label { get; set; }
        public string url { get; set; }
        public bool external { get; set; }
        public string target { get; set; } = "_blank";

    }


    public class NestedLink:Link
    {
        public List<NestedLink> items { get; set; }
    }

   


}







