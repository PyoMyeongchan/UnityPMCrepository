using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Text talk;
    public Button next;

    public Queue<string> stringQueue = new Queue<string>();
        

    public int Count //큐 길이 가져오기
    {
        get { return stringQueue.Count; }
    }


    public void Start()
    {
        stringQueue.Enqueue("안녕하신가 자네 시간이 되면 날 도와주게나.");
        stringQueue.Enqueue("무슨 일이시죠?");
        stringQueue.Enqueue("나 배가고파 빵을 사다주게.");
        stringQueue.Enqueue("아..알겠습니다.");

        foreach (string dialog in stringQueue)
        {
            talk.text = stringQueue.Peek();
        }
    }

}
