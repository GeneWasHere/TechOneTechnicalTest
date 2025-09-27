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


        //1st Initial Solution: Brute-Force approach (Iterative)
        //The intention of this function is to handle each digit one at a time, building the string as it goes
        //This function is iterative and handles each digit in a loop
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
            }
            return OutputText.TrimEnd(' ');
        }

        //OnSubmit functions for both the brute-force and array solutions
        //Both functions can be accessed on the webpage via buttons -- one for each solution, kept for show-of-work and comparison

        private void OnSubmit_BruteForce()
        {
            //Let OutputText be the same as UserInput for now
            OutputText = "";

            //Solution 1: Brute-Force approach submission for front-facing end
            try
            {
                string[] separatedinput = UserInput.Split(".");
                long dollar = long.Parse(separatedinput[0]);

                //If there are cents to process, process them with the same function
                if (1 < separatedinput.Length)
                {
                    //Accounting for cent plurality
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