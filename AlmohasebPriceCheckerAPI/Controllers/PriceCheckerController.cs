using AlmohasebDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlmohasebPriceCheckerAPI.Controllers
{
    public class PriceCheckerController : ApiController
    {

        public IHttpActionResult GetPriceByBarcode(string Barcode)
        {
            using (AlmohasebSQLEntities cc = new AlmohasebSQLEntities())
            {
                var Data = from data in cc.The_Items
                           join itemDetails in cc.The_ItemDetails on data.Item_No equals itemDetails.Item_No
                           join barcode in cc.The_Barcode on data.Item_No equals barcode.Item_No
                           where barcode.Barcode == Barcode 
                           select new
                           {
                               data.Scientific_Name,
                               itemDetails.price,
                           };
                return Ok(Data.ToList());
            }
        }

    }
}
