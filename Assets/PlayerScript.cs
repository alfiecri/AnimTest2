using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float speed = 5.0f;
    float jump = 5.0f;
    bool isOnPlayPlane = true;

    public Rigidbody playerRb;
    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        isOnPlayPlane = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAnim.SetBool("isMove", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnPlayPlane)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            playerAnim.SetTrigger("trigFlip");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerAnim.SetTrigger("trigDeath");
            playerAnim.SetBool("boolStop", true);
        }
        else
        {
            playerAnim.SetBool("isMove", false);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayPlane"))
        {
            isOnPlayPlane = true;
        }
    }
}
