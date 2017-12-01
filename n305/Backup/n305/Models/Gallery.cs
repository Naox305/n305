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
    public class Gallery
    {

        public class ItemsAndURLs
        {
            public String Name { get; set; }
            public String ImageURL { get; set; }
            public String ItemURL { get; set; }
            public String Description { get; set; }
            public int Value { get; set; }
        }

        public class MyItems
        {

            public ICollection<ItemsAndURLs> GetItemList()
            {
                List<ItemsAndURLs> TempList = new List<ItemsAndURLs>();
                if (TempList.Count == 0)
                {
               
                    var LabURL = "http://angularjsdemo1.azurewebsites.net/";

                    TempList.Add(new ItemsAndURLs()
                    {
                        Name = "Noonian Soong" + "\r" + "or" + "\r" + "Khan Noonien Singh",
                        ImageURL = "~/Content/LabScreenshot.jpg",
                        ItemURL = LabURL,
                        Value = 1,
                        Description = "Experimentation"
                    });

                    TempList.Add(new ItemsAndURLs() { Name = "SkyNotes 305", ImageURL = "~/Content/SkyNotes305ScreenShot.jpg",
                                                      ItemURL = "http://apps.microsoft.com/windows/en-us/app/sky-notes-305/df2a6fc0-f572-4fbb-a442-afed6da5d7a4",
                                                      Value = 2,
                                                      Description = "Sky Notes 305"
                    });

                    TempList.Add(new ItemsAndURLs() { Name = "NotePad 305", ImageURL = "~/Content/NotePad305ScreenShot.jpg", 
                                                      ItemURL = "http://apps.microsoft.com/windows/en-us/app/notepad-305/0abf6c54-4247-4972-82ee-9d3b687fad3f", 
                                                      Value = 3,
                                                      Description = "NotePad 305"
                    });

                    TempList.Add(new ItemsAndURLs() { Name = "CutPaste", ImageURL = "~/Content/CutPasteScreenShot.jpg", 
                                                      ItemURL = "http://apps.microsoft.com/windows/en-us/app/cutpaste/2e238216-17c3-4ad6-a705-501ee48fad23", 
                                                      Value = 4,
                                                      Description = "CutPaste"
                    });

                     TempList.Add(new ItemsAndURLs() { Name = "MVC Theme", ImageURL = "~/Content/MvcThemeScreenshot.jpg",
                                                       ItemURL = "http://template1n305.azurewebsites.net/",
                                                       Value = 5,
                                                       Description = "MVC Theme"
                     });

                    TempList.Add(new ItemsAndURLs() { Name = "Medium", ImageURL = "~/Content/MediumScreenshot.jpg",
                                                      ItemURL = "https://medium.com/@Naox305",
                                                      Value = 6,
                                                      Description = "Medium Articles"
                    });

                
                    return TempList;
                }
                else
                    return TempList;
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
            

            private String GalleryItemMaker(n305.Models.Gallery.ItemsAndURLs Value, String ItemClass, String ImageClass, String DescriptionClass)
            {
                UrlHelper NewUrlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                
                var ThisName = Value.Name;
                var ThisItemUrl = Value.ItemURL;

                var ThisImageUrl = VirtualPathUtility.ToAbsolute(Value.ImageURL);

                var ThisUrl = Value.ItemURL;
                var ThisDescription = Value.Description;
                String GotoUrl = null;
                
                if (ThisUrl.Contains(".") == false)

                    GotoUrl = NewUrlHelper.Action(ThisUrl);
                else
                    GotoUrl = ThisUrl;
                //=========================================================================================================//
                var ThisItemImage = "<input type=" +
                    "\"image\"" + "src=" +
                    "\"" + ThisImageUrl + "\"" +
                 "class=" + "\"" + ImageClass + "\"" +
                 "title=" + "\"" + ThisName + "\"" +
                 "value=" + "\"" + ThisName + "\""
                 +

                  ">";

                var ThisItemDescription = "<input type=" +
                    "\"text\"" + " class=" + DescriptionClass + " readonly " + "value=" + "\"" + ThisDescription + "\"" + "maxLength=" + "1000" + ">";

                var ThisItem = "<button class=" + ItemClass +" "+ "onclick=" + "\"" + "location.href=" + "'" + GotoUrl + "'" + "\"" + ">" + "<div>" + ThisItemImage + ThisItemDescription + "</div>" + "</button>"; 
                return ThisItem;
            }

            public MvcHtmlString CreateItemsForGallery(dynamic GenericList, String ItemClass, String ImageClass, String DescriptionClass)
            {
                String ThisHtmlList = null;
                String CreateRawHtmlList;


                foreach (var Item in GenericList)
                {
                    ThisHtmlList = ThisHtmlList + GalleryItemMaker(Item, ItemClass, ImageClass, DescriptionClass);
                }


                CreateRawHtmlList = ThisHtmlList;

                return MvcHtmlString.Create(ThisHtmlList);
            }
        }
            
    }
}
