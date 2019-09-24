using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Vector3 TargetPosition;
    Vector3 ObjectPosition;
    Vector3 Distance;

    public SensoHandExample Hand;
    public float maxdistance = 0.01f;
    bool isMove;
    GameObject Obj;

    public List<GameObject> MoleculesInside;
    public List<Vector3> MolPose;

    [Header("Molecules")]
    public int O, H;

    void Start()
    {
        TargetPosition = transform.position;
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            MolPose.Add(child.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove == true)
        {
            Move();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Molecule")
        {
            col.attachedRigidbody.isKinematic = true;
            isMove = true;
            Obj = col.gameObject;
            MoleculesInside.Add(Obj);
            Vibrate(500, 5);
        }
    }

    void Move()
    {
        ObjectPosition = Obj.transform.position;
        TargetPosition = MolPose[MoleculesInside.Count - 1];
        Distance = TargetPosition - ObjectPosition;
        if (Vector3.Distance(ObjectPosition, TargetPosition) > maxdistance)
        {
            print(Distance);
            Obj.transform.Translate(
                (Distance.x * Time.deltaTime),
                (Distance.y * Time.deltaTime),
                (Distance.z * Time.deltaTime),
                Space.World);
        }

        else
        {
            isMove = false;
            Obj = null;
        }
    }

    public void Connect()
    {
        foreach(GameObject point in MoleculesInside)
        {
            switch(point.GetComponent<MoleculeInteractable>().Type)
            {
                case Type.O2: O++; break;
                case Type.H2: H++; break;
                case Type.Unknown: break;
            }
        }

        if(H==2 && O==1)
        {

        }
    }

    public void Vibrate(ushort duration, byte Hardness)
    {
        Hand.VibrateFinger(Senso.EFingerType.Thumb, duration, Hardness);
        Hand.VibrateFinger(Senso.EFingerType.Index, duration, Hardness);
        Hand.VibrateFinger(Senso.EFingerType.Third, duration, Hardness);
        Hand.VibrateFinger(Senso.EFingerType.Middle, duration, Hardness);
        Hand.VibrateFinger(Senso.EFingerType.Little, duration, Hardness);
    }
}
