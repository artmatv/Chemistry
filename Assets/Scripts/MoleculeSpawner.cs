using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeSpawner : MonoBehaviour
{
    MoleculeStorage Storage;
    public GameObject Molecule;
    public GameObject StorageObj;
    GameObject Instantiated;
    Vector3 TargetPosition;
    Vector3 ObjectPosition;
    Vector3 Distance;

    public bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = StorageObj.transform.position;
        Storage = StorageObj.GetComponent<MoleculeStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Storage.Molecule)
        {
            Instantiated = Instantiate(Molecule, transform);            
            Storage.Molecule = true;
            isMove = true;
            Instantiated.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (isMove)
        {
            Move();
        }
    }

    void Move()
    {
        ObjectPosition = Instantiated.transform.position;
        Distance = TargetPosition - ObjectPosition;
        if (Vector3.Distance(ObjectPosition, TargetPosition) > .001f)
        {

            Instantiated.transform.Translate(
                (Distance.x * Time.deltaTime),
                (Distance.y * Time.deltaTime),
                (Distance.z * Time.deltaTime),
                Space.World);
        }
    }
}
