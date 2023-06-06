using Microsoft.VisualBasic;
using System;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int CalculateDifference(string firstDateData, string secondDateData)
        {
            DateTime firstDate = DateTime.Parse(firstDateData);
            DateTime secondDate = DateTime.Parse(secondDateData);
            TimeSpan difference = firstDate - secondDate;
            return Math.Abs(difference.Days);
        }
       
    }
}

