using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreText;
    public Text bestScoreText;
    public int currentscore;
    public int bestscore;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestscore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "최고점수 : " + bestscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
