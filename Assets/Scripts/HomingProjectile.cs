using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private Transform target;

    private float time;
    private float homingTime;
    private Vector3 targetVec;
    
    // Start is called before the first frame update
    void Awake()
    {
        time = 0.0f;
        target = GameObject.FindWithTag("Player").transform;
        homingTime = Random.Range(12.0f, 24.0f);
        if (GameManager.Instance.GameTime == 2)
        {
            float mul = GameManager.Instance.GameTime / 180.0f * 1.1f + 1;
            speed = mul > 2.1f ? Random.Range(2.2f, 3.0f) * 2.1f : Random.Range(2.2f, 3.0f) * mul;
        }
        else
        {
            speed = Random.Range(2.2f, 3.0f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time <= homingTime)
        {
            targetVec = (target.position - transform.position).normalized;
            GetComponent<SpriteRenderer>().flipY = targetVec.x < 0;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan(targetVec.y / targetVec.x) * Mathf.Rad2Deg - 90.0f);
        }

        transform.position += targetVec * speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHP>().Damage(2);
            AudioManager.Instance.PlaySFX(AudioManager.SFXType.Explosion);
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Destoryer"))
        {
            Destroy(gameObject);
        }
    }
}
