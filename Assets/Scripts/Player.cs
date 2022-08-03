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
    private GameObject deadPrefab;
    [SerializeField]
    private Bullet bulletPrefab;
    private Bullet currentBullet;
    private bool isRun;
    [SerializeField]
    private bool isFinish;
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

    private void Start()
    {
        isFinish = false;
    }
    public void SetTarget(Transform target)
    {
        if(lastTarget)
        Destroy(lastTarget.gameObject);

        if (target.GetComponent<Finish>())
        {
            isFinish = true;
        }

        currentTarget = Instantiate(new GameObject("position"), target.position, Quaternion.identity);
        lastTarget = currentTarget;
    }

    public void Dead()
    {
        Instantiate(deadPrefab, transform.position, Quaternion.identity);
        GameController.Instance.LoseGame();
        Destroy(gameObject);
    }

    private void Update()
    {
        if (GameController.Instance.IsGame)
        {
            if (currentTarget != null && isRun)
            {
                if (isFinish)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, currentTarget.transform.position.z + 2f), moveSpeed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, currentTarget.transform.position.z - 2f), moveSpeed * Time.deltaTime);
                }
               
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentBullet = Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.identity);
                isRun = false;
            }
            if (Input.GetKey(KeyCode.Mouse0) && currentBullet != null)
            {
                if (transform.localScale.z <= 0.25f)
                {

                }
                if (transform.localScale.z <= 0.15f)
                {
                    currentBullet.Shoot();
                    Dead();
                }

                transform.localScale -= (Vector3.one * speedPower * Time.deltaTime);
                road.localScale = new Vector3(transform.localScale.x, road.localScale.y, road.localScale.z);
                Debug.Log(road.localScale);
                currentBullet.SetScale(speedPower);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                currentBullet.Shoot();
                isRun = true;
            }
        }
    }
}
