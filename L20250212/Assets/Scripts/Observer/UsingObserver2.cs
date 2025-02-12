using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//인터페이스 ISubject를 기반으로 설계하는 옵저버 사용 예제
public class UsingObserver2 : MonoBehaviour, ISubject
{
    List<UObserver> observers = new List<UObserver>();

    public void Add(UObserver observer)
    {
        observers.Add(observer);

    }
   
    //갱신
    public void Notigfy()
    {
        foreach (UObserver observer in observers)
        {
            observer.OnNotify();
        }


    }

    //옵저버 제거
    public void Remove(UObserver observer)
    {
        if (observers.Count >0)
        observers.Remove(observer);
    
    }

    void Start()
    {
        var observer1 = new Observer1();
        var observer2 = new Observer2();
        
        Add(observer1);
        Add(observer2);
    
    }



}
