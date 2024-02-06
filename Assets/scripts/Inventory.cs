using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] List<int> InventoryArray;
    
    public void Reset(){
        InventoryArray.Clear();
    }

    public void Add(int value){
        InventoryArray.Add(value);
    }

    public List<int> Get(){
        return InventoryArray;
    }
}
