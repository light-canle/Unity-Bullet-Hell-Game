using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private Vector3 moveDirection;
    [SerializeField]
    private float moveSpeed = 8.0f;


    void Update()
    {
        bool hasControl = (moveDirection != Vector3.zero);
        if(hasControl)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            gameObject.GetComponent<SpriteRenderer>().flipX = moveDirection.x < 0;
        }
    }


    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();                   
        if(input != null)
        {
            moveDirection = new Vector3(input.x, input.y, 0f);
            //Debug.Log(moveDirection);
        }
    }
}
