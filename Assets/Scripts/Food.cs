using UnityEngine;
using static EtA.SceneController;

namespace EtA
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;


        private void Update()
        {
            transform.Translate(speed * Time.deltaTime * new Vector3(0, 0, 1));

            if (transform.position.z > 20f)
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider target)
        {
            if (target.transform.CompareTag("Animals"))
            {
                score++;
                Destroy(gameObject);
                Destroy(target.gameObject);
            }
        }
    }
}