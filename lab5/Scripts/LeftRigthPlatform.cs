using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
 
public class horizontal_platform : MonoBehaviour {
    public float speed = 2.0f;
    private bool ismoving;
    Vector3[] positions;
    int position =0;
    private Transform oldParent;
 
    void Start()
    {
        positions = new Vector3[2];
        positions[0] = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        positions[1] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
       
 
    }
 
    void FixedUpdate()
    {
        if(ismoving)
        {
        transform.position = Vector3.MoveTowards(transform.position, positions[position], speed * Time.deltaTime);
        }
 
        if (Vector3.Distance(transform.position, positions[position]) < 0.1f) {
           
            position = (position + 1) % 2;
           
        }
       
       
 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            oldParent = other.gameObject.transform.parent;
            // skrypt przypisany do windy, ale other może być innym obiektem
            other.gameObject.transform.parent = transform;
            ismoving=true;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = null;
            ismoving=false;
        }
    }
}