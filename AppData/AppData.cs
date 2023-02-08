namespace TestProject.AppData
{
    public static class AppData
    {
        public static string DefaultImage = "/Images/default.png";
        public static string DefaultPath = "/Images/";


        public static int NotifyDefaultQuantity = 10;

        public static string intComId = "4"; //(HttpContext.Current.Session["comid"].ToString())
        public static string userid = "";//(HttpContext.Current.HttpContext.Session.GetString("userid"))

        //public static string dbGTCommercial = "GTRCOMMERCIAL_FOURH";
        public static string dbGTCommercial = "GTERP_DAP";
        public static string dbdaperpconstring = "Data Source=NAZIM;" +
                                                  "Initial Catalog=TestProject;" +
                                                  "Integrated Security=SSPI;";
        public static string globalException = "";


        public static string AppPath = "";
        public static string RefNo = "";
        public static string Percentage = "";

        public static string PrintDate = "";
        public static string TruckNo = "";
        public static string DriverName = "";
        public static string DriverMobileNo = "";

        public static int intHasSubReport = 0;

        //public static object AppData { get; internal set; }

        //public static object AppData { get; internal set; }



        //public static int comid = int.Parse(HttpContext.Current.Session["comid"].ToString());
        //public static int userid = int.Parse(HttpContext.Current.HttpContext.Session.GetString("userid"));



        //Object[] myParam1 = new Object[2];
        //myParam1[0] = "blah";
        //myParam1[1] = "blah blah"; 

    }
    public class AppVar
    {
        public string StoreProcedureExecutionError { get; set; }
    }

    //public static DataTable ToDataTable<T>(this IList<T> data)
    //{
    //    PropertyDescriptorCollection properties =
    //        TypeDescriptor.GetProperties(typeof(T));
    //    DataTable table = new DataTable();
    //    foreach (PropertyDescriptor prop in properties)
    //        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
    //    foreach (T item in data)
    //    {
    //        DataRow row = table.NewRow();
    //        foreach (PropertyDescriptor prop in properties)
    //            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
    //        table.Rows.Add(row);
    //    }
    //    return table;
    //}
}
