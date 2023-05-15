using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winConditions: MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject deadZone;
    public GameObject timerObject;
    public float timeLimit;

    private charactee player1Charactee;
    private charactee player2Charactee;
    private Timer timer;

    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        player1Charactee = player1.GetComponent<charactee>();
        player2Charactee = player2.GetComponent<charactee>();
        timer = timerObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            CheckHealth();
            CheckFallenInDeadZone();
            CheckTimeLimit();
        }
    }

    private void CheckHealth()
    {
        if (player1Charactee.player.HPplayer <= 0)
        {
            AnnounceWinner("Team B");
        }
        else if (player2Charactee.player.HPplayer <= 0)
        {
            AnnounceWinner("Team A");
        }
    }

    private void CheckFallenInDeadZone()
    {
        if (player1.transform.position.y < deadZone.transform.position.y)
        {
            AnnounceWinner("Team B");
        }
        else if (player2.transform.position.y < deadZone.transform.position.y)
        {
            AnnounceWinner("Team A");
        }
    }

    private void CheckTimeLimit()
    {
        if (timer.currentTime >= timeLimit)
        {
            if (player1Charactee.player.HPplayer > player2Charactee.player.HPplayer)
            {
                AnnounceWinner("Team A");
            }
            else if (player1Charactee.player.HPplayer < player2Charactee.player.HPplayer)
            {
                AnnounceWinner("Team B");
            }
            else
            {
                AnnounceWinner("No one");
            }
        }
    }

    private void AnnounceWinner(string winningTeam)
    {
        Debug.Log(winningTeam + " wins!");
        isGameOver = true;
    }
}