using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneTransitionButton : MonoBehaviour
{
    public string newSceneName;  // The name of the scene to transition to.
    public GameObject loadingScreen;
    public Slider slider;
    public float transitionTime = 2.0f;
    public CanvasGroup mainMenu;
    public GameObject player;
    public void OnButtonClick()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        if (GameManager.Instance != null)
        {
            string sceneToUnload = GameManager.Instance.CurrentLevelName;
            if (loadingScreen != null && slider != null)
            {
                loadingScreen.SetActive(true);

                // loadingScreen.SetActive(true);

                float timer = 0f;

                while (timer < transitionTime)
                {
                    timer += Time.deltaTime;
                    float progress = Mathf.Clamp01(timer / transitionTime);
                    // slider.value = progress;
                    Debug.Log(progress + " snfosdnvio");
                    slider.value = progress;

                    yield return null;
                }

            }
            AsyncOperation asyncOperation = GameManager.Instance.transferToAnotherScene(newSceneName, sceneToUnload);

            if (loadingScreen != null && slider!= null)
            {
                 loadingScreen.SetActive(false);
                 // Ensure the slider reaches the end when the transition is completed
                 slider.value = 1;
            }

            /* loadingScreen.SetActive(false);
             // Ensure the slider reaches the end when the transition is completed
             slider.value = 1;*/
        }
        else
        {
            // Display an error message if GameManager is not properly initialized.
            Debug.LogError("GameManager.Instance is not available. Make sure GameManager is properly initialized.");
        }
    }
    public void HideMenu()
    {
        if(mainMenu != null)
        {
            mainMenu.alpha = 0f;
        }
       
    }
    public void Level2()
    {
        GameObject.Find("XR Origin (XR Rig)").transform.position=Vector3.zero;
        EnemyController.kill_all_enemies = false;
    }
    public void reset_player()
    {
        player.transform.position = Vector3.zero;
    }
}
