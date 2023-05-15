using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class charactee : MonoBehaviourPunCallbacks

{
    [System.Serializable]

    public class Player
    {
        public int HPplayer = 10;
        public int domage = 1;
        public int combo = 5;
    }
    protected Rigidbody2D rbody = null;

    public Player player;
    public Slider healthBar;

    protected Animator animator = null;
    protected SpriteRenderer spr = null;

    public float knockbackForce = 5.0f;

    public bool dead = false;  


    protected void Awake()
    {  
        spr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
    }
    public void takeDomage(int domage)
    {
        player.HPplayer -= domage;
        healthBar.value = player.HPplayer;
        // Mise à jour de la barre de vie en fonction de l'équipe
    if (gameObject.GetComponent<PlayerController>() != null)
    {
        PlayerController teamA = gameObject.GetComponent<PlayerController>();
        teamA.UpdateHealthBarTeamA(player.HPplayer);
    }
    else if (gameObject.GetComponent<TeamB>() != null)
    {
        TeamB teamB = gameObject.GetComponent<TeamB>();
        teamB.UpdateHealthBarTeamB(player.HPplayer);
    }

        if (player.HPplayer <= 0)
        {
            StartCoroutine(PlayDeathAnimation());
        }
        else
        {
            StartCoroutine(ApplyKnockback());
            animator.Play("takehit", 0, 0f);
        }
    }

    public void takeCombo(int combo)
    {
        player.HPplayer -= combo;
        healthBar.value = player.HPplayer;
        if (player.HPplayer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(ApplyKnockback());
            animator.Play("takehit", 0, 0f);
        }
    }
    
    private IEnumerator PlayDeathAnimation()
    {
        animator.Play("dead");
         yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        healthBar.value = 10;
    }

    private IEnumerator ApplyKnockback()
    {
        yield return new WaitForSeconds(0.25f);

        if (rbody != null)
        {
           // Vector2 knockbackDirection = new Vector2(0.25f, 0f);
            //rbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
