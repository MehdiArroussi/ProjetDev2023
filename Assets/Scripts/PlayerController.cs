using System.Net.Mime;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    Rigidbody2D rbody = null;
    Vector2 movement = Vector2.zero;
    public float speed = 2.0f;
    bool grounded = false;
    public float HPplayer ;
    private static List<PlayerController> allPlayers = new List<PlayerController>();


    [Header("Animation")]
    SpriteRenderer spr = null;
    public LayerMask platformLayer;
    bool isAnimationPlaying = false;
    Animator animator = null;
    public Text hpjoueur ;


    [Header("Inputs")]
    public KeyCode crouchKey = KeyCode.LeftControl;
    public KeyCode S = KeyCode.S;
    public KeyCode attaquehaut = KeyCode.A;
    public KeyCode attaquecoter = KeyCode.E;

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
        hpjoueur.text = "HP : " + HPplayer;
    }

    void Awake()
    {
        allPlayers.Add(this);
    }
    void OnDestroy()
    {
        allPlayers.Remove(this);
    }

    void OnMove()
    {
        // Deplacement du personnage de gauche à droite
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // permet de deplacer le personnage de gauche a droite en fonction de la vitesse
        rbody.velocity = new Vector2(movement.x * speed, rbody.velocity.y);
        //declanche l'animation de course
        animator.SetBool("Running", movement.x != 0);
        // condition pour que le personnage regarde dans la direction de son déplacement
        if (movement.x != 0)
        {
            spr.flipX = movement.x < 0;
        }
        // condition pour que si espace est appuyé, le personnage saute
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                animator.SetBool("InTheAir", true);
                rbody.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
                grounded = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && !isAnimationPlaying && grounded == true)
        {
            animator.Play("Attaque haut", 0, 0f);
            isAnimationPlaying = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && !isAnimationPlaying && grounded == true)
        {
            animator.Play("attaque left", 0, 0f);
            isAnimationPlaying = true;
        }
    }
 void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.8f)
            {
                grounded = true;
                animator.SetBool("InTheAir", false);
            }
        }
    }
    public void Hit()
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f, platformLayer);
    foreach (Collider2D collider in colliders)
    {
        // Ignore the collision between the character and the platform.
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, false);
        
    }
    // Affichage du texte dans la console
    Debug.Log("Le joueur a attaqué un autre joueur !");
}

    public void ResetAnimationState()
    {
        isAnimationPlaying = false;
    }
}