using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChangePosition : MonoBehaviour
{

    [SerializeField] private List<Transform> positions;
    [SerializeField] private float _speedOfTransition;
    [SerializeField] private float _speedOfRotation;

    [Inject] private Shooting player;
    private int _index;
    private float _degreeStep;
    /*
        private void RotateRight() => player.transform.eulerAngles -= new Vector3(0, _degreeStep, 0);
        private void RotateLeft() => player.transform.eulerAngles += new Vector3(0, _degreeStep, 0);*/

    private PlayerPositionState _state;
    private PlayerPositionState _moveState = PlayerPositionState.MOVE;
    private PlayerPositionState _stopState = PlayerPositionState.STOP;
    private void Awake()
    {
        _state = PlayerPositionState.STOP;
        _index = 0;
        _degreeStep = 360 / positions.Count;
    }

    public void TurnRight()
    {
        if (_state == _moveState) return;

        if (_index == positions.Count-1)
        {
            _index =  0;
        } else _index++;

        _state = _moveState;
        StartCoroutine(TransitionTo(player.transform, positions[_index]));
        StartCoroutine(RotationAnimaiton(player.transform));

    }
    public void TurnLeft()
    {
        if (_state == _moveState) return;

        if (_index <= 0)
        {
            _index = positions.Count - 1;
        } else _index--;

        _state = _moveState;

        StartCoroutine(TransitionTo( player.transform, positions[_index]));
        StartCoroutine(RotationAnimaiton(player.transform));
        //RotateLeft();


    }
    private IEnumerator TransitionTo(Transform startPos, Transform endPos)
    {
        //new Vector3 = startPos.position - endPos.position;
        while(startPos.position != endPos.position)
        {
            startPos.position = Vector3.MoveTowards(startPos.position, endPos.position, _speedOfTransition * Time.deltaTime);   
            yield return null;
        }
        Debug.Log("Transition END");

        _state = _stopState;

    }
    private IEnumerator RotationAnimaiton(Transform startPos)
    {

        float ratioTime = 0f;
        while (startPos.rotation != positions[_index].rotation)
        {
            startPos.rotation = Quaternion.Slerp(startPos.rotation, positions[_index].rotation, ratioTime);
            ratioTime += Time.deltaTime * _speedOfRotation;
            
            yield return null;
        }
        Debug.Log("Rotation END");


    }
    public enum PlayerPositionState
    {
        STOP, MOVE
    }


}
