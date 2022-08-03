using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private new Rigidbody rigidbody;
    [SerializeField]
    private float shootPower;

    public void SetScale(float speedPower)
    {
        transform.localScale += (Vector3.one * speedPower * Time.deltaTime);
    }

    public void Shoot()
    {
        rigidbody.AddForce(Vector3.forward * shootPower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() || collision.gameObject.GetComponent<Finish>())
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position,transform.localScale.x*2f, Vector3.one);

            for (int i = 0; i < hits.Length; i++)
            {
                if(hits[i].transform.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage();
                }
            }

            if (collision.gameObject.GetComponent<Finish>())
            {
                Player.Instance.SetTarget(collision.gameObject.transform);
            }

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x);
    }
}
