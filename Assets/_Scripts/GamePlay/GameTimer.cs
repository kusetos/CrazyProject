using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameTimer : ITickable
{
    private float _elapsedTime;
    private bool _isRunning = false;
    public GameTimer()
    {
        _elapsedTime = 0;
        StopTimer();
    }
    public void StartTimer()
    {
        _isRunning = true;
        _elapsedTime = 0f;
    }
    public void StopTimer()
    {
        _isRunning=false;
    }
    public float GetElapsedTime => _elapsedTime;
    public void Tick()
    {
        if( _isRunning )
        {
            _elapsedTime += Time.deltaTime;
        }
        
    }
}
                                                                    