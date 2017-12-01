using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.Data;
using System.Web.WebPages;

namespace n305.Models
{
    public class Navigation
    {
        
         //internal String GitHub = "https://github.com/Naox305";
         //   internal String Blog = "https://medium.com/@Naox305";
       // internal String[] ListOfWebsites = { "https://github.com/Naox305", "https://medium.com/@Naox305" };

        public class URLs
        {
            public String Name { get; set; }
            public String URL { get; set; }
            public int Value { get; set; } 
        }

        public class ItemsAndURLs
        {
            public String Name { get; set; }
            public String ImageURL { get; set; }
            public String ItemURL { get; set; }
            public int Value { get; set; }
        }

        public class MyWebSites
        {
            private static int HoldThisSelection { get; set; }

            public int SelectedWebSite
            {
                get
                {
                    return MyWebSites.HoldThisSelection;
                }
                set
                {
                    value = MyWebSites.HoldThisSelection;
                }
            }

            public ICollection<URLs> GetList()
            {
                List<URLs> TempList = new List<URLs>();
                if (TempList.Count == 0)
                {
                    String ContactURL = "Contact";
                    String GalleryURL = "Gallery";
                    String AboutURL = "About";

                    //renamed GALLERY to PROJECTS.
                    TempList.Add(new URLs() { Name = "PROJECTS", URL = GalleryURL, Value = 1 });
                    TempList.Add(new URLs() { Name = "GITHUB", URL = "https://github.com/Naox305", Value = 2 });
                    TempList.Add(new URLs() { Name = "CONTACT", URL = ContactURL, Value = 3 });
                    TempList.Add(new URLs() { Name = "ABOUT", URL = AboutURL, Value = 4 });
                    return TempList;
                }
                else
                    return TempList;
            }

            public String GetUrl(int WebSiteName)
            {
                return GetList().Where(x => x.Value == WebSiteName).FirstOrDefault().URL;
            }

        }

        public class NewWebPageView<T>:WebViewPage
        {
            public override void Execute() {}
            public ControlMaker ControlMaker { get; set; }
        }

        public sealed class ControlMaker : NewWebPageView<ControlMaker>
        {
              private static readonly ControlMaker StaticInstance = new ControlMaker();
   
              private ControlMaker(){}

                public static ControlMaker Instance
                {
                    get 
                    {
                        return StaticInstance; 
                    }
                }
            
            public String ButtonMaker(n305.Models.Navigation.URLs Value, String GetClass)
            {
                var ThisName = Value.Name;
                var ThisUrl = Value.URL;
                String GotoUrl = null;
                UrlHelper NewUrlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                if (ThisUrl.Contains(".") == false)

                    GotoUrl = NewUrlHelper.Action(ThisUrl);
                 else 
                    GotoUrl = ThisUrl;
                
                var ThisButton = "<input type=" +
                    "\"button\"" +
                 "class=" + "\""+ GetClass + "\""+
                 "title=" + "\"" + ThisName + "\"" +
                 "value=" + "\"" + ThisName + "\""
                 +

                 "onclick=" + "\"" + "location.href=" + "'" + GotoUrl + "'" + "\"" + ">";
                
               
                return ThisButton;
            }

           
            public MvcHtmlString CreateSelectBox(dynamic GenericList)
            {
                String ThisHtmlList = null;
                String CreateRawHtmlList;


                foreach (var Item in GenericList)
               {
                   ThisHtmlList = ThisHtmlList + ButtonMaker(Item, "MenuItem");
               }


                CreateRawHtmlList = "<div id=" + "NavigationMenu" + " >" + ThisHtmlList + "<div/>";

                return MvcHtmlString.Create(ThisHtmlList); 
            }

            public MvcHtmlString CreateMenuBarItems(dynamic GenericList)
            {
                String ThisHtmlList = null;
                String CreateRawHtmlList;


                foreach (var Item in GenericList)
                {
                    ThisHtmlList = ThisHtmlList + ButtonMaker(Item, "MenuButtons");
                }


                CreateRawHtmlList = ThisHtmlList;

                return MvcHtmlString.Create(ThisHtmlList);
            }

        }
            
    }
}