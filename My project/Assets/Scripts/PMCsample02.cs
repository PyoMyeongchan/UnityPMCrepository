using System;
using UnityEngine;

public class PMCsample02 : MonoBehaviour
{
    [Tooltip("üũ�ϸ� ������ �����մϴ�.")]
    public bool isdead = true;

    [Header("���Ϲٱ��� ���� ����")]
    public string fruit;

    public int money;

    [Range(1,99)]
    public int fieldview;

    [Flags]
    public enum RAINBOW
    {
        �� = 1 << 0,
        �� = 1 << 1,
        �� = 1 << 2,
        �� = 1 << 3,
        �� = 1 << 4,
        �� = 1 << 5,
        �� = 1 << 6
    }
}
