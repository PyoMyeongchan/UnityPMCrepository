using System;
using UnityEngine;

public class PMCsample02 : MonoBehaviour
{
    [Tooltip("체크하면 점프가 가능합니다.")]
    public bool isjump = true;

    [Header("과일바구니 안의 과일")]
    public string[] basket;

    public int money;

    [Range(1.0f,99)]
    public float fieldofview;

    [Flags]
    public enum RAINBOW
    {
        빨,주,노,초,파,남,보
    }
}
