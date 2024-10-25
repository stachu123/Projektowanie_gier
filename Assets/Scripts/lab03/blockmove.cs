using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ExampleScript : MonoBehaviour {
    public float speed = 2.0f;
    Vector3[] positions;
    int position =0;

    void Start()
    {
        positions = new Vector3[2];
        positions[0] = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        positions[1] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        transform.Rotate(0, 180, 0, Space.Self);

    }

    void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[position], speed * Time.deltaTime);


        if (Vector3.Distance(transform.position, positions[position]) < 0.1f) {
            
            position = (position + 1) % 2;
            transform.Rotate(0, 180, 0, Space.Self);
        }
        
        

    }
}