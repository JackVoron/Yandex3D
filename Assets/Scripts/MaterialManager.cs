using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{

    [SerializeField] private ModelVariants _modelVariants;
    [SerializeField] private Material _defaultMaterial;
    public Material CurrentMaterial { get; private set; }

    public void SetMaterial(Material material) 
    {
        CurrentMaterial = material;
        _modelVariants.CurrentSelected.GetComponent<Renderer>().material = material;
    }

    public void UpdateMaterial() 
    {
        Material material = CurrentMaterial ?? _defaultMaterial;
        _modelVariants.CurrentSelected.GetComponent<Renderer>().material = material;
    }
}
