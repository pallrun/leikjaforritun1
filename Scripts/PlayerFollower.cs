using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    bool lookAt = true;
    Space offsetPositionSpace = Space.Self;
    // Update is called once per frame
    void Update()
    {
        if (offsetPositionSpace==Space.Self)
        {
            transform.position = player.TransformPoint(offset);
        }
        else
        {
            transform.position = player.position + offset;//myndavél aðeins fyrir aftan player
        }
        if (lookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }
    }
}
