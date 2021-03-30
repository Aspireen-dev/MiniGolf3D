using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    public RectTransform powerBar;
    public GameObject guide;
    public GameObject ball;
    Rigidbody ballRb;
    Button shotBtn;

    bool canShot = true;
    bool powerActivated = false;
    int shotPowerMultiplier = 4000;
    bool canCheckSpeed = false;

    int nbShots = 0;

    private void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
        shotBtn = GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            HandleShot();
        }
        if (canCheckSpeed && ballRb.velocity.magnitude < 0.2f)
        {
            canShot = true;
            shotBtn.interactable = true;
        }
    }

    public void HandleShot()
    {
        if (canShot)
        {
            if (!powerActivated)
            {
                powerActivated = true;
                guide.SetActive(true);
                StartCoroutine(AnimatePowerBar());
            }
            else
            {
                powerActivated = false;
                canShot = false;
                canCheckSpeed = false;
                guide.SetActive(false);
                ShotBall();
                nbShots++;
            }
        }
    }

    public void ShotBall()
    {
        StopAllCoroutines();

        shotBtn.interactable = false;
        SFXManager.Instance.PlayClipById(0);
        float shotPower = powerBar.localScale.y * shotPowerMultiplier;
        ballRb.AddForce(Camera.main.transform.forward * shotPower);
        powerBar.localScale = Vector3.one;
        StartCoroutine(ActivateSpeedCheck());
    }

    IEnumerator ActivateSpeedCheck()
    {
        yield return new WaitForSeconds(1);
        canCheckSpeed = true;
    }

    IEnumerator AnimatePowerBar()
    {
        float val = 0.01f;
        while (powerActivated)
        {
            yield return new WaitForSeconds(val);
            powerBar.localScale = new Vector3(1, powerBar.localScale.y - val, 1);
            if (powerBar.localScale.y < 0.02f || powerBar.localScale.y > 0.99f)
            {
                val = -val;
            }
        }
    }

    public int GetNbShots()
    {
        return nbShots;
    }

}
