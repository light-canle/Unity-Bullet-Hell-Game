using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIRanking : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI[] names;
    [SerializeField] private TextMeshProUGUI[] scores;

    public int _mode = 0;

    void Awake()
    {
        _mode = 0;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        ShowRanking(_mode);
    }

    public void ShowRanking(int mode)
    {
        int count = 0;
        Dictionary<string, float> infos = new Dictionary<string, float>();
        if (PlayerPrefs.HasKey($"RecordCount{mode}"))
        {
            count = PlayerPrefs.GetInt($"RecordCount{mode}");
            
            for (int i = 0; i < count; i++)
            {
                string[] info = new string[2];
                switch (mode)
                {
                    case 0:
                        info = PlayerPrefs.GetString($"R{i+1}").Split();
                        break;
                    case 1:
                        info = PlayerPrefs.GetString($"C{i+1}").Split();
                        break;
                    case 2:
                        info = PlayerPrefs.GetString($"B{i+1}").Split();
                        break;
                }
                infos.Add(info[0], float.Parse(info[1]));
            }
        }
        
        var result = infos.OrderBy(k => k.Value).Reverse().ToList();
        for (int i = 0; i < count; i++)
        {
            names[i].text = result[i].Key;
            scores[i].text = result[i].Value+"s";
        }

        for (int i = 9; i >= count; i--)
        {
            names[i].text = "---";
            scores[i].text = "0.000s";
        }
    }
    
    public void Hide()
    {
        panel.SetActive(false);
    }

    public void Activate()
    {
        panel.SetActive(true);
    }

    public void ModeChange()
    {
        _mode = (_mode + 1) % 3;
        ShowRanking(_mode);
    }
}
