using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameCamera : MonoBehaviour
{
    public GameObject ball;
    public float distance = 11;
    
    // Rotation angles X and Y of the camera
    float xAngle = 0f;
    float yAngle = 0f;

    Quaternion rotation;

    void Start()
    {
        xAngle = transform.eulerAngles.x;
        yAngle = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
    #if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButton(0))
            yAngle += Input.GetAxis("Mouse X") * Time.deltaTime * 400;
    #endif
    #if UNITY_ANDROID || UNITY_IOS
        if (Input.touches.Length == 1)
        {
            yAngle += Input.GetTouch(0).deltaPosition.x * Time.deltaTime * 4;
        }
    #endif
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // Initialize rotation to orient the camera
            rotation = Quaternion.Euler(xAngle, yAngle, 0);
        }
        
        // final position = orientation * camera recoil in space
        // + camera movement in relation to the position of the ball
        Vector3 position = rotation * new Vector3(0f, 0f, -distance) + ball.transform.position;

        transform.rotation = rotation;
        transform.position = position;

        // Lock down height position of the camera (if the ball falls off the platform)
        if (transform.position.y < 2.5f)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
        }
    }
}
