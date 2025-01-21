using System;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private FixedJoystick fixedJoystick;
    private Rigidbody rigidbody;
    
    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xValue = fixedJoystick.Horizontal;
        float yValue = fixedJoystick.Vertical;

        Vector3 movement = new Vector3(xValue, 0, yValue);
        rigidbody.linearVelocity = movement * speed;

        if (xValue != 0 && yValue != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xValue, yValue) * Mathf.Rad2Deg, transform.eulerAngles.z);
            
        }
    }
}