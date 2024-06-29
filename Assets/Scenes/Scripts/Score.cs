using UnityEngine;
using TMPro;

namespace BlobIO.Game
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scorebitisText; // Score bitiþ panelindeki metin alaný
      

        private  int currentScore = 0;

        void Start()
        {
            UpdateScoreUI();
            
        }

        public void IncreaseScore(int puan)
        {
            currentScore += puan;
            UpdateScoreUI();
        }

        public void SetScore(int score)
        {
            currentScore = score;
            UpdateScoreUI();
            scorebitis();
        }

        private void scorebitis()
        {
            scorebitisText.text = "Score: " + currentScore.ToString();

        }

        private void UpdateScoreUI()
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
}
