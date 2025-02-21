using UnityEngine;


public enum ItemType { Arrow, Life, Key}



public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;
    public int arrangeID = 0; //식별 값

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 타입에 따라 처리할 내용

            switch (type)
            { 
                case ItemType.Arrow:
                    ArrowShoot shoot = collision.gameObject.GetComponent<ArrowShoot>();
                    ItemKeeper.hasArrows += count;
                    break;
                case ItemType.Key:
                    ItemKeeper.haskey += count;
                    break;
                case ItemType.Life:
                    if (PlayerController.hp < 3)
                    {
                        PlayerController.hp++;                    
                    }
                    break;
            
            
            }
        
            // 아이템 획득 시의 연출
            // 아이템이 공통적으로 가지고있는 콜라이더를 비활성화합니다.
           GetComponent<CircleCollider2D>().enabled = false;
            // 아이템이 공통적으로 가지고 있는 리지드바디를 통해 위로 튀어오르는 연출을 표현합니다.
            var itemRbody = GetComponent<Rigidbody2D>();
            itemRbody.gravityScale = 2.5f;
            itemRbody.AddForce(new Vector2(0,6),ForceMode2D.Impulse);
            Destroy(gameObject,0.5f);

        }
    }
}
