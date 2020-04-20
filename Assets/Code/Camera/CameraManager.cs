using UnityEngine;

namespace Common
{
    public class CameraManager
    {
        private Camera m_CurrentCamera;

        public static Camera Current
        {
            get { return m_Instance.m_CurrentCamera; }
        }

        public static void Set(Camera camera)
        {
            m_Instance.m_CurrentCamera = camera;
        }

        #region Singleton

        private static CameraManager m_Instance;

        static CameraManager()
        {
            m_Instance = new CameraManager();
        }

        #endregion
    }
}