using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector2 minArea = new Vector2(-10, -10);
    public Vector2 maxArea = new Vector2(10, 10);
    public float directionChangeInterval = 2f;

    private Vector2[] directions = new Vector2[8];
    private Vector2 currentDirection;

    private void Start()
    {
        directions[0] = new Vector2(0, 1).normalized;   
        directions[1] = new Vector2(1, 1).normalized;   
        directions[2] = new Vector2(1, 0).normalized;   
        directions[3] = new Vector2(0, -1).normalized;  
        directions[4] = new Vector2(-1, -1).normalized;
        directions[5] = new Vector2(-1, 0).normalized;  
        directions[6] = new Vector2(-1, 1).normalized; 
        directions[7] = new Vector2(1, -1).normalized;  
        
        StartCoroutine(WalkFor3Seconds());
    }

    private void Update()
    {
        if(transform.position.x < minArea.x || transform.position.x > maxArea.x ||
            transform.position.y < minArea.y || transform.position.y > maxArea.y)
        {
            Debug.Log("지역 범위 밖");
        }
        else
        {
            transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
        }
        
    }

    IEnumerator WalkFor3Seconds()
    {
        while (true)  
        {
            RandomSelect();

            yield return new WaitForSeconds(3f);
            
        }
    }

    void RandomSelect()
    {
        int num = Random.Range(0, 8);  
        currentDirection = directions[num];  
    }
}
