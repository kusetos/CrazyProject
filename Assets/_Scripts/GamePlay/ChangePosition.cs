using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChangePosition : MonoBehaviour
{

    [SerializeField] private List<Transform> positions;

    [Inject] private Shooting player;
    private int _index;
    private float _degreeStep;
    private void RotateRight() => player.transform.eulerAngles -= new Vector3(0, _degreeStep, 0);
    private void RotateLeft() => player.transform.eulerAngles += new Vector3(0, _degreeStep, 0);

    private void Awake()
    {
        _index = 0;
        _degreeStep = 360 / positions.Count;
    }

    public void TurnRight()
    {
        try
        {
            UpdatePositionByIndex(++_index);
        }
        catch (ArgumentOutOfRangeException)
        {
            UpdatePositionByIndex(_index = 0);
        }
        RotateRight();
    }
    public void TurnLeft()
    {
        try
        {
            UpdatePositionByIndex(--_index);

        }
        catch (ArgumentOutOfRangeException)
        {
            UpdatePositionByIndex(_index = positions.Count - 1);
        }
        RotateLeft();

    }
    private void UpdatePositionByIndex(int index)
    {
        player.transform.position = positions[_index].position;
    }


}
