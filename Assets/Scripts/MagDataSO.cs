using UnityEngine;
using System;
using TMPro;

//---------------------------------------------------------------------------------
// Author		: Vincent
// Date  		: 2023-07-19
// Description	: Scriptable Object for different magazine type.
//---------------------------------------------------------------------------------

[CreateAssetMenu(fileName = "New MagData", menuName = "Weapons/Magazine Data", order = 51)]
public class MagDataSO : ScriptableObject
{
    #region Variables

    [SerializeField] private string _magType;
    [SerializeField] private GameObject magazine;

    public int MaxBulletCount { get => this._maxBulletCount; }
    [SerializeField] private int _maxBulletCount = 10;

    #endregion

}
