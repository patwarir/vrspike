using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class GameLogic : MonoBehaviour
{

    //Game status Enum
    private enum GameStatus
    {
        IN_PLAY,
        SERVE,
        FINISHED
    }
    //Current Game status
    private GameStatus CurrentGameStatus = GameStatus.SERVE;

    //List of joined player IDs
    private List<string> playerIds = new List<string>();

    //Called when the ball hits the ground
    void onBallHitGround()
    {
        CurrentGameStatus = GameStatus.SERVE;
        
    }

    /* Called when a player hits the ball. Pass in ID.
     * @param string id : id of the player who hit the ball
     * */
    void onPlayerHit(string id)
    {

    }

    /*
     * Called when a player serves
     * */
    void onPlayerServed()
    {
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
