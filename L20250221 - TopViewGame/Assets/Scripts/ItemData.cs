using UnityEngine;


public enum ItemType { Arrow, Life, Key}



public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;
    public int arrangeID = 0; //�ĺ� ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Ÿ�Կ� ���� ó���� ����

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
        
            // ������ ȹ�� ���� ����
            // �������� ���������� �������ִ� �ݶ��̴��� ��Ȱ��ȭ�մϴ�.
           GetComponent<CircleCollider2D>().enabled = false;
            // �������� ���������� ������ �ִ� ������ٵ� ���� ���� Ƣ������� ������ ǥ���մϴ�.
            var itemRbody = GetComponent<Rigidbody2D>();
            itemRbody.gravityScale = 2.5f;
            itemRbody.AddForce(new Vector2(0,6),ForceMode2D.Impulse);
            Destroy(gameObject,0.5f);

        }
    }
}
