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

    private bool isLasersFire = true;
    private bool isBlueSphereFire = true;

    void Start()
    {
        leftLaser = lasers[0].transform.Find("LineUp").GetComponent<ParticleSystem>();
        rightLaser = lasers[1].transform.Find("LineUp").GetComponent<ParticleSystem>();
        leftFlash = lasers[0].transform.Find("Flash").GetComponent<ParticleSystem>();
        rightFlash = lasers[1].transform.Find("Flash").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(transform.position.z > 25)
        {
            transform.Translate(0, 0, -3 * Time.deltaTime);         
        }
        else
        {
            if(isLasersFire)
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
        if(collision.gameObject.name == "Player")
        {
            var playerRb = collision.gameObject.GetComponent<Rigidbody>();
            playerRb.AddForce((transform.position - playerRb.position).normalized * 100, ForceMode.Impulse);
            //var colPlayer = collision.gameObject.transform.position;
            //collision.gameObject.transform.position = new Vector3(colPlayer.x, colPlayer.y, colPlayer.z - 1);
        }
    }
}
