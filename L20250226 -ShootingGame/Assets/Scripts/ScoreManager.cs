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
        currentScoreText.text = "�������� : " + currentscore;
        bestScoreText.text = "�ְ����� : " + bestscore;
    }

    // ���� ���� ���ٰ� ������ ����ó�� ������ �� �ֽ��ϴ�.
    public int score
    {
        get 
        { 
            return currentscore; 
        }
        set 
        {   // ���� ���� ���� ������ ������ �����˴ϴ�.
            currentscore = value;
            // UI�� ���� ���� ����˴ϴ�.
            currentScoreText.text = "�������� : " + currentscore;

            // ���� �� ������ �ְ� ������ �Ѿ��ٸ�
            if (currentscore > bestscore)
            { 
                // �� ������ �ְ� ������ �����Ǹ�
                bestscore = currentscore;
                // UI�� ���ŵ˴ϴ�.
                bestScoreText.text = "�ְ����� : " + bestscore;
                // ���� �����Ϳ��� �� ��ġ�� �����մϴ�.
                PlayerPrefs.GetInt("bestScore", bestscore);
            }
        }
    }



}
