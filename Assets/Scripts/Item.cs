using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Heal,
    Slow,
    Shield,
    Flash
}

public class Item : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer SpriteRenderer;
    [SerializeField]
    private Sprite[] Sprites;
    private float time;
    private float lifeTime = 60.0f;
    private ItemType itemType;

    void Awake()
    {
        time = 0.0f;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            switch (itemType)
            {
                case ItemType.Heal:
                    col.gameObject.GetComponent<PlayerHP>().Heal(1);
                    AudioManager.Instance.PlaySFX(AudioManager.SFXType.Heal);
                    break;
                case ItemType.Slow:
                    GameManager.Instance.ActiveSlowTime();
                    AudioManager.Instance.PlaySFX(AudioManager.SFXType.Clock);
                    break;
                case ItemType.Shield:
                    col.gameObject.GetComponent<PlayerHP>().AddShield(6);
                    AudioManager.Instance.PlaySFX(AudioManager.SFXType.Shield);
                    break;
                case ItemType.Flash:
                    GameManager.Instance.ActiveDestoryer();
                    AudioManager.Instance.PlaySFX(AudioManager.SFXType.Flash);
                    break;
            }
            
            Destroy(gameObject);
        }
    }

    public void SetType(ItemType type)
    {
        itemType = type;
        SpriteRenderer.sprite = Sprites[(int)type];
    }
}
