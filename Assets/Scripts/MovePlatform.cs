using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    public bool dirX;

    bool moveinUp = true;
    bool moveinRight = true;

    [SerializeField] private GameObject PointLeft;
    [SerializeField] private GameObject PoinRigth;

    // Update is called once per frame
    void Update()
    {
        if (dirX)
        {
            MoveDirX();
        }
        else
        {
            MoveDirY();
        }
    }

    void MoveDirX()
    {
        if (transform.position.x > PoinRigth.transform.position.x)
        {
            moveinRight = false;
        }
        else if (transform.position.x < PointLeft.transform.position.x)
        {
            moveinRight = true;
        }

        if (moveinRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void MoveDirY()
    {
        if (transform.position.y > PoinRigth.transform.position.y)
        {
            moveinUp = false;
        }
        else if (transform.position.y < PointLeft.transform.position.y)
        {
            moveinUp = true;
        }

        if (moveinUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }


}
