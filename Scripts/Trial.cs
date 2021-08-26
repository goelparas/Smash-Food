using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class Trial : MonoBehaviour
{
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider col;
    private bool swiping = false;

void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
  transform.position = mousePos;
      
    }
  void Update()
 {
        if (gameManager.isactive)
        {
            if (Input.GetMouseButtonDown(0)) // this just return the true when type the mouse 

            {
                swiping = true;
                UpdateComponents();
            }

            if (Input.GetMouseButtonUp(0)) // this just return the true when type the mouse 

            {
                swiping = false;
                UpdateComponents();
            }
            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    { if (other.gameObject.GetComponent<Target>())
    { 
     
        other.gameObject.GetComponent<Destroi>().DestroyObject();
    }
    }

    //Destroy the target


    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }
   
}
