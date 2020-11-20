using UnityEngine;

namespace Platformer.View
{
    public class ParallaxLayer : MonoBehaviour
    {
        public Vector3 movementScale = Vector3.one;

        Transform _camera;

        void Awake()
        {
            _camera = Camera.main.transform;
        }

        void LateUpdate()
        {
            transform.position = Vector3.Scale(_camera.position, movementScale);
        }

    }
}
