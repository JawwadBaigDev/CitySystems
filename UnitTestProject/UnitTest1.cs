using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    /// <summary>
    /// Reruirements: 
    /// List of tax codes: NI, Wage, Salary, IncomeTax, Tax
    /// 1) We need to return Tax code found, when we search for tax code
    /// 2) We need to return "No Tax Code Found"
    /// 3) If we found two tax codes then add ! at the end of the tax code and concatenate
    /// </summary>

    public class TaxCodeFinder
    {
        List<string> listOfCodes = new List<string>();

        public string TaxCodeExists(List<string> listOfCodes)
        {
            StringBuilder stringToReturn = new StringBuilder(); 
            try
            {
                if (listOfCodes.Count <= 0)
                {
                    return "No Tax Code found";

                }
                else if (listOfCodes.Count != 0)
                {
                    foreach (var code in listOfCodes)
                    {
                        if (code.Contains("Tax"))
                        {
                            if(stringToReturn.Length == 0 )
                            {
                                stringToReturn.Append(code);
                                
                            } else
                            {
                                stringToReturn.AppendFormat("!{0}", code);
                            }
                        }
                    }
                }


            } catch(Exception ex)
            {
                return "Exception";
            }

            return stringToReturn.ToString();
        }

        // String Test Calculator
        public int CalculatorIntAddString(string numbers)
        {
            if(numbers.Length > 0)
            {
                var splitedNumbers = numbers.Trim().Split(',');
                int holdNumbers = 0;
                int outPutInt;
                foreach(var num in splitedNumbers)
                {
                    if(num != null && int.TryParse(num, out outPutInt))
                    {
                        if (holdNumbers == 0)
                        {
                            holdNumbers = int.Parse(num);
                        }
                        else
                        {
                            holdNumbers = holdNumbers + int.Parse(num);
                        }
                    }
                }
                return holdNumbers;
            }
            return 0;
        }

        public int test1 ()
        {
            // this is async test jawwad

            return 1;
        }



    }


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTaxCodesExist()
        {
            TaxCodeFinder taxCodeFinder = new TaxCodeFinder();
            List<string> listOfCodes = new List<string>();
            Assert.AreEqual(taxCodeFinder.TaxCodeExists(listOfCodes), "No Tax Code found");
        }

        [TestMethod]
        public void TestTaxCodesFundAndReturned()
        {
            TaxCodeFinder taxCodeFinder = new TaxCodeFinder();
            List<string> listOfCodes = new List<string>();
            listOfCodes.Add("Tax");
            Assert.AreEqual(taxCodeFinder.TaxCodeExists(listOfCodes), "Tax");
        }

        [TestMethod]
        public void TestTaxCodesFundAndMultipleReturned()
        {
            TaxCodeFinder taxCodeFinder = new TaxCodeFinder();
            List<string> listOfCodes = new List<string>();
            listOfCodes.Add("Tax");
            listOfCodes.Add("Income Tax");
            Assert.AreEqual(taxCodeFinder.TaxCodeExists(listOfCodes), "Tax!Income Tax");
        }


        // String Calculator tests
        
        [TestMethod]
        public void TestCalculatorIntAddStringReturnsZero()
        {
            TaxCodeFinder taxCodeFinder = new TaxCodeFinder();
            Assert.AreEqual(taxCodeFinder.CalculatorIntAddString(string.Empty), 0);
        }

        [TestMethod]
        public void TestCalculatorIntAddStringReturnSum()
        {
            TaxCodeFinder taxCodeFinder = new TaxCodeFinder();

            Assert.AreEqual(taxCodeFinder.CalculatorIntAddString("1,1"), 2);
            Assert.AreEqual(taxCodeFinder.CalculatorIntAddString("1,3"), 4);
            Assert.AreEqual(taxCodeFinder.CalculatorIntAddString("1"), 1);
            Assert.AreEqual(taxCodeFinder.CalculatorIntAddString("1,#"), 1);
        }

        
    }
}
