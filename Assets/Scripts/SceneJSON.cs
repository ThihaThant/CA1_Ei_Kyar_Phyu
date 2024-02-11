using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SceneJSON : MonoBehaviour
{
    public GameDataSO GameData; //  Your Scriptable Object Script
    public GameObject player;


    public void savePrefs()
    {
        //whichever file path you want
        String path = Application.dataPath + "/Scripts/Output/";
        //json file name
        String jsonName = "saveData.json";
        //if don't have file path, create path
        if (!Directory.Exists(path))
        {
            Debug.Log("Create Directory");
            Directory.CreateDirectory(path);
        }

        //Save Scriptable object as json
        string json = JsonUtility.ToJson(GameData);
        System.IO.File.WriteAllText(Path.Combine(path, jsonName), json);
    }

    public void loadPrefs()
    {

        //File path same as on top
        string filePath = Application.dataPath + "/Scripts/Output/SaveData.json";
        if (System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            //Load Scriptable object as json

            JsonUtility.FromJsonOverwrite(json, GameData);
        }
        if (GameManager.Instance.CurrentLevelName == "Level1")
        {
            player.transform.position = GameData.LevelOnePosition;
        }
        else
        {
            player.transform.position = GameData.LevelTwoPosition;
        }
    }
}