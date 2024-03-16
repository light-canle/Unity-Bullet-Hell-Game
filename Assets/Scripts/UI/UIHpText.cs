using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHpText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private PlayerHP playerHp;

    // Update is called once per frame
    void Update()
    {
        text.text = playerHp.Shield > 0 ? $"HP : {playerHp.Hp}+{playerHp.Shield}/10" : $"HP : {playerHp.Hp}/10";
    }
}
