using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float minScale;
    [SerializeField]
    private float speedPower, moveSpeed;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private Transform road;
    private GameObject currentTarget, lastTarget;
    [SerializeField]
    private Bullet bulletPrefab;
    private Bullet currentBullet;
    private bool isRun;
    public static Player Instance { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform target)
    {
        if(lastTarget)
        Destroy(lastTarget.gameObject);
        currentTarget = Instantiate(new GameObject("position"), target.position, Quaternion.identity);
        lastTarget = currentTarget;
    }
    private void Update()
    {
        if (currentTarget != null && isRun)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f,0f, currentTarget.transform.position.z-2f), moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentBullet = Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.identity);
            isRun = false;
        }
        if (Input.GetKey(KeyCode.Mouse0) && currentBullet!=null)
        {
            if (transform.localScale.z <= 0.1f)
            {
                SceneManager.LoadScene(0);
            }

            transform.localScale -= (Vector3.one * speedPower * Time.deltaTime);
            road.localScale = new Vector3(transform.localScale.x,road.localScale.y,road.localScale.z);
            Debug.Log(road.localScale);
            currentBullet.SetScale(speedPower);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            currentBullet.Shoot();
            isRun = true;
        }
    }

    public void AddScale(float value)
    {
        transform.localScale += new Vector3(value, value, value);
    }
}
