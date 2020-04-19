using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class CoroutineTools
    {
        public static IEnumerator InvokeNextFrame(Action callback)
        {
            yield return null;
            callback.Invoke();
        }

        public static IEnumerator InvokeDelayed(Action callback, float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            callback.Invoke();
        }

        public static IEnumerator InvokeRepeating(Action callback, float delay)
        {
            while (true)
            {
                yield return InvokeDelayed(callback, delay);
            }
        }
    }
}
