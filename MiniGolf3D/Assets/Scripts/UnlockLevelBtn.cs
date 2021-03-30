using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevelBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int thisLvl = int.Parse(gameObject.name);
        int lastUnlockedLevel = PlayerPrefs.GetInt("lastUnlockedLevel");
        if (thisLvl <= lastUnlockedLevel)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
