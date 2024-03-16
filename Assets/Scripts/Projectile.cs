using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    Normal,
    Fast,
    Big,
}

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private int damage;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private Sprite[] ProjectileImages;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        var direction = Vector3.right;
        transform.Translate(transform.TransformDirection(-direction) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHP>().Damage(damage);
            AudioManager.Instance.PlaySFX(AudioManager.SFXType.Hit);
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Destoryer"))
        {
            Destroy(gameObject);
        }
    }

    public void SetType(ProjectileType type)
    {
        switch (type)
        {
            case ProjectileType.Normal:
                speed = 7;
                damage = 1;
                transform.localScale = Vector3.one;
                sprite.sprite = ProjectileImages[0];
                break;
            case ProjectileType.Fast:
                speed = 11;
                damage = 1;
                transform.localScale = Vector3.one;
                sprite.sprite = ProjectileImages[1];
                break;
            case ProjectileType.Big:
                speed = 5;
                damage = 2;
                transform.localScale = Vector3.one * 2f;
                sprite.sprite = ProjectileImages[2];
                break;
        }
    }
}
