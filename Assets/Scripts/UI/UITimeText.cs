using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum UITextType
{
    GameTime,
    ItemSlowTime,
    ItemShieldTime,
}

public class UITimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private PlayerHP playerHp;
    [SerializeField] private UITextType type;
    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case UITextType.GameTime:
                text.text = $"{GameManager.Instance.GameTime:f2}s";
                break;
            case UITextType.ItemSlowTime:
                text.text = GameManager.Instance.SlowTime > 0 ? $"저속 시간 : {(GameManager.Instance.SlowTime):f1}s" : "";
                break;
            case UITextType.ItemShieldTime:
                text.text = playerHp.Shield > 0 ? $"쉴드 감소 : {(5.0f - playerHp.ShieldDecreaseTime):f1}s" : "";
                break;
        }
        
    }
}
