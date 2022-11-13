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
        //sn� player
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))//sn�a leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (Input.GetKey(KeyCode.Space))//hoppa
        {
            transform.position += transform.up * jump * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))//�fram
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))// til baka
        {
            transform.position += -transform.forward * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.RightArrow))//h�gri
        {
            transform.position += transform.right * sideways * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//vinstri
        {
            //hreyfir player um sideways � hvert skipti sem �tt er � leftArrow
            transform.position += -transform.right * sideways * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("b�mm");
            //Vector3 movement = new Vector3(0, 10, 0);
            transform.position += transform.up * jump;
        }
        //h�r r�tti �g playerinn vi� ef hann dettur
        if (Input.GetKey("q"))// ef �tt er � q
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        if (transform.position.y <= -1)
        {
            Endurr�sa();
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "peningur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 1;
            //Debug.Log("N� er �g komin me� " + count);
            SetCountText();//kallar � falli�
        }
        if (collision.collider.tag == "hindrun")
        {
            collision.collider.gameObject.SetActive(false);
            count = count - 1;
            //Debug.Log("N� er �g komin me� " + count);
            SetCountText();//kallar � falli�
        }
    }
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();

        if (count <= 0)
        {
            this.enabled = false;//kemur � veg fyrir a� playerinn geti hreyfst �fram eftir dau�an
            countText.text = "Dau�ur " + count.ToString() + " stigum";

            StartCoroutine(Bida());

        }

    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(1);
        Endurr�sa();
    }

    public void Endurr�sa()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
        SceneManager.LoadScene(0);
    }

}
