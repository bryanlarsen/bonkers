using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotateAngle;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private Transform tf;
    private Animator anim;
    private int animSpeedHash = Animator.StringToHash("Speed");
    private int count;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        count = 0;
        countText.text = "Get some hearts!";
        winText.text = "";
    }

    void Update() {
        if (Input.GetKey("escape")) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Application.Quit();
        }
    }

    void FixedUpdate ()
    {
        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");
        float r = Input.GetAxis ("Mouse X");

        transform.Rotate(0, r, 0);
        rb.AddForce (transform.forward * z * speed);
        rb.AddForce (transform.right * x * speed);
        //anim.speed = Math.Min(1.0f, rb.velocity.magnitude / 4);
        anim.SetFloat(animSpeedHash, rb.velocity.magnitude * rotateAngle);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Heart")) {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Count: " + count.ToString();
            if (count >= 9) {
                winText.text = "You Win!";
                anim.speed = 0.1f;
                anim.SetTrigger("Win");
            }
        }
    }
}
