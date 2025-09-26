using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TechOneTechnicalTest.Components.Pages
{
    //Primary solution page for the Numerical Translator
    public partial class NumericalTranslator
    {
 
        private string? OutputText { get; set; }
        private string? UserInput { get; set; }

        public string BruteTranslatorAlgorithm(long numerical)
        {
            string OutputText = "";
            int thousandCounter = 0;
            bool isHundredAnd = false;
            bool isnegative = false;
            //Check if the numerical is negative
            if (numerical < 0)
            {
                isnegative = true;
                //Handling of long negatives which cannot be represented as positive
                try
                {
                    numerical = Math.Abs(numerical);
                }
                catch (OverflowException)
                {
                    //If the number is negative and cannot be represented as positive, return an error
                    return "Error: Number is at the lowest possible numer of long, an unrealistic input";

                }
            }
            //Hundreds are treated as a special case, including "and"
            if (numerical < 1000 && numerical >= 100)
            {
                isHundredAnd = true;
            }
            //Get all the numbers in words
            string[] digits = ["One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"];
            string[] teens = ["Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"];
            string[] tens = ["Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];
            string[] thousands = ["Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion"];
            while (numerical > 0)
            {
                //Get the last three digits
                long lastThree = numerical % 1000;
                numerical /= 1000;
                if (lastThree > 0)
                {
                    string segment = "";
                    //Handle hundreds place
                    if (lastThree >= 100)
                    {

                        //If the number is not higher than a thousand and has a hundreds place, add "and"

                        segment += digits[(lastThree / 100) - 1] + " Hundred ";
                        lastThree %= 100;

                        if (isHundredAnd && lastThree > 0)
                        {
                            segment += "and ";
                        }

                    }
                    //Handle tens and units place
                    
                    if (lastThree >= 20)
                    {
                        //If divisible by 10, no hyphen
                        if (lastThree % 10 == 0)
                        {
                            segment += tens[(lastThree / 10) - 1] + " ";
                            lastThree = 0;
                        }
                        else
                        {
                            segment += tens[(lastThree / 10) - 1] + "-";
                            lastThree %= 10;
                        }
                    }
                    //Handles the teens
                    else if (lastThree >= 11 && lastThree <= 19)
                    {
                        segment += teens[lastThree - 11] + " ";
                        lastThree = 0;
                    }
                    //Handles the ten
                    else if (lastThree == 10)
                    {
                        segment += tens[0] + " ";
                        lastThree = 0;
                    }
                    //Handles the units place
                    if (lastThree > 0 && lastThree <= 9)
                    {
                        segment += digits[lastThree - 1] + " ";
                    }
                    //Append the thousands, millions, etc. place
                    if (thousandCounter > 0)
                    {
                        segment += thousands[thousandCounter - 1] + " ";
                    }
                    OutputText = segment + OutputText;
                }
                thousandCounter++;
            }
            //Handle negative numbers and Edge Cases
            if (OutputText == "")
            {
                OutputText = "Zero ";
            }
            //If the number was negative, prepend "Negative"
            if (isnegative == true)
            {
                OutputText = "Negative " + OutputText;
            }
            return OutputText.TrimEnd(' ');
        }
        
        private void OnSubmit()
        {
            //Let OutputText be the same as UserInput for now
            OutputText = "";

            //Solution 1: Brute-Force approach (Iterative)
            double number;
            try
            {

                string[] separatedinput = UserInput.Split(".");
                long dollar = long.Parse(separatedinput[0]);

                //Check if dollar or cents are in the negatives
                if (dollar < 0 || (1 < separatedinput.Length && int.Parse(separatedinput[1]) < 0))
                {
                    OutputText = "Error: Negative numbers are not allowed.";
                    return;
                }

                if (1 < separatedinput.Length)
                {
                    int cents = int.Parse(separatedinput[1]);
                    //Accounting for 1 cent
                    if (cents == 1)
                    {
                        OutputText = $"{BruteTranslatorAlgorithm(dollar)} Dollars and {BruteTranslatorAlgorithm((long)(cents))} Cent";
                    }
                    else
                    {
                        OutputText = $"{BruteTranslatorAlgorithm(dollar)} Dollars and {BruteTranslatorAlgorithm((long)(cents))} Cents";
                    }
                }
                else
                {
                    //Full dollars and no cents
                    OutputText = $"{BruteTranslatorAlgorithm(dollar)} Dollars";
                }




            }catch (Exception ex) {
            
                OutputText += ex.Message;
            }
        }


    }
}