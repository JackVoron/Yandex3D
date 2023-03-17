using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour
{

    [SerializeField] private Camera _camera;

    private int _fingerID = -1;

    private void Awake()
    {
        #if !UNITY_EDITOR
             _fingerID = 0; 
        #endif
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(_fingerID) == false)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Clickable clickable))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        clickable.Hit();
                    }
                }
            }
        }
    }
}
