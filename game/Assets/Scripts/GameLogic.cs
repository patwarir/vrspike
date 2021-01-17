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

    ////List of joined player IDs
    private List<string> playerIds = new List<string>();
    private int serveIndex = 0;

    //Scores of each player
    private Dictionary<string, int> playersToScores = new Dictionary<string, int>();

    //Current player
    private string curPlayer;
    private int curPlayerHitCount = 0;

    //Add Player to game
    void addPlayer(string id)
    {
        if (playerIds.Contains(id)) return;
        playersToScores.Add(id, 0);
        playerIds.Add(id);
        playerIds.Sort();
    }

    //Called when the ball hits the ground
    void onBallHitGround()
    {
        onCurPlayerLost();
    }

    /* Called when a player hits the ball. Pass in ID.
     * @param string id : id of the player who hit the ball
     * */
    void onPlayerHit(string id)
    {
        if (curPlayer != id)
        {
            curPlayerHitCount = 1;
            curPlayer = id;
        }
        else if (curPlayerHitCount > 3) onCurPlayerLost();
        else curPlayerHitCount++;
    }

    /*
     * Called when a player serves
     * */
    void onPlayerServed()
    {
        serveIndex = (serveIndex + 1) % playerIds.Count;
    }

    //Called when current player loses
    private void onCurPlayerLost()
    {
        CurrentGameStatus = GameStatus.SERVE;
        playersToScores[curPlayer]--;
    }

    void Update()
    {
        
    }
}
