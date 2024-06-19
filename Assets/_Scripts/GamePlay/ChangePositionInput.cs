using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChangePositionInput : MonoBehaviour
{

    [Inject] private Shooting _player;

    [SerializeField] private List<Transform> _positions;
    [SerializeField] private float _durationOfTransition;

    private uint _index;
    private InputSystem _input;
    private bool _isMoving;


    private void Awake()
    {
        _input = new InputSystem();
        _input.Enable();
        _isMoving = false;
        _index = 0;
        _player.transform.position = _positions[0].position;
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
        if (_isMoving) return;
        else _index = (uint)(++_index % _positions.Count);

        StartCoroutine(CameraTransition());
    }

    private void MoveLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_isMoving) return;
        else  _index = (uint)(--_index % _positions.Count);

        StartCoroutine(CameraTransition());
    }

    private IEnumerator CameraTransition()
    {
        _player.AbleToShoot = false;
        _isMoving = true;

        Vector3 startPosition = _player.transform.position;
        Quaternion startRotation = _player.transform.rotation;

        float elapsedTime = 0f;

        while (elapsedTime <= _durationOfTransition) 
        {

            elapsedTime += Time.deltaTime;
            _player.transform.rotation = Quaternion.Lerp(startRotation, _positions[(int)_index].rotation, elapsedTime / _durationOfTransition);
            _player.transform.position = Vector3.Lerp(startPosition, _positions[(int)_index].position, elapsedTime / _durationOfTransition);
            
            yield return null;
        }
        Debug.Log("Transition END");
        _isMoving = false;
        _player.AbleToShoot = true;
    }
}
