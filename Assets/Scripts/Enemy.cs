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
     
        animator.SetTrigger("Boom");
    }

    public void DestroyObject()
    {
        if (Player.Instance != null)
        {
            Player.Instance.SetTarget(transform);
        }
        Instantiate(explodePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.Dead();
        }
    }
}
