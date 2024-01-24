using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using PrimeTween;

// Ensure the namespace declaration encompasses all elements in the script
public class OpenBox : MonoBehaviour
{
    public Animator _ani;
    private Sequence mySequence;
    public GameObject Obj_One;
    public GameObject Obj_Two;

    private void Start()
    {
        _ani = GetComponentInChildren<Animator>();
    }

    public void OpenBoxAnimation()
    {
        mySequence = Sequence.Create();
        mySequence.ChainCallback(OpenBoxAni);
        mySequence.ChainDelay(1f);
        mySequence.ChainCallback(SetActiveObjects);
    }

    private void OpenBoxAni()
    {
        _ani.SetTrigger("Open");
    }

    private void SetActiveObjects()
    {
        Obj_One.SetActive(true);
        Obj_Two.SetActive(true);
    }
}
