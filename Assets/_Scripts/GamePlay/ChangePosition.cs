using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChangePosition : MonoBehaviour
{
    private const PlayerPositionState MOVE_STATE = PlayerPositionState.MOVE;
    private const PlayerPositionState STOP_STATE = PlayerPositionState.STOP;

    [Inject] private Shooting player;

    [SerializeField] private List<Transform> positions;
    [SerializeField] private float _durationOfTransition;

    private int _index;
    /*
        private void RotateRight() => player.transform.eulerAngles -= new Vector3(0, _degreeStep, 0);
        private void RotateLeft() => player.transform.eulerAngles += new Vector3(0, _degreeStep, 0);*/

    private PlayerPositionState _state;
    private void Awake()
    {
        _state = PlayerPositionState.STOP;
        _index = 0;
    }

    public void TurnRight()
    {
        if (_state == MOVE_STATE) return;

        if (_index == positions.Count-1) _index =  0;
        else _index++;

        _state = MOVE_STATE;
        StartCoroutine(CameraTransition());

    }
    public void TurnLeft()
    {
        if (_state == MOVE_STATE) return;

        if (_index <= 0) _index = positions.Count - 1;
        else _index--;

        _state = MOVE_STATE;
        StartCoroutine(CameraTransition());
    }
    private IEnumerator CameraTransition()
    {

        float elapsedTime = 0f;
        while (elapsedTime <= _durationOfTransition) 
        {

            elapsedTime += Time.deltaTime;
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, positions[_index].rotation, elapsedTime / _durationOfTransition);
            player.transform.position = Vector3.Lerp(player.transform.position, positions[_index].position, elapsedTime / _durationOfTransition);

            Debug.Log(elapsedTime);
            
            yield return null;
        }
        Debug.Log("Transition END");
        _state = STOP_STATE;


    }
    public enum PlayerPositionState
    {
        STOP, MOVE
    }


}
