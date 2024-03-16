using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    public PlayerRanking ranking;
    public TMP_InputField name;
    // Start is called before the first frame update
    public void AddRecord()
    {
        float score = GameManager.Instance.GameTime;
        int mode = GameManager.Instance.GameMode;
        ranking.AddRecord(name.text, score, mode);
    }

    public void EndGame()
    {
        AddRecord();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
