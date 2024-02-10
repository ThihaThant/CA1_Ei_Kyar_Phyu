using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera1 : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles=new Vector3 (0,Camera.transform.eulerAngles.y,0);
    }
}
