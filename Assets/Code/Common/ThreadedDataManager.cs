using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Safari.Common
{
    public class ThreadedDataManager : MonoBehaviour
    {
        private static Queue<ThreadInfo> m_DataQueue = new Queue<ThreadInfo>();
        private static ThreadedDataManager m_Instance;

        static ThreadedDataManager()
        {
            m_Instance = new GameObject("Threaded Data Manager")
                .AddComponent<ThreadedDataManager>();
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (m_DataQueue.Count > 0)
            {
                for (int i = 0; i < m_DataQueue.Count; i++)
                {
                    ThreadInfo threadInfo = m_DataQueue.Dequeue();
                    threadInfo.callback(threadInfo.parameter);
                }
            }
        }

        public static void RequestData(Func<object> generator, Action<object> callback)
        {
            ThreadStart threadStart = delegate
            {
                ProcessData(generator, callback);
            };

            new Thread(threadStart).Start();
        }

        private static void ProcessData(Func<object> generator, Action<object> callback)
        {
            object data = generator();
            lock (m_DataQueue)
            {
                m_DataQueue.Enqueue(new ThreadInfo(callback, data));
            }
        }

        struct ThreadInfo
        {
            public readonly Action<object> callback;
            public readonly object parameter;

            public ThreadInfo(Action<object> callback, object parameter)
            {
                this.callback = callback;
                this.parameter = parameter;
            }
        }
    }
}