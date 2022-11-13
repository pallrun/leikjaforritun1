using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Takki : MonoBehaviour
{
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    public void Endir()
    {
        SceneManager.LoadScene(0);//upphafssenan
        PlayerMovment.count = 0;//núll stilli stigin
    }

}
