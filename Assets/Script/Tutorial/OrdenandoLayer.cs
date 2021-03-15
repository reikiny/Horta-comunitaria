using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrdenandoLayer : MonoBehaviour
{
    public SpriteRenderer sprite;
    public static int orderInLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sprite.sortingOrder = orderInLayer;
        
    }


}
