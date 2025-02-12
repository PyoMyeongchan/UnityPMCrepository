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
        Debug.Log("뛰어옵니다");
    }

    public override void Attack()
    {
        Debug.Log("나뭇가지를 휘두르며 공격합니다.");
    }

}

public class Woman : Emeny
{
    public override void Move()
    {
        Debug.Log("달려듭니다.");
    }
    public override void Attack()
    {
        Debug.Log("도마를 들고 공격합니다.");
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




