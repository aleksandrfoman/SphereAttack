using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField]
    private Material matTrue, matFalse;
    [SerializeField]
    private Renderer renderer;
    [SerializeField]
    private LayerMask enemyLayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == enemyLayer)
        {
            renderer.material = matFalse;
        }
        else
        {
            renderer.material = matTrue;
        }
        Debug.Log(other.gameObject.name);
    }
}
