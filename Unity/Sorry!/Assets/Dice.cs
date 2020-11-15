using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private static int whosTurn = 0;
    private bool coroutineAllowed = true;

    public static string[,] players = new string[,]{ { "RedPieceA", "RedPieceB", "RedPieceC", "RedPieceD" }, 
        { "BluePieceA", "BluePieceB", "BluePieceC", "BluePieceD" }, 
        { "YellowPieceA", "YellowPieceB", "YellowPieceC", "YellowPieceD" },
        { "GreenPieceA", "GreenPieceB", "GreenPieceC", "GreenPieceD" } };

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4 };

    int currPiece = 0;

    // Use this for initialization
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("CardFaces/");
        rend.sprite = diceSides[5];
    }

    public static int GetWhosTurn () {return whosTurn;}

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {

        coroutineAllowed = false;
        int randomDiceSide = 0;
        randomDiceSide = Random.Range(0, 12);
        rend.sprite = diceSides[randomDiceSide];
        yield return new WaitForSeconds(0.05f);

        while (!Input.GetKeyDown(keyCodes[0]) && !Input.GetKeyDown(keyCodes[1]) && !Input.GetKeyDown(keyCodes[2]) && !Input.GetKeyDown(keyCodes[3])) //select your piece with keyboard
        {
            yield return null;
        }

        for (int i = 0; i < keyCodes.Length; i++) //sets which piece to move
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                currPiece = i;
            }
        }

        string home = "";
        switch (whosTurn)
        {
            case 0:
                home += "Red";
                break;
            case 1:
                home += "Blue";
                break;
            case 2:
                home += "Yellow";
                break;
            case 3:
                home += "Green";
                break;
        }


        home += "Start";

        switch (currPiece)
        {
            case 0:
                home += "A";
                break;
            case 1:
                home += "B";
                break;
            case 2:
                home += "C";
                break;
            case 3:
                home += "D";
                break;
        }


        if (GameObject.Find(players[whosTurn,currPiece]).transform.position == GameObject.Find(home).transform.position)
            {

            Debug.Log("check");    

                if (randomDiceSide == 0 || randomDiceSide == 1)
                {
                    GameControl.diceSideThrown = randomDiceSide + 1;

                    //Move player
                    GameControl.MovePlayer(whosTurn, currPiece);
                }
            }
        else
        {
            GameControl.diceSideThrown = randomDiceSide + 1;

            //Move player
            GameControl.MovePlayer(whosTurn, currPiece);
        }



        whosTurn += 1;
        int numOfPlayers = MainMenu.GetNumOfPlayers();
        whosTurn = whosTurn % (numOfPlayers);
        coroutineAllowed = true;
    }
}