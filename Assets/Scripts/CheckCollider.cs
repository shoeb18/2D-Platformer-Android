using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    [SerializeField] private string colliderName;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == this.gameObject.tag)
        {
            // everything is fine here
            Debug.Log("Welcome!");
        }
        else if (other.gameObject.tag == colliderName){
            // damage player health here
            Player.Instance.TakeDamage(1);
            Debug.Log("You are playing wrong Baby!");
        }
    }
}
