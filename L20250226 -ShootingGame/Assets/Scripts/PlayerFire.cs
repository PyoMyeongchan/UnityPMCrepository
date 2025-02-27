using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // 총알 프리팹
    public GameObject firePosition;  // 총구

    public int poolSize = 10;

    GameObject[] bulletObjectPool;

    private void Start()
    {
        // 설정된 크기만큼 풀에 오브젝트 생성
        bulletObjectPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {   
            // 총알생성
            var bullet = Instantiate(bulletFactory);

            // 풀에 등록
            bulletObjectPool[i] = bullet;

            // 비활성화 필요할때 활성화
            bullet.SetActive(false);
        
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left crtl
        {
            for (int i = 0; i < poolSize; i++)
            {
                // 총알생성
                var bullet = bulletObjectPool[i];

                if (bullet.activeSelf == false)
                { 
                    bullet.SetActive (true);
                    bullet.transform.position = firePosition.transform.position;
                    break;

                }
            }


        }
    }
}
