using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public GameObject dialog;
    public Text text;
    public Queue<string> stringQueue = new Queue<string>();
    
    public void Start()
    {
        
        stringQueue.Enqueue("안녕하신가 자네 시간이 되면 날 도와주게나.");
        stringQueue.Enqueue("무슨 일이시죠?");
        stringQueue.Enqueue("나 배가고파 빵을 사다주게.");
        stringQueue.Enqueue("아..알겠습니다.");
                      

    }

    public void NextButtonCLick()
    {
        dialog.SetActive(true);

        StartCoroutine("talk");
    }


    IEnumerator talk()
    {
        for (int i = 0; i < 5; i++)
        {
            text.text = stringQueue.Dequeue();
            yield return new WaitForSeconds(5.0F);
        }
        dialog.SetActive(false);
    }


}

    