using UnityEngine;
using System.Collections;

public class BallScript_control : MonoBehaviour {

    public GameObject player1_hold_RH; //starting guy
    public GameObject player2_hold_RH; //second guy's right hand
    public GameObject player2_hold_LH; //second guy's left hand
    public GameObject self_hold_RH; //third guy
    public GameObject player1_ground; //ground next to first
    public GameObject player2_ground; //ground next to second
    public GameObject self_ground; //ground next to third
    public Rigidbody rigid;
    public Vector3 currBallPosition;
    public int switchInt;  //Indicates where the current ball is
    public int counter;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    // registering the trigger
    public bool ballOnGround = false;
<<<<<<< HEAD
    public bool thrown = false;
    public bool calledTwo = false;
=======
>>>>>>> e93b9d563ec1aafb84bf404bee66a14de2f85347


    // var lastPos:Vector3;
    // var curVel:Vector3;


    // Use this for initialization
    void Start () {
        transform.parent = player1_hold_RH.transform;
        transform.position = player1_hold_RH.transform.position;
        rigid.useGravity = false;
        Vector3 currBallPosition = player1_hold_RH.transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (counter == 5)
        {
<<<<<<< HEAD
            // pause animations
=======
>>>>>>> e93b9d563ec1aafb84bf404bee66a14de2f85347
            Debug.Log("manually calling pick up");
            pickUpBall();
            ReleaseMe();
        }
<<<<<<< HEAD
        if (counter == 2 && !calledTwo) // fix this
        {
            // pause animations
            Debug.Log("manually calling release");
            calledTwo = true;
=======
        if (counter == 3) // fix this
        {
            Debug.Log("manually calling release");
>>>>>>> e93b9d563ec1aafb84bf404bee66a14de2f85347
            ReleaseMe();
        }
    }

    public void pickUpBall()
    {
        CancelInvoke();
        if (counter == 3)
        {
            //transform.parent = self_hold_RH.transform;
            //transform.position = self_hold_RH.transform.position;
            transform.parent = player1_hold_RH.transform;
            transform.position = player1_hold_RH.transform.position;
            Debug.Log("in Three");
        }
        if (counter == 5)
        {
            trackedObject = GameObject.FindWithTag("Right Controller").GetComponent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)trackedObject.index);
            if (device.GetPress(triggerButton) && ballOnGround)
            {
                transform.parent = self_hold_RH.transform;
                transform.position = self_hold_RH.transform.position;
                Debug.Log("trigger pressed");
                ballOnGround = false;
            }
            //transform.parent = self_hold_RH.transform;
            //transform.position = self_hold_RH.transform.position;
            Debug.Log("In Five");
            //transform.parent = player1_hold_RH.transform;
            //transform.position = player1_hold_RH.transform.position;
        }
    }

    public void ReleaseMe()
    {
<<<<<<< HEAD
        thrown = false;
=======
>>>>>>> e93b9d563ec1aafb84bf404bee66a14de2f85347
        CancelInvoke();
        counter = counter + 1; //increments for each trial, on the ball throw (purpose: when ball falls)
        transform.parent = null;
        Debug.Log(counter);
        switch (counter)
        {
            case 1:
                switchInt = 1;
                break;
            case 2:
                switchInt = 2;
                break;
            case 3:
                // self throws
<<<<<<< HEAD
                trackedObject = GameObject.FindWithTag("Right Controller").GetComponent<SteamVR_TrackedObject>();
                device = SteamVR_Controller.Input((int)trackedObject.index);
                Debug.Log(device);
                if (device.GetPressUp(triggerButton))
                {
                    Debug.Log("trigger pressed; self is throwing for case 3");
                    thrown = true;
                }
                switchInt = 2;
=======
                switchInt = 6;
>>>>>>> e93b9d563ec1aafb84bf404bee66a14de2f85347
                break;
            //first pickup should happen here
            case 4:
                switchInt = 1;
                // maybe move this to case 5
                ballOnGround = true;
                break;
            case 5:
                switchInt = 5;
                break;
            //second pickup should happen here
            case 6:
                // self throws
<<<<<<< HEAD
                trackedObject = GameObject.FindWithTag("Right Controller").GetComponent<SteamVR_TrackedObject>();
                device = SteamVR_Controller.Input((int)trackedObject.index);
                if (device.GetPress(triggerButton))
                {
                    Debug.Log("trigger pressed; self is throwing for case 6");
                    thrown = true;
                }
=======
>>>>>>> e93b9d563ec1aafb84bf404bee66a14de2f85347
                switchInt = 3;
                break;
            case 7:
                switchInt = 7;
                break;
            default:
                Debug.Log("Error");
                break;
        }


        InvokeRepeating("MoveToOther", 0f, .005f);
        //2nd Parameter: delay to call (don't want delay, so 0 seconds), 3rd parameter: how frequently move to other is called(every .005 seconds)

    }

    public void MoveToOther()
    {
        GameObject desttarg = getDestTarg();
<<<<<<< HEAD
        if ((counter == 6 || counter == 3) && thrown)
        {
            Debug.Log("self to other player: "+desttarg);
            transform.position = Vector3.MoveTowards(transform.position, desttarg.transform.position, .06f);
            currBallPosition = desttarg.transform.position;
=======
        if (counter == 6)
        {
            Debug.Log("self is throwing");
            trackedObject = GameObject.FindWithTag("Right Controller").GetComponent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)trackedObject.index);
            if (device.GetPress(triggerButton))
            {
                Debug.Log("trigger pressed; self is throwing");
                transform.position = Vector3.MoveTowards(transform.position, desttarg.transform.position, .06f);
                currBallPosition = desttarg.transform.position;
            }
>>>>>>> e93b9d563ec1aafb84bf404bee66a14de2f85347
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, desttarg.transform.position, .06f);
            currBallPosition = desttarg.transform.position;
        }
    }

    public GameObject getDestTarg()
    {
        switch (switchInt)
        {
            case 1:
                return player2_hold_RH;
            case 2:
                return self_hold_RH;
            case 3:
                return player1_hold_RH;
            case 4:
                return player2_ground;
            case 5:
                return self_ground;
            case 6:
                return player1_ground;
            case 7:
                return player2_hold_LH;
            default:
                Debug.Log("Error");
                return player1_hold_RH;
        }
    }

    //use the function 'coroutine' for delays

}