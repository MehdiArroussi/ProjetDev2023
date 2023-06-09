using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class TeamB : charactee
{

    [Header("Movement")]
    Vector2 movement = Vector2.zero;
    public float speed = 2.0f;
    bool grounded = false;
    [SerializeField] Transform checkjoueurs;
    public GameObject emptyObject;
    public float recoilForce = 10.0f;
    public bool IsMove = true;

    [Header("Animation")]
    public LayerMask platformLayer;
    bool isAnimationPlaying = false;
    public Text hpjoueur;
    public Slider healthBarTeamB;


    [Header("Inputs")]
    public KeyCode crouchKey = KeyCode.LeftControl;
    public KeyCode S = KeyCode.S;
    public KeyCode attaquehaut = KeyCode.A;
    public KeyCode attaquecoter = KeyCode.E;
    public KeyCode combo = KeyCode.R;
    public KeyCode combo2 = KeyCode.LeftShift;

    



        private void Update()
        {
        if(view.IsMine) 
        {
            OnMove();
            Attack();
        }
    }

    void OnMove()
    {
        if (!IsMove)
        {
        // Si IsMove est faux, le personnage ne peut pas bouger
            movement = Vector2.zero;
            rbody.velocity = Vector2.zero;
            return;
        }
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
            if (spr.flipX == true)
            {
                emptyObject.transform.localPosition = new Vector2(-0.36f, 0.04f);
            }
            else if (spr.flipX == false)
            {
                emptyObject.transform.localPosition = new Vector2(0.25f, 0.04f);
            }
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
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isAnimationPlaying && grounded == true)
        {
            animator.Play("Attaque haut", 0, 0f);
            isAnimationPlaying = true;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(checkjoueurs.position, 0.5f, LayerMask.GetMask("TeamA"));
            foreach (Collider2D col in hitEnemies)
            {
                if (col.gameObject != gameObject)
                {
                    col.GetComponent<PlayerController>().takeDomage(player.domage);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && !isAnimationPlaying && grounded == true)
        {
            animator.Play("attaque left", 0, 0f);
            isAnimationPlaying = true;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(checkjoueurs.position, 0.5f, LayerMask.GetMask("TeamA"));
            foreach (Collider2D col in hitEnemies)
            {
                if (col.gameObject != gameObject)
                {
                    col.GetComponent<PlayerController>().takeDomage(player.domage);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R)&& Input.GetKey(KeyCode.A)&& !isAnimationPlaying && grounded == true){
            animator.Play("combo final", 0, 0f);
            isAnimationPlaying = true;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(checkjoueurs.position, 0.5f, LayerMask.GetMask("TeamA"));
            foreach (Collider2D col in hitEnemies)
            {
                if (col.gameObject != gameObject)
                {
                    col.GetComponent<PlayerController>().takeCombo(player.combo);
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
    private void canMove(){
        IsMove = !IsMove;
    }
       public void ResetAnimationState()
    {
        isAnimationPlaying = false;
    }
    public void UpdateHealthBarTeamB(int currentHealth)
{
    healthBarTeamB.value = currentHealth;
}
}