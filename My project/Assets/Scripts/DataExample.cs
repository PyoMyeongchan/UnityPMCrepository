using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[Flags]
// ��ǻ�ʹ� 2�μ��̱⿡ 1���� 0ĭ �������� = 1<<0 (2��0��)
// �޴��� ���Ҷ� 1ĭ�� ���� ������ ����Ѵ�.
public enum DAY
{
    None = 0,
    �� = 1 << 0,
    �� = 1 << 1,
    ȭ = 1 << 2,
    �� = 1 << 3,
    �� = 1 << 4,
    �� = 1 << 5,
    �� = 1 << 6
}

public enum JOB
{
    ������, ��������
}


public class DataExample : MonoBehaviour
{
    public string[] schedules;
    public DAY workDay;
    public JOB job;



    private void Start()
    {
        for (int i = 0; i < schedules.Length; i++)
        {
            Debug.Log(schedules[i]);
        }
        Debug.Log(workDay);
        Debug.Log(job);
    }
}