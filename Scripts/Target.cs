using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour

{
    

    private Rigidbody Food;  
    void Start()
    {
        //Bio = GameObject.Find("Capsule").GetComponent<test>();
 


        Food = GetComponent<Rigidbody>();
        Force();
        transform.position = new Vector3(Random.Range(-3, 3), -0.81f);
    


    }
   

    void Force()
{
    float forcex=Random.Range(10,13);
    float forcey = Random.Range(3,5);
    Food.AddForce(Vector3.up*forcex,ForceMode.Impulse);
    Food.AddTorque(forcex,forcey,0,ForceMode.Impulse);

}
   
}
