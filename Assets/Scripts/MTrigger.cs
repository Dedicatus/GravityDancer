using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MTrigger : MonoBehaviour {
    public UnityEvent triggerEnterEvent;
    public UnityEvent triggerExitEvent;

    void OnTriggerEnter()
    {
        if(triggerEnterEvent != null)
            triggerEnterEvent.Invoke();
    }

    void OnTriggerExit()
    {
        if(triggerExitEvent != null)
            triggerExitEvent.Invoke();
    }
}
