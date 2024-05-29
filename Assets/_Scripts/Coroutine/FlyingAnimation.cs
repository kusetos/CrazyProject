using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAnimation : MonoBehaviour
{
    [SerializeField] float speed = 1F;
    private void Start()
    {
        StartCoroutine(Flying());
    }
    public IEnumerator Flying()
    {
        while (transform.position.y < 10f)
        {

            transform.position += Vector3.up * speed * Time.deltaTime;

            yield return null;

        }
        yield return new WaitForSeconds(1);
        Debug.Log("Stoped");

    }
}
