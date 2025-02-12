using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public enum ENEMYTYPE
    { 
        Goblin,Slime,WildBoar
    
    }
   
    /// <summary>
    /// Factory���� �ٷ�� ������ ���¸� return�ϴ� �ڵ�
    /// </summary>
    /// <param name="type">������ ��ü�� ���� ǥ��</param>
    /// <returns></returns>
    public Enemy Create(ENEMYTYPE type)
    {
        switch (type)
        {
            case ENEMYTYPE.Goblin:
                return new Goblin();
            case ENEMYTYPE.Slime:
                return new Slime();
            case ENEMYTYPE.WildBoar:
                return new WildBoar();
            default:
                //���� ��Ȳ �߻�(������ ����� �ȵ� ���)
                throw new System.Exception("���� ����");
        }
    }
    
}
