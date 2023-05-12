using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : charactee
{
    [Header("Movement")]
    Rigidbody2D rbody = null;
    Vector2 movement = Vector2.zero;
    public float speed = 2.0f;
    bool grounded = false;
    [SerializeField] LayerMask layer;
    [SerializeField] Transform checkjoueurs;
    public GameObject emptyObject;
    public float recoilForce = 10.0f;

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
        Attack();
        //hpjoueur.text = "HP : " ;
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
        if (spr.flipX == true)
        {
            emptyObject.transform.localPosition = new Vector3(-0.4f, 0.15f,0);
        }
        else if (spr.flipX == false)
        {
            emptyObject.transform.localPosition = new Vector3(0.25f, 0.15f,0);
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
    private void Attack(){
        if (Input.GetKeyDown(KeyCode.A) && !isAnimationPlaying && grounded == true)
        {
            animator.Play("Attaque haut", 0, 0f);
            isAnimationPlaying = true;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(checkjoueurs.position, 0.5f, layer);
            foreach (Collider2D col in hitEnemies){
                if (col.gameObject != gameObject){
                col.GetComponent<PlayerController>().takeDomage(player.domage);
            }}
        }
        if (Input.GetKeyDown(KeyCode.E) && !isAnimationPlaying && grounded == true)
        {
            animator.Play("attaque left", 0, 0f);
            isAnimationPlaying = true;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(checkjoueurs.position, 0.5f, layer);
            foreach (Collider2D col in hitEnemies){
                if (col.gameObject != gameObject){
                col.GetComponent<PlayerController>().takeDomage(player.domage);
                       // Calcul du vecteur de recul
            Vector2 recoilDirection = transform.position - col.transform.position;
            recoilDirection = recoilDirection.normalized;

            // Appliquer le recul au joueur attaquant
            rbody.AddForce(recoilDirection * recoilForce, ForceMode2D.Impulse);
                }}}}
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


    public void ResetAnimationState()
    {
        isAnimationPlaying = false;
    }
    
}