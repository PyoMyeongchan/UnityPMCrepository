using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
    }

    public Text currentScoreText;
    public Text bestScoreText;
    private int currentscore;
    private int bestscore;

    private void Start()
    {
        PlayerPrefs.GetInt("bestScore");
        currentScoreText.text = "현재점수 : " + currentscore;
        bestScoreText.text = "최고점수 : " + bestscore;
    }

    // 값에 대한 접근과 설정을 변수처럼 진행할 수 있습니다.
    public int score
    {
        get 
        { 
            return currentscore; 
        }
        set 
        {   // 전달 받은 값이 현재의 점수로 설정됩니다.
            currentscore = value;
            // UI에 대한 값이 적용됩니다.
            currentScoreText.text = "현재점수 : " + currentscore;

            // 현재 의 점수가 최고 점수를 넘었다면
            if (currentscore > bestscore)
            { 
                // 그 점수가 최고 점수로 설정되며
                bestscore = currentscore;
                // UI에 갱신됩니다.
                bestScoreText.text = "최고점수 : " + bestscore;
                // 내부 데이터에도 그 수치를 적용합니다.
                PlayerPrefs.GetInt("bestScore", bestscore);
            }
        }
    }



}
