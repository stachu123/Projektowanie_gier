using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class squaremove : MonoBehaviour {
    public float speed = 2.0f;
    Vector3[] rogi;
    int pozycja =0;

    void Start()
    {
        rogi = new Vector3[4];
        rogi[0] = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        rogi[1] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        rogi[2] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z + 10);
        rogi[3] = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
        transform.Rotate(0, 90, 0, Space.Self);

    }

    void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, rogi[pozycja], speed * Time.deltaTime);


        if (Vector3.Distance(transform.position, rogi[pozycja]) < 0.1f) {
            
            pozycja = (pozycja + 1) % 4;
            transform.Rotate(0, -90, 0, Space.Self);
        }
        
        

    }
}