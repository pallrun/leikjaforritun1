using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class byrtir : MonoBehaviour
{
    private Transform player;
    public GameObject enemy;
    public int radius = 20;

    void Start()
    {
        player = GameObject.Find("player").transform; //finn leikmanninn
    }
    void Update()
    {
        if ((player.transform.position-this.transform.position).sqrMagnitude<3*radius) //ath hvort leikmaður se nalægt
        {
            Destroy(this.gameObject); //eyðilegg byrtir
            Instantiate(enemy, transform.position, new Quaternion(0, 0 , 0, 1)); //byrta ovin
        }
    }
}
