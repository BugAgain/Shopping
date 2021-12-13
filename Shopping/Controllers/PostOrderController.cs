using Shopping.Data;
using Shopping.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Shopping.Controllers
{
    public class PostOrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public PostOrderController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: PostOrder

        //[Throttle(Name = "ThrottleDemo",
        //    Message = "You must wait {n} seconds before accessing this url again.", Seconds = 15)]
        //[IpAuth]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProcessPayment()
        {
            #region Real implementation logic
            //using (LKEntities db = new LKEntities())
            //{
            //    int orderID = Convert.ToInt32(Session["OrderID"].ToString());
            //    var customerBillingDetails = db.tbl_OrderBillingDetails.FirstOrDefault(x => x.OrderID == orderID);
            //    if (customerBillingDetails != null)
            //    {
            //        tbl_OrderMaster objOrder = db.tbl_OrderMaster.OrderByDescending(f => f.OrderDate).FirstOrDefault(x => x.ID == orderID);

            //        var cartDetails = getCartDetails(true);
            //        var status = PostRequest(cartDetails, customerBillingDetails);
            //        if (status == "Success")
            //            return Redirect("/paymentprocessing");
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }

            //}
            //return RedirectToAction("Index", "Home"); 
            #endregion

            //var id = HttpContext.Session.GetInt32("");
            //int orderID = Convert.ToInt32("0"); // Not a problem when null

            var customerBillingDetails = "";
            if (customerBillingDetails != null)
            {
                var status = PostRequest();
                if (status == "Success")
                    return Redirect("/Products");
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        private string PostRequest()
        {
            //throw new NotImplementedException("Fake error!");

            context.Products.Add(new Models.Product()
            {
                Name = "Poduct test",
                ImagePath = "01.jpg",
                Price = 5,
                Color = Models.Color.Red,
                Description = "web scrapping attack simulation"
            });

            context.SaveChanges();

            return "Success";
        }
    }
}
