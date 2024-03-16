using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecoration : MonoBehaviour
{
    private int count = 200;
    [SerializeField] private Sprite[] decorationList;
    [SerializeField] private GameObject decoration;
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(3, 40) * (Random.Range(0, 2) == 1 ? 1 : -1) + 0.5f;
            float y = Random.Range(3, 40) * (Random.Range(0, 2) == 1 ? 1 : -1) + 0.5f;
            Vector3 pos = new Vector3(x, y, 0);
            GameObject obj =  Instantiate(decoration, pos, Quaternion.identity, gameObject.transform);
            obj.GetComponent<SpriteRenderer>().sprite = decorationList[Random.Range(0, decorationList.Length)];
        }
    }

}
