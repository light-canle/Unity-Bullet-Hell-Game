using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRanking : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("RecordCount0") || !PlayerPrefs.HasKey("RecordCount1") || !PlayerPrefs.HasKey("RecordCount2"))
        {
            Init();
        }
    }
    // Start is called before the first frame update
    public void AddRecord(string playerName, float score, int mode)
    {
        int count = PlayerPrefs.GetInt($"RecordCount{mode}");
        PlayerPrefs.SetInt($"RecordCount{mode}", count + 1);
        string name = string.Join("", playerName.Split());
        if (mode == 0)
        {
            PlayerPrefs.SetString($"R{count + 1}", $"{name} {score:f3}");
        }
        else if (mode == 1)
        {
            PlayerPrefs.SetString($"C{count + 1}", $"{name} {score:f3}");
        }
        else if (mode == 2)
        {
            PlayerPrefs.SetString($"B{count + 1}", $"{name} {score:f3}");
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Init()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("RecordCount0", 0);
        PlayerPrefs.SetInt("RecordCount1", 0);
        PlayerPrefs.SetInt("RecordCount2", 0);
    }
}
