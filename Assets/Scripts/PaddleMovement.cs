using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] GameObject particalEffect;
    [SerializeField] float paddleSpeed;
    [SerializeField] int numberOfFruitsInBusket;
    [SerializeField] Text score;
    private Vector2 screenBounds;    
    private float paddleWidth;
    private float paddleHeight;
    private AudioSource audioClip;
    private Rigidbody2D rb;
    SceneChanger sceneChanger;
    FruitsSpawner fruitsSpawner;

    void Start()
    {
        numberOfFruitsInBusket = 0;
        score.text = numberOfFruitsInBusket.ToString();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        audioClip = GetComponent<AudioSource>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        paddleWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        paddleHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        sceneChanger = FindObjectOfType<SceneChanger>();
        fruitsSpawner = FindObjectOfType<FruitsSpawner>();
        

    }

    

    private void Update()
    {
        TouchMove();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + paddleWidth, screenBounds.x - paddleWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + paddleHeight, screenBounds.y - paddleHeight);
        transform.position = viewPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fruit")
        {
            audioClip.Play();
            numberOfFruitsInBusket++;
            fruitsSpawner.totalAmountOfFruitsDown--;
            score.text = numberOfFruitsInBusket.ToString();
            StartCoroutine(FruitsPartical());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator FruitsPartical()
    {
        GameObject partical = Instantiate(particalEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(partical);
        
    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //rb.position = mousePosition;            
            //rb.velocity = new Vector2(mousePosition.x, rb.velocity.y);
            //rb.MovePosition(rb.velocity);
            rb.MovePosition(new Vector2(mousePosition.x, rb.velocity.y));            
        }
    }

   
}
