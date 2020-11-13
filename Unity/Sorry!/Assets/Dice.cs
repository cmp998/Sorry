using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 0;
    private bool coroutineAllowed = true;

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
            //Debug.Log("nope");
            yield return null;
        }

        for (int i = 0; i < keyCodes.Length; i++) //sets which piece to move
        {
            //Debug.Log(currPiece);
            if (Input.GetKeyDown(keyCodes[i]))
            {
                currPiece = i;
            }
        }

        GameControl.diceSideThrown = randomDiceSide + 1;

        //Move player
        GameControl.MovePlayer(whosTurn, currPiece);

        whosTurn += 1;
        int numOfPlayers = MainMenu.GetNumOfPlayers();
        whosTurn = whosTurn % (numOfPlayers);
        Debug.Log("Turn: " + whosTurn);
        coroutineAllowed = true;
    }
}