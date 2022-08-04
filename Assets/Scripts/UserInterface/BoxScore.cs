using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxScore : MonoBehaviour
{
    [SerializeField] SpawnTriggerAndJump penguinScript;
    [SerializeField] TextMeshProUGUI tmp;

    private int boxCount = 0;

    public void addBoxCount()
    {
        boxCount++;
        tmp.text = boxCount.ToString();
    }
}
