using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;
    private Vector3 endPosition;
    
    public float throwForce;
    public float startZ;
    public float endZ;
    public float timeLimit;

    public Transform spawn;

    private float timeThrow = 0f;
    private bool isThrow = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        rb.isKinematic = true; // При старте игры мяч находится в покое
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            startPosition.z = startZ;
            startPosition = Camera.main.ScreenToWorldPoint(startPosition);
            rb.isKinematic = true; // Задаем мячу покой при начале удерживания
            isThrow = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;
            endPosition.z = endZ;
            endPosition = Camera.main.ScreenToWorldPoint(endPosition);
            Vector3 throwDirection = endPosition - startPosition;
            rb.isKinematic = false;  // Даем мячу физику, чтобы он полетел
            if(timeThrow < timeLimit)
            {
                rb.AddForce(throwDirection * throwForce * (timeLimit - timeThrow), ForceMode.Impulse);
            }
            isThrow = false;
            timeThrow = 0;
        }

        if(isThrow)
        {
            timeThrow+=0.1f;
            print(timeThrow);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            transform.position = spawn.position;
            rb.isKinematic = true;
        }
        else if(other.tag == "Gol")
        {
            transform.position = spawn.position;
            rb.isKinematic = true;
        }
    }
    //public Rigidbody rigidbody;

    //public float forseY;
    //public float forseZ;

    //public bool isToss = false;

    //void Start()
    //{
    //    rigidbody = GetComponent<Rigidbody>();
    //}

    //public void OnMouseUp()
    //{
    //    if(!isToss)
    //    {
    //        rigidbody.useGravity = true;
    //        rigidbody.AddForce(0, forseY, forseZ, ForceMode.Impulse);
    //        isToss = true;
    //    }
    //}

    //void Update()
    //{

    //}
}
