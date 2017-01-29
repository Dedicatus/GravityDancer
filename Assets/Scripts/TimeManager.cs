using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    private static TimeManager _instance = null;

    public static TimeManager Instance()
    {
        return _instance;
    }

    public Dictionary<string, float> timeDictionary;

    void Start () {
        _instance = this;
        timeDictionary = new Dictionary<string, float>();
	}
	
	void Update () {
        List<string> keyList = new List<string>();

		foreach (KeyValuePair<string, float> entry in timeDictionary)
        {
            keyList.Add(entry.Key);
            
        }
        foreach (string key in keyList )
        {
            timeDictionary[key] = timeDictionary[key] - Time.deltaTime;
            if (timeDictionary[key] < 0)
            {
                timeDictionary.Remove(key);
            }
        }
	}
}
