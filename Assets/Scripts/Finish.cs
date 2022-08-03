using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    [SerializeField]
    private GameObject prefabWinEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Win();
        }
    }
    public void Win()
    {
        Instantiate(prefabWinEffect, transform.position, Quaternion.identity);
        GameController.Instance.WinGame();
    }
}
