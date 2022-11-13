using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);//læt player hverfa
        StartCoroutine(Bida());//þessi aðferð bíður í smá tíma
    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);//bíður í 3 sekúndur
        Endurræsa();//fall sem skiptir um sneu
    }
    public void Endurræsa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//næsta sena
    }
}

