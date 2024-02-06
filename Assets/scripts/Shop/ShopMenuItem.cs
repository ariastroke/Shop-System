using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuItem : MonoBehaviour
{

    private GameObject Target;
    private int Item;
    private int Price;

    public void Create(Sprite mySprite, int newItem, int newPrice, GameObject newTarget){

        Item = newItem;
        Price = newPrice;

        transform.GetChild(0).gameObject.GetComponent<Image>().sprite = mySprite;
        transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = $"${newPrice}";

        Target = newTarget;
    }

    public void Purchase(){
        Debug.Log($"Compro {Item} al precio de {Price}");
        if( Target.GetComponent<MoneyManager>().Get() >= Price ){
            Target.GetComponent<MoneyManager>().Decrease(Price);
            Target.GetComponent<Inventory>().Add(Item);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
