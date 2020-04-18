using System;
using Unity.Mathematics;
using UnityEngine;

namespace Common
{
    public class StandardInput : AbstractInput
    {
        public override float GetAxisHorizontal()
        {
            return Input.GetAxis(HORIZONTAL);
        }


        public override float GetAxisRawHorizontal()
        {
            return Input.GetAxisRaw(HORIZONTAL);
        }


        public override float GetAxisVertical()
        {
            return Input.GetAxis(VERTICAL);
        }


        public override float GetAxisRawVertical()
        {
            return Input.GetAxisRaw(VERTICAL);
        }


        public override bool GetKey(KeyCode key)
        {
            return Input.GetKey(key);
        }


        public override bool GetKeyDown(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }


        public override bool GetKeyUp(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }


        public override float3 GetMousePosition()
        {
            return Input.mousePosition;
        }


        public override void SetAxisHorizontal(float value)
        {
            throw new Exception(EXCEPTION);
        }


        public override void SetAxisRawHorizontal(float value)
        {
            throw new Exception(EXCEPTION);
        }


        public override void SetAxisVertical(float value)
        {
            throw new Exception(EXCEPTION);
        }


        public override void SetAxisRawVertical(float value)
        {
            throw new Exception(EXCEPTION);
        }


        public override void SetKeyDown(KeyCode key)
        {
            throw new Exception(EXCEPTION);
        }


        public override void SetKeyUp(KeyCode key)
        {
            throw new Exception(EXCEPTION);
        }


        public override void SetMousePosition(float3 position)
        {
            throw new Exception(EXCEPTION);
        }


        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private const string EXCEPTION = "Unable to set input axis on non-mobile platform";
    }
}