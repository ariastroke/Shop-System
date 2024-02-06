using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class DefaultScene : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI Display;
    [SerializeField] private GameObject Target;
    [SerializeField] private Sprite[] ItemSprites;
    [SerializeField] private GameObject ItemTemplate;
    [SerializeField] private float DisplayXSpacing;
    [SerializeField] private float DisplayXOffset;

    private MoneyManager PlayerMoney;
    private Inventory PlayerInv;

    private List<int> oldInventory;
    private GameObject InventoryContainer;

    bool CompareLists(List<int> first, List<int> second){
        if(first == null || second == null){
            return false;
        }
        return first.SequenceEqual(second);
    }

    void RefreshInventory(){
        int count = 0;

        if(InventoryContainer.transform.childCount > 0){
            foreach(Transform item in InventoryContainer.transform){
                Destroy(item.gameObject);
            }
        }

        foreach(int current in oldInventory){
            GameObject CurrentIcon = Instantiate(ItemTemplate, new Vector2(0, 0), transform.rotation);

            CurrentIcon.transform.SetParent(InventoryContainer.transform);
            CurrentIcon.GetComponent<Image>().sprite = ItemSprites[current];

            float ComponentX = count * DisplayXSpacing;
            CurrentIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(ComponentX, 0);

            count++;
        }
    }

    void Start(){
        InventoryContainer = transform.Find("Inventory").gameObject;

        PlayerMoney = Target.GetComponent<MoneyManager>();
        PlayerInv = Target.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        Display.text = $"Dinero: {PlayerMoney.Get()}";
        if(!CompareLists(PlayerInv.Get(), oldInventory)){
            oldInventory = PlayerInv.Get().ToList();
            RefreshInventory();
            Debug.Log("El inventario del jugador ha cambiado!");
        }
    }
}
