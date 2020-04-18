using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Common
{
    public class MobileInput : AbstractInput
    {
        private Dictionary<KeyCode, VirtualButton> m_Keys = new Dictionary<KeyCode, VirtualButton>();
        private float2 m_Axes;
        private float3 m_MousePosition;


        public override float GetAxisHorizontal()
        {
            return m_Axes[HORIZONTAL];
        }


        public override float GetAxisRawHorizontal()
        {
            return m_Axes[HORIZONTAL];
        }


        public override float GetAxisRawVertical()
        {
            return m_Axes[VERTICAL];
        }


        public override float GetAxisVertical()
        {
            return m_Axes[VERTICAL];
        }


        public override bool GetKey(KeyCode key)
        {
            if (!m_Keys.ContainsKey(key))
            {
                AddButton(key);
            }
            return m_Keys[key].GetButton();
        }


        public override bool GetKeyDown(KeyCode key)
        {
            if (!m_Keys.ContainsKey(key))
            {
                AddButton(key);
            }
            return m_Keys[key].GetButtonDown();
        }


        public override bool GetKeyUp(KeyCode key)
        {
            if (!m_Keys.ContainsKey(key))
            {
                AddButton(key);
            }
            return m_Keys[key].GetButtonUp();
        }


        public override float3 GetMousePosition()
        {
            return m_MousePosition;
        }


        public override void SetAxisHorizontal(float value)
        {
            m_Axes[HORIZONTAL] = value;
        }


        public override void SetAxisRawHorizontal(float value)
        {
            m_Axes[HORIZONTAL] = value;
        }


        public override void SetAxisRawVertical(float value)
        {
            m_Axes[VERTICAL] = value;
        }


        public override void SetAxisVertical(float value)
        {
            m_Axes[VERTICAL] = value;
        }


        public override void SetKeyDown(KeyCode key)
        {
            if (!m_Keys.ContainsKey(key))
            {
                AddButton(key);
            }
            m_Keys[key].Pressed();
        }


        public override void SetKeyUp(KeyCode key)
        {
            if (!m_Keys.ContainsKey(key))
            {
                AddButton(key);
            }
            m_Keys[key].Released();
        }


        public override void SetMousePosition(float3 position)
        {
            m_MousePosition = position;
        }


        void AddButton(KeyCode key)
        {
            m_Keys.Add(key, new VirtualButton());
        }


        private const int HORIZONTAL = 0;
        private const int VERTICAL = 1;
    }
}