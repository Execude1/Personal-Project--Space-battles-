using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    private Rigidbody playerRb;

    private float zBound = 30;
    private float xBound = 35;

    private float startFire = 1;
    public float delayFire = .5f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            var powerUpTypes = collision.gameObject.GetComponent<PowerUpTypes>().powerUpTypes;
            var powerUpSound = collision.gameObject.GetComponent<AudioSource>();

            if (powerUpTypes == PowerUp.Bullet)
            {
                delayFire -= .1f;
            }
            if (powerUpTypes == PowerUp.Health)
            {
                gameManager.AddHealth(35);
            }
            if (powerUpTypes == PowerUp.Score)
            {
                gameManager.AddScore(200);
            }

            powerUpSound.PlayOneShot(powerUpSound.clip);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Fire()
    {
        while(gameManager.isGameActive)
        {
            yield return new WaitForSeconds(delayFire);
            Instantiate(bullet, new Vector3(transform.position.x, 2, transform.position.z + 7.5f), Quaternion.Euler(90, 0, 0));
        }    
    }
}
