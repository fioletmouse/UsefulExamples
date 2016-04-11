using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace UsefulExamples
{
    static class XDocument_Linq
    {
        public static void MainMethod()
        {
            XDocument doc = XDocument.Load("ProductSuppliers.xml");
            var filtered = from p in doc.Descendants("Product")
                           join s in doc.Descendants("Supplier")
                           on (int)p.Attribute("SupplierID")
                           equals (int)s.Attribute("SupplierID")
                           where (decimal)p.Attribute("Price") > 10
                           orderby (string)s.Attribute("Name"),
                           (string)p.Attribute("Name")
                           select new
                           {
                               SupplierName = (string)s.Attribute("Name"),
                               ProductName = (string)p.Attribute("Name")
                           };
            foreach (var v in filtered)
            {
                Console.WriteLine("Supplier={0}; Product={1}",
                v.SupplierName, v.ProductName);
            }
        }
    }
}
