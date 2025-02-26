using UnityEngine;

public class DZone : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
;
    }
}
