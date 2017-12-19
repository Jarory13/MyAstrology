using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class EnergyManager : MonoBehaviour {

    public static EnergyManager instance;
    public static int EnergyMeter;

    [SerializeField]
    private int EnergyLimit = 20;
    [SerializeField]
    private float timeBetweenRefills = 3 * 60;
    private float timeToNextRefill;
    private int EnergyToAdd = 1;


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
        //TODO: Get date time since last start in player pref then set that as last time in player prefs

        //int lastTime = PlayerPrefs.GetInt("LastTime");
        //if (lastTime == 0)
        //{
        //    Debug.Log("Last time doesnt exist ");
        //    lastTime = DateTime.
        //    PlayerPrefs.SetInt("LastTime", lastTime);
        //}
        //else
        //{
        //    Debug.Log("Last time is " + lastTime);
        //}

        timeToNextRefill = Time.time + timeBetweenRefills;
    }
	
	// Update is called once per frame
	void Update ()
    {
        TrackEnergyTime();

    }

    public void ReduceEnergy(int amount)
    {
        EnergyMeter -= amount;
        if (EnergyMeter < 0)
        {
            EnergyMeter = 0;
        }
    }

    public void AddEnergy(int amount)
    {
        EnergyMeter += amount;
        if (EnergyMeter > EnergyLimit)
        {
            EnergyMeter = EnergyLimit;
        }
    }

    private void TrackEnergyTime()
    {
        if (Time.time > timeToNextRefill)
        {
            AddEnergy(EnergyToAdd);
            timeToNextRefill = Time.time + timeBetweenRefills;
        }
    }
}
