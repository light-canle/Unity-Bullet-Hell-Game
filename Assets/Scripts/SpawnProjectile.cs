using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    private float reloadTime;
    private float totalTime;
    private float time;
    private float eventTime;
    private float homingSpawnTime;
    private float homingSpawnRate;
    private float clusterHomingTime;
    private int eventLevel;
    private int homingSpawnCount;

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject clusterProjectile;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject homingProjectile;

    [SerializeField] private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        totalTime = 0.0f;
        time = 0.0f;
        eventTime = 0.0f;
        homingSpawnRate = 54f;
        reloadTime = Random.Range(0.18f, 0.30f);
        homingSpawnTime = 0.0f;
        homingSpawnCount = 0;
        clusterHomingTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameMode == 0)
        {
            NormalMode();
        }
        else if (GameManager.Instance.GameMode == 1)
        {
            ClusterMode();
        }
        else
        {
            homingSpawnRate = 3f;
            BombMode();
        }
    }

    void NormalMode()
    {
        totalTime += Time.deltaTime;
        time += Time.deltaTime;
        eventTime += Time.deltaTime;
        homingSpawnTime += Time.deltaTime;

        if (homingSpawnCount > 0)
        {
            clusterHomingTime += Time.deltaTime;
            if (clusterHomingTime >= 0.15f)
            {
                clusterHomingTime = 0.0f;
                homingSpawnCount -= 1;
                Instantiate(homingProjectile, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
            }
        }
        
        if (time >= reloadTime)
        {
            time = 0.0f;
            reloadTime = totalTime > 90.0f ? Random.Range(0.04f, 0.12f) : (totalTime > 45.0f ? Random.Range(0.10f, 0.22f) : Random.Range(0.18f, 0.30f));
            int type = totalTime > 45.0f ? Random.Range(0, 20) : Random.Range(0, 18);
            if (type == 19)
            {
                Instantiate(bomb, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
            }
            else if (type == 18)
            {
                Instantiate(clusterProjectile, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
            }
            else
            {
                GameObject obj = Instantiate(projectile, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
                int ammoType = totalTime > 30.0f ? Random.Range(0, 3) : Random.Range(0, 2);
                obj.GetComponent<Projectile>().SetType((ProjectileType)ammoType);
            }
        }

        if (eventTime >= 30.0f)
        {
            eventTime = 0.0f;
            if (totalTime >= 60.0f)
            {
                int type = Random.Range(0, 3);
                int count = 16 + eventLevel * 16;
                if (type == 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Instantiate(bomb, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
                    }
                }
                else if (type == 2 && totalTime >= 120.0f)
                {
                    homingSpawnCount = Random.Range(3, (int)(count / 1.5));
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        Instantiate(clusterProjectile, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
                    }
                }
            }
        }

        if (homingSpawnTime >= homingSpawnRate)
        {
            homingSpawnTime = 0.0f;
            homingSpawnRate = (homingSpawnRate <= 5.0f) ? 5.0f : homingSpawnRate - 3f;
            Instantiate(homingProjectile, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
        }

        eventLevel = (totalTime >= 360.0f) ? 5 : (int)(totalTime / 90.0f) + 1;
    }

    void ClusterMode()
    {
        totalTime += Time.deltaTime;
        time += Time.deltaTime;
        eventTime += Time.deltaTime;
        
        if (time >= reloadTime)
        {
            time = 0.0f;
            reloadTime = totalTime > 90.0f ? Random.Range(0.04f, 0.12f) : (totalTime > 45.0f ? Random.Range(0.10f, 0.22f) : Random.Range(0.18f, 0.30f));
            Instantiate(clusterProjectile, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
        }

        if (eventTime >= 30.0f)
        {
            eventTime = 0.0f;
            int count = 16 + eventLevel * 16;
            for (int i = 0; i < count; i++)
            {
                Instantiate(clusterProjectile, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
            }
        }
        
        eventLevel = (totalTime >= 360.0f) ? 5 : (int)(totalTime / 90.0f) + 1;
    }

    void BombMode()
    {
        totalTime += Time.deltaTime;
        time += Time.deltaTime;
        eventTime += Time.deltaTime;
        homingSpawnTime += Time.deltaTime;
        
        if (homingSpawnCount > 0)
        {
            clusterHomingTime += Time.deltaTime;
            if (clusterHomingTime >= 0.15f)
            {
                clusterHomingTime = 0.0f;
                homingSpawnCount -= 1;
                Instantiate(homingProjectile, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
            }
        }
        
        if (time >= reloadTime)
        {
            time = 0.0f;
            reloadTime = totalTime > 90.0f ? Random.Range(0.2f, 0.3f) : (totalTime > 45.0f ? Random.Range(0.3f, 0.4f) : Random.Range(0.4f, 0.6f));
            Instantiate(bomb, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
        }
        
        if (eventTime >= 30.0f)
        {
            eventTime = 0.0f;
            int count = 16 + eventLevel * 16;
            for (int i = 0; i < count; i++)
            {
                Instantiate(bomb, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
            }
            homingSpawnCount = Random.Range(3, (int)(count / 1.5));
        }
        if (homingSpawnTime >= homingSpawnRate)
        {
            homingSpawnTime = 0.0f;
            homingSpawnRate = 3f;
            Instantiate(homingProjectile, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0f, 360.0f)));
        }
        
        eventLevel = (totalTime >= 360.0f) ? 5 : (int)(totalTime / 90.0f) + 1;
    }
}
