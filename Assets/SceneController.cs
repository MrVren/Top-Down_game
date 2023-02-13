using UnityEngine;

namespace EtA
{
    public class SceneController : MonoBehaviour
    {
        public static SceneController instance;

        public GameObject Spawner;

        public static float score;
        public int highscore;
        public bool isNewHighscore = false;


        private void Awake()
        {
            instance = this;
        }

        public void StartGame()
        {
            PlayerHUD.instance.newHighscore.gameObject.SetActive(false);
            PlayerHUD.instance.menuPanel.SetActive(false);
            PlayerHUD.instance.gameOverPanel.SetActive(false);
            PlayerHUD.instance.inGamePanel.SetActive(true);
            Spawner.SetActive(true);
            score = 0;
        }

        public void EndGame()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Spawner.SetActive(false);
            PlayerHUD.instance.inGamePanel.SetActive(false);
            PlayerHUD.instance.menuPanel.SetActive(true);
            PlayerHUD.instance.gameOverPanel.SetActive(true);
            HighscoreUpdate();
            PlayerHUD.instance.TotalPoints();
        }

        /// <summary>
        /// Метод обновляет рекорд игрока. Необходимо вызывать перед "TotalPoints()"
        /// </summary>
        public void HighscoreUpdate()
        {
            if (score > PlayerPrefs.GetInt("score"))
            {
                Debug.Log("Новый рекорд");
                isNewHighscore = true;
                highscore = (int)score;

                if (PlayerPrefs.GetInt("score") <= highscore)
                    PlayerPrefs.SetInt("score", highscore);
            }
            else
                isNewHighscore = false;


        }
    }
}