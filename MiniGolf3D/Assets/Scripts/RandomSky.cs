using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSky : MonoBehaviour
{
    public Material[] mats;

    void Start()
    {
        int random = Random.Range(0, mats.Length);
        RenderSettings.skybox = mats[random];
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }

}
