using System;
using UnityEngine;

public class PMCsample02 : MonoBehaviour
{
    [Tooltip("üũ�ϸ� ������ �����մϴ�.")]
    public bool isjump = true;

    [Header("���Ϲٱ��� ���� ����")]
    public string[] basket;

    public int money;

    [Range(1.0f,99)]
    public float fieldofview;

    [Flags]
    public enum RAINBOW
    {
        ��,��,��,��,��,��,��
    }
}
