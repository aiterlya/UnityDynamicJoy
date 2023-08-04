using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{

    [SerializeField]
    private DynamicJoy joy;

    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody=transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void FixedUpdate() {
        if(joy!=null){
            rigidbody.AddForce(new Vector3(joy.GetAxis().x,0,joy.GetAxis().y )*5  ) ;
        }
    }
}
