using System;
using System.Collections.Generic;

namespace Common.Collections
{
    public class AutoList<T> : List<T>
    {
        private Func<T> m_Constructor;
        private Action<T> m_Destructor;

        public Func<T> Constructor
        {
            set { m_Constructor = value; }
        }

        public Action<T> Destructor
        {
            set { m_Destructor = value; }
        }

        public AutoList(Func<T> constructor, Action<T> destructor)
        {
            m_Constructor = constructor;
            m_Destructor = destructor;
        }

        public new int Count
        {
            get { return base.Count; }
            set
            {
                var diff = value - base.Count;
                if (diff == 0)
                    return;

                if (diff > 0)
                {
                    var ts = new T[diff];
                    for (int i = 0; i < diff; ++i)
                        ts[i] = m_Constructor();
                    base.AddRange(ts);
                }
                else
                {
                    while (diff++ < 0)
                    {
                        var element = this.Last();
                        m_Destructor(element);
                        this.RemoveLast();
                    }
                }
            }
        }
    }
}