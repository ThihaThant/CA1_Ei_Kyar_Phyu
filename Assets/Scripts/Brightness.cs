using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//---------------------------------------------------------------------------------
// Author		: Vincent
// Date  		: 2023-08-21
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
//#define DEBUG_DrawMousePoint

//namespace WAPIGS{
//[RequireComponent(typeof(Rigidbody))]
public class Brightness : MonoBehaviour 
{
    public Light sceneLight;

    void Start()
    {
        float savedBrightness = GameManager.Instance.GetBrightness();
        sceneLight.intensity = savedBrightness;
    }
}
//}