using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float SpeedX;
    private float SpeedY;

    [SerializeField] private float Speed;
    [SerializeField] private float Friction;

    void Move(){
        if(Input.GetKey("up")){
            SpeedY = Speed;
        }
        if(Input.GetKey("down")){
            SpeedY = -Speed;
        }
        if(Input.GetKey("left")){
            SpeedX = -Speed;
        }
        if(Input.GetKey("right")){
            SpeedX = Speed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpeedX = 0;
        SpeedY = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Aplicar movimiento
        Move();

        // Mover personaje y reducir velocidad
        transform.position += new Vector3(SpeedX, SpeedY, 0f);
        SpeedX = SpeedX * Friction;
        SpeedY = SpeedY * Friction;
    }
}
