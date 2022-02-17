using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoxCreate : MonoBehaviour
{
    int CountBoxes = 3;
    [SerializeField]
    GameObject Box;

    void Start()
    {
        ReCreate();
    }

    public void ReCreate()
    {
        var gamePlay = GameObject.Find("[INTERFACE]").GetComponent<Gameplay>();
        if (gamePlay.CurrentLevelGame != 3)
        {
            Destroy(GameObject.Find("Box(Clone)"));
            for (int i = 0; i < GameObject.Find("GridContainer").GetComponent<Transform>().childCount; i++)
            {
                Destroy(GameObject.Find("GridContainer").transform.GetChild(i).gameObject);
            }

            for (int i = 0; i < gamePlay.alogic.LevelDifficulty[gamePlay.CurrentLevelGame] + 1; i++)
            {
                var obj = Instantiate(Box);
                obj.transform.parent = GameObject.Find("GridContainer").transform;
                obj.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
