using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private GameObject blueSphere;

    private ParticleSystem leftLaser;
    private ParticleSystem rightLaser;
    private ParticleSystem leftFlash;
    private ParticleSystem rightFlash;
    private GameObject blueSphereObject;
    private Rigidbody bossRb;

    private bool isLasersFire = true;
    private bool isBlueSphereFire = true;

    [SerializeField] private ParticleSystem[] smallExplosion;
    [SerializeField] private ParticleSystem bigExplosion;

    [SerializeField] private float health = 100;

    void Start()
    {
        leftLaser = lasers[0].transform.Find("LineUp").GetComponent<ParticleSystem>();
        rightLaser = lasers[1].transform.Find("LineUp").GetComponent<ParticleSystem>();
        leftFlash = lasers[0].transform.Find("Flash").GetComponent<ParticleSystem>();
        rightFlash = lasers[1].transform.Find("Flash").GetComponent<ParticleSystem>();
        bossRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(transform.position.z > 25)
        {
            //transform.Translate(0, 0, -3 * Time.deltaTime);
            bossRb.velocity += new Vector3(0, 0, -2 * Time.deltaTime);
        }
        else
        {
            bossRb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;


            if (isLasersFire)
            {
                StartCoroutine(FireLasers());
            }
            if (isBlueSphereFire)
            {
                StartCoroutine(FireSphere());
            }
        }
    }

    IEnumerator FireLasers()
    {
        isLasersFire = false;

        leftFlash.Play();
        rightFlash.Play();
        leftLaser.Play();
        rightLaser.Play();

        yield return new WaitForSeconds(4);

        lasers[0].GetComponent<BoxCollider>().enabled = true;
        lasers[1].GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(8);

        lasers[0].GetComponent<BoxCollider>().enabled = false;
        lasers[1].GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(5);

        isLasersFire = true;
    }

    IEnumerator FireSphere()
    {
        isBlueSphereFire = false;

        Instantiate(blueSphere, transform);

        foreach(var obj in GetComponentsInChildren<Transform>())
        {
            if(obj.gameObject.name == "Light" || obj.gameObject.name == "Light2")
            {
                obj.GetComponent<ParticleSystem>().Play();
            }
            if(obj.gameObject.name.Contains("Blue sphere"))
            {
                blueSphereObject = obj.gameObject;            
            }
        }

        yield return new WaitForSeconds(6);

        blueSphereObject.GetComponent<moveForward>().enabled = true;
        blueSphereObject.GetComponent<SphereCollider>().enabled = true;

        if (gameObject.transform.childCount > 4)
        {
            isBlueSphereFire = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 0.2f;

            Destroy(collision.gameObject);

            if ((int)health % 10 == 0)
            {
                int numExplosion = Random.Range(0, smallExplosion.Length - 1);
                smallExplosion[numExplosion].Play();
            }

            if (health <= 0)
            {
                bigExplosion.Play();
                StartCoroutine(DestroyBoss());
            }
        }
    }

    IEnumerator DestroyBoss()
    {
        bossRb.velocity = Vector3.down;

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);

        GameManager.gameManager.AddScore(1000);
        GameUIManager.gameUIManager.VictoriousEnd();
    }
}
