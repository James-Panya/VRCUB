using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPosition;
    public float moveSpeed = 2f;
    public float moveRange = 2f;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time * moveSpeed) * moveRange, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
