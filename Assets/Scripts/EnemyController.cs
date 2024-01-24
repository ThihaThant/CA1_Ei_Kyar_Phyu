using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Image Health_image;
    public float Health_amt, HealthMax_amt;
    public GameObject HealthBar_canvas;
    public Animator _ani;
    public GameObject Blood_ps;
    public GameObject magazineTen;
    public GameObject magazineTwenty;
    public GameObject magazineThirty;
    public GameObject canvasForMutant;
    private Animator[] animators;
    private NavMeshAgent _nav;
    // private int playerScore = 0;
    //  public GameObject firstGem;
    //  public GameObject controller;
    // public AudioClip gemAppearSound;
    //  private AudioSource gemAudioSource;
    //  private Coroutine gemSoundCoroutine;

    private void Start()
    {
        animators = transform.parent.GetComponentsInChildren<Animator>();
        _nav = transform.parent.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        HealthBar_canvas.transform.LookAt(Camera.main.transform.position);
        UpdateHealthBar();

    }

   /* private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            float damage = 20f;
            TakeDamage(damage);
            Debug.Log("Current Health: " + Health_amt);
        }
    }
   */

    public void TakeDamage(float damage)
    {
        Health_amt -= damage;
        //GameObject _blood = Instantiate(Blood_ps);
        GameObject _blood = Instantiate(Blood_ps, transform.position, Quaternion.identity);

        Health_amt = Mathf.Max(Health_amt); // Ensure health doesn't go below 0


        if (Health_amt == 0f)
        {
            _nav.isStopped = true;
            foreach (var item in animators)
            {
                item.SetTrigger("Death");
            }
            //Transform parentTransform = transform.parent;

            //  Destroy(transform.parent.gameObject,10f);
            //Destroy(gameObject);
            Destroy(gameObject.transform.parent.gameObject, 4f);
            Vector3 enemyPosition = transform.position; // Get the enemy's position

            // Store only the x and z coordinates
            Vector3 magazinePosition = new Vector3(enemyPosition.x, 1f, enemyPosition.z);

           // Vector3 canvasPosition = new Vector3(enemyPosition.x, 1.5f, enemyPosition.z); 

            // playerScore += 1;
            PatrolPointsList.me.playerScore += 1;

            if (gameObject.CompareTag("MutantEnemy") || PatrolPointsList.me.playerScore == 11)
            {
                Debug.Log("win");
           //     Transform playerCamera = FindPlayerCamera();
                // Activate the canvas for the mutant enemy
                if (canvasForMutant != null)
                {

                   Vector3 canvasPosition = Camera.main.transform.position + Camera.main.transform.forward * 2f; // Adjust distance as needed

                    // Create a canvas as a child of the player's camera
                    GameObject canvasObj = Instantiate(canvasForMutant, canvasPosition, Quaternion.identity, Camera.main.transform);

                    // Rotate the canvas to face the camera's forward direction
                    canvasObj.transform.LookAt(Camera.main.transform.position + Camera.main.transform.forward);

                    // Ensure the canvas is facing forward by offsetting its rotation
                    canvasObj.transform.Rotate(0f, 0f, 0f);

                    // Optionally, set canvas properties or activate/deactivate as needed
                    canvasObj.SetActive(true); 

                }
            }

            if (PatrolPointsList.me.playerScore == 1)
            {
                GameObject firstmagazine = Instantiate(magazineTen, magazinePosition, Quaternion.identity);

                // Activate the pickup object
                firstmagazine.SetActive(true);

            } 
            else if (PatrolPointsList.me.playerScore == 3)
            {
                GameObject secondmagazine = Instantiate(magazineTwenty, magazinePosition, Quaternion.identity);

                // Activate the mana object
                secondmagazine.SetActive(true);

            }
            else if(PatrolPointsList.me.playerScore == 4)
            {
                GameObject thirdmagazine = Instantiate(magazineThirty, magazinePosition, Quaternion.identity);

                // Activate the pickup object
                thirdmagazine.SetActive(true);
            }

            else if(PatrolPointsList.me.playerScore == 7)
            {
                GameObject secondmagazine = Instantiate(magazineTwenty, magazinePosition, Quaternion.identity);

                // Activate the mana object
                secondmagazine.SetActive(true);
            }

            else if(PatrolPointsList.me.playerScore == 9)
            {
                GameObject thirdmagazine = Instantiate(magazineThirty, magazinePosition, Quaternion.identity);

                // Activate the pickup object
                thirdmagazine.SetActive(true);
            }

        }

    }

   /* Transform FindPlayerCamera()
    {
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("PlayerCamera"); // Find cameras with a specific tag
        if (cameras.Length > 0)
        {
            Transform camerasTransform = cameras[0].GetComponent<Transform>();
            return camerasTransform; // Assuming there's only one player camera, return the first found
        }
        return null; // Return null if no camera is found
    } */

    private void UpdateHealthBar()
    {
        float fillAmount = Health_amt / HealthMax_amt;
        Health_image.fillAmount = fillAmount;
    }
}
