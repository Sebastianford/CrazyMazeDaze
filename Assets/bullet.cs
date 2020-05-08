using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public Transform Bullet;
    public Transform Nozzle;
    public int speed = 35;

    move _move = FindObjectOfType<move>();

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bulletstop")
        {
            Destroy(this.gameObject);

        }

        if (other.tag == "enemy")
        {
            _move.baddies -= 1;

        }
    }
}
