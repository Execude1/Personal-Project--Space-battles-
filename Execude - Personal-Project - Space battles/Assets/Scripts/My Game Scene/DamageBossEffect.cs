using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBossEffect : MonoBehaviour
{
    private bool isAvailableForDamageLasers = true;

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && transform.gameObject.name.Contains("Laser bombardment"))
        {
            if(isAvailableForDamageLasers)
            {
                StartCoroutine(SubHealthFromDamageLasers());
                isAvailableForDamageLasers = false;
            }
            else
            {
                return;
            }              
        }
        if (collision.gameObject.name == "Player" && transform.gameObject.name.Contains("Blue sphere"))
        {
            GameManager.gameManager.SubHealth(25);
            Destroy(gameObject);
        }
    }

    IEnumerator SubHealthFromDamageLasers()
    {
        yield return new WaitForSeconds(.35f);
        GameManager.gameManager.SubHealth(10);
        isAvailableForDamageLasers = true;
    }
}
