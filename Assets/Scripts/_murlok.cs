using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _murlok : MonoBehaviour
{

public PlayerController pc;
public Rigidbody2D rb;































    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
