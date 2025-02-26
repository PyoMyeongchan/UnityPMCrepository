using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // ÃÑ¾Ë ÇÁ¸®ÆÕ
    public GameObject firePosition;  // ÃÑ±¸

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left crtl
        {
            // ÃÑ¾Ë »ý¼º
            GameObject bullet = Instantiate(bulletFactory);

            // ÃÑ¾Ë À§Ä¡ º¯°æ
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
