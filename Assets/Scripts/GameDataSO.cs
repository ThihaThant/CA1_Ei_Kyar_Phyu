using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

//---------------------------------------------------------------------------------
// Author		: Vincent
// Date  		: 2023-08-21
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
//#define DEBUG_DrawMousePoint

//namespace WAPIGS{
//[RequireComponent(typeof(Rigidbody))]

[CreateAssetMenu(fileName = "NewGameData", menuName = "ScriptableObjects/Location")]


public class GameDataSO : ScriptableObject
{
    public Vector3 LevelOnePosition;
    public Vector3 LevelTwoPosition;

    public Vector3 LevelOneLocation { get => this.LevelOnePosition; }
    public Vector3 LevelTwoLocation { get => this.LevelTwoPosition; }

    public int LevelOneScore;
    public int LevelTwoScore;

    [System.Serializable]
    public class RobotInLevelOne
    {
        public string id;
        public bool active;
        public GameObject enemy;
    }

    public RobotInLevelOne[] LevelOneRobots;

    [System.Serializable]
    public class RobotInLevelTwo
    {
        public string id;
        public bool active;
    }

    public RobotInLevelTwo[] LevelTwoRobots;


    public int LevelOnePlayerScore { get => this.LevelOneScore; }
    public int LevelTwoPlayerScore { get => this.LevelTwoScore; }

    public void UpdateLevelOneLocation(Vector3 newPosition)
    {
        LevelOnePosition = newPosition;
    }

    public void UpdateLevelTwoLocation(Vector3 newPosition)
    {
        LevelTwoPosition = newPosition;
    }

    public void UpdateLevelOneScore(int newScore)
    {
        LevelOneScore = newScore;
    }

    public void UpdateLevelTwoScore(int newScore)
    {
        LevelTwoScore = newScore;
    }


    public void UpdateLevelOneRobotStatus(string robotId, bool newStatus)
    {
        // Iterate through the robots array
        for (int i = 0; i < LevelOneRobots.Length; i++)
        {
            // Check if the current robot has the specified ID
            if (LevelOneRobots[i].id == robotId)
            {
                // Update the active status of the robot
                LevelOneRobots[i].active = newStatus;
                // Optionally, you can break the loop if you're sure each ID is unique
                // break;
            }
        }
    }

    public void UpdateLevelTwoRobotStatus(string robotId, bool newStatus)
    {
        // Iterate through the robots array
        for (int i = 0; i < LevelTwoRobots.Length; i++)
        {
            // Check if the current robot has the specified ID
            if (LevelTwoRobots[i].id == robotId)
            {
                // Update the active status of the robot
                LevelTwoRobots[i].active = newStatus;
                // Optionally, you can break the loop if you're sure each ID is unique
                // break;
            }
        }
    }

    public void ResetToDefaultsForLevelOne()
    {
        // Reset positions
        LevelOnePosition = Vector3.zero;

        // Reset scores
        LevelOneScore = 0;

    }

    public void ResetToDefaultsForLevelTwo()
    {
        // Reset positions
        LevelTwoPosition = Vector3.zero;

        // Reset scores
        LevelTwoScore = 0;


    }
    public void ResetActiveStatusforLevelOne()
    {
        // Reset active status for robots in LevelOne
        ResetActiveStatus(LevelOneRobots);

    }

    public void ResetActiveStatusforLevelTwo()
    {
        // Reset active status for robots in LevelTwo
        ResetActiveStatus(LevelTwoRobots);
    }

    // Helper method to reset active status of robots in an array
    private void ResetActiveStatus(RobotInLevelOne[] robots)
    {
        foreach (var robot in robots)
        {
            // Reset active status to false
            robot.active = true;
        }
    }

    // Helper method to reset active status of robots in an array
    private void ResetActiveStatus(RobotInLevelTwo[] robots)
    {
        foreach (var robot in robots)
        {
            // Reset active status to false
            robot.active = true;
        }
    }
    //}
}