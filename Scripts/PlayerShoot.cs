using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BulletTemplate;
    public GameObject RightHand;
    public float shootPower = 100f;
    public InputActionReference trigger;

    void Start()
    {
        trigger.action.performed += Shoot;
    }

    void Shoot(InputAction.CallbackContext __)
    {
        GameObject newBullet = Instantiate(BulletTemplate, RightHand.transform.position, RightHand.transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * shootPower);
        // newBullet.GetComponent<Rigidbody>().velocity = transform.forward * shootPower;
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){

        GameObject newBullet = Instantiate(BulletTemplate, RightHand.transform.position, RightHand.transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * shootPower);
        }

    }
}