using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBehaviour : MonoBehaviour
{
    public static Action OnWinAction;

    public void Win()
    {
        Debug.Log("win");
        
    }
}
