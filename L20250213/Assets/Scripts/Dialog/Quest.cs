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
        
        stringQueue.Enqueue("�ȳ��ϽŰ� �ڳ� �ð��� �Ǹ� �� �����ְԳ�.");
        stringQueue.Enqueue("���� ���̽���?");
        stringQueue.Enqueue("�� �谡���� ���� ����ְ�.");
        stringQueue.Enqueue("��..�˰ڽ��ϴ�.");
                      

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

    