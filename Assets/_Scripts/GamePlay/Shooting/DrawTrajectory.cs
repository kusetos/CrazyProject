using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField][Range(3, 30)] int _lineSegmentCount = 20;

    private List<Vector3> _linePoints = new List<Vector3>();
    
    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        

        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;

        float stepTime = FlightDuration / _lineSegmentCount;

        _linePoints.Clear();

        for(int i =  0; i < _lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;
            Vector3 MovementVector;
            if (velocity.y < 0)
            {
                 MovementVector = new Vector3(
                    -velocity.x * stepTimePassed,
                    -(velocity.y * stepTimePassed) - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                       -velocity.z * stepTimePassed);

            }else 
            MovementVector = new Vector3(
                velocity.x * stepTimePassed,
                (velocity.y * stepTimePassed) - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                velocity.z * stepTimePassed
                );

            _linePoints.Add(-MovementVector + startingPoint);

        }

        _lineRenderer.positionCount = _linePoints.Count;
        _lineRenderer.SetPositions(_linePoints.ToArray());

    }
    public void HideLine()
    {
        _lineRenderer.positionCount = 0;
    }
}
