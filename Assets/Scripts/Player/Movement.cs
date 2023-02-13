using UnityEngine;

namespace EtA
{
    public class Movement : MonoBehaviour
    {
        #region Constants

        //bounds of field for 1920x1080 resolution
        private const float LEFT_BOUND = -15f;
        private const float RIGHT_BOUND = 15f;
        private const float UPPER_BOUND = 15f;
        private const float LOWER_BOUND = -1f;

        private const float VERTICAL_INPUT_COEFF = 1.2f;

        #endregion

        [SerializeField] private float _horizontalInput;
        [SerializeField] private float _verticalInput;
        [SerializeField] private float _sensetivity = 65f;


        #region MonoBehaviour
        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        private void Update()
        {
            Moving();
        }
        private void OnTriggerEnter(Collider target)
        {
            if (target.gameObject.CompareTag("Animals"))
            {
                SceneController.instance.EndGame();
                Destroy(gameObject);
            }
        }

        #endregion

        /// <summary>
        /// Движение игрока с помощью мыши
        /// </summary>
        private void Moving()
        {
            #region Horizontal moving

            _horizontalInput = Input.GetAxis("Mouse X");
            transform.Translate(_horizontalInput * _sensetivity * Time.deltaTime * Vector3.right);

            //keep player inbounds
            if (transform.position.x < LEFT_BOUND)
            {
                transform.position = new Vector3(LEFT_BOUND, transform.position.y, transform.position.z);
            }
            if (transform.position.x > RIGHT_BOUND)
            {
                transform.position = new Vector3(RIGHT_BOUND, transform.position.y, transform.position.z);
            }

            #endregion

            #region Vertical moving

            _verticalInput = Input.GetAxis("Mouse Y");
            transform.Translate(_verticalInput * (_sensetivity / VERTICAL_INPUT_COEFF) * Time.deltaTime * Vector3.forward);

            //keep player inbounds
            if (transform.position.z < LOWER_BOUND)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, LOWER_BOUND);
            }
            if (transform.position.z > UPPER_BOUND)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, UPPER_BOUND);
            }

            #endregion
        }
    }
}