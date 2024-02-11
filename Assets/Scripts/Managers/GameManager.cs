using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//---------------------------------------------------------------------------------
// Author		: Vincent
// Date  		: 2023-08-21
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
//#define DEBUG_DrawMousePoint

//namespace WAPIGS{
//[RequireComponent(typeof(Rigidbody))]
public class GameManager : Singleton<GameManager>
{
    public GameObject splashImage;

    private string _currentLevelName = string.Empty;

    private const string BrightnessKey = "Brightness";

    // Get the name of the current level.
    public string CurrentLevelName { get { return _currentLevelName; } }

    List<AsyncOperation> _loadOperations;

    public GameObject LevelOneScore;
    public GameObject LevelTwoScore;
    public GameObject MenuCanvas;

    public GameDataSO gameData;
    public Transform playerTransform;
    public GameObject player;


    private void Start()
    {
        // Ensure that this GameManager persists across scene changes.
        DontDestroyOnLoad(gameObject);

        // Initialize the list to track async load operations.
        _loadOperations = new List<AsyncOperation>();

        // Load the initial scene, such as the Main Menu.
        // LoadLevel("MainMenu");
        StartCoroutine(DisplayImageForTime(3f));

        // CheckScene(playerTransform);
        if (_currentLevelName == "Level1")
        {

            player.transform.position = gameData.LevelOneLocation;
         //   levelOneScoreDisplay.text = ("Score:" + gameData.LevelOnePlayerScore);

        }
        else if (_currentLevelName == "Level2")
        {
            player.transform.position = gameData.LevelTwoLocation;
           // levelTwoScoreDisplay.text = ("Score:" + gameData.LevelTwoPlayerScore);
        }
    }

    private void Update()
    {
        CheckScene(playerTransform);
    }

    private IEnumerator DisplayImageForTime(float displayTime)
    {
        // Activate the image object
       // imageToDisplay.SetActive(true);

        // Wait for the specified duration
        yield return new WaitForSeconds(displayTime);

        // Deactivate the image after the specified time
        splashImage.SetActive(false);

        // Load the initial scene, such as the Main Menu.
        LoadLevel("MainMenu");
    }

    // Called when an asynchronous load operation is completed.
    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);


        }
    }

    // Called when an asynchronous unload operation is completed.
    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Unload Complete");
    }

    // Load a new scene by name asynchronously.
    private AsyncOperation LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to laod level " + levelName);

            return null;
        }

        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        _currentLevelName = levelName;

        return ao;
    }

    // Unload a scene by name asynchronously.
    public void UnloadLevel(string levelName)
    {

        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unlaod level " + levelName);
            return;
        }

        ao.completed += OnUnloadOperationComplete;
    }

    // Replace the current scene with a new scene while unloading the old one.
    //public void transferToAnotherScene(string newLevelName, string sceneToUnload)
    public AsyncOperation transferToAnotherScene(string newLevelName, string sceneToUnload)
    {
        if (string.IsNullOrEmpty(newLevelName) || string.IsNullOrEmpty(sceneToUnload))
        {
           
            Debug.LogError("Invalid scene names provided.");
            return null;
        }
        

        // Unload the scene to be replaced
        UnloadLevel(sceneToUnload);

        // Load the new scene while keeping the persistent scene loaded
        //LoadLevel(newLevelName);

        AsyncOperation operation = LoadLevel(newLevelName);
        player.transform.parent.parent.transform.position = gameData.LevelOneLocation;
        // Update the current level name
        _currentLevelName = newLevelName;
        return operation;
    }

    public float GetBrightness()
    {
        if (PlayerPrefs.HasKey(BrightnessKey))
        {
            return PlayerPrefs.GetFloat(BrightnessKey);
        }
        return 1.0f; // Default value if brightness not set yet
    }

    public void SetBrightness(float brightness)
    {
        PlayerPrefs.SetFloat(BrightnessKey, brightness);
        PlayerPrefs.Save();
    }

    private void CheckScene(Transform newTransform)
    {
        if (_currentLevelName == "Level1")
        {
            LevelTwoScore.SetActive(false);
            LevelOneScore.SetActive(true);
            MenuCanvas.SetActive(true);

            Vector3 leveloneTransform = newTransform.position;
            gameData.UpdateLevelOneLocation(leveloneTransform);

        }
        else if (_currentLevelName == "Level2")
        {
            LevelOneScore.SetActive(false);
            LevelTwoScore.SetActive(true);
            MenuCanvas.SetActive(true);

            Vector3 leveltwoTransform = newTransform.position;
            gameData.UpdateLevelTwoLocation(leveltwoTransform);
        }
    }
}
//}