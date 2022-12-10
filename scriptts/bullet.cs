using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject gem;
    SpriteRenderer sprite;

    void Start()
    {
        rb.velocity = transform.right * speed; //sendi hann flugandi
        transform.Rotate(0f, 180f, 0f); //sny honum rett
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy"){
            Destroy(gameObject); //eyði hnif
            Instantiate(gem, other.transform.position, other.transform.rotation); //spawna demant
            other.gameObject.SetActive(false); // eyði leðurbloku
            //StartCoroutine(Hit(other));
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        Destroy(gameObject); // eyði hnif ef klessir a vegg
    }
}
