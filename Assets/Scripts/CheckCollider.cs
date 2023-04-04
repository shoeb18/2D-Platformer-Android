using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == this.gameObject.tag)
        {
            // everything is fine here
            Debug.Log("Welcome!");
        }
        else{
            // damage player health here
            Debug.Log("You are playing wrong Baby!");
        }
    }
}
