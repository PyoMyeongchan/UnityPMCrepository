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
        

    public int Count //ť ���� ��������
    {
        get { return stringQueue.Count; }
    }


    public void Start()
    {
        stringQueue.Enqueue("�ȳ��ϽŰ� �ڳ� �ð��� �Ǹ� �� �����ְԳ�.");
        stringQueue.Enqueue("���� ���̽���?");
        stringQueue.Enqueue("�� �谡���� ���� ����ְ�.");
        stringQueue.Enqueue("��..�˰ڽ��ϴ�.");

        foreach (string dialog in stringQueue)
        {
            talk.text = stringQueue.Peek();
        }
    }

}
