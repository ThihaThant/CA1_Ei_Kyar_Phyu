using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_ani : MonoBehaviour
{
    public Enemy _code;

    public void Attack()
    {
        _code.Attack();
    }

    public void AttackFinish()
    {
        _code.AttackFinish();
    }
}
