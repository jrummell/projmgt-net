using System;

namespace PMT.BLL
{
    public static class Utility
    {
        /// <summary>
        /// Returns date.ToShortDateString() if date has a value, else String.Empty.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static string MaskNull(DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToShortDateString();
            }

            return String.Empty;
        }
    }
}