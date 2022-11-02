using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    private Rigidbody2D rb;
    public float acceleration;
    public float ratioDisparo = 0.5f;
    private float Vertical;
    private float Horizontal;
    private bool Disparando;
    public float velocidadMax;
    public float drag;
    public float velocidadAngular;
    public Vector2 posicionProyectil;
    public GameObject proyectilPrefab;
    public float proyectilOffset;
    public bool puedeDisparar = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;
    }

    // Update is called once per frame
    void Update()
    {
        Vertical = InputManager.Vertical;
        Horizontal = InputManager.Horizontal;
        Disparando = InputManager.Disparar;
        Rotar();
        Disparo();
    }

    void FixedUpdate()
    {
        var forwardMotor = Mathf.Clamp (Vertical, 0f, 1f);
        rb.AddForce (transform.up * acceleration * forwardMotor);
        if (rb.velocity.magnitude > velocidadMax)
        {
            rb.velocity = rb.velocity.normalized * velocidadMax;
        }
    }

   void Rotar()
   {
    
        if (Horizontal == 0)
        {
            return;
        }
        transform.Rotate (0, 0, -velocidadAngular * Horizontal * Time.deltaTime);
   } 
   
   public void Lose()
   {
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
   }

   void Disparo()
   {
        if (Disparando && puedeDisparar)
        {
            StartCoroutine(VelocidadDisparo());
        }
   }
   private IEnumerator VelocidadDisparo()
   {
        puedeDisparar = false;
        var pos = transform.up * proyectilOffset + transform.position;

        var proyectil = Instantiate (
            proyectilPrefab, pos, transform.rotation
        );
        Destroy (proyectil, 5);
        yield return new WaitForSeconds (ratioDisparo);
        puedeDisparar = true;
   }
}
