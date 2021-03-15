using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Borboleta : MonoBehaviour
{
    public Transform pieces;
    public float speed;
    public float width;
    public Image image;
    void Start()
    {
        if (this.gameObject.tag == "Borboleta")
            image.color = Random.ColorHSV(0.2f, 0.8f,0.7f,1,1,1);

        pieces.transform.position = new Vector3(pieces.transform.position.x, pieces.transform.position.y, pieces.transform.position.z);
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        if (pieces.position.x >= width * 2 && speed > 0)
        {
            if (this.gameObject.tag == "Borboleta")
                image.color = Random.ColorHSV(0.2f, 0.8f,0.7f,1,1,1);
            pieces.transform.position = new Vector3(width * -2, pieces.transform.position.y, pieces.transform.position.z);
        }
        else if(pieces.position.x <= width * -2)
        {
            pieces.transform.position = new Vector3(width * 2, pieces.transform.position.y, pieces.transform.position.z);
        }

        pieces.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
