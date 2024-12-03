using UnityEngine;
namespace Udacity.GameDevelopment.Shared
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private float _relativeSpeed;

        private void Update()
        {
            transform.position = new Vector2(
                _camera.transform.position.x * _relativeSpeed,
                _camera.transform.position.y * _relativeSpeed);
        }
    }
}
