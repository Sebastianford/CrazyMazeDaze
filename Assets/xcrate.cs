using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xcrate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            float xmove = 15 * Time.deltaTime;

            xmove += this.transform.position.x;

            this.gameObject.transform.position = new Vector3(xmove, transform.position.y, transform.position.z);

        }
    }
}
