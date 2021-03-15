using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    bool touching;
    Collider2D collide;
    public Transform background;
    public float speed;
    public float widht;
    int pau;

    private void Start()
    {
        collide = GetComponent<Collider2D>();
    }
    private void Update()
    {
        DetectColission();

    }

    void DetectColission()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(collide == touchedCollider)
                {
                    touching = true;
                    if (gameObject.tag == "Right")
                    {
                        pau++;
                    }
                }
                
            }

            if(touch.phase == TouchPhase.Stationary)
            {
                MovePlate();
                   
            }
            if(touch.phase == TouchPhase.Ended)
            {
                touching = false;
            }
        }
    }

    void MovePlate()
    {
        if (touching)
        {
            if (gameObject.tag == "Left")
            {
                if (background.transform.position.x <= widht)
                {
                    background.transform.Translate(Vector2.right * speed * Time.deltaTime);
                }
            }
            if (gameObject.tag == "Right")
            {
               // pau++;
                if (background.transform.position.x >= -widht)
                {
                    
                    //background.transform.Translate(Vector2.left * speed * Time.deltaTime);
                }
            }

        }
    }
}
