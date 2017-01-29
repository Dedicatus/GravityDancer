using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootTrigger : MonoBehaviour {

    Player parent;

    int collisionCount = 0;

    private void Start()
    {
        parent = transform.parent.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            collisionCount++;
            parent.Grounded();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            collisionCount--;
            if(collisionCount == 0)
            parent.NotGrounded();
        }
        parent.NotGrounded();
    }
}
