using UnityEngine;
using UnityEngine.UI;
using static EtA.SceneController;

namespace EtA
{
    public class PlayerHUD : MonoBehaviour
    {
        public static PlayerHUD instance;

        public GameObject menuPanel;
        public GameObject gameOverPanel;
        public GameObject inGamePanel;
        public Text inGameScoreText;
        public Text inGameHighscoreText;
        public Text newHighscore;
        public Text totalScore;
        public Text totalHighscore;


        #region MonoBehaviour

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            if (inGamePanel.activeSelf)
            {
                inGameScoreText.text = $"Счет: {score}";
                inGameHighscoreText.text = $"Рекорд: {PlayerPrefs.GetInt("score")}";
            }
        }

        #endregion

        /// <summary>
        /// Вывод очков после окончания игры
        /// </summary>
        public void TotalPoints()
        {
            if (!SceneController.instance.isNewHighscore)
            {
                totalScore.gameObject.SetActive(true);
                totalHighscore.gameObject.SetActive(true);
                newHighscore.gameObject.SetActive(false);
                totalScore.text = $"Score: {score}";
                totalHighscore.text =
                    $"Highscore: {PlayerPrefs.GetInt("score")}";
            }
            else
            {
                totalScore.gameObject.SetActive(false);
                totalHighscore.gameObject.SetActive(false);
                newHighscore.gameObject.SetActive(true);
                newHighscore.text =
                    $"New Highscore: {SceneController.instance.highscore} !";
            }
        }

        #region CALLBACKS
        public void OnStartClick()
        {
            SceneController.instance.StartGame();
        }

        //Closing GameOver panel
        public void ToMenu()
        {
            gameOverPanel.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit(0);
        }
        #endregion
    }
}