using UnityEngine;

public class Game
{
    
}


public class Player : Game
{
    public void Move()
    { 
    
    }
    public void Attack() 
    { 
    
    }
    public void GetWeapon()
    { 
    
    }

    public void GetGold()
    { 
    
    }
    public void Die()
    { 
    
    }

}

public class Emeny : Game
{
    public virtual void Move()
    { }

    public virtual void Attack() 
    { 
    
    }

    public void Die() 
    { 
    
    }

    public void DropGold()
    { 
    
    }
}
public class Weapon : Game
{ 

}

public class Man : Emeny
{
    public override void Move()
    {
        Debug.Log("�پ�ɴϴ�");
    }

    public override void Attack()
    {
        Debug.Log("���������� �ֵθ��� �����մϴ�.");
    }

}

public class Woman : Emeny
{
    public override void Move()
    {
        Debug.Log("�޷���ϴ�.");
    }
    public override void Attack()
    {
        Debug.Log("������ ��� �����մϴ�.");
    }

}

public class Gun : Weapon
{

}
public class Sword : Weapon
{
    

}

public class Gold : Game 
{ 

}




