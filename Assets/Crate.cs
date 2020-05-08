using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
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
            float zmove = 15 * Time.deltaTime;

            zmove += this.transform.position.z;

            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, zmove);

        }
    }
}
