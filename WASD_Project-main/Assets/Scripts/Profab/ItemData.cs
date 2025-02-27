using Unity.VisualScripting;
using UnityEngine;

public enum ItemType { key }

public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            { 
                case ItemType.key:
                    ItemKeeper.haskey += count;
                    break;
            
            
            }

            GetComponent<CircleCollider2D>().enabled = false;

            var itemRbody = GetComponent<Rigidbody2D>();
            var itemTransform = GetComponent<Transform>();
            itemTransform.rotation = Quaternion.Euler(0, 0, 90);
            itemRbody.gravityScale = 0f;
            itemRbody.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            Destroy(gameObject, 0.5f);

        
        }
    }

}
