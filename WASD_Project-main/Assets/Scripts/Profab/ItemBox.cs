using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject itemPrefab;
    public bool isClosed = true;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClosed && collision.gameObject.tag == "Player")
        { 
            isClosed = false;

            if (itemPrefab != null)
            {
                Instantiate(itemPrefab,transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
