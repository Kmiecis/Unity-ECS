using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common
{
    public static class ObjectTools
    {
        public static void DestroySafely<T>(T obj)
            where T : Object
        {
            if (obj == null)
                return;

            if (Application.isPlaying)
                Object.Destroy(obj);
            else
                Object.DestroyImmediate(obj);
        }

        public static void DestroySafely<T>(ref T obj)
            where T : Object
        {
            DestroySafely(obj);

            obj = null;
        }

        public static void DestroySafely<T>(ref T[] arr)
            where T : Object
        {
            if (arr == null)
                return;

            for (int i = 0; i < arr.Length; ++i)
                DestroySafely(ref arr[i]);

            arr = null;
        }

        public static void DestroySafely<T>(ref List<T> objs)
            where T : Object
        {
            if (objs == null)
                return;

            foreach (var obj in objs)
                DestroySafely(obj);

            objs = default;
        }

        public static void Dispose<T>(T arg)
            where T : IDisposable
        {
            if (arg == null)
                return;

            arg.Dispose();
        }

        public static void Dispose<T>(ref T arg)
            where T : IDisposable
        {
            Dispose(arg);

            arg = default;
        }

        public static void Dispose<T>(ref T[] arr)
            where T : IDisposable
        {
            if (arr == null)
                return;

            for (int i = 0; i < arr.Length; ++i)
                Dispose(ref arr[i]);

            arr = null;
        }

        public static void Dispose<T>(ref IEnumerable<T> values)
            where T : IDisposable
        {
            if (values == null)
                return;

            foreach (var value in values)
                Dispose(value);

            values = null;
        }
    }

    public static class BitwiseTools
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFlag(int value, int flag)
        {
            return (value & flag) == flag;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFlag(int value, int flag)
        {
            return (value & flag) != 0;
        }
    }
}