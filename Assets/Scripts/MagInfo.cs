using UnityEngine;
using System.Collections;
using TMPro;
using System;

//---------------------------------------------------------------------------------
// Author		: Vincent
// Date  		: 2023-07-19
// Description	: Magazine Information.
//---------------------------------------------------------------------------------
public class MagInfo : MonoBehaviour
{
    #region Variables
    // Public Variables: camelCase
    public int magBulletCount;

    [SerializeField] private TMP_Text bulletDisplay;
    [SerializeField] private MagDataSO magData;

    #endregion

    private void Start()
    {

        UpdateBulletsDisplay();
    }

    private void OnEnable()
    {
        magBulletCount = magData.MaxBulletCount;
    }
    public void UpdateBulletsDisplay()
    {
        bulletDisplay.text = String.Format("{0:D2}", magBulletCount);
    }
    public void SnapToPlayer()
    {
        transform.parent = GameObject.Find("XR Origin (XR Rig)").transform;
    }
}