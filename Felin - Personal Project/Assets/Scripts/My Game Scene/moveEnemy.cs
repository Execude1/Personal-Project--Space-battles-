using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    private float speed = 3000.0f;
    private float zDestroy = -20.0f;
    private Rigidbody enemyRb;
    private ParticleSystem enemyPs;
    private GameManager gameManagerScript;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyPs = GetComponentInChildren<ParticleSystem>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        enemyRb.AddForce(Vector3.forward * -speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")   // отталкивание метеорита при столкновении с кораблем
        {
            enemyRb.AddForce((transform.position - collision.transform.position) * 5000, ForceMode.Impulse);
        }

        if(collision.gameObject.CompareTag("Bullet"))   // уничтожение метеорита и запуск эффекта при столкновении с пулей
        {
            enemyPs.Play();
            StartCoroutine(DestroyAfterParticles());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DestroyAfterParticles()
    {
        yield return new WaitForSeconds(0.5f);
        gameManagerScript.AddScore(100);
        Destroy(gameObject);
    }
}
