using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generujkostki : MonoBehaviour
{
   public GameObject block;
   List<Vector3> pozycje;
  
   void Start()
   {
    

       //pobieranie wartości skrajnych platformy
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Bounds bounds = meshRenderer.bounds;
        float minX = bounds.min.x;
        float maxX = bounds.max.x;
        float minZ = bounds.min.z;
        float maxZ = bounds.max.z;
        pozycje = GenerujPozycje(minX, maxX, minZ, maxZ);
        for(int i=0; i <10; ++i)
        {
            Instantiate(block, pozycje[i], Quaternion.identity);
        }


   }
   List<Vector3> GenerujPozycje( float minX, float maxX, float minZ, float maxZ)
   {
    // tworzenie hashmapy dla unikalnych wartosci vector3
    HashSet<Vector3> HashPozycje = new HashSet<Vector3>();

    // tworzenie losowych wektorów do momentu aż ilość  w hashmapie bedzie rowna 10
    while(HashPozycje.Count < 10)
    {
        Vector3 wektor = new Vector3(
            Random.Range(minX, maxX),
            0, 
            Random.Range(minZ, maxZ)
        );

        //dodaje do listy tylko  jezeli jest to nowa wartosc
        HashPozycje.Add(wektor);
    }

    return new List<Vector3>(HashPozycje);
   }
}
