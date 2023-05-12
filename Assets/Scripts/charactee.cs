using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactee : MonoBehaviour
{
    
    public int hitsTaken = 0;
    [System.Serializable]

    public class Player 
    {
        public float HPplayer = 2;
        public int domage = 1;
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
}
