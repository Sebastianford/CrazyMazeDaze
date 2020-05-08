using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float force = 10;

    public bool floor = false;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (floor == true)
        {
            rb.AddForce(Vector3.up * force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            floor = true;

        }

        if (other.tag == "bullet")
        {
            Destroy(other.gameObject);
            this.enabled = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Floor")
        {
            floor = false;

        }
    }
}
