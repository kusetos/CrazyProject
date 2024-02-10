using UnityEngine;

public abstract class BananaBaseState
{   
    public abstract void EnterState(BananaStateManager banana);
    public abstract void UpdaetState(BananaStateManager banana);
    public abstract void OoCollisionEnter(BananaStateManager banana);


}
