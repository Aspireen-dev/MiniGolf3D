using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject winParticles;
    public Text nbShotsText;
    public Shot shotScript;
    public GameObject endLevelPanel;

    Rigidbody rb;
    Vector3 initalPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Save initial position to use it as respawn position
        initalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the ball goes into the hole
        if (other.gameObject.tag == "Hole")
        {
            // Increase score in function of the number of shots
            int nbShots = shotScript.GetNbShots();
            int score = (10 - nbShots) * 100;
            if (score < 0) score = 0;
            GameManager.Instance.IncreaseScore(score);

            // Instantiate particle effect and play audioclip
            Instantiate(winParticles, other.transform);
            SFXManager.Instance.PlayClipById(1);

            // Update UI and show endLevelPanel
            nbShotsText.text = "Terminé en " + nbShots + " coup(s) !";
            endLevelPanel.SetActive(true);
        }

        // If the ball falls off the platform level, respawn
        if (other.gameObject.tag == "Fall")
        {
            StartCoroutine(Respawn());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the ball hits a barrel, it explodes
        if (collision.gameObject.tag == "Barrel")
        {
            collision.gameObject.GetComponent<Barrel>().Explode(rb);
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1);
        // Sleep the rigidbody of the ball to reset movement and rotation speeds
        rb.Sleep();
        transform.position = initalPosition;
    }
}
