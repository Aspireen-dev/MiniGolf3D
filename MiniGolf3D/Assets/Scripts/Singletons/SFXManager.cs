using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    // Singleton pattern
    private static SFXManager _instance;
    public static SFXManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /* List of audioclips to play when :
     * - we hit the ball
     * - the ball falls into the hole
     * - ... (if needed)
     */

    public AudioClip[] clips;
    public AudioSource audioSource;

    public void PlayClipById(int id)
    {
        audioSource.PlayOneShot(clips[id]);
    }
}
