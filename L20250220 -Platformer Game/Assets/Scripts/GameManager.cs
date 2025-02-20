using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainImage;
    public Sprite gameOverSprite;
    public Sprite gameClearSprite;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image image;


    // TimeController
    public GameObject timeBar;
    public GameObject timeText;
    TimeController timeController;


    void Start()
    {
        // Ÿ�� ��Ʈ�ѷ� ���� �� ����
        timeController = GetComponent<TimeController>();
        if (timeController != null)
        {
            if (timeController.gameTime == 0)
            { 
                timeBar.SetActive(false); // �ð� ������ ���ٸ� ����ڽ��ϴ�.
            }
        }


        Invoke("InactiveImage", 1.0f);
        panel.SetActive(false);

        

    }

    void InactiveImage()
    {
        mainImage.SetActive(false);

    }
    
    void Update()
    {
        if (PlayerController.state == "gameclear")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            // �ٽ� ���� ��ư�� ���� ��Ȱ��ȭ(������ Ŭ���������ϱ�)
            restartButton.GetComponent<Button>().interactable = false;
            // ���� �̹����� ���� Ŭ���� �̹����� �����մϴ�.
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            // �÷��̾� ��Ʈ�ѷ��� ���¸� end�� �����մϴ�.
            PlayerController.state = "end";

            if (timeController != null)
            { 
            timeController.isTimeover = true;
            
            }

        }
        else if (PlayerController.state == "gameover")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            // �ٽ� ���� ��ư�� ���� ��Ȱ��ȭ(������ Ŭ���������ϱ�)
            nextButton.GetComponent<Button>().interactable = false;
            // ���� �̹����� ���� Ŭ���� �̹����� �����մϴ�.
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            // �÷��̾� ��Ʈ�ѷ��� ���¸� end�� �����մϴ�.
            PlayerController.state = "end";

            if (timeController != null)
            {
                timeController.isTimeover = true;

            }

        }
        else if (PlayerController.state == "Playing")
        {
            // ���� ����ÿ� ���� �߰� ó���� �����ϴ� �ڸ�

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            PlayerController playerController = player.GetComponent<PlayerController>();

            if (timeController != null)
            {
                if (timeController.gameTime > 0)
                { 
                    //ǥ��� ������ ���̰� ����(�Ҽ����� �����ϴ�.)
                    int time =(int)timeController.displayTime;
                    // �ð� ����(UI)
                    timeText.GetComponent<Text>().text=time.ToString();

                    if (time == 0)
                    {
                        playerController.Dead();
                    
                    }
                }
                
            
            }

        }


    }
}
