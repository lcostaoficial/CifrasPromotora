using System;
using System.Collections.Generic;

namespace CIFRAS.Application.Helpers.General
{
    public static class ForEachExtension
    {
        public static void ForEach<T>(this ICollection<T> seq, Action<T> action)
        {
            foreach (var item in seq)
                action(item);
        }
    }
}