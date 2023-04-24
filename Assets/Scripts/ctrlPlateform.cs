using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlPlateform : MonoBehaviour
{
    Rigidbody2D rbody = null;
    private void Start() {
       rbody = GetComponent<Rigidbody2D>(); 
    }
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject.Find("Player").SendMessage("est sur la plateforme");
    }
    private void crunch(){
        rbody.AddForce(new Vector2(0,10),ForceMode2D.Impulse);
    }
}