using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Sprite openImage;
    public GameObject itemPrefab;
    public bool isClosed = true;
    public int arrangeID = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClosed && collision.gameObject.tag == "Player")
        { 
            GetComponent<SpriteRenderer>().sprite = openImage;
            isClosed = false;
            if (itemPrefab != null)
            {
                Instantiate(itemPrefab, transform.position, Quaternion.identity);


            }

        
        
        }
    }
}
