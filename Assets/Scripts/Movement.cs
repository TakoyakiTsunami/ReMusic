using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Totem"))
        {
            Vector3 pushBack = rb.position - other.GetComponent<Rigidbody>().position;

            rb.AddForce(pushBack * 300);

            other.GetComponent<AudioSource>().PlayOneShot(other.GetComponent<AudioSource>().clip, 1);
        }
       
    }
}
