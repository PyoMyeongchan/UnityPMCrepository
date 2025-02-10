using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[Flags]
// 컴퓨터는 2인수이기에 1에서 0칸 움직여라 = 1<<0 (2에0승)
// 메뉴를 정할때 1칸씩 띄우는 것으로 사용한다.
public enum DAY
{
    None = 0,
    일 = 1 << 0,
    월 = 1 << 1,
    화 = 1 << 2,
    수 = 1 << 3,
    목 = 1 << 4,
    금 = 1 << 5,
    토 = 1 << 6
}

public enum JOB
{
    직장인, 프리랜서
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