using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] Transform penguin;
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        float score = 0;
        if (penguin.position.x < 0)
        {
            score = 0;
        }
        else
        {
            score = penguin.position.x;
        }
        tmp.text = score.ToString("0");
    }
}
