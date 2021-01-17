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
    private GameStatus CurrentGameStatus;
    private bool player1Serve = true;

    void onBallHitGround()
    {

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
