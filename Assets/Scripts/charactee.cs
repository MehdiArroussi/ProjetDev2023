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
    public Vector2 AttackDirection { get; set; }

    protected void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
public void takeDomage(int domage, Vector2 attackDirection)
    {
        player.HPplayer -= domage;

        if (player.HPplayer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(ApplyKnockback(attackDirection));
        }
    }

    public void takeCombo(int combo, Vector2 attackDirection)
    {
        player.HPplayer -= combo;
        if (player.HPplayer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(ApplyKnockback(attackDirection));
        }
    }

private IEnumerator ApplyKnockback(Vector2 attackDirection)
{
    yield return new WaitForSeconds(0.5f);

    if (rbody != null)
    {
        // Normalise la direction du coup pour obtenir une direction de recul unitaire
        Vector2 knockbackDirection = -attackDirection.normalized;
        rbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
}
}