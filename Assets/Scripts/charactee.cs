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
    public Player player;
    public void takeDomage(int domage)
    {
        player.HPplayer -= domage;
        if (player.HPplayer <= 0)
        {
            Destroy(this.gameObject);
        }
}
    public void takeCombo(int combo)
    {
        player.HPplayer -= combo;
        if (player.HPplayer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
