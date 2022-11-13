using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1;
    public float sideways = 20;
    public float jump = 2;
    //private Rigidbody leikmadur;
    public static int count;
    public Text countText;

    void Start()
    {
        Debug.Log("byrja");

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //sný player
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (Input.GetKey(KeyCode.Space))//hoppa
        {
            transform.position += transform.up * jump * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))//áfram
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))// til baka
        {
            transform.position += -transform.forward * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.RightArrow))//hægri
        {
            transform.position += transform.right * sideways * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("búmm");
            //Vector3 movement = new Vector3(0, 10, 0);
            transform.position += transform.up * jump;
        }
        //hér rétti ég playerinn við ef hann dettur
        if (Input.GetKey("q"))// ef ýtt er á q
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        if (transform.position.y <= -1)
        {
            Endurræsa();
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "peningur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 1;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
        if (collision.collider.tag == "hindrun")
        {
            collision.collider.gameObject.SetActive(false);
            count = count - 1;
            //Debug.Log("Nú er ég komin með " + count);
            SetCountText();//kallar á fallið
        }
    }
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();

        if (count <= 0)
        {
            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
            countText.text = "Dauður " + count.ToString() + " stigum";

            StartCoroutine(Bida());

        }

    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(1);
        Endurræsa();
    }

    public void Endurræsa()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
        SceneManager.LoadScene(0);
    }

}
