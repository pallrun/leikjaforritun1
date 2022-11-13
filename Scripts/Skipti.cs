using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);//l�t player hverfa
        StartCoroutine(Bida());//�essi a�fer� b��ur � sm� t�ma
    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);//b��ur � 3 sek�ndur
        Endurr�sa();//fall sem skiptir um sneu
    }
    public void Endurr�sa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//n�sta sena
    }
}

