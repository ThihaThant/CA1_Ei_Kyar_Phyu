using UnityEngine;
using System.Collections;
//---------------------------------------------------------------------------------
// Author		: Vincent
// Date  		: 2023-08-21
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
//#define DEBUG_DrawMousePoint

//namespace WAPIGS{
//[RequireComponent(typeof(Rigidbody))]
public class FollowPlayer : MonoBehaviour 
{
	#region Variables
	// Constant: UpperCase, SnakeCase
	//public const int ATTACK_RANGE = 10;

	// Properties: PascalCase
	// public MyCodeStyle Instance { get; private set;}

	// Events: PascalCade
	//private EventHandler OnSomethingTriggered;

	//[Header("Header / Separator in Inspector")]
    //[Tooltip("Pop up description if put on top of variable.")]
	// Public Variables: camelCase or Use Properties 
	//public GameObject goPlayer;
	
	// [SerializeField] Private Variables: underscore, camelCase
	//[SerializeField] private int _size;

	// Private Variables: underscore, camelCase
	//private float _speed;

#if DEBUG_DrawMousePoint
    public bool DrawMousePoint = false;
#endif

	#endregion
	
	#region Unity Methods

	// Method or Function: PascalCase
	// Method or Function Params: camelCase
	protected void Awake() 
	{
		// Called once when GameObject is SetActive
		// Use to initialize this script variables
		// Local Variables: camelCase
		//int playerHealth;
	}

	protected void Start() 
	{
		// Called once when Component is enabled
		// Use to initialize other class variables to prevent null error
		gameObject.transform.parent = GameObject.Find("XR Origin (XR Rig)").transform;
	}
	
	protected void Update() 
	{
	}

	// FixedUpdate for Physics update
	protected void FixedUpdate() 
	{
	}
	
	#endregion

	#region Own Methods
	//  Use PascalCase for methods
	/// <summary>
    /// Write a summary of the method. Then when you hover over the method
	/// this summary and how to use will pop up. 
    /// <para/>
    /// </summary>
    /// <param name="speed">A reference to the Speed variable.</param>
	//private void MoveAgent(Float speed) {
    //}
	#endregion

#if DEBUG_TurretPointAtMouse_DrawMousePoint
    private void OnDrawGizmos()
    {
        if (DrawMousePoint && Application.isPlaying)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(mousePoint3D, 0.2f);
            Gizmos.DrawLine(transform.position, mousePoint3D);
        }
    }
#endif
}
//}