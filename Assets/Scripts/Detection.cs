using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    public GameObject playerPrefab = null;
    GameObject newPlayer = null;
    void OnTriggerEnter2D(Collider2D other){
        if(other.name != "Player"){
            return;
        }
        Debug.Log($"Hey! {other.name} vient d'entrer dans la zone!");
        newPlayer = GameObject.Instantiate(playerPrefab,transform.position,Quaternion.identity);
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.name != "Player"){
            return;
        }
        Debug.Log($"Hey! {other.name} vient de quitter la zone!");
        newPlayer.GetComponent<Rigidbody2D>().AddForce(8*Vector2.up,ForceMode2D.Impulse);
    }
}
