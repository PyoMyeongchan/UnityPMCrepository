using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // �Ѿ� ������
    public GameObject firePosition;  // �ѱ�

    public int poolSize = 10;

    GameObject[] bulletObjectPool;

    private void Start()
    {
        // ������ ũ�⸸ŭ Ǯ�� ������Ʈ ����
        bulletObjectPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {   
            // �Ѿ˻���
            var bullet = Instantiate(bulletFactory);

            // Ǯ�� ���
            bulletObjectPool[i] = bullet;

            // ��Ȱ��ȭ �ʿ��Ҷ� Ȱ��ȭ
            bullet.SetActive(false);
        
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left crtl
        {
            for (int i = 0; i < poolSize; i++)
            {
                // �Ѿ˻���
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
