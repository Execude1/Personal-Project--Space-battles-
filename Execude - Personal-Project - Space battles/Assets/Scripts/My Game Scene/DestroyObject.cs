using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private ParticleSystem enemyPs;
    private bool isInsideEnemy = false;

    private void Start()
    {
        enemyPs = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {      
        if (collision.gameObject.CompareTag("Bullet") && !isInsideEnemy)
        {
            Destroy(collision.gameObject);
            GameManager.gameManager.AddScore(100);
            enemyPs.Play();
            StartCoroutine(DestroyAfterParticles());
            isInsideEnemy = true;
        }
        if (collision.gameObject.name == "Player")
        {
            if (gameObject.name.Contains("Asteroid") && !isInsideEnemy)
            {
                GameManager.gameManager.SubHealth(10);
                gameObject.GetComponent<SphereCollider>().enabled = false;
                isInsideEnemy = true;
            }
            if (gameObject.name.Contains("Bomb") && !isInsideEnemy)
            {
                GameManager.gameManager.SubHealth(10);
                gameObject.GetComponent<SphereCollider>().enabled = false;
                isInsideEnemy = true;
            }
            if (gameObject.name.Contains("StarSparrow") && !isInsideEnemy)
            {
                GameManager.gameManager.SubHealth(10);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                isInsideEnemy = true;
            }

            enemyPs.Play();
            StartCoroutine(DestroyAfterParticles());
        }
    }

    IEnumerator DestroyAfterParticles()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        isInsideEnemy = false;
    }     
}
