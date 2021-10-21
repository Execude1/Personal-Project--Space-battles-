using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    private Rigidbody playerRb;

    private float zBound = 12;
    private float xBound = 43;

    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        playerRb.transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void Fire()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 7.5f), Quaternion.Euler(90, 0, 0));
    }
}
