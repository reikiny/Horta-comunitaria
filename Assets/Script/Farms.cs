using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farms : MonoBehaviour
{
    private Animator myAnimacion;
    private Rigidbody2D myRigdbody;

    public GameObject[] campoDePlantar;

    private void Start()
    {
        myRigdbody = GetComponent<Rigidbody2D>();
        myAnimacion = GetComponent<Animator>();  
    }
}
