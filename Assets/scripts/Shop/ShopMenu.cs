using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{

    // El catálogo que se va a mostrar en la tienda
    private GameObject oldCatalog;
    private TMPro.TextMeshProUGUI RemainingMoneyDisplay;
    private TMPro.TextMeshProUGUI CatchphraseDisplay;

    // Opciones para como se muestra la tienda
    [SerializeField] private GameObject ShopIconPrefab;
    [SerializeField] private Sprite[] ShopSprites;
    [SerializeField] private float DisplayXSpacing;
    [SerializeField] private float DisplayYSpacing;
    [SerializeField] private float DisplayXOffset;
    [SerializeField] private float DisplayYOffset;
    [SerializeField] private float DisplayItemsPerRow;

    // Elementos independientes de lo que se muestra en la tienda
    private GameObject Target;

    // Función que llama la tienda para actualizarla a las cosas de ese vendedor en específico.
    public void Create(Dictionary<int,int> ShopkeeperCatalog, string ShopkeeperCatchphrase, GameObject ShopkeeperTarget){
        Target = ShopkeeperTarget;
        CatchphraseDisplay.text = ShopkeeperCatchphrase;

        // Destroy items from previous loaded catalog
        if(oldCatalog.transform.childCount > 0){
            foreach(Transform child in oldCatalog.transform){
                Destroy(child.gameObject);
            }
        }

        int ItemCount = 0;
        // Crear elementos para los objetos que vende el vendedor
        foreach(var CurrentCatalogItem in ShopkeeperCatalog){

            // Crear icono en pantalla para el objecto
            GameObject current = Instantiate(ShopIconPrefab, new Vector2(0, 0), transform.rotation);
            current.transform.SetParent(oldCatalog.transform);   // Hacer hijo del UI
            current.GetComponent<ShopMenuItem>().Create(ShopSprites[CurrentCatalogItem.Key], CurrentCatalogItem.Key, CurrentCatalogItem.Value, Target); // Poner imagen del objeto en venta
            
            // Fijar coordenadas en UI
            float ComponentX = ( ItemCount % DisplayItemsPerRow )               * DisplayXSpacing + DisplayXOffset;
            float ComponentY = - Mathf.Floor( ItemCount / DisplayItemsPerRow )  * DisplayYSpacing + DisplayYOffset;
            current.GetComponent<RectTransform>().anchoredPosition = new Vector2(ComponentX, ComponentY);
            
            ItemCount++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        oldCatalog = transform.Find("OldCatalog").gameObject;
        RemainingMoneyDisplay = transform.Find("MoneyLabel").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        CatchphraseDisplay = transform.Find("Catchphrase").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RemainingMoneyDisplay.text = $"Dinero: {Target.GetComponent<MoneyManager>().Get()}";
    }
}
