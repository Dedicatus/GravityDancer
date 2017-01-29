using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootTrigger : MonoBehaviour {

    Player parent;

    private void Start()
    {
        parent = transform.parent.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        parent.canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        parent.canJump = false;
    }
}
