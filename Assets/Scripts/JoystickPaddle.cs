using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPaddle : MonoBehaviour    
{
    public Transform paddle;
    [SerializeField] float speed;    
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;    

    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, Camera.main.transform.position.z));

        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MovePaddle(direction);
        }
    }

    private void MovePaddle(Vector2 direction)
    {
        paddle.Translate(direction * speed * Time.deltaTime);
    }
}
