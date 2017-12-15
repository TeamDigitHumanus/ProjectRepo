using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DigitCashier
{
    //public class ReadFile
    //{
    //    public static string[] prdArray;
    //    public static void Hope()
    //    {
    //        prdArray = File.ReadAllLines(@"C:\Users\Giannis\Documents\digitcashierproj\products.txt");
    //        foreach (string line in prdArray)
    //        {
    //            prdArray = line.Split(',');
    //        }
    //    }
    //}
    //public class ReadToArray
    //{
    //    public static void Read()
    //    {
    //        // Read the lines of a file into a list of strings
    //        string[] prdArray;
    //        var lines = ReadFile(@"C: \Users\Giannis\Documents\digitcashierproj\products.txt");
    //        foreach (string line in lines)
    //        {
    //            prdArray = CreateArray(line);
    //        }
    //    }
    //    static List<string> ReadFile(string fileName)
    //    {
    //        var lines = new List<string>();
    //        using (var file = new StreamReader(fileName))
    //        {
    //            string line = string.Empty;
    //            while ((line = file.ReadLine()) != null)
    //            {
    //                lines.Add(line); 
    //            }
    //        }
    //        return lines;
    //    }
    //    // Create an array of string elements from a comma separated file
    //    static string[] CreateArray(string line)
    //    {
    //        return line.Split(',');
    //    }
    //}

    //public class Product
    //{
    //    public int productID;
    //    public string productName;
    //    public float productPrice;
    //    public string productCurrency;

    //    public void Reading()
    //    {
    //        //Reading from txt file and copying to an array
    //        List<Product> prd = new List<Product>();
    //        using (StreamReader sr = new StreamReader(@"C:\Users\Giannis\Documents\digitcashierproj\products.txt"))
    //        {
    //            while (sr.Peek() >= 0)
    //            {
    //                string str;
    //                string[] prdArray;
    //                str = sr.ReadLine();
    //                prdArray = str.Split(',');
    //                Product currentPrd = new Product();
    //                currentPrd.productID = int.Parse(prdArray[0]);
    //                currentPrd.productName = prdArray[1];
    //                currentPrd.productPrice = float.Parse(prdArray[2]);
    //                currentPrd.productCurrency = prdArray[3];
    //                prd.Add(currentPrd);
    //            }
    //        }
    //    }
    //}
}

