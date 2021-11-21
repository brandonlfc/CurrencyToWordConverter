using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersToEnglish
{
    public class CurrencyToEnglish
    {

        public static String ones(String number)
        {
            //Converts the value of the specified 32-bit unsigned integer to an equivalent 32-bit signed integer
            int iNumber = Convert.ToInt32(number);

            //Used for assigning the user input to the corresponding characters
            String sNumber = "";

            switch(iNumber)
            {
                case 1:
                    sNumber = "One";
                    break;
                case 2:
                    sNumber = "Two";
                    break;
                case 3:
                    sNumber = "Three";
                    break;
                case 4:
                    sNumber = "Four";
                    break;
                case 5:
                    sNumber = "Five";
                    break;
                case 6:
                    sNumber = "Six";
                    break;
                case 7:
                    sNumber = "Seven";
                    break;
                case 8:
                    sNumber = "Eight";
                    break;
                case 9:
                    sNumber = "Nine";
                    break;
            }
            return sNumber;
        }

        private static String tens(String Number)
        {
            int iNumber = Convert.ToInt32(Number);
            String sNumber = null;
            switch (iNumber)
            {
                case 10:
                    sNumber = "Ten";
                    break;
                case 11:
                    sNumber = "Eleven";
                    break;
                case 12:
                    sNumber = "Twelve";
                    break;
                case 13:
                    sNumber = "Thirteen";
                    break;
                case 14:
                    sNumber = "Fourteen";
                    break;
                case 15:
                    sNumber = "Fifteen";
                    break;
                case 16:
                    sNumber = "Sixteen";
                    break;
                case 17:
                    sNumber = "Seventeen";
                    break;
                case 18:
                    sNumber = "Eighteen";
                    break;
                case 19:
                    sNumber = "Nineteen";
                    break;
                case 20:
                    sNumber = "Twenty";
                    break;
                case 30:
                    sNumber = "Thirty";
                    break;
                case 40:
                    sNumber = "Fourty";
                    break;
                case 50:
                    sNumber = "Fifty";
                    break;
                case 60:
                    sNumber = "Sixty";
                    break;
                case 70:
                    sNumber = "Seventy";
                    break;
                case 80:
                    sNumber = "Eighty";
                    break;
                case 90:
                    sNumber = "Ninety";
                    break;
                default:

                    //By default will check if the user input is greater than 0 which will then run through the switch statements
                    if (iNumber > 0)
                    {
                        sNumber = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return sNumber;
        }

        public static String ConvertNum(String Number)
        {
            string word = "";
            try
            {
                bool conDone = false;//test if already number has already been converted    
                double dblAmt = (Convert.ToDouble(Number));

                if (dblAmt > 0 && !dblAmt.ToString().Contains("."))
                {
                    int iDigits = Number.Length;
                    int pos = 0;//digit grouping    
                    String place = "";//digit grouping names   
                    switch (iDigits)
                    {
                        case 1://ones 

                            word = ones(Number);
                            conDone = true;
                            break;
                        case 2://tens   
                            word = tens(Number);
                            conDone = true;
                            break;
                        case 3://hundreds  
                            pos = (iDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands   
                        case 5:
                        case 6:
                            pos = (iDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        default:
                            conDone = true;
                            break;
                    }

                    if (!conDone)
                    {//if conversion is not done, process continues
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertNum(Number.Substring(0, pos)) + place + ConvertNum(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertNum(Number.Substring(0, pos)) + ConvertNum(Number.Substring(pos));
                        }

                    }
                    //ignore grouping names    
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        public static String ToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "", dolStr = "", endStr = "";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";//separate numbers from points/cents    
                        endStr = "Cents ";//Cents
                        dolStr = "Dollars";
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1} {2}{3} {4}", ConvertNum(wholeNo).Trim(),dolStr ,andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }

        private static String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                if (Int32.Parse(digit) < 10)
                {
                    engOne = ones(digit);
                }
                if (Int32.Parse(digit) > 10 && Int32.Parse(digit) < 19)
                {
                    engOne = tens(digit);
                }
                //else
                //{
                //    engOne = ones(digit);
                //}
                cd += " " + engOne;
            }
            return cd;
        }

        static void Main(string[] args)
        {
            string isNegative = "";
            try
            {
                Console.WriteLine("Enter a Number to convert to currency");
                string number = Console.ReadLine();
                number = Convert.ToDouble(number).ToString();

                if (number.Contains("-"))
                {
                    isNegative = "Minus ";
                    number = number.Substring(1, number.Length - 1);
                }
                if (number == "0")
                {
                    Console.WriteLine("The number in currency fomat is \nZero");
                }
                else
                {
                    Console.WriteLine("The number in currency fomat is \n{0}", isNegative + ToWords(number));
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
