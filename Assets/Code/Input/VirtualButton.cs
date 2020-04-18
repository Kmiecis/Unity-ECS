using UnityEngine;

namespace Common
{
    public class VirtualButton
    {
        private KeyCode key;

        private bool m_Pressed;
        private int m_PressedFrame = -1;
        private int m_ReleasedFrame = -1;


        public void Pressed()
        {
            m_Pressed = true;
            m_PressedFrame = Time.frameCount;
        }


        public void Released()
        {
            m_Pressed = false;
            m_ReleasedFrame = Time.frameCount;
        }


        public bool GetButton()
        {
            return m_Pressed;
        }


        public bool GetButtonDown()
        {
            return m_PressedFrame == Time.frameCount - 1;
        }


        public bool GetButtonUp()
        {
            return m_ReleasedFrame == Time.frameCount - 1;
        }
    }
}