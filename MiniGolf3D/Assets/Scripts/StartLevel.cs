using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    public GameObject introLevelCamera;
    public GameObject gameIHMPanel;
    public GameObject pauseBtn;

    private void Start()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        GetComponent<Text>().text = "Press <b><i>Space</i></b> or <b><i>Left Click</i></b> to play";
#endif

#if UNITY_ANDROID || UNITY_IOS
        GetComponent<Text>().text = "Touch the screen to play";
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            PrepareLevel();
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            PrepareLevel();
        }
#endif
    }

    private void PrepareLevel()
    {
        introLevelCamera.SetActive(false);
        gameIHMPanel.SetActive(true);
        pauseBtn.SetActive(true);
        gameObject.SetActive(false);
    }

}
