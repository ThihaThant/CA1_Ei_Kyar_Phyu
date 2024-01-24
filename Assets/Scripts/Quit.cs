using UnityEngine;

public class Quit : MonoBehaviour
{
    public void Exit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;

         Application.Quit();
    }
}