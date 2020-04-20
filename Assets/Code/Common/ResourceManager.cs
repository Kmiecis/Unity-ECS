using UnityEngine;

namespace Common
{
    public static class ResourceManager
    {
        private static Object[] m_Resources = new Object[(int)ResourcePath.Count];

        public static T Load<T>(ResourcePath path)
            where T : Object
        {
            return Load(path) as T;
        }

        public static GameObject Instantiate(ResourcePath path)
        {
            return Object.Instantiate(Load<GameObject>(path));
        }

        public static GameObject Instantiate(ResourcePath path, Transform parent)
        {
            return Object.Instantiate(Load<GameObject>(path), parent);
        }

        public static T Instantiate<T>(ResourcePath path)
            where T : Component
        {
            return Instantiate(path)
                .GetComponent<T>();
        }

        private static Object Load(ResourcePath path)
        {
            int index = (int)path;
            if (m_Resources[index] == null)
            {
                var pathString = path.ToPathString();
                m_Resources[index] = Resources.Load(pathString);
#if UNITY_EDITOR
                if (m_Resources[index] == null)
                {
                    Debug.LogErrorFormat("Unable to load resource at: {0}", pathString);
                }
#endif
            }
            return m_Resources[index];
        }
    }
}