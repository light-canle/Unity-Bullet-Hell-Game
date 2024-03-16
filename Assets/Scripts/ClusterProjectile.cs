using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterProjectile : MonoBehaviour
{
    private float flyDist;
    private float moveDistance;
    
    private float speed = 3.5f;

    [SerializeField] private GameObject projectile;

    [SerializeField] private int count;
    // Start is called before the first frame update
    void Awake()
    {
        flyDist = 0.0f;
        moveDistance = Random.Range(10f, 25f);
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
        else
        {
            for (int i = 0; i < count; i++)
            {
                GameObject obj = Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(0, 0, i / (float)count * 180.0f));
                obj.GetComponent<Projectile>().SetType((ProjectileType)0);
            }
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHP>().Damage(4);
            AudioManager.Instance.PlaySFX(AudioManager.SFXType.Hit);
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Destoryer"))
        {
            Destroy(gameObject);
        }
    }
}
