using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaGrowingState : BananaBaseState
{

    private Vector3 startScale = new Vector3(0.1f, 0.2f, 0.1f);
    private Vector3 scalarScale = new Vector3(1f, 2f, 1f);

    public override void EnterState(BananaStateManager banana)
    {
        banana.transform.localScale = startScale;
    }
    public override void OoCollisionEnter(BananaStateManager banana, Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);
    }
    public override void UpdateState(BananaStateManager banana)
    {
        if (banana.transform.localScale.x <= 0.5)
            banana.transform.localScale += scalarScale * Time.deltaTime / 10; //speed of growing, Scalar
        else
            banana.SwitchState(banana.WholeState);
        
    }
}
