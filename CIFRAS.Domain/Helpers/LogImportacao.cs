using System;
using System.IO;
using System.Text;

namespace CIFRAS.Domain.Helpers
{
    public static class LogImportacao
    {
        public static string Filename
        {
            get
            {
                var data = DateTime.Now;
                var dia = data.Day;
                var mes = data.Month;
                var ano = data.Year;
                var hora = data.Hour;
                var minuto = data.Minute;
                var segundo = data.Second;
                var milissegundo = data.Millisecond;
                return $"{dia}_{mes}_{ano}_{hora}_{minuto}_{segundo}_{milissegundo}.txt";
            }
        }

        public static string Msg(string text)
        {
            var data = DateTime.Now;
            return $"{data.ToShortDateString()} {data.ToLongTimeString()} - {text}";
        }

        public static void Save(string path, string msg)
        {
            File.AppendAllLines(path, new[] {msg}, Encoding.Unicode);
        }
    }
}