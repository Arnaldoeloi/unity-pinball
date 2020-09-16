using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float maxForce = 10.0f;
    private float forceTarget = 0f;
    private bool releasing = false;
    private Rigidbody rb;

    private Vector3 originalPosition;


    // Start is called before the first frame update
    void Start()
    {
        this.originalPosition = transform.position;
        this.rb = GetComponent<Rigidbody>();
        // this.rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Vertical") && !releasing){
            this.forceTarget = Mathf.Clamp(this.forceTarget + 10f, 0f, this.maxForce);
            transform.Translate(Vector3.forward * -0.02f) ;
            Debug.Log(this.forceTarget);
        }

        else if(Input.GetButtonUp("Vertical") && !releasing){
            // rb.isKinematic = true;
            releasing = true;
            // rb.AddForce(transform.forward * currentForce * 1000, ForceMode.Impulse);
        }

        else if(releasing){
            Debug.Log("RELEASE! "+forceTarget);
            
            rb.AddForce(transform.forward*forceTarget, ForceMode.VelocityChange);
            
            if(transform.position.z >= originalPosition.z ){
                rb.velocity = Vector3.zero;
                transform.position = originalPosition;
                releasing = false;
            }

            this.forceTarget=0f;
        }
    }
}
