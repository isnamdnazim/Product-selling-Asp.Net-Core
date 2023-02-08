using TestProject.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestProject.Data;
using TestProject.Models;
using TestProject.ViewModel;

namespace TestProject.Controllers
{
    public class SalesController : Controller
    {
        private readonly DataContext _context;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private IHttpContextAccessor _httpContextAccessor;
        public SalesController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public ActionResult Print(int? id)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ConstrName = "ApplicationServices";
            var ReportType = "PDF";
            

            var reportname = "rptSalesReport";
            HttpContext.Session.SetString("ReportPath", "~/Report/" + reportname + ".rdlc");
            HttpContext.Session.SetString("reportquery", "Exec [rptSalesInfo] '" + id + "'");

            string filename = _context.Sales.Where(x => x.SaleID == id).Single().SaleID.ToString();
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            string DataSourceName = "DataSet1";
            HttpContext.Session.SetObject("rptList", postData);

            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("reportquery");
            clsReport.strDSNMain = DataSourceName;


            SqlCmd = clsReport.strQueryMain;
            ReportPath = clsReport.strReportPathMain;
            ReportType = "PDF";

            //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); // this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType);
            string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = ReportType });
            return Redirect(callBackUrl);

        }


        public IActionResult Salesindex()
        {

            var salesin = _context.Sales.ToList();
            var viewmodel = new List<CustomerVM>();
            var model = new CustomerVM();

            for (int i = 0; i < salesin.Count(); i++)
            {
                if (salesin[i].CustID == 0)
                {
                    var item = new CustomerVM
                    {
                        SaleID = salesin[i].SaleID,
                        Date = salesin[i].Date,
                        TotalAmount = salesin[i].TotalAmount,
                        CustomerName = "None"
                    };
                    viewmodel.Add(item);
                }
                else
                {
                    var customer = _context.CustomerInfos.Where(x => x.CustomerID == salesin[i].CustID).FirstOrDefault();
                    var item = new CustomerVM
                    {
                        SaleID = salesin[i].SaleID,
                        Date = salesin[i].Date,
                        TotalAmount = salesin[i].TotalAmount,
                        CustomerName = customer.CustomerName + " - " + customer.CustomarPhn
                    };
                    viewmodel.Add(item);
                }


            }
            return View(viewmodel);
        }


        public IActionResult Sales()
        {

            //IEnumerable<SelectListItem> pro = from Product in _context.Products.ToList()

            IEnumerable<SelectListItem> pro = from Product in _context.Products.Where(x => x.RemainingQty > 0).ToList()
                                              select new SelectListItem
                                              {
                                                  Value = Product.Id.ToString(),
                                                  Text = Product.ProductCode + "_" + Product.ProductTittle
                                              };


            IEnumerable<SelectListItem> cus = from Customer in _context.CustomerInfos.ToList()
                                              select new SelectListItem
                                              {
                                                  Value = Customer.CustomerID.ToString(),
                                                  Text = Customer.CustomarPhn + "_" + Customer.CustomerName
                                              };
            ViewBag.cs = cus;
            ViewBag.pr = pro;
            return View();
        }



        public IActionResult Salesdetails(int id)
        {

            var salesdetails = (from sal in _context.Sales.Where(x => x.SaleID == id).ToList()
                                join prosel in _context.SalesProducts
                                on sal.SaleID equals prosel.SaleID
                                join product in _context.Products
                                on prosel.ProductID equals product.Id
                                select new CustomerVM
                                {
                                    SaleID = sal.SaleID,
                                    SalesProID = prosel.SalesProID,
                                    Date = sal.Date,
                                    Amount = prosel.Amount,
                                    ProductTittle = product.ProductTittle,
                                    OrderQty = prosel.OrderQty,
                                    PDiscount = prosel.PDiscount,
                                    Pvat = prosel.Pvat,

                                }).ToList();
            return View(salesdetails);

        }

        [HttpPost]
        public JsonResult CustomerCreate(CustomerVM data)
        {
            CustomerInfo customer = new CustomerInfo
            {
                CustomerID = 0,
                CustomerName = data.CustomerName,
                CustomarAddress = data.CustomarAddress,
                CustomarPhn = data.CustomarPhn,
                CustomerArea = data.CustomerArea,
                CustomerEmail = data.CustomerEmail
            };
            _context.CustomerInfos.Add(customer);
            _context.SaveChanges();
            var allcus = _context.CustomerInfos.OrderByDescending(x => x.CustomerID).ToList();
            return Json(allcus);
        }



        public JsonResult SalesCreate(CustomerVM data)
        {
            try
            {
                var sales = new Sales()
                {

                    CustID = data.CustID,
                    Date = DateTime.UtcNow.AddHours(6),
                    SubTotalAmount = data.SubTotalAmount,
                    TotalAmount = data.TotalAmount,
                    Discount = data.Discount,
                    CashAmount = data.CashAmount,
                    CardAmount = data.CardAmount,
                    MobilebankingAmount = data.MobilebankingAmount,
                    GiftAmount = data.GiftAmount,
                    Vat = data.Vat,

                };
                _context.Add(sales);
                _context.SaveChanges();

                foreach (var item in data.selsp)
                {
                    var proqty = _context.Products.Where(x => x.Id == item.ProductID).FirstOrDefault();
                    proqty.RemainingQty = proqty.RemainingQty - item.OrderQty;
                    _context.Update(proqty);
                    _context.SaveChanges();


                    var salep = new SalesProduct()
                    {
                        SaleID = sales.SaleID,
                        ProductID = item.ProductID,
                        OrderQty = item.OrderQty,
                        UnitPrice = item.UnitPrice,
                        Amount = item.Amount,
                        Pvat = item.Pvat,
                        PDiscount = item.PDiscount,
                        Returnable = false,
                    };
                    _context.Add(salep);
                    _context.SaveChanges();


                }


                return Json(sales.SaleID);
            }
            catch
            {
                return Json(0);
            }

        }

        public JsonResult GetProductName(int proname)
        {
            var p = _context.Products.Where(x => x.Id == proname).FirstOrDefault();
            return Json(p);
        }
        public JsonResult GetAmount(int name, int Quantity)
        {
            var p = _context.Products.Where(x => x.Id == name).FirstOrDefault().SalesPrice;
            var amnt = (Quantity * p);

            return Json(amnt);
        }
    }
}
