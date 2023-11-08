using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float normalSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate( 0, 0, -steerAmount);
        transform.Translate( 0, moveAmount, 0);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost")
        {
            Debug.Log("BOOST!!!!!!!!!!!!!!!!!!!");
            moveSpeed = boostSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("NORMAL SPEED!!!!!!!!!!!!!!!!!!!");
        moveSpeed = normalSpeed;
        
    }
}
