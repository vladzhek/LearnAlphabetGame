using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    [SerializeField]
    Text TextFind;
    [SerializeField]
    GameObject PanelRestart;

    public AlphabetLogic alogic;
    public int CurrentLevelGame = 0;

    const int SetEasyMode = 2, SetMediumMode = 5, SetHardMode = 8;
    void Start()
    {
        CurrentLevelGame = 0;
        //����� ���������� ����� �� ������ ���������
        alogic = new AlphabetLogic(SetEasyMode, SetMediumMode, SetHardMode);
        SetDifficultyLevel(CurrentLevelGame);//������������ ��������� 1
        PanelRestart.SetActive(false);
        //Fade
        StartCoroutine(DelayTime(1));

    }

    private void Update()
    {
        if (CurrentLevelGame == 3)
        {
            PanelRestart.SetActive(true);
        }
    }

    public void SetDifficultyLevel(int levelDifficulty)
    {
        if (CurrentLevelGame <= 3)
        {
            Debug.Log("CurrentLevelGame = " + CurrentLevelGame);
            alogic.FillArray();// �������������� ������� �������
            alogic.CurretLevelDifficulty = levelDifficulty;// ��������� ���������
            //����� ��������� ����� �� ������ �������
            alogic.GetRandomLetter(alogic.LevelDifficulty[CurrentLevelGame]);
            TextFind.text = "Find: " + alogic.FindLetter;
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator DelayTime(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        GameObject.Find("StartPanel").SetActive(false);
    }
}
