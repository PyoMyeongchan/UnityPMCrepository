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
        // 타임 컨트롤러 연결 및 설정
        timeController = GetComponent<TimeController>();
        if (timeController != null)
        {
            if (timeController.gameTime == 0)
            { 
                timeBar.SetActive(false); // 시간 제한이 없다면 숨기겠습니다.
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

            // 다시 시작 버튼에 대한 비활성화(게임을 클리어했으니까)
            restartButton.GetComponent<Button>().interactable = false;
            // 메인 이미지를 게임 클리어 이미지로 변경합니다.
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            // 플레이어 컨트롤러의 상태를 end로 변경합니다.
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

            // 다시 시작 버튼에 대한 비활성화(게임을 클리어했으니까)
            nextButton.GetComponent<Button>().interactable = false;
            // 메인 이미지를 게임 클리어 이미지로 변경합니다.
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            // 플레이어 컨트롤러의 상태를 end로 변경합니다.
            PlayerController.state = "end";

            if (timeController != null)
            {
                timeController.isTimeover = true;

            }

        }
        else if (PlayerController.state == "Playing")
        {
            // 게임 진행시에 대한 추가 처리를 구현하는 자리

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            PlayerController playerController = player.GetComponent<PlayerController>();

            if (timeController != null)
            {
                if (timeController.gameTime > 0)
                { 
                    //표기상 정수로 보이게 설정(소수점을 버립니다.)
                    int time =(int)timeController.displayTime;
                    // 시간 갱신(UI)
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
