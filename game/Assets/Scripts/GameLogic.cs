using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject ground;

    private enum GameStatus
    {
        IN_PLAY,
        FINISHED,
        SERVE
    }
    private GameStatus CurrentGameStatus = GameStatus.SERVE;
    private bool player1Serve = true;
    private bool player1LastHit = true;

    private int score1 = 0, score2 = 0;
    private int hitNum1 = 0, hitNum2 = 0;

    void onBallHitGround()
    {
        CurrentGameStatus = GameStatus.FINISHED;
        

    }

    void setPlayer1LastHit()
    {

    }
    void onPlayerHit()
    {
        if (player1LastHit)
        {
            hitNum1++;
            if (hitNum1 > 3)
            {
                score2++;
                CurrentGameStatus = GameStatus.SERVE;
            }
    }

    void onPlayerServed()
    {
        player1Serve = !player1Serve;
    }

    void Start()
    {
        CurrentGameStatus = GameStatus.SERVE;
    }

    void Update()
    {
        
    }
}
