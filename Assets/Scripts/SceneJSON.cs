using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.PlayerLoop;

public class SceneJSON : MonoBehaviour
{
    public GameDataSO GameData; //  Your Scriptable Object Script
    public GameObject player;

    [SerializeField] private TMP_Text levelOneScoreDisplay;
    [SerializeField] private TMP_Text levelTwoScoreDisplay;

    public void Update()
    {
        if ( GameManager.Instance.CurrentLevelName == "Level1" || GameManager.Instance.CurrentLevelName == "Level2")
        {
            UpdateScore();
        }
       
    }

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
            levelOneScoreDisplay.text = "Score:" + GameData.LevelOnePlayerScore;

        }
        else if(GameManager.Instance.CurrentLevelName == "Level2")
        {
            player.transform.position = GameData.LevelTwoPosition;
            levelTwoScoreDisplay.text = "Score:" + GameData.LevelTwoPlayerScore;
        }
    }

    private void UpdateScore()
    {
        if (GameManager.Instance.CurrentLevelName == "Level1" && PatrolPointsList.me!=null)
        {
           
            levelOneScoreDisplay.text = "Score:" + PatrolPointsList.me.playerScore;

        }
        else if (GameManager.Instance.CurrentLevelName == "Level2" && PatrolPointsList.me != null)
        {
            levelTwoScoreDisplay.text = "Score:" + PatrolPointsList.me.playerScore;
        }
    }
}