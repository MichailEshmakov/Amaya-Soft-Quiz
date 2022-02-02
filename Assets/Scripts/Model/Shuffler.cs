using UnityEngine;
using System.Collections.Generic;

namespace Model
{
    public static class Shuffler
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count; i > 0; i--)
                list.Swap(0, Random.Range(0, i));
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}

