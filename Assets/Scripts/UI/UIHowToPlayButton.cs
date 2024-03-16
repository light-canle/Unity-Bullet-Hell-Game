using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHowToPlayButton : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void Activate()
    {
        panel.gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        panel.gameObject.SetActive(false);
    }
}
