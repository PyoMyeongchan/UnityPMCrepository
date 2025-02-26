using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // �Ѿ� ������
    public GameObject firePosition;  // �ѱ�

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left crtl
        {
            // �Ѿ� ����
            GameObject bullet = Instantiate(bulletFactory);

            // �Ѿ� ��ġ ����
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
