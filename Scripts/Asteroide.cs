using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject[] subAsteroides;
    public int numeroAsteroides;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;
        rb.angularDrag = 0;

        rb.velocity = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0
        ).normalized * speed;
        
        rb.angularVelocity = Random.Range(-50f, 50f);
    }
    private bool isDestroying = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(isDestroying == true)
            return;
        if (other.CompareTag("Proyectil"))
        {
            isDestroying = true;
            Destroy(gameObject);
            Destroy (other.gameObject);
            for (var i = 0; i < numeroAsteroides; i++)
            {
                Instantiate (
                    subAsteroides[Random.Range(0, subAsteroides.Length)],
                    transform.position,
                    Quaternion.identity
                );
            }
        }
        if (other.CompareTag("Player"))
        {
            var asteroides = FindObjectsOfType<Asteroide>();
            for (var i = 0; i < asteroides.Length; i++){
                Destroy(asteroides[i].gameObject);
            }
            other.GetComponent<Jugador>().Lose();
        }
    }
}
