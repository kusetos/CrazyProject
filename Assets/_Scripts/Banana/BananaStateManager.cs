using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaStateManager : MonoBehaviour
{
    BananaBaseState currentState;

    public BananaGrowingState GrowingState = new BananaGrowingState();
    public BananaChewedState ChewedState = new BananaChewedState();
    public BananaRottenState RottenState = new BananaRottenState();
    public BananaWholeState WholeState = new BananaWholeState();

    void Start()    
    {
        currentState = GrowingState;
        currentState.EnterState(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdaetState(this);
    }

    public void SwitchState(BananaBaseState newState){
        currentState = newState;
        currentState.EnterState(this);
    }
}   
