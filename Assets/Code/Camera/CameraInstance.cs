using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(Camera))]
    public class CameraInstance : MonoBehaviour
    {
        private void Awake()
        {
            var camera = GetComponent<Camera>();
            CameraManager.Set(camera);
        }
    }
}