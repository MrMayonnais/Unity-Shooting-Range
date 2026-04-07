using System;
using UnityEngine;

public class ResourceFinder : MonoBehaviour
{

    [SerializeField] private static Camera playerCamera;

    private void Awake()
    {
        if (playerCamera == null)
        {
            playerCamera = GameObject.Find("Camera").GetComponent<Camera>();
        }
    }

    public static Camera PlayerCamera()
    {
        
        if (playerCamera == null) 
        { 
            playerCamera = Camera.main;
        }
        return playerCamera;
        
    }
}
