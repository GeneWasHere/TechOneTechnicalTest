using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.CompilerServices;


namespace TechOneTechnicalTest.Components.Pages
{
    public partial class NumericalTranslator
    {
        /// <summary>
        ///Properties for the HTML component; connected via @bind in the .razor file
        ///This file is the code-behind for NumericalTranslator.razor that was popped in via @inherits
        /// </summary>
        /// 
        /// <remarks>
        ///Output text to be displayed within an HTML element, when returned from the function -- should tell the razor to re-render
        ///For active rendering -- remember to call StateHasChanged() if nothing else is triggering a re-render in the Submit function
        ///Otherwise, re-rendering should be automatic when the function is called via a button click or similar event as long as @rendermode InteractiveServer is used
        /// </remarks>

        private string? OutputText { get; set; }

        //User input from an HTML input element, connected via @bind in the .razor file
        private string? UserInput { get; set; }

        public string ConversionAlgorithm(long inputnumber)
        {
            string output = "";
            //Arrays for number words
            string[] belowTwenty = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] thousands = { "", "Thousand", "Million", "Billion", "Trillion", "Quintillion", "Sextillion"};

            if (inputnumber == 0) return "Zero";
            if (inputnumber == long.MinValue) return "Input number is too small";
            if (inputnumber < 0) return "Negative " + ConversionAlgorithm(Math.Abs(inputnumber));

            //Build the output string
            if (inputnumber < 20) return output += belowTwenty[inputnumber];
            else if (inputnumber < 100) return output += tens[inputnumber / 10] + (inputnumber % 10 > 0 ? "-" + ConversionAlgorithm(inputnumber % 10) : "");
            else if (inputnumber < 1000) return output += belowTwenty[inputnumber / 100] + " Hundred" + (inputnumber % 100 > 0 ? " and " + ConversionAlgorithm(inputnumber % 100) : "");
            else
            {
                for (int i = 0; inputnumber > 0; i++, inputnumber /= 1000)
                {
                    long seg = inputnumber % 1000;
                    if (seg != 0)
                        output = $"{ConversionAlgorithm(seg)} {thousands[i]}".Trim() + (output == "" ? "" : " ") + output;
                }
            }
            //Dollars and cents are dealt with in the OnSubmit function, so just return the output here
            return output;
        }

        private void OnSubmit()
        {
            //Let OutputText be the same as UserInput for now
            OutputText = "";

            //Solution 1: Brute-Force approach submission for front-facing end
            try
            {
                if (string.IsNullOrWhiteSpace(UserInput)) OutputText = "Please enter a valid number."; else {
                    string[] separatedinput = UserInput.Split("."); long dollar = long.Parse(separatedinput[0]); 
                    if (separatedinput.Length == 2) OutputText = $"{ConversionAlgorithm(dollar)} Dollars and {ConversionAlgorithm((long)(int.Parse(separatedinput[1])))} Cents"; 
                    else OutputText = $"{ConversionAlgorithm(dollar)} Dollars"; 
                }
                
            }catch (Exception ex) {
            
                OutputText += ex.Message;
            }
        }

    }
}