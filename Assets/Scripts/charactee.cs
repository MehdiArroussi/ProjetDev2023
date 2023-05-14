using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactee : MonoBehaviour
{
    [System.Serializable]

    public class Player
    {
        public float HPplayer = 2;
        public int domage = 1;
        public int combo = 5;
    }
    protected Rigidbody2D rbody = null;
    public Player player;
    public float knockbackForce = 5.0f;
    public bool dead = false;

    protected void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
public void takeDomage(int domage)
    {
        player.HPplayer -= domage;

        if (player.HPplayer <= 0)
        {
            dead = true;
        }
        else
        {
            StartCoroutine(ApplyKnockback());
        }
    }

    public void takeCombo(int combo)
    {
        player.HPplayer -= combo;
        if (player.HPplayer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(ApplyKnockback());
        }
    }

    private IEnumerator ApplyKnockback()
    {
        yield return new WaitForSeconds(0.25f);

        if (rbody != null)
        {
            Vector2 knockbackDirection = new Vector2(0.25f, 0f);
            rbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
