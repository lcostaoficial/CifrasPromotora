using System;

namespace CIFRAS.Infra.CrossCutting.Helpers
{
    public static class ImportacaoRulesExtension
    {
        public static string RuleCpf(this string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        public static T RuleEstado<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}