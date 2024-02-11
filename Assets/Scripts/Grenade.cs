using NPOI.SS.Formula.Functions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade : MonoBehaviour
{
    private bool hasPin;
    public GameObject splint;
    public GameObject ExplosionPS;
    // Start is called before the first frame update
    void Start()
    {
        hasPin = true;
    }
    private void Awake()
    {
        splint.layer = 1;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Thrown()
    {
        if (hasPin)
        {
            splint.layer = 1;
            Debug.Log("Does not explode");
        }
        else
        {
            StartCoroutine(Explosion());
        }
    }
    public void Pin_In()
    {
        hasPin = true;
    }
    public void Pin_Out()
    {
        hasPin = false;
    }
    public void Selected()
    {
        splint.layer = 0;
    }
    public IEnumerator Explosion()
    {
        yield return new WaitForSeconds(3f);
        ExplosionPS.SetActive(true);
        gameObject.GetComponent<SphereCollider>().enabled=true;
        StartCoroutine(ContinueExplode());
    }
    public IEnumerator ContinueExplode()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyController controller = other.GetComponentInChildren<EnemyController>();
        if (controller != null)
        {
            controller.GetComponent<EnemyController>().TakeDamage(70);
        }
    }
}
