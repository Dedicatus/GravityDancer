using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootTrigger : MonoBehaviour {

    Player parent;

    public int collisionCount = 0;

    private void Start()
    {
        parent = transform.parent.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && other.tag != "ExtraTriggers")
        {
            collisionCount++;
            parent.Grounded();
        }
    }

    void Update()
    {
        if (collisionCount > 0)
            parent.Grounded();
        else
            parent.NotGrounded();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "ExtraTriggers")
        {
            collisionCount--;
            if(collisionCount == 0)
                parent.NotGrounded();
        }
        parent.NotGrounded();
    }
}
