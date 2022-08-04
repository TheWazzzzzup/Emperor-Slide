using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxScore : MonoBehaviour
{
    [SerializeField] SpawnTriggerAndJump penguinScript;
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        tmp.text = penguinScript.GetReward().ToString();
    }
}
