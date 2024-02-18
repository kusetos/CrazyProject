using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaWholeState : BananaBaseState
{
    public override void EnterState(BananaStateManager banana)
    {
        banana.GetComponent<Rigidbody>().useGravity = true;  
    }
    public override void OoCollisionEnter(BananaStateManager banana, Collision collision)
    {
      
    }
    public override void UpdateState(BananaStateManager banana)
    {
        
    }
}
