using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField]
    Sprite[] spite;

    void Start()
    {
        var Gameplay = GameObject.Find("[INTERFACE]").GetComponent<Gameplay>();
        var arrLetter = GameObject.Find("[INTERFACE]").GetComponent<Gameplay>().alogic.arrLetter;
        for (int i = 0; i < spite.Length - 1; i++)
        {
            if (Gameplay.CurrentLevelGame < 3)
            {
                try
                {
                    if (spite[i].name == arrLetter[Box.NumberThisBox - 1])
                    {
                        GetComponent<Image>().sprite = spite[i];
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
        
    }
}
