using System;
using System.IO;
using System.Web;
using System.Web.Mvc;


namespace Account.Helpers
{
    public class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                   ModelBindingContext bindingContext)
        {
            object temp = null;
            return temp;

            //HttpRequestBase request = controllerContext.HttpContext.Request;
            //HttpFileCollectionBase file = request.Files;

            //string base64 = GetByteArrayString(file.Get(0));
            //string contentType = file.Get(0).ContentType;

            //string title = request.Form.Get("Title");
            //string day = request.Form.Get("Day");
            //string month = request.Form.Get("Month");
            //string year = request.Form.Get("Year");

            //return new DefaultModel
            //{
            //    Name = title,
            //    Date = day + "/" + month + "/" + year
            //};
        }
        
        
        
        private string GetByteArrayString(HttpPostedFileBase file)
        {
            byte[] data;

            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                data = binaryReader.ReadBytes(file.ContentLength);
                return Convert.ToBase64String(data);
            }
        }
    }
}