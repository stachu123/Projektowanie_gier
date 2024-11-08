using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
 
public class Moving_platform : MonoBehaviour {
    public float speed = 2.0f;
    public List<Vector3> positions = new List<Vector3>();

    private bool ismoving;
    private bool isreturning;
    private Vector3 startPosition;
    
    int position =0;
    private Transform oldParent;
 
    void Start()
    {
        if (positions.Count == 0)
        {
            // Domyślne pozycje, jeśli lista jest pusta
            startPosition = transform.position;
            positions.Add(startPosition);
            positions.Add(startPosition + new Vector3(10, 0, 0));
        }
        else
        {
            // Przypisanie pozycji początkowej jako pierwszego punktu
            startPosition = positions[0];
        }
 
    }
 
    void FixedUpdate()
    {
        if (ismoving)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, positions[position], speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, positions[position]) < 0.1f)
            {
                position = (position + 1) % positions.Count;
            }
        }
        else if (isreturning)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                isreturning = false; // Zatrzymaj po osiągnięciu pozycji początkowej
            }
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
            isreturning = false;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = null;
            ismoving=false;
            isreturning = true;
        }
    }
}