using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int Money;

    public void Reset(){
        Money = 0;
    }

    public void Set(int amount){
        Money = amount;
    }

    public void Add(int amount){
        Money += amount;
    }

    public void Decrease(int amount){
        Money -= amount;
    }

    public int Get(){
        return Money;
    }
}
