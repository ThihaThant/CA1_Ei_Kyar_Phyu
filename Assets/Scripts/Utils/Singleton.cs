using UnityEngine;
using System.Collections;

//---------------------------------------------------------------------------------
// Author		: Vincent Goh
// Date  		: 2023-08-21
// Description	: Tempalte for a generic use Singleton class
//              : From PluralSight Sword and Shovels Series that is no longer available
//---------------------------------------------------------------------------------

/// <summary>
/// Class that creates a Singleton
/// requires other class to inherit Singleton for it to work
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    #region Variables
    private static T instance;
    #endregion

    #region Getter
    public static T Instance
    {
        get { return instance; }
    }
    #endregion

    #region Unity Methods
    /// <summary>
    /// Called when script is loaded. Can be overidden
    /// </summary>
    protected virtual void Awake()
    {
        // check for any instance of the Singleton
        if (instance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a second instance of Singleton class");
        }
        else
        {
            instance = (T)this;
        }
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Called when script is destroyed. Can be overidden
    /// </summary>
    protected virtual void OnDestroy()
    {
        // check if destroyed object is this
        if (instance == this)
        {
            instance = null;
        }
    }
    #endregion
}
