using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f; // hra�a fall
    private float turnSpeed = 45.0f; // beygju fall
    private float horizontalInput; // tekur inn takka skilabo�
    private float forwardInput; // tekur inn takkaskilabo� til a� fara aframm
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); 
        forwardInput = Input.GetAxis("Vertical");// f�rir bilinn aframm e�a aftur fer eftir hva� �u ytir a
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); // -- ii --
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime); // snyr bilnum eftir takkaskilabo�um
    }
}
