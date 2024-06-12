using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChangePositionInput : MonoBehaviour
{

    [Inject] private Shooting player;

    [SerializeField] private List<Transform> positions;
    [SerializeField] private float _durationOfTransition;

    private int _index;
    private InputSystem _input;
    private bool _isMoving;
    /*
        private void RotateRight() => player.transform.eulerAngles -= new Vector3(0, _degreeStep, 0);
        private void RotateLeft() => player.transform.eulerAngles += new Vector3(0, _degreeStep, 0);*/

    private void Awake()
    {
        _input = new InputSystem();
        _input.Enable();
        _isMoving = false;
        _index = 0;
    }
    private void OnEnable()
    {
        _input.Game.MoveLeft.performed += MoveLeft_performed;
        _input.Game.MoveRight.performed += MoveRight_performed;
    }


    private void OnDisable ()
    {
        _input.Game.MoveRight.performed -= MoveRight_performed;
        _input.Game.MoveLeft.performed -= MoveLeft_performed;
    }
    private void MoveRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        TurnRight();
    }

    private void MoveLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        TurnLeft();
    }

    public void TurnRight()
    {
        if (_isMoving) return;

        if (_index == positions.Count-1) _index =  0;
        else _index++;

        StartCoroutine(CameraTransition());

    }
    public void TurnLeft()
    {
        if (_isMoving) return;

        if (_index <= 0) _index = positions.Count - 1;
        else _index--;

        StartCoroutine(CameraTransition());
    }
    private IEnumerator CameraTransition()
    {
        player.AbleToShoot = false;
        _isMoving = true;

        Vector3 startPosition = player.transform.position;
        Quaternion startRotation = player.transform.rotation;

        float elapsedTime = 0f;

        while (elapsedTime <= _durationOfTransition) 
        {

            elapsedTime += Time.deltaTime;
            player.transform.rotation = Quaternion.Lerp(startRotation, positions[_index].rotation, elapsedTime / _durationOfTransition);
            player.transform.position = Vector3.Lerp(startPosition, positions[_index].position, elapsedTime / _durationOfTransition);
            
            yield return null;
        }
        Debug.Log("Transition END");
        _isMoving = false;
        player.AbleToShoot = true;

    }


}
