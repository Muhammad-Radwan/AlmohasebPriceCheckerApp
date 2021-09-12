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

    //    (from p in DBContext.TBL007
    //                          join cu in DBContext.TBL128 on p.CardGuide equals cu.MainGuide into ntb
    //                          from sub in ntb.DefaultIfEmpty()
    //                          where p.Barcode.Contains(Barcode) || sub.Barcode.Contains(Barcode)
    //                          select new
    //                          {
    //                              p.ProductName,
    //                              p.Barcode,
    //                              p.EndUserPrice,
    //                              p.Unit
    //});
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
