using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector2 minArea = new Vector2(-10, -10);
    public Vector2 maxArea = new Vector2(10, 10);
    public float directionChangeInterval = 2f;

    private Vector2 currentDirection;
    private float pie = 3.1415f;

    private void Start()
    {
        RandomSelect(); 
        StartCoroutine(WalkFor3Seconds());
    }

    private void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 nextPosition = currentPosition + currentDirection * moveSpeed * Time.deltaTime;

        bool hitWall = false;
        Vector2 normal = Vector2.zero;

        if (nextPosition.x < minArea.x)
        {
            hitWall = true;
            normal = Vector2.right;
            nextPosition.x = minArea.x; 
        }
        else if (nextPosition.x > maxArea.x)
        {
            hitWall = true;
            normal = Vector2.left;
            nextPosition.x = maxArea.x;
        }

        if (nextPosition.y < minArea.y)
        {
            hitWall = true;
            normal = Vector2.up;
            nextPosition.y = minArea.y;
        }
        else if (nextPosition.y > maxArea.y)
        {
            hitWall = true;
            normal = Vector2.down;
            nextPosition.y = maxArea.y;
        }

        if (hitWall)
        {
            currentDirection = Vector2.Reflect(currentDirection, normal).normalized;
        }

        transform.position = nextPosition;
    }

    IEnumerator WalkFor3Seconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(directionChangeInterval);
            RandomSelect();
        }
    }

    void RandomSelect()
    {
        float angle = Random.Range(0f, 360f);
        float radian = angle * (pie/180f);

        float x = Mathf.Cos(radian);
        float y = Mathf.Sin(radian);

        currentDirection = new Vector2(x, y).normalized;
    }
}
