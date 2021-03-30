using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.PunchScale(gameObject, iTween.Hash(
            "looptype", iTween.LoopType.loop,
            "amount", new Vector3(1.01f, 1.01f, 1.01f),
            "time", 2.0f,
            "easetype", iTween.EaseType.easeInSine
        ));
    }

}
