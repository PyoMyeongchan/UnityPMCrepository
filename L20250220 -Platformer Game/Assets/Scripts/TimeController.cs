using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true; // true : ī��Ʈ �ٿ� ���� / false : ī��Ʈ ó�� X
    public float gameTime = 0;      // ���� ������ ���� �ð�(�ִ�ð�)
    public bool isTimeover = false; // false : Ÿ�̸� �۵� ��, true : Ÿ�̸� ����
    public float displayTime = 0;   // ȭ�鿡 ǥ���ϱ� ���� �ð�(����ð�)

    float times = 0;                 // ���� �ð�

    
    void Start()
    {
        // ī��Ʈ�ٿ��� ���� ���̶��, ǥ��� �ð��� ���� �ð����� �����մϴ�.
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
