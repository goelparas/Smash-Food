using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Destroi : MonoBehaviour
{
    private GameManager gamemanager;
    public ParticleSystem[] particles;
    
  // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }





    
    
// on mouse click whenever we press some collider it destroi the gameobject .
 
// gamemanager.enabled = false;this disable the script but   functionality still happens the gamemanger 
 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Sensor"))
        {
            Destroy(gameObject);          

        }

    }
    private void controlBadfood()
    {
        Destroy(gameObject);
        gamemanager.Updatescore(-1);
        Instantiate(particles[1], transform.position, Quaternion.identity);
        gamemanager.Totallife(-1);
       
        

       
    }

    private void controllgoodfood()
    {
        Destroy(gameObject);
     
        gamemanager.Updatescore(1);
        Instantiate(particles[0], transform.position, Quaternion.identity);

    }
    public void DestroyObject()
    {
        if (gameObject.CompareTag("Food"))
        {

            if (gamemanager.isactive)
            {
                controllgoodfood();

            }
        }

        else
        {
            controlBadfood();
            if (gamemanager.lifeLoss == 0)
            {
                gamemanager.isactive = false;
            }
        }
    }

}
