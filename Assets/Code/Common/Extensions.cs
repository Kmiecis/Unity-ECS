using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Common
{
    public static class ArrayExtensions
    {
        public static bool IsNullOrEmpty<T>(this T[] arr)
        {
            return arr == null || arr.Length == 0;
        }

        public static int GetLengthSafely<T>(this T[] arr)
        {
            if (arr == null)
                return 0;
            return arr.Length;
        }

        public static T First<T>(this T[] arr)
        {
            return arr[0];
        }

        public static T Last<T>(this T[] arr)
        {
            return arr[arr.Length - 1];
        }

        public static T[] Populate<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = value;
            }
            return arr;
        }

        public static bool InBounds<T>(this T[] arr, int value)
        {
            return value > -1 && value < arr.Length;
        }

        public static void Shuffle<T>(this T[] arr)
        {
            int n = arr.Length;
            while (n-- > 1)
            {
                int k = Random.Range(0, n);
                T value = arr[k];
                arr[k] = arr[n];
                arr[n] = value;
            }
        }

        public static bool Contains<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; ++i)
                if (arr[i].Equals(value))
                    return true;
            return false;
        }
    }

    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static int GetCountSafely<T>(this List<T> list)
        {
            if (list == null)
                return 0;
            return list.Count;
        }

        public static T First<T>(this List<T> list)
        {
            return list[0];
        }

        public static T Last<T>(this List<T> list)
        {
            return list[list.Count - 1];
        }

        public static void RemoveLast<T>(this List<T> list)
        {
            list.RemoveAt(list.Count - 1);
        }

        public static void RemoveLast<T>(this List<T> list, int count)
        {
            list.RemoveRange(list.Count - 1 - count, count);
        }

        public static T RevokeLast<T>(this List<T> list)
        {
            var last = list.Last();
            list.RemoveLast();
            return last;
        }

        public static T[] RevokeLast<T>(this List<T> list, int count)
        {
            var last = new T[count];
            list.CopyTo(list.Count - 1 - count, last, 0, count);
            list.RemoveLast(count);
            return last;
        }

        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            while (n-- > 1)
            {
                int k = Random.Range(0, n);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public static class StringExtensions
    {
        public static Color32 HexToColorRGB(this string value)
        {
            byte r = Convert.ToByte(value.Substring(0, 2), 16);
            byte g = Convert.ToByte(value.Substring(2, 2), 16);
            byte b = Convert.ToByte(value.Substring(4, 2), 16);
            return new Color32(r, g, b, 255);
        }

        public static Color32 HexToColorRGBA(this string value)
        {
            byte r = Convert.ToByte(value.Substring(0, 2), 16);
            byte g = Convert.ToByte(value.Substring(2, 2), 16);
            byte b = Convert.ToByte(value.Substring(4, 2), 16);
            byte a = Convert.ToByte(value.Substring(6, 2), 16);
            return new Color32(r, g, b, a);
        }
    }


    public static class ResourcePathExtensions
    {
        public static string ToPathString(this ResourcePath resourcePath)
        {
            return resourcePath.ToString().Replace('_', '/');
        }
    }
}