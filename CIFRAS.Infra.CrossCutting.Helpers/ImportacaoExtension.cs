using System;

namespace CIFRAS.Infra.CrossCutting.Helpers
{
    public static class ImportacaoExtension
    {
        public static string ToText(this string[] line, Enum index)
        {
            return line[Convert.ToInt32(index)].Replace("\"", string.Empty);
        }

        public static int ToInt(this string[] line, Enum index)
        {
            if (line[Convert.ToInt32(index)].Trim() == "")
                return 0;
            return Convert.ToInt32(line[Convert.ToInt32(index)]);
        }

        public static decimal ToDecimal(this string[] line, Enum index)
        {
            return Convert.ToDecimal(line[Convert.ToInt32(index)].Replace("\"", string.Empty).Replace("R$", string.Empty).Replace(".", string.Empty));
        }

        public static DateTime? ToDate(this string[] line, Enum index)
        {
            if (line[Convert.ToInt32(index)].Trim() != "")
            {
                return Convert.ToDateTime(line[Convert.ToInt32(index)]);
            }
            else
            {
                return null;
            }
        }
    }
}