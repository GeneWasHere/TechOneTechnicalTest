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
            //If the number was negative, prepend "Negative"
            if (isnegative == true)
            {
                OutputText = "Negative " + OutputText;
            }
            return OutputText.TrimEnd(' ');
        }

        //Array and List approach, breaking the number into segments of three digits via modulus and division
        //Each segment of a maximum of three digits is added to an array, then processed individually, then added a list, reversed (as order is reversed for translation), then combined into a single string
        public string ArrayTranslatorAlgorithm(long numerical)
        {
            //Output string and Declarables
            string OutputText = "";
            bool isnegative = false;

            //Outline all values, digits, tens, hundreds, thousands, etc.
            string[] digits = ["One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"];
            string[] teens = ["Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"];
            string[] tens = ["Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];
            string[] thousands = ["Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion"];

            //Create an array to hold segments of three digits
            long[] segments = new long[7]; //Supports up to Sextillion
            //Tracks the number of segments, 1 segment means hundreds, 2 means thousands, 3 means millions, etc. 
            //If the segment count is 0, it means the number is maximum 999 -- 2 segments means maximum 999,999 -- 3 segments means maximum 999,999,999, etc.
            int segmentCount = 0;
            //List to hold the translated segments. Combined at the end.
            List<string> segments_translated = new List<string> { };

            //Preliminary checks; zero and negatives are checked before segmenting
            if (numerical == 0)
            {
                return "Zero";
            }
            //Check if the numerical is negative, in which case, set a flag and convert to positive
            //This is to simplify the translation process, as negative numbers are simply "Negative" + positive number in words
            //This struggles with the lowest possible long value, as it cannot be represented as a positive number
            if (numerical < 0)
            {
                isnegative = true;
                //Handling of long negatives which cannot be represented as positive
                if (numerical != long.MinValue)
                {
                    try
                    {
                        //Convert to positive for easier processing
                        numerical = Math.Abs(numerical);
                    }
                    catch (OverflowException)
                    {
                        //If the number is negative and cannot be represented as positive, return an error
                        return "Error: Number is at the lowest possible number of long, an unrealistic input";
                    }
                }
                //This section is to catch the long.MinValue case, which cannot be converted to positive
                else
                {
                    //Leave it as is, and handle the negative sign later
                    //Convert the long.MinValue to long.MaxValue + 1
                    if (numerical == long.MinValue)
                    {
                        numerical = long.MaxValue;
                    }
                }
            }

            //Separate the number into segments of three digits
            while (numerical > 0)
            {
                //Get the last three digits using modulus
                segments[segmentCount] = numerical % 1000;
                numerical /= 1000;
                //Increment the segment count
                segmentCount++;
            }

            //Given each segment, translate them by building the string via the outlined digits, tens, hundreds, thousands, etc.
            for (int i = 0; i < segmentCount; i++)
            {
                //Depending on the location of the segment, append thousands, millions, etc.
                //For example, if the number of segments is 2, the first segment is thousands, 3 is millions, etc. 
                long segment = segments[i];
                //If the segment is 0 or empty, it is skipped
                if (segment == 0)
                {
                    OutputText += "";
                }
                else if (segment > 0 ) //Else, keep translating into words
                {
                    //Current segment string to be built -- once built, it is added to the list of segments_translated
                    string currentsegment = "";
                    //Handle hundreds place
                    if (segment >= 100)
                    {
                        currentsegment += digits[(segment / 100) - 1] + " Hundred ";
                        segment %= 100;
                        //Hundred exception for "and"
                        if (segment > 0 && segmentCount == 1)
                        {
                            currentsegment += "and ";
                        }
                    }
                    //Handle tens and units place
                    if (segment >= 20)
                    {
                        //If divisible by 10, no hyphen
                        //Hyphenation is used for numbers like Twenty-One, Thirty-Four, etc. as per example output provided
                        if (segment % 10 == 0)
                        {
                            currentsegment += tens[(segment / 10) - 1] + " ";
                            segment = 0;
                        }
                        else
                        {
                            currentsegment += tens[(segment / 10) - 1] + "-";
                            segment %= 10;
                        }
                    }
                    //Handles the teens
                    else if (segment >= 11 && segment <= 19)
                    {
                        currentsegment += teens[segment - 11] + " ";
                        segment = 0;
                    }
                    //Handles the ten
                    else if (segment == 10)
                    {
                        currentsegment += tens[0] + " ";
                        segment = 0;
                    }
                    //Handles the units place
                    if (segment > 0 && segment <= 9)
                    {
                        currentsegment += digits[segment - 1] + " ";
                    }
                    //Handles the thousands, millions, and etc
                    if (i > 0)
                    {
                        currentsegment += thousands[i - 1] + " ";
                    }
                    segments_translated.Add(currentsegment.TrimEnd(' '));
                }
            }
            //Add "Negative" if the number was negative
            if (isnegative == true)
            {
                segments_translated.Add("Negative");
            }
            //Combine all results for each segment, because of how segments are stored, they need to be reversed first before combining
            //This is because the first segment is the least significant (units), then thousands, millions, etc.
            segments_translated.Reverse();
            OutputText = string.Join(" ", segments_translated);
            return OutputText;
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
                    int cents = int.Parse(separatedinput[1]);
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

        private void OnSubmit_ArraySolution()
        {
            //Let OutputText be the same as UserInput for now
            OutputText = "";

            //Solution 2: Array and List approach submission for front-facing end
            //This function is similar to the brute-force submission, but calls the ArrayTranslatorAlgorithm instead
            try
            {

                string[] separatedinput = UserInput.Split(".");
                long dollar = long.Parse(separatedinput[0]);

                //Check if dollar or cents are in the negatives
                //if (dollar < 0 || (1 < separatedinput.Length && int.Parse(separatedinput[1]) < 0))
                //{
                //    OutputText = "Error: Negative numbers are not allowed.";
                //    return;
                //}

                if (1 < separatedinput.Length)
                {
                    int cents = int.Parse(separatedinput[1]);
                    //Accounting for cent plurality
                    if (cents == 1)
                    {
                        OutputText = $"{ArrayTranslatorAlgorithm(dollar)} Dollars and {ArrayTranslatorAlgorithm((long)(cents))} Cent";
                    }
                    else
                    {
                        OutputText = $"{ArrayTranslatorAlgorithm(dollar)} Dollars and {ArrayTranslatorAlgorithm((long)(cents))} Cents";
                    }
                }
                else
                {
                    //Full dollars and no cents
                    OutputText = $"{ArrayTranslatorAlgorithm(dollar)} Dollars";
                }
            }
            catch (Exception ex)
            {
                OutputText += ex.Message;
            }
        }
    }
}