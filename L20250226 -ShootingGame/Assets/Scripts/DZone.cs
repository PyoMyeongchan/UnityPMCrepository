using UnityEngine;

public class DZone : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        { 
            other.gameObject.SetActive(false);
        }
;
    }
}
