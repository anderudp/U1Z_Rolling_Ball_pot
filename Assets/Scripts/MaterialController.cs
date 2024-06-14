using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = materials[PlayerController.level];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
