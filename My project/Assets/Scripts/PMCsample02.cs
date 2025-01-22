using System;
using UnityEngine;

public class PMCsample02 : MonoBehaviour
{
    [Tooltip("체크하면 점프가 가능합니다.")]
    public bool isdead = true;

    [Header("과일바구니 안의 과일")]
    public string fruit;

    public int money;

    [Range(1,99)]
    public int fieldview;

    [Flags]
    public enum RAINBOW
    {
        빨 = 1 << 0,
        주 = 1 << 1,
        노 = 1 << 2,
        초 = 1 << 3,
        파 = 1 << 4,
        남 = 1 << 5,
        보 = 1 << 6
    }
}
