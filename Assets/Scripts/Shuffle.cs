using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shuffle {

    public static void ShuffleList<T>(this List<T> list)
    {
        int count = list.Count;
        int p;

        for (int i = 0; i < list.Count - 1; i++)
        {
            p = Random.Range(i, count);
            T tmp = list[i];
            list[i] = list[p];
            list[p] = tmp;
        }
    }

}
