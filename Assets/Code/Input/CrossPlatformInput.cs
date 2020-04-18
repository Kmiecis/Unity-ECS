using Unity.Mathematics;
using UnityEngine;

namespace Common
{
    public class CrossPlatformInput
    {
        private AbstractInput m_Input;

        public CrossPlatformInput()
        {
#if MOBILE_INPUT
            m_Input = new MobileInput();
#else
            m_Input = new StandardInput();
#endif
        }

        private static AbstractInput Input
        {
            get { return m_Instance.m_Input; }
        }

        public static float GetAxisHorizontal()
        {
            return Input.GetAxisHorizontal();
        }

        public static void SetAxisHorizontal(float value)
        {
            Input.SetAxisHorizontal(value);
        }

        public static float GetAxisRawHorizontal()
        {
            return Input.GetAxisRawHorizontal();
        }

        public static void SetAxisRawHorizontal(float value)
        {
            Input.SetAxisRawHorizontal(value);
        }

        public static float GetAxisVertical()
        {
            return Input.GetAxisVertical();
        }

        public static void SetAxisVertical(float value)
        {
            Input.SetAxisVertical(value);
        }

        public static float GetAxisRawVertical()
        {
            return Input.GetAxisRawVertical();
        }

        public static void SetAxisRawVertical(float value)
        {
            Input.SetAxisRawVertical(value);
        }

        public static float3 GetMousePosition()
        {
            return Input.GetMousePosition();
        }

        public static void SetMousePosition(float3 position)
        {
            Input.SetMousePosition(position);
        }

        public static bool GetKey(KeyCode key)
        {
            return Input.GetKey(key);
        }

        public static bool GetKeyDown(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }

        public static void SetKeyDown(KeyCode key)
        {
            Input.SetKeyDown(key);
        }

        public static bool GetKeyUp(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }

        public static void SetKeyUp(KeyCode key)
        {
            Input.SetKeyUp(key);
        }


#region Singleton
        static CrossPlatformInput()
        {
            m_Instance = new CrossPlatformInput();
        }
        private static CrossPlatformInput m_Instance;
#endregion
    }
}