using System;
using UnityEngine;

namespace Common
{
    public class UniqueObject<T> : IDisposable
            where T : UniqueBehaviour
    {
        protected GameObject m_Object;
        protected T m_Component;

        public UniqueObject(string path, Transform parent = null)
        {
            Create(path, parent);
        }

        void Create(string path, Transform parent = null)
        {
            GameObject prefab = Resources.Load(path) as GameObject;

            m_Object = GameObject.Instantiate(prefab);
            if (m_Object == null)
            {
                Debug.LogErrorFormat("Failed to load Entity from \"Resources/{0}\".", path);
                return;
            }

            m_Component = m_Object.GetComponent<T>();
            if (m_Component == null)
            {
                Debug.LogErrorFormat("Failed to load Data of type {0} from {1}.", typeof(T).Name, m_Object.name);
            }

            if (parent != null)
            {
                m_Object.transform.SetParent(parent, false);
            }
        }

        public virtual void Dispose()
        {
            ObjectTools.DestroySafely(ref m_Object);
        }

        public virtual bool Visible
        {
            get { return m_Object.activeSelf; }
            set { m_Object.SetActive(value); }
        }

        public bool Exists
        {
            get { return m_Object != null; }
        }
    }
}