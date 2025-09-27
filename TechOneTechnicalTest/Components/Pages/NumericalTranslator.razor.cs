using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.CompilerServices;


namespace TechOneTechnicalTest.Components.Pages
{
    /// <summary>
    //Primary solution page for the Numerical Translator
    //Background: Within this page, the user can input a numerical value (up to the limits of a long integer)
    //and have it translated into English words representing the number, including support for decimal values (cents)
    //Within this code-behind file, two different algorithms are implemented for the translation:
    //The first one uses a brute-force iterative approach, handling each digit one at a time then traslating it into a string of words then combining them for the output
    //The second one uses an array to separate the number into segments of three digits, then processes each segment recursively to build the final string
    /// </summary>


    //My theory and approach for this problem is to break down the number into manageable parts, then translate each part into words.
    //My first approach was a brute-force iterative method, handling each digit one at a time but keeping track of the place value (units, tens, hundreds, thousands, etc.).
    //It took me the longest out of all to determine the method of reserving the last three digits, then moving on to the next three digits, and so on.
    //However, after much trial and errors with arrays and lists -- I was able to use a modulus to separate a workable digit segment of 3 digits at a time. Then remove the translated digits using division.
    //This was the most straightforward approach I could think of, and it worked well for the brute-force method. However, it took the longest to compute, as it had to handle each digit one at a time.
    //At longer numbers, the performance difference was noticeable. Taking 1.6 seconds on average. 
    //In addition, there are many ways to discern and separate the digits but configuring via modulus and division was the most straightforward. An alternative may be to convert the number into a string, then process each character via an array then separate my multiples from the right-side towards the left.

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

        //OnSubmit functions for both the brute-force and array solutions
        //Both functions can be accessed on the webpage via buttons -- one for each solution, kept for show-of-work and comparison

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