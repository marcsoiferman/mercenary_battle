using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    private Transform _cameraPosition;


    [Range(1, 20)]
    public float Smoothing;

    private void Start()
    {
        _cameraPosition = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Follow();
    }

    // Update is called once per frame
    private void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(_cameraPosition.position, targetPosition, Smoothing * Time.fixedDeltaTime);
        smoothPosition.z = 10;
        _cameraPosition.position = new Vector3(smoothPosition.x, smoothPosition.y, _cameraPosition.position.z);
    }
}
