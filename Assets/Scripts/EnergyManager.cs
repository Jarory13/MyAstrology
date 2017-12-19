using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class EnergyManager : MonoBehaviour {

    public static EnergyManager instance;
    public static int EnergyMeter;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
