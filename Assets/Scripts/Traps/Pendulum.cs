using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : Trap
{
    [SerializeField] private Animation anim;
    protected override void Initiate()
    {
        base.Initiate();
        anim["Swing"].time = Random.Range(0.0f, 2.0f);
    }
    protected override void Execute()
    {
        base.Execute();
        Debug.Log("Dead");
    }
   
}
