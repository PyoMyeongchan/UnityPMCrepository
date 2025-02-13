using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����Ƽ���� Ư�� ������ �Ǵ� ����� �����ϱ� ���� ������ �ڷ����� ���°� �ʼ��Դϴ�.
//�⺻ �ڷ��� �̿ܿ� Ư�� ���, �۾��� ������ �� �ִ� ������ ����ü�� �ڷᱸ����� �θ��ڽ��ϴ�.(������ ���� ����)

//���� Ȱ��Ǵ� �ڷᱸ��
//1. List : ������� ������ �� �ְ�, ���� �����͸� �߰�, ����, �˻��� �� �ִ� ������ ������ �迭
//2. Dictionary : Ű - ������ ��� ������ �� �ִ� ����(json ���Ͽ����� Ȯ�� ����)
//3. Queue : �ڷḦ ���Լ���(FIFO)�� ������ �� ����� �ڷ� ����
//4. Stack : �ڷḦ ���Լ���(LIFO)�� ������ �� ����� �ڷ� ����
//5. HashSet : �������� �ߺ��� ���� ������� �ʴ� ���, ���� ������ �ʿ� ���� ���

public class DataStructure : MonoBehaviour
{
    // Queue
    //�������ִ� ��� : ����, ����, ù��° �� ��ȸ ���
    //���� : �߰��� �ִ� �����͸� �����ϴ� �κп��� �ſ� ��ȿ�����Դϴ�. 


    //string ������ ���� ������ �� �ִ� ť
    public Queue<string> stringQueue = new Queue<string>();

    private void Start()
    {
        //1) ť�� ������ �߰�
        stringQueue.Enqueue("�ڳ� �Ѱ��غ��̴µ� �� �� �����ְԳ�");
        stringQueue.Enqueue("�Ѱ������� �ʴµ�..���� ���̽���");
        stringQueue.Enqueue("�츮�� ������ �� ã���ְ�");
        stringQueue.Enqueue("�˰ھ�� ��� ���峪��?");
        stringQueue.Enqueue("������ ���� ���� �� �������� �ֺ��� ������ �����ž�");


        //2) ù��° ������ ��ȸ
        foreach (string dialog in stringQueue)
        {
            Debug.Log(stringQueue.Peek()); //ť�� ����� ���� �� ���� ���� return�մϴ�.
        }

        //3) ť�� ������ ����
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        //ť�� ����� ���� �� ���� ���� return�մϴ�.
        //�߰������� �� ���� ���� �����մϴ�.

    }

}
