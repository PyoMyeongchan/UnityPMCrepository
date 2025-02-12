using UnityEngine;

public interface Enemy
{
    void Action();
}

//인터페이스나 추상 클래스(abstract class) 사용 목적 1. 비슷한 형태의 데이터 양산이 매우 쉽게 진행됩니다.

public class Goblin : Enemy
{
    public void Action()
    {
        Debug.Log("고블린이 공격을 합니다.");
    }


}

public class Slime : Enemy
{
    public void Action()
    {
        Debug.Log("슬라임이 점프 공격을 합니다.");
    }

}

public class WildBoar : Enemy
{
    public void Action()
    {
        Debug.Log("멧돼지가 달려들어 공격을 합니다.");
    }

}
