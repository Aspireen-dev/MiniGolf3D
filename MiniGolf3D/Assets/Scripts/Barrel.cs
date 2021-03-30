using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject explosionParticles;
    bool hasExploded = false;

    public void Explode(Rigidbody otherRb)
    {
        // If the barrel hasn't been hit yet by the ball, explode it
        if (!hasExploded)
        {
            hasExploded = true;
            GameObject particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            otherRb.AddExplosionForce(2000f, transform.position, 3f);
            Destroy(particles, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the barrel falls off the platform level, destroy it
        if (other.gameObject.tag == "Fall")
        {
            print("fallen");
            Destroy(gameObject, 1f);
        }
    }
}
