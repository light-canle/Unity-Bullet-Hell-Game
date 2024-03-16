using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIRanktext : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI text;
    private float[] timeList;
    void Start()
    {
        float[] normalList = new float[] { 45.0f, 90.0f, 150.0f, 210.0f, 300.0f, 420.0f, 540.0f };
        float[] clusterList = new float[] { 35.0f, 70.0f, 105.0f, 140.0f, 180.0f, 220.0f, 270.0f };
        float[] bombList = new float[] { 40.0f, 75.0f, 120.0f, 165.0f, 220.0f, 280.0f, 350.0f };
        int mode = GameManager.Instance.GameMode;
        timeList = mode == 0 ? normalList : (mode == 1 ? clusterList : bombList);
        float curTime = GameManager.Instance.GameTime;

        if (curTime <= timeList[0])
        {
            text.text = "E";
            text.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else if (curTime <= timeList[1])
        {
            text.text = "D";
            text.color = new Color(0.75f, 0.75f, 0.75f);
        }
        else if (curTime <= timeList[2])
        {
            text.text = "C";
        }
        else if (curTime <= timeList[3])
        {
            text.text = "B";
            text.color = new Color(1.0f, 1.0f, 0.75f);
        }
        else if (curTime <= timeList[4])
        {
            text.text = "A";
            text.color = new Color(1.0f, 1.0f, 0.65f);
        }
        else if (curTime <= timeList[5])
        {
            text.text = "S";
            text.color = new Color(1.0f, 1.0f, 0.40f);
        }
        else if (curTime <= timeList[6])
        {
            text.text = "SS";
            text.color = new Color(1.0f, 1.0f, 0.25f);
        }
        else
        {
            text.text = "SSS";
            text.color = new Color(1.0f, 1.0f, 0.0f);
        }
    }
}
