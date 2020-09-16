using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float restPos    = 0f;
    public float posOnPress = 45f;
    public float hitStrenght = 100f;
    public float flipperDamping = 160f;

    public string inputType  = "left";

    private HingeJoint hinge;

    private JointSpring spring;


    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
        hinge.useLimits = true;
        //hinge.motor.force = this.hitStrenght;
        spring = new JointSpring();
        spring.spring = hitStrenght;
        spring.damper = flipperDamping;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(inputType))
        {
            spring.targetPosition = posOnPress;
        }
        else
        {
            spring.targetPosition = restPos;
        }

        hinge.spring = spring;
        

        //if (Input.GetAxis("Horizontal") < -0.1f)
        //{
        //    hinge.useMotor = false;
        //    Debug.Log("Left");
        //}
    }
}
