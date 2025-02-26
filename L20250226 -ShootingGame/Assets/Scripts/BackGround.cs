using UnityEngine;

// 배경 스크롤 기능을 만들겁니다.
// 확인한 것 : 머티리얼의 offset을 건드렸더니 이미지가 밀림.
// 필요한 것 : 머티리얼, 스크롤링 속도
// 어떻게 진행할 것인가? 위로? 아래로? 옆으로?

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
