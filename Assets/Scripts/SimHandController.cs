using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandController : MonoBehaviour
{
    #region Variables

    // variables! 
    public float moveSpeed;
    public float turnSpeed;
    public Transform location;
    public float sprintFactor;
    public float jumpForce;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        location.position = new Vector3(250, 45, 250);

    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = location.position;

        #region Translational movement

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);            
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
           
                transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            
        }

        // sprint!

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= sprintFactor;  // is the same as moveSpeed = moveSpeed*sprintFactor
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= sprintFactor;  // is the same as moveSpeed = moveSpeed/sprintFactor
        }

        #endregion

        #region Rotation using keyboard

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed, Space.Self);
        }

        #endregion

        #region Rotation using Mouse

        // transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed, Space.Self);
        // transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * turnSpeed, Space.Self);

        #endregion
    }


}
