using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIRankingMode : MonoBehaviour
{
    [SerializeField] private UIRanking ranking;
    [SerializeField] private TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        switch (ranking._mode)
        {
            case 0:
                text.text = "순위표(일반 모드)";
                break;
            case 1:
                text.text = "순위표(분열탄 모드)";
                break;
            case 2:
                text.text = "순위표(미사일 모드)";
                break;
        }
    }
}
