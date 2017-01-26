using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour {

    public static Seeker Instance { get; private set; }

    public int moveSpeed;
    public float headHeightIndex;
    [HideInInspector]
    public Transform targetPoint;
    [HideInInspector]
    public bool newPoint = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (newPoint)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetPoint.position.x, targetPoint.position.y + headHeightIndex, targetPoint.position.z), Time.deltaTime * moveSpeed);
            if (Mathf.Abs(transform.position.x - targetPoint.position.x) <= 0.1f &&
                Mathf.Abs(transform.position.z - targetPoint.position.z) <= 0.1f)
            {
                newPoint = false;
            }
        }
    }
}
