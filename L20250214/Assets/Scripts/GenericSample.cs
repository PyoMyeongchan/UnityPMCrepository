using UnityEngine;

//C# �Ϲ�ȭ ���α׷���(Generic Programming)
//������ ���Ŀ� ���� �Ϲ�ȭ�� �����ϴ� ����Դϴ�.
//<T>�� �̿��ؼ� �����ϴ� ����� �ǹ��մϴ�.

public class GenericSample : MonoBehaviour
{
    //�迭�� ���޹޾Ƽ� �迭�� ��Ҹ� ������� ����ϴ� �ڵ�
    public static void printIArray(int[] number)
    {
        for (int i = 0; i < number.Length; i++)
        { 
            Debug.Log(number[i]);
        
        }
    
    }

    public static void printFArray(float[] number)
    {
        for (int i = 0; i < number.Length; i++)
        {
            Debug.Log(number[i]);

        }

    }

    public static void printSArray(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            Debug.Log(words[i]);

        }

    }

    public static void printGArray<T>(T[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            Debug.Log(values[i]);

        }

    }


    void Start()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        float[] numbers2 = { 1.1f, 1.2f, 3.3f, 4.4f };
        string[] words = { "hello", "hi" };
        printGArray<int>(numbers);
        printGArray(numbers2);
        printGArray<string>(words);
    }

    
}
