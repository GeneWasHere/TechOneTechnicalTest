using Microsoft.AspNetCore.Components;
using System;
using System.Globalization;

namespace TechOneTechnicalTest.Components.Pages
{
    /// <summary>
    /// Represents the code-behind logic for the NumericalTranslator.razor component.
    /// This class handles user input and invokes conversion logic to transform numeric values into words.
    /// </summary>
    public partial class NumericalTranslator : ComponentBase
    {
        /// <summary>
        /// Gets or sets the numeric input value entered by the user via the UI.
        /// This value is bound to the HTML input field.
        /// </summary>
        private string? UserInput { get; set; }

        /// <summary>
        /// Gets or sets the output text result displayed in the UI after conversion.
        /// </summary>
        private string? OutputText { get; set; }

        /// <summary>
        /// Handles the submission event from the user interface.
        /// Parses the user input, converts it to words, and updates the <see cref="OutputText"/>.
        /// </summary>
        private void OnSubmit()
        {
            OutputText = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(UserInput))
                {
                    OutputText = "Please enter a valid number.";
                    return;
                }

                string[] parts = UserInput.Split('.');

                if (!long.TryParse(parts[0], out long dollars))
                {
                    OutputText = "Invalid dollar amount.";
                    return;
                }

                var converter = new NumberToWordsConverter();
                string result = $"{converter.ConvertNumbers(dollars)} Dollars";

                if (parts.Length == 2 && int.TryParse(parts[1], out int cents))
                {
                    result += $" and {converter.ConvertNumbers(cents)} Cents";
                }

                OutputText = result;
            }
            catch (Exception ex)
            {
                OutputText = $"Error: {ex.Message}";
            }
        }
    }

    /// <summary>
    /// Provides functionality for converting numeric values into their English word representation.
    /// </summary>
    public class NumberToWordsConverter
    {
        private readonly string[] _belowTwenty =
        {
            "", "One", "Two", "Three", "Four", "Five", "Six", "Seven",
            "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
            "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private readonly string[] _tens =
        {
            "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        private readonly string[] _thousands =
        {
            "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion"
        };

        /// <summary>
        /// Converts a numeric value into its word equivalent.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>A string containing the word representation of the number.</returns>
        public string ConvertNumbers(long number)
        {
            if (number == 0)
                return "Zero";

            if (number == long.MinValue)
                return "Input number is too small";

            if (number < 0)
                return $"Negative {ConvertNumbers(Math.Abs(number))}";

            return ConvertToWords(number).Trim();
        }

        /// <summary>
        /// Recursively builds the English representation of a given number.
        /// </summary>
        /// <param name="number">The number to process.</param>
        /// <returns>The constructed word string.</returns>
        private string ConvertToWords(long number)
        {
            if (number < 20)
                return _belowTwenty[number];
            else if (number < 100)
                return $"{_tens[number / 10]}{(number % 10 > 0 ? "-" + _belowTwenty[number % 10] : string.Empty)}";
            else if (number < 1000)
                return $"{_belowTwenty[number / 100]} Hundred{(number % 100 > 0 ? " and " + ConvertToWords(number % 100) : string.Empty)}";

            //Approach for larger numbers, e.g., thousands, millions, etc.
            //Append the appropriate scale (thousand, million, etc.) based on the segment position.
            string result = string.Empty;
            for (int i = 0; number > 0 && i < _thousands.Length; i++, number /= 1000)
            {
                long segment = number % 1000;
                if (segment > 0)
                {
                    string segmentText = $"{ConvertToWords(segment)} {_thousands[i]}".Trim();
                    result = $"{segmentText} {result}".Trim();
                }
            }

            return result;
        }
    }
}
