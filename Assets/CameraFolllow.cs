using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolllow : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Transform target;

    private void Update()
    {
        Vector3 curPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, curPos, moveSpeed * Time.deltaTime);
    }
}
