using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class Dice : MonoBehaviour
{

    // Array of dice sides sprites to load from Resources folder
    public Sprite[] diceSides;

    // Array of dice sides sprites to load from Resources folder
    public Sprite[] rollSequence;

    // Reference to sprite renderer to change sprites
    private Image diceImg;

    // Final side or value that dice reads in the end of coroutine
    public int finalSide = 0;

    public bool rolling = false;
    public bool stopRoll = false;

    // Use this for initialization
    private void Start()
    {

        // Assign Renderer component
        diceImg = GetComponent<Image>();
    }

    // If you left click over the dice then RollTheDice coroutine is started
    public void Roll()
    {
        if (!rolling && !stopRoll && GameManager.instance.State == GameState.DicePhase) //&& GameManager.instance.State == GameState.Playing
        {
        StartCoroutine("RollTheDice");
        }
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 6);
        }

        for (int i = 0; i < 6; i++)
        {
            rolling = true;
            // Set sprite to upper face of dice from array according to random value
            diceImg.sprite = rollSequence[i];

            // Pause before next itteration
            yield return new WaitForSeconds(0.2f);
        }

        // Set sprite to upper face of dice from array according to random value
        diceImg.sprite = diceSides[randomDiceSide];

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;
        rolling = false;
        stopRoll = true;
        // Show final dice value in Console
        //Debug.Log(finalSide);
    }
}
