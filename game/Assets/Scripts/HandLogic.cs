using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandLogic : MonoBehaviour
{
    //hand is colliding with this object
    private GameObject collidingObject;

    //The user is currently picking up this object
    private GameObject inHand;

    //Specifies if this is the left hand or right hand
    [SerializeField]
    private bool isLeft = false;

    private XRNode xrNode;
    private InputDevice hand;
    private List<InputDevice> devices = new List<InputDevice>();

    //Assign the xrnode
    private void Awake()
    {
        xrNode = isLeft ? XRNode.LeftHand : XRNode.RightHand;
    }

    //Get all the devices for the appropiate node (left or right node)
    //And assign it to the hand if there exists a device
    private void GetDevices()
    {
        InputDevices.GetDevicesAtXRNode(xrNode, devices);
        if (devices.Count > 0) hand = devices[0];
    }

    //Called when object is colliding with another object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GameObject>())
        {
            collidingObject = other.gameObject;
        }
    }

    //Called when an object leaves the collision radius
    private void OnTriggerExit(Collider other)
    {
        collidingObject = null;
    }

    //Called when user attempts to grab object
    private void onGrabObject()
    {
        inHand = collidingObject;
        if (!inHand) return;
        inHand.transform.SetParent(transform);
        inHand.GetComponent<Rigidbody>().isKinematic = true;
    }

    //Called when user releases object
    private void onReleaseObject()
    {
        inHand.GetComponent<Rigidbody>().isKinematic = false;
        inHand.transform.SetParent(null);
        inHand = null;
    }

    void Update()
    {
        //Check if hand exists
        if (!hand.isValid)
        {
            GetDevices();
        }
        float percent;
        if (hand.TryGetFeatureValue(CommonUsages.trigger, out percent)) {
            if (percent >= 0.2f && collidingObject)
            {
                //Trigger Pressed
                onGrabObject();
            }
            if (percent < 0.2f && inHand)
            {
                //Release object
                onReleaseObject();
            }
        }
    }
}
