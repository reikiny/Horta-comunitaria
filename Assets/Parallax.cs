using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] pieces;
    public float[] speed;
    public float width;
    public Vector2 randomHeightChange, randomSpeed;

    void Awake()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            speed[i] = Random.Range(randomSpeed.x, randomSpeed.y);
            pieces[i].transform.position = new Vector3(pieces[i].transform.position.x, Random.Range(randomHeightChange.x, randomHeightChange.y), pieces[i].transform.position.z);
        }

    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].position.x >= width * 2)
            {
                pieces[i].transform.position = new Vector3(width * -2, Random.Range(randomHeightChange.x, randomHeightChange.y), pieces[i].transform.position.z);
            }
            pieces[i].transform.Translate(Vector2.right * speed[i] * Time.deltaTime);
        }
    }
}
