using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_looks : MonoBehaviour
{
    public GameObject Item;

    public int speed;
    public Mesh Cube;
    public Mesh Capsule;
    public Mesh Sphere;

    MeshFilter meshFilter;
    
    // Start is called before the first frame update
    void Start()
    {
        Mesh[] Item = {Cube, Capsule, Sphere};

        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = Item[Random.Range(0, Item.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
