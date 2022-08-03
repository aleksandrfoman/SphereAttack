using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private new Collider collider;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject explodePrefab;
    private void DeactivateCollider()
    {
        collider.enabled = false;
    }

    public void TakeDamage()
    {
        DeactivateCollider();
        Player.Instance.AddScale(0f);
     
        animator.SetTrigger("Boom");
    }

    public void DestroyObject()
    {
        Player.Instance.SetTarget(transform);
        Instantiate(explodePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            SceneManager.LoadScene(0);
        }
    }
}
