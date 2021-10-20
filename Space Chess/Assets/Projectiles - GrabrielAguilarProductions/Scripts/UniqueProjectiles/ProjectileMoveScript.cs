using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ProjectileMoveScript : MonoBehaviour
{
    public float targetingTime = 5f;
    public float targetedTime = 5f;
    public bool rotate = false;
    public float rotateAmount = 45;
    public bool bounce = false;
    public bool seekAfterBounce = false;
    public float bounceForce = 10;
    public float speed;
    [Tooltip("From 0% to 100%")]
    public float accuracy;
    public float fireRate;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;
    public List<GameObject> trails;
    public bool isNotDestroy;
    public float destroyTime = 7f;

    private Vector3 startPos;
    private float speedRandomness;

    private bool collided;
    private Rigidbody rb;
    private GameObject target;

    private float passTime = 0f, targetTime = 5;
    public bool sineMovement = false;

    private Vector3 pos;
    private Vector3 axisUp;
    private Vector3 axisRight;

    private Vector3 lastVelocity;

    private float timeToBounce = 0;

    [System.NonSerialized] public Vector3 offset;
    [System.NonSerialized] public float range;
    [System.NonSerialized] public float startTime;
    [System.NonSerialized] public bool directionUp;
    [System.NonSerialized] public bool directionRight;
    [System.NonSerialized] public float angleUp;
    [System.NonSerialized] public float angleRight;

    void Start()
    {
        startTime = Time.time;
        pos = transform.position;
        axisUp = transform.up;
        axisRight = transform.right;
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        if (!isNotDestroy)
            StartCoroutine(waiter());
    }

    void FixedUpdate()
    {
        if (speed != 0 && rb != null)
        {
            transform.position += (transform.forward) * (speed);
        }

        rb.angularVelocity = Vector3.zero;
        lastVelocity = rb.velocity;

        Bounce();
    }

    void Bounce()
    {
        if (transform.localPosition.x <= -3.5)
        {
            Vector3 direction = new Vector3(transform.forward.x * -1, transform.forward.y, transform.forward.z);

            transform.LookAt(transform.position + direction * 10);
            transform.localPosition = new Vector3(-3.5f, transform.localPosition.y, transform.localPosition.z);
        }   
        else if (transform.localPosition.x >= 3.5)
        {
            Vector3 direction = new Vector3(transform.forward.x * -1, transform.forward.y, transform.forward.z);

            transform.LookAt(transform.position + direction * 10);
            transform.localPosition = new Vector3(3.5f, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.y >= -0.5)
        {
            Vector3 direction = new Vector3(transform.forward.x, transform.forward.y * -1, transform.forward.z);

            transform.LookAt(transform.position + direction * 10);
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f, transform.localPosition.z);
        }
        else if (transform.localPosition.y <= -7.5)
        {
            Vector3 direction = new Vector3(transform.forward.x, transform.forward.y * -1, transform.forward.z);

            transform.LookAt(transform.position + direction * 10);
            transform.localPosition = new Vector3(transform.localPosition.x, -7.5f, transform.localPosition.z);
        } 
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);

        Delete();
    }

    void Delete()
    {
        collided = true;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision co)
    {
            Vector3 direction = Vector3.Reflect(transform.forward, co.contacts[0].normal);

            transform.LookAt(transform.position + direction * 10);
    }

    public GameObject getMuzzlePrefab()
    {
        return muzzlePrefab;
    }
}