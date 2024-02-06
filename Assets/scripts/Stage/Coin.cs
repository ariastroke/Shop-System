using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player"){
            transform.position = new Vector2(Random.Range(-10,10), Random.Range(-5,5));
            other.GetComponent<MoneyManager>().Add(1);
        }
    }
}
