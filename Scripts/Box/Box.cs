using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public static int NumberThisBox;
    private int LetterNumberInArray = 0;
    [SerializeField]
    GameObject WinEffect;

    void Start()
    {
        anim = GetComponentInChildren<Animator>(); 
        LetterNumberInArray = NumberThisBox;
        var GamePlay = GameObject.Find("[INTERFACE]").GetComponent<Gameplay>();
        ++NumberThisBox;
    }

    Animator anim;
    public void ONbuttonClick()
    {
        var GamePlay = GameObject.Find("[INTERFACE]").GetComponent<Gameplay>();
        try
        {            
            if (GamePlay.alogic.arrLetter[LetterNumberInArray] == GamePlay.alogic.FindLetter)
            {
                anim.Play("TrueAnswer");
                Instantiate(WinEffect, new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
                StartCoroutine(DelayTime(anim.GetCurrentAnimatorStateInfo(0).length));                
            }
            else
            {               
                anim.Play("Event");
            }
        }
        catch 
        {
            Debug.Log("OOPS");
        }
    }

    IEnumerator DelayTime( float _delay = 0 )
    {
        yield return new WaitForSeconds(_delay);

        var GamePlay = GameObject.Find("[INTERFACE]").GetComponent<Gameplay>();
        GamePlay.CurrentLevelGame++;
        GameObject.Find("[INTERFACE]").GetComponent<BoxCreate>().ReCreate();
        NumberThisBox = 0;
        GamePlay.SetDifficultyLevel(GamePlay.CurrentLevelGame);
    }
}
