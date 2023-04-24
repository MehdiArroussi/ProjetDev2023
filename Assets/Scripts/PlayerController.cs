using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public TextMesh textMesh;
    public float pourcentagederecul = 0;
    Rigidbody2D rbody = null;
    Vector2 movement = Vector2.zero;

    SpriteRenderer spr = null;

    public float speed = 2.0f;
    bool grounded = false;

    Animator animator = null;
    public KeyCode crouchKey = KeyCode.LeftControl;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {   
        // appelle la fonction pour  déplacer le personnage
        OnMove();
    }

    void OnMove(){
        // Deplacement du personnage de gauche à droite
        movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        // permet de deplacer le personnage de gauche a droite en fonction de la vitesse
        rbody.velocity = new Vector2(movement.x*speed,rbody.velocity.y);
        //declanche l'animation de course
        animator.SetBool("Running",movement.x != 0);
        // condition pour que le personnage regarde dans la direction de son déplacement
        if(movement.x != 0){
            spr.flipX = movement.x < 0;
        }
        // condition pour que si espace est appuyé, le personnage saute
        if(Input.GetButtonDown("Jump")){
            if(grounded){
            animator.SetBool("InTheAir",true);
            rbody.AddForce(new Vector2(0,10),ForceMode2D.Impulse);
            grounded = false;
                }
            }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(Input.GetKeyDown(crouchKey)){
            GameObject.Find("Player").SendMessage("est sur la plateforme");
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        foreach(ContactPoint2D contact in collision.contacts){
            if(contact.normal.y > 0.8f){
                grounded = true;
                animator.SetBool("InTheAir",false);
            }
        }
    }
}
