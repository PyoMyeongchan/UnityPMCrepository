using UnityEngine;

// ��� ��ũ�� ����� ����̴ϴ�.
// Ȯ���� �� : ��Ƽ������ offset�� �ǵ�ȴ��� �̹����� �и�.
// �ʿ��� �� : ��Ƽ����, ��ũ�Ѹ� �ӵ�
// ��� ������ ���ΰ�? ����? �Ʒ���? ������?

public class BackGround : MonoBehaviour
{
    public Material backgroundMaterial;

    public float scrollSpeed = 0.2f;

    void Update()
    {
        Vector2 dir = Vector2.up;

        backgroundMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
}
