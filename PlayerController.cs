using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f; // hraða fall
    private float turnSpeed = 45.0f; // beygju fall
    private float horizontalInput; // tekur inn takka skilaboð
    private float forwardInput; // tekur inn takkaskilaboð til að fara aframm
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); 
        forwardInput = Input.GetAxis("Vertical");// færir bilinn aframm eða aftur fer eftir hvað þu ytir a
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); // -- ii --
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); // snyr bilnum eftir takkaskilaboðum
    }
}
