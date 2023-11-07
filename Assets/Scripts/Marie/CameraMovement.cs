using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector2 minMaxXPosition;
    [SerializeField] private float smoothingSpeed;
    private PlayerMovement target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > minMaxXPosition.x)
        {
            
            Vector3 targetPosition = Vector3.Lerp(transform.position, target.transform.position, smoothingSpeed * Time.deltaTime);
            transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        }
    }
}
