using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameEndTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    // Update is called once per frame
    void Start()
    {
        text.text = $"{GameManager.Instance.GameTime:f2}초 동안 생존했습니다.";
    }
}
