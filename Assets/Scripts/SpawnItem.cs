using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    private float reloadTime;
    private float time;
    [SerializeField] private GameObject item;
    
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        reloadTime = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameMode == 1)
            return;
        
        time += Time.deltaTime;

        if (time >= reloadTime)
        {
            time = 0.0f;
            reloadTime = Random.Range(4.0f, 9.5f);
            float x = Random.Range(3, 30) * (Random.Range(0, 2) == 1 ? 1 : -1) + 0.5f;
            float y = Random.Range(3, 30) * (Random.Range(0, 2) == 1 ? 1 : -1) + 0.5f;
            Vector3 pos = new Vector3(x , y, 0);
            GameObject obj =  Instantiate(item, pos, Quaternion.identity, gameObject.transform);
            
            // 아이템 스폰 비율 설정
            // 회복 : 저속 : 보호막 : 섬광 = 4 : 2 : 1 : 3
            switch (Random.Range(0, 10))
            {
                case < 4:
                    obj.GetComponent<Item>().SetType(ItemType.Heal);
                    break;
                case < 6:
                    obj.GetComponent<Item>().SetType(ItemType.Slow);
                    break;
                case < 7:
                    obj.GetComponent<Item>().SetType(ItemType.Shield);
                    break;
                case < 10:
                    obj.GetComponent<Item>().SetType(ItemType.Flash);
                    break;
            }
            
        }
    }
}
