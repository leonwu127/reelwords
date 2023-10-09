﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelWords.Utility
{
    public static class WordValidator
    {

        public static bool IsValidWord(string word)
        {
            // Skip null or empty words
            if (string.IsNullOrEmpty(word)) return false;

            // Skip words with uppercase characters
            if (word.Any(char.IsUpper)) return false;

            // Skip words longer than 6 characters if that rule is still applicable
            if (word.Length > 6) return false;

            foreach (char c in word)
            {
                if (!char.IsLetter(c)) return false;
            }

            return true;
        }

        public static string NormalizeWord(string word)
        {
            string normalized = word.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
