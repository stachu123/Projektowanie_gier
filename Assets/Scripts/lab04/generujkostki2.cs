using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generujkostki2 : MonoBehaviour
{
    public Material material_1;
    public Material material_2;
    public Material material_3;
    public Material material_4;
    public Material material_5; 
    List<Material> materials;

    //pobranie renderer objektu block
    public GameObject block;

    //utworzenie listy na pozycje kostki
    List<Vector3> pozycje;
   
    
    public float delay = 3.0f;

    // Start is called before the first frame update
    void Start()
    {   
        //tworzenie listy materialow
        materials = new List<Material>()
        {
            material_1,
            material_2,
            material_3,
            material_4,
            material_5
        };

        //pobieranie wartości skrajnych platformy
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Bounds bounds = meshRenderer.bounds;
        float minX = bounds.min.x + 0.5f;
        float maxX = bounds.max.x - 0.5f;
        float minZ = bounds.min.z + 0.5f;
        float maxZ = bounds.max.z - 0.5f;
        pozycje = GenerujPozycje(minX, maxX, minZ, maxZ);


        StartCoroutine(GenerujObiekt());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in pozycje)
        {
            // Tworzymy nowy obiekt
            GameObject newBlock = Instantiate(this.block, pos, Quaternion.identity);

            // Pobieramy Renderer z nowo utworzonego obiektu
            Renderer objectRenderer = newBlock.GetComponent<Renderer>();

            
            // Losowo przypisujemy materiał do obiektu
            objectRenderer.material = materials[Random.Range(0, materials.Count)];
                       

            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
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
                0.5f, 
                Random.Range(minZ, maxZ)
            );

            //dodaje do listy tylko  jezeli jest to nowa wartosc
            HashPozycje.Add(wektor);
        }

        return new List<Vector3>(HashPozycje);
    }
}
