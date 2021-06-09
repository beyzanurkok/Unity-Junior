using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Animator animController { get { return GetComponent<Animator>(); } }
    private GameObject room;
    Material[] materials;
    public Material wallMaterial;
    void Start()
    {
        room = GameObject.Find("room");
        materials = room.GetComponent<MeshRenderer>().sharedMaterials;

    }

    // Update is called once per frame
    public void SetMaterial()
    {
        animController.SetTrigger("click");
        materials[0] = wallMaterial;
        
        //room.GetComponent<MeshRenderer>().sharedMaterials[0] = materials[0];
        room.GetComponent<MeshRenderer>().sharedMaterials = materials;


    }
}
