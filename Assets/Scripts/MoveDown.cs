//Компонент добавляется на префабы врагов
using UnityEngine;

namespace EtA
{
    public class MoveDown : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;


        private void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
            if (transform.position.z < 0f)
                Destroy(gameObject);
        }
    }
}