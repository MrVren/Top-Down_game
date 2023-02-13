using UnityEngine;

namespace EtA
{
    public class Throwing : MonoBehaviour
    {
        [SerializeField] private GameObject[] _food;
        [SerializeField] private float _holdingThrow = 0f;


        private void Update()
        {
            if (_holdingThrow == 0f)
                ThrowTheFood();

            _holdingThrow += Time.deltaTime;

            if (_holdingThrow > 0.3f)
                _holdingThrow = 0f;
        }

        private void ThrowTheFood()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                int i = Random.Range(0, _food.Length);
                Instantiate(_food[i], new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
            }
        }
    }
}