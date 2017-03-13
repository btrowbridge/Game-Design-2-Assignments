using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

    static Singleton instance = null;
	// Use this for initialization
	void Start ()
    {
		if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}

}
