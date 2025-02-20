using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true; // true : 카운트 다운 진행 / false : 카운트 처리 X
    public float gameTime = 0;      // 실제 진행할 게임 시간(최대시간)
    public bool isTimeover = false; // false : 타이머 작동 중, true : 타이머 정지
    public float displayTime = 0;   // 화면에 표시하기 위한 시간(현재시간)

    float times = 0;                 // 현재 시간

    
    void Start()
    {
        // 카운트다운이 진행 중이라면, 표기된 시간을 게임 시간으로 설정합니다.
        if (isCountDown)
        { 
            displayTime = gameTime;
        
        }
    }

    
    void Update()
    {
        if (isTimeover == false)
        {
            times += Time.deltaTime;

            if (isCountDown)
            {
                displayTime = gameTime - times;

                if (displayTime <= 0.0f)
                {
                    displayTime = 0.0f;
                    isTimeover = true;


                }


            }
            else 
            {
                displayTime = times;
                
                if (displayTime <= gameTime)
                {
                    displayTime = gameTime;
                    isTimeover=true;
                  
                
                }
            
            
            }
        
        }

    }
}
