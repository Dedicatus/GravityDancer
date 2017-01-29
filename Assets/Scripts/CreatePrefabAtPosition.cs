using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabAtPosition : MonoBehaviour {

    public GameObject prefab;
    public Vector3 pos;

    public void createPrefabAtPosition (Transform tran)
    {
        Instantiate(prefab, tran);
    }

    public void createPrefabAtPosition(Vector3 pos)
    {
        GameObject obj = (GameObject) Instantiate(prefab);
        obj.transform.position = pos;
    }
}
