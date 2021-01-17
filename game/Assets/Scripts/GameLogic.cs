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
    private int score1 = 0, score2 = 0;
    //Called when the ball hits the ground
    void onBallHitGround()
    {
        CurrentGameStatus = GameStatus.FINISHED;

    }

    //Called when a player has served
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
