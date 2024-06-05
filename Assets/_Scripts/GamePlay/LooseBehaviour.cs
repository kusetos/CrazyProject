using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseBehaviour : MonoBehaviour
{
    public static Action OnLooseAction;

    public void Loose()
    {
        Debug.Log("win");
        
    }
}
