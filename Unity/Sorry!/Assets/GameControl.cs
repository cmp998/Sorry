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

        player1 = GameObject.Find("RedPieceA"); //default stuff
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

        for (int i = 0; i < keyCodes.Length; i++) //sets which piece to move
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                currPiece = i;
            }
        }

        if (gameOver)
            Debug.Log("done");

        player1 = GameObject.Find(player1Pieces[currPiece]);
        player2 = GameObject.Find(player2Pieces[currPiece]);
        player3 = GameObject.Find(player3Pieces[currPiece]);
        player4 = GameObject.Find(player4Pieces[currPiece]);



        if (player1.GetComponent<FollowThePath>().waypointIndex >
            player1StartWaypoint[currPiece] + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1StartWaypoint[currPiece] = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint[currPiece] + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2StartWaypoint[currPiece] = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player3.GetComponent<FollowThePath>().waypointIndex >
            player3StartWaypoint[currPiece] + diceSideThrown)
        {
            player3.GetComponent<FollowThePath>().moveAllowed = false;
            player3StartWaypoint[currPiece] = player3.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player4.GetComponent<FollowThePath>().waypointIndex >
            player4StartWaypoint[currPiece] + diceSideThrown)
        {
            player4.GetComponent<FollowThePath>().moveAllowed = false;
            player4StartWaypoint[currPiece] = player4.GetComponent<FollowThePath>().waypointIndex - 1;
        }


        if ((GameObject.Find(player1Pieces[0]).transform.position == GameObject.Find("RedHomeA").transform.position) &&
            (GameObject.Find(player1Pieces[1]).transform.position == GameObject.Find("RedHomeB").transform.position) &&
            (GameObject.Find(player1Pieces[2]).transform.position == GameObject.Find("RedHomeC").transform.position) &&
            (GameObject.Find(player1Pieces[3]).transform.position == GameObject.Find("RedHomeD").transform.position))
            gameOver = true;

        if ((GameObject.Find(player2Pieces[0]).transform.position == GameObject.Find("BlueHomeA").transform.position) &&
            (GameObject.Find(player2Pieces[1]).transform.position == GameObject.Find("BlueHomeB").transform.position) &&
            (GameObject.Find(player2Pieces[2]).transform.position == GameObject.Find("BlueHomeC").transform.position) &&
            (GameObject.Find(player2Pieces[3]).transform.position == GameObject.Find("BlueHomeD").transform.position))
            gameOver = true;

        if ((GameObject.Find(player3Pieces[0]).transform.position == GameObject.Find("YellowHomeA").transform.position) &&
            (GameObject.Find(player3Pieces[1]).transform.position == GameObject.Find("YellowHomeB").transform.position) &&
            (GameObject.Find(player3Pieces[2]).transform.position == GameObject.Find("YellowHomeC").transform.position) &&
            (GameObject.Find(player3Pieces[3]).transform.position == GameObject.Find("YellowHomeD").transform.position))
            gameOver = true;

        if ((GameObject.Find(player4Pieces[0]).transform.position == GameObject.Find("GreenHomeA").transform.position) &&
            (GameObject.Find(player4Pieces[1]).transform.position == GameObject.Find("GreenHomeB").transform.position) &&
            (GameObject.Find(player4Pieces[2]).transform.position == GameObject.Find("GreenHomeC").transform.position) &&
            (GameObject.Find(player4Pieces[3]).transform.position == GameObject.Find("GreenHomeD").transform.position))
            gameOver = true;
        ///////////////////
    }

    public static void MovePlayer(int playerToMove, int curr)
    {

        currPiece = curr;

        switch (playerToMove)
        {
            case 0:
                player1 = GameObject.Find(player1Pieces[curr]);
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
                Debug.Log("check");
                player4 = GameObject.Find(player4Pieces[curr]);
                player4.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }



}
