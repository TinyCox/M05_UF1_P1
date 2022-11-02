using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoProyectil : MonoBehaviour
{
    public float speed;

    void Update(){
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
