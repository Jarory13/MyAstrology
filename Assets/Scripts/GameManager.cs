using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public UIManager UI;
    private string fileName = "/playerInfo.dat";

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
	void Update ()
    {
		
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);

        PlayerData data = new PlayerData();
        data.Energy = EnergyManager.EnergyMeter;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            EnergyManager.EnergyMeter = data.Energy;
        }
    }

    public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        Canvas[] canvases = UI.GetComponentsInChildren<Canvas>();

        foreach (Canvas canvas in canvases)
        {
            if (canvas.enabled)
            {
                canvas.enabled = !canvas.enabled;
                Time.timeScale = 1.0f;
            }
            else
            {
                canvas.enabled = !canvas.enabled;
                Time.timeScale = 0f;
            }
        }

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }
}

[Serializable]
class PlayerData
{
    public int Energy { get; set; }

}
