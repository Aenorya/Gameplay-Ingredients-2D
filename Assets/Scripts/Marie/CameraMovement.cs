using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector2 minMaxXPosition;
    [SerializeField] private float smoothingSpeed;
    
    private PlayerMovement target;
    private float y, z;
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>();
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x < minMaxXPosition.x || target.transform.position.x > minMaxXPosition.y)
        {
            float x = Mathf.Clamp(target.transform.position.x, minMaxXPosition.x, minMaxXPosition.y);
            
            Vector3 targetPosition = Vector3.Lerp(transform.position, new Vector3(x, y, z), smoothingSpeed * Time.deltaTime);
            transform.position = new Vector3(targetPosition.x, y, z);
        }
        else if (Mathf.Abs(transform.position.x - target.transform.position.x) > 0.1f)
        {
            Vector3 targetPosition = Vector3.Lerp(transform.position, target.transform.position, smoothingSpeed * Time.deltaTime);
            transform.position = new Vector3(targetPosition.x, y, z);
        }
    }
}
