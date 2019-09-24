using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeStorage : MonoBehaviour
{
    public bool Molecule;
    MoleculeSpawner Spawner;

    // Start is called before the first frame update
    void Start()
    {
        Spawner = GetComponentInParent<MoleculeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Molecule")
            Molecule = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Molecule")
        {
            Molecule = true;
            Spawner.isMove = false;
        }
    }
}
