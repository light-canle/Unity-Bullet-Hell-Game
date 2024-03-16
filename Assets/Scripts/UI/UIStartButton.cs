using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartButton : MonoBehaviour
{
    [SerializeField] private GameObject gameModePanel;
    public void GameStart()
    {
        gameModePanel.SetActive(true);
    }
}
