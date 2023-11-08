using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{   
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 hasPackageColor = new Color32(0,1,0,1);
    SpriteRenderer carSprite;
    bool isPicked = false;
    private void Start() {
        carSprite = GetComponent<SpriteRenderer>();
        carSprite.color = noPackageColor;
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("COLLISION!!!!!!!!!!!!!!!!!!!");           
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !isPicked){
            Debug.Log("PACKAGE PICKED UP!!!!!!!!!!!!!!!!!!!");
            Destroy(other.gameObject,destroyDelay);
            isPicked = true;
            carSprite.color = hasPackageColor;
        }
        if(other.tag == "Destination" && isPicked)
        {
            Debug.Log("DELIVERY COMPLETE!!!!!!!!!!!!!!!!!!!");
            isPicked = false;
            carSprite.color = noPackageColor;
        }
        if(other.tag == "Boost")
        {
            Debug.Log("BOOST!!!!!!!!!!!!!!!!!!!");
        }
    }
}
