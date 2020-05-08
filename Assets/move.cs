using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public KeyCode Down;
    public KeyCode Up;
    public KeyCode Left;
    public KeyCode Right;

    public KeyCode Leap;
    public KeyCode Shoot;

    public Rigidbody rb;

    public bool floor = false;

    public Transform Bullet;
    public Transform Nozzle;
    public Transform Attack;

    public float force = 10;
    public float movement = 10;

    public Text life;
    public int HP = 1;

    public AudioSource amp;
    public AudioClip spawn;

    public int baddies = 1;

    // Start is called before the first frame update
    void Start()
    {
        hitpoints();
    }

    // Update is called once per frame
    void Update()
    {
        float xmove = 0;
        float zmove = 0;

        if (Input.GetKeyDown(Leap)&& floor == true)
        {
            rb.AddForce(Vector3.up * force);
        }

        if (Input.GetKey(Right))
        {
            xmove += movement * Time.deltaTime;
        }

        if (Input.GetKey(Left))
        {
            xmove -= movement * Time.deltaTime;
        }

        if (Input.GetKey(Up))
        {
            zmove += movement * Time.deltaTime;
        }

        if (Input.GetKey(Down))
        {
            zmove -= movement * Time.deltaTime;
        }

        if (Input.GetKeyDown(Shoot))
        {
            Instantiate(Bullet, Nozzle.position, Nozzle.rotation, Attack);
        }

        xmove += this.transform.position.x;
        zmove += this.transform.position.z;
        this.gameObject.transform.position = new Vector3(xmove, this.transform.position.y, zmove);

        if (HP <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Death");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            floor = true;

        }

        if (other.tag == "enemy")
        {
            other.enabled = false;
            Destroy(other.gameObject);
            HP -= 1;
            hitpoints();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Floor")
        {
            floor = false;

        }
    }

    void hitpoints()
    {
        life.text = HP.ToString();
    }
}
