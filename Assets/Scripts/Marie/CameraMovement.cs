using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;
    [SerializeField] private float smoothingSpeed;
    
    private PlayerMovement target;
    private float x, y, z;
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>();
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x < minPosition.x || target.transform.position.x > maxPosition.x)
        {
            x = Mathf.Clamp(target.transform.position.x, minPosition.x, maxPosition.x);
        }
        else if (Mathf.Abs(transform.position.x - target.transform.position.x) > 0.1f)
        {
            x = target.transform.position.x;
        }
        if (target.transform.position.y < minPosition.y || target.transform.position.y > maxPosition.y)
        {
            y = Mathf.Clamp(target.transform.position.y, minPosition.y, maxPosition.y);
        }
        else if (Mathf.Abs(transform.position.y - target.transform.position.y) > 0.1f)
        {
            y = target.transform.position.y;
        }
        Vector3 targetPosition = Vector3.Lerp(transform.position, new Vector3(x, y, z), smoothingSpeed * Time.deltaTime);
        transform.position = new Vector3(targetPosition.x, y, z);
    }
}
