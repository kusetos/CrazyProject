using UnityEngine;

public abstract class BananaBaseState
{   
    public abstract void EnterState(BananaStateManager banana);
    public abstract void UpdateState(BananaStateManager banana);
    public abstract void OoCollisionEnter(BananaStateManager banana, Collision collision);

}
