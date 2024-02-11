using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class Player : MonoBehaviour
{
    public float Health_amt;
    public float HealthMax_amt;
    public GameObject dealth_pp;
    public static string player_id;
    public PostProcessVolume postProcessVolume;
    public GameObject canvasForGameOver;


    public void Damage(float _dmg)
    {
        Health_amt -= _dmg;
        Health_amt = Mathf.Max(Health_amt, 0f);
        if(Health_amt > 75)
        {
            SetIntensity(0.2f);
        }

        else if(Health_amt > 50)
        {
            SetIntensity(0.5f);
        }
        else if(Health_amt > 25)
        {
            SetIntensity(0.8f);
        }
        else if (Health_amt == 0)
        {
            SetIntensity(1.0f);
            /*if (canvasForGameOver != null)
            {

                Vector3 canvasPosition = Camera.main.transform.position + Camera.main.transform.forward * 2f; // Adjust distance as needed

                // Create a canvas as a child of the player's camera
                GameObject canvasObj = Instantiate(canvasForGameOver, canvasPosition, Quaternion.identity, Camera.main.transform);

                // Rotate the canvas to face the camera's forward direction
                canvasObj.transform.LookAt(Camera.main.transform.position + Camera.main.transform.forward);

                // Ensure the canvas is facing forward by offsetting its rotation
                canvasObj.transform.Rotate(0f, 180f, 0f);

                // Optionally, set canvas properties or activate/deactivate as needed
                canvasObj.SetActive(true);

            }*/
            GameManager.Instance.transferToAnotherScene("GameOver", SceneManager.GetSceneAt(1).name);
            gameObject.transform.parent.parent.parent.position = Vector3.zero;
        }

    }

    void SetIntensity(float intensity)
    {
        if (postProcessVolume != null)
        {
            postProcessVolume.weight = intensity;
        }
    }
}
