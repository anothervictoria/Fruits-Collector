using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] fruits;    
    GameObject fruittoFall;    
    int fruitsIndex;
    bool couroutineHasStarted = false;  
    Vector3 fruitsPosition;  
    Vector2 bounds;
    [SerializeField] float yPos;
    float xPos = 20f;
    public int totalAmountOfFruitsDown;
   
   


    private void Start()
    {
        couroutineHasStarted = true;
        totalAmountOfFruitsDown = 40;
    }

    void Update()
    {
          StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        if (couroutineHasStarted)
        {
            couroutineHasStarted = false;
            for (int i = 0; i < 40; i++)
            {
                bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                Debug.Log($"bounds {bounds}");                
                xPos = Random.Range(-bounds.x, bounds.x);              

                fruitsPosition = new Vector3(xPos, yPos, 0);
                Debug.Log($"fruits position {fruitsPosition}");
                Debug.Log($"xPos {xPos}");
                Debug.Log($"yPos{yPos}");
                fruitsIndex = Random.Range(0, fruits.Length);                
                fruittoFall = Instantiate(fruits[fruitsIndex], fruitsPosition, Quaternion.identity) as GameObject;
                ConstantForce2D fruitsFconstantForce = fruittoFall.GetComponent<ConstantForce2D>();
                Vector2 fruitsForce = fruitsFconstantForce.force;
                fruitsForce.y = Random.Range(-3f, -12f);
                fruitsFconstantForce.force = fruitsForce;               

                yield return new WaitForSeconds(1f);
                couroutineHasStarted = false;
            }
            
        }                    
       
    }

   


}
