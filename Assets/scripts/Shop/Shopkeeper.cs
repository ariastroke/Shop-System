using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{

    // Arrays para fijar parametros
    public int[] Objetos;   // Por id
    public int[] Precios;  
    public string Catchphrase;

    // Diccionario donde se guardan los objetos a vender como <id de objeto, precio>
    private Dictionary<int,int> MyCatalog;

    [SerializeField] private GameObject ShopUI;      // Guarda la interfaz de la tienda
    private bool ShopActivated;     // Si la tienda fue activada por este comerciante

    void Start(){
        // ShopUI = GameObject.Find("Shop UI");

        // Crear catalogo en diccionario a partir de lo que el dev le ha dado
        MyCatalog = new Dictionary<int, int>();

        for(int i = 0; i < Objetos.Length; i++){
            if(i > Precios.Length)
                break;
            MyCatalog.Add(Objetos[i], Precios[i]);
        }
    }

    void Update()
    {
        // Si esta es la tienda activada, desactivarla
        if(Input.GetKey("space") && ShopActivated){
            Time.timeScale = 1;
            ShopActivated = false;
            ShopUI.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        // Activar tienda
        if(other.gameObject.name == "Player"){
            Time.timeScale = 0;
            ShopActivated = true;
            ShopUI.SetActive(true);
            ShopUI.GetComponent<ShopMenu>().Create(MyCatalog, Catchphrase, other.gameObject);
        }
    }
}
