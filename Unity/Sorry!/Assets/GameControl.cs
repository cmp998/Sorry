using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    // private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    private static GameObject player1, player2, player3, player4;

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4 };

    public static string[] player1Pieces = { "RedPieceA", "RedPieceB", "RedPieceC", "RedPieceD"};
    public static string[] player2Pieces = { "BluePieceA", "BluePieceB", "BluePieceC", "BluePieceD" };
    public static string[] player3Pieces = { "YellowPieceA", "YellowPieceB", "YellowPieceC", "YellowPieceD" };
    public static string[] player4Pieces = { "GreenPieceA", "GreenPieceB", "GreenPieceC", "GreenPieceD" };

    public static int diceSideThrown = 0;
    public static int[] player1StartWaypoint = { 0, 0, 0, 0 };
    public static int[] player2StartWaypoint = { 0, 0, 0, 0 };
    public static int[] player3StartWaypoint = { 0, 0, 0, 0 };
    public static int[] player4StartWaypoint = { 0, 0, 0, 0 };

    public static int currPiece = 0;

    public static bool gameOver = false;

    //Default to all real players
    public int numOfPlayers = 4;


    // Use this for initialization
    void Start()
    {
        //whoWinsTextShadow = GameObject.Find("WhoWinsText");
        //player1MoveText = GameObject.Find("Player1MoveText");
        //player2MoveText = GameObject.Find("Player2MoveText");
        
        numOfPlayers = MainMenu.GetNumOfPlayers();
        Debug.Log("Number of Players:" + numOfPlayers);

        player1 = GameObject.Find("RedPieceA");
        player2 = GameObject.Find("BluePieceA");
        player3 = GameObject.Find("YellowPieceA");
        player4 = GameObject.Find("GreenPieceA");


        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;
        player3.GetComponent<FollowThePath>().moveAllowed = false;
        player4.GetComponent<FollowThePath>().moveAllowed = false;

        //whoWinsTextShadow.gameObject.SetActive(false);
        //player1MoveText.gameObject.SetActive(true);
        //player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex >
            player1StartWaypoint[currPiece] + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint[currPiece] = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint[currPiece] + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            //player2MoveText.gameObject.SetActive(false);
            //player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint[currPiece] = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player3.GetComponent<FollowThePath>().waypointIndex >
            player3StartWaypoint[currPiece] + diceSideThrown)
        {
            player3.GetComponent<FollowThePath>().moveAllowed = false;
            //player3MoveText.gameObject.SetActive(false);
            //player1MoveText.gameObject.SetActive(true);
            player3StartWaypoint[currPiece] = player3.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player4.GetComponent<FollowThePath>().waypointIndex >
            player4StartWaypoint[currPiece] + diceSideThrown)
        {
            player4.GetComponent<FollowThePath>().moveAllowed = false;
            //player4MoveText.gameObject.SetActive(false);
            //player1MoveText.gameObject.SetActive(true);
            player4StartWaypoint[currPiece] = player4.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex ==
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            //whoWinsTextShadow.gameObject.SetActive(true);
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(false);
            //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            //whoWinsTextShadow.gameObject.SetActive(true);
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(false);
            //whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
        }
        if (player3.GetComponent<FollowThePath>().waypointIndex ==
            player3.GetComponent<FollowThePath>().waypoints.Length)
        {
            //whoWinsTextShadow.gameObject.SetActive(true);
            //player1MoveText.gameObject.SetActive(false);
            //player3MoveText.gameObject.SetActive(false);
            //whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
        }
        if (player4.GetComponent<FollowThePath>().waypointIndex ==
            player4.GetComponent<FollowThePath>().waypoints.Length)
        {
            //whoWinsTextShadow.gameObject.SetActive(true);
            //player1MoveText.gameObject.SetActive(false);
            //player4MoveText.gameObject.SetActive(false);
            //whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
        }
    }

    public static void MovePlayer(int playerToMove, int curr)
    {

        currPiece = curr;

        switch (playerToMove)
        {
            case 0:
                player1 = GameObject.Find(player1Pieces[curr]);
                //player1.GetComponent<FollowThePath>().waypointIndex = 

                player1.GetComponent<FollowThePath>().moveAllowed = true;


                break;

            case 1:
                player2 = GameObject.Find(player2Pieces[curr]);
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player3 = GameObject.Find(player3Pieces[curr]);
                player3.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 3:
                player4 = GameObject.Find(player4Pieces[curr]);
                player4.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }



}
