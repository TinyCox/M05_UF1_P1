using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Bordes {
    public float bordeSuperior, bordeInferior, bordeDerecha, bordeIzquierda;
}

public class BordesTP : MonoBehaviour
{
    public Bordes bordes;

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var x = transform.position.x;
        var y = transform.position.y;

        if (x > bordes.bordeDerecha)
        {
            pos.x = bordes.bordeIzquierda;
            transform.position = pos;
        }
        if (x < bordes.bordeIzquierda)
        {
            pos.x = bordes.bordeDerecha;
            transform.position = pos;
        }
        if (y > bordes.bordeSuperior)
        {
            pos.y = bordes.bordeInferior;
            transform.position = pos;
        }
        if (y < bordes.bordeInferior)
        {
            pos.y = bordes.bordeSuperior;
            transform.position = pos;
        }
    }
}
