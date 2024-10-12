using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeScriptManager : MonoBehaviour
{

    // Here is some code you might need to accomplish this task.
    // Try creating a new script and attaching it to an object.

    // Create a public reference to the hand controller object 
    // so you can manually connect them
    [SerializeField] private GameObject rightHandReference;

    // Create a variable to store the position of the controller from the last frame
    Vector3 previousRightHandPosition = new Vector3(0, 0, 0);

    void Start()
    {
        previousRightHandPosition = rightHandReference.transform.position;
    }
    void Update()
    {
        // 
        // Get the distance between frames on the hand
        float distance = Vector3.Distance(previousRightHandPosition, rightHandReference.transform.position);
        // Now YOU need to figure out to set the time scale to a lower value
        // when the player moves their hands more
        if (distance < 0.1f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0.5f;
        }
        // <- This will make the game move at half speed

        // dont forget to set the previous position
        previousRightHandPosition = rightHandReference.transform.position;
    }
}