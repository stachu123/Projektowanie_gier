using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
 
public class Door : MonoBehaviour {
    public float speed = 2.0f;
    private bool ismoving;
    private bool isClosing;
    private Vector3 zamkniete; // Pozycja zamkniętych drzwi
    private Vector3 otwarte;
    private Transform oldParent;
 
    void Start()
    {
        zamkniete = transform.position;
        otwarte = zamkniete + new Vector3(0,3,0);

    }
 
    void FixedUpdate()
    {
        if(ismoving)
        {
        transform.position = Vector3.MoveTowards(transform.position, otwarte, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, otwarte) < 0.1f)
            {
                ismoving = false; // Zatrzymaj, gdy drzwi są otwarte
            }
        }
        else if (isClosing)
        {
            // Przesuwanie drzwi do pozycji zamkniętej
            transform.position = Vector3.MoveTowards(transform.position, zamkniete, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, zamkniete) < 0.1f)
            {
                isClosing = false; // Zatrzymaj, gdy drzwi są zamknięte
            }
        }
        
       
       
 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            // oldParent = other.gameObject.transform.parent;
            // // skrypt przypisany do windy, ale other może być innym obiektem
            // other.gameObject.transform.parent = transform;
            ismoving=true;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Player zszedł z windy.");
            // other.gameObject.transform.parent = null;
            isClosing=true;
        }
    }
}