using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bomb : MonoBehaviour
{
    private bool isCollidePlayer = false;
    private bool isExploding = false;

    private float moveDistance;

    private float flyDist;

    private float speed = 6.5f;
    private float radius = 6.0f;

    private float waitExplosionTime;

    [SerializeField] private ParticleSystem explosionEffect;

    [SerializeField] private CircleCollider2D collider;

    [SerializeField] private Transform explosionRadius;
    // Start is called before the first frame update
    void Awake()
    {
        explosionRadius.gameObject.SetActive(false);
        flyDist = 0.0f;
        waitExplosionTime = 0.0f;
        isCollidePlayer = false;
        moveDistance = Random.Range(5f, 39f);
        explosionEffect.Stop();
        collider.radius = 0.27f;
        if (GameManager.Instance.GameMode == 2)
        {
            float size = (GameManager.Instance.GameTime / 100.0f) * 5 + 6f;
            radius = size > 20 ? 20 : size;
        }
        else
        {
            radius = 6f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flyDist <= moveDistance)
        {
            var direction = Vector3.right;
            transform.Translate(transform.TransformDirection(-direction) * speed * Time.deltaTime);
            flyDist += speed * Time.deltaTime;
        }
        else if (waitExplosionTime <= 3.0f)
        {
            waitExplosionTime += Time.deltaTime;
        }
        else
        {
            collider.radius += Time.deltaTime * radius / 2;
            explosionRadius.gameObject.SetActive(true);
            explosionRadius.localScale = new Vector3(radius * 2, radius * 2, 1);
            var explosionEffectMain = explosionEffect.main;
            explosionEffectMain.startSpeed = new ParticleSystem.MinMaxCurve(radius / 6.0f * 2.65f);
            explosionEffect.Play();
            isExploding = true;
            Destroy(gameObject, 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (isExploding)
            {
                if (!isCollidePlayer)
                {
                    isCollidePlayer = true;
                    col.gameObject.GetComponent<PlayerHP>().Damage(3);
                }
            }
        }
        else if (col.gameObject.CompareTag("Destoryer"))
        {
            Destroy(gameObject);
        }
    }
}
