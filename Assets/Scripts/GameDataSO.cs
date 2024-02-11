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



}
//}