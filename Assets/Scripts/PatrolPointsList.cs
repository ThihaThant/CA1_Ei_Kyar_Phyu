using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatrolPointsList : MonoBehaviour
{
    public static PatrolPointsList me;
    public List<GameObject> Patrol_list = new List<GameObject>(); // Initialize the Patrol_list
    public List<GameObject> Patrol_list_one = new List<GameObject>();
    public List<GameObject> Patrol_list_two = new List<GameObject>();
    public List<GameObject> Patrol_list_three = new List<GameObject>();
    public List<GameObject> Patrol_list_four = new List<GameObject>();
    public List<GameObject> Patrol_list_five = new List<GameObject>();
    public List<GameObject> Patrol_list_six = new List<GameObject>();
    public List<GameObject> Patrol_list_seven = new List<GameObject>();
    public List<GameObject> Patrol_list_eight = new List<GameObject>();
    public List<GameObject> Patrol_list_nine = new List<GameObject>();
    public List<GameObject> Patrol_list_ten = new List<GameObject>();
    public int playerScore = 0;

    public void Awake()
    {
        me = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
