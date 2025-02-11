using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    public static DiceManager instance;

    public RectTransform dice1;
    public RectTransform dice2;
    public bool rollDone;

    private Dice player1_dice;
    private Dice player2_dice;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player1_dice = dice1.GetComponent<Dice>();
        player2_dice = dice2.GetComponent<Dice>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player1_dice.stopRoll && player2_dice.stopRoll)
        {
            whoIsWinner();
        }
        
    }

    void whoIsWinner() {

            if (player1_dice.finalSide > player2_dice.finalSide)
            {
                Debug.Log("p1 win");
                BattleManager.instance.attacker = BattleManager.instance.player1;
                BattleManager.instance.target = BattleManager.instance.player2;
                StartCoroutine(attack(0));
            }
            else if (player1_dice.finalSide < player2_dice.finalSide)
            {
                Debug.Log("p2 win");
                BattleManager.instance.attacker = BattleManager.instance.player2;
                BattleManager.instance.target = BattleManager.instance.player1;
                StartCoroutine(attack(1));
            }
            else
            {
                Debug.Log("Draw");
            }
        
        player1_dice.stopRoll = false;
        player2_dice.stopRoll = false;
    }

    IEnumerator attack(int n) {
        GameManager.instance.State = GameManager.GameState.AttackPhase;
        yield return new WaitForSeconds(1.0f);
        if(n==0)
            GameManager.instance.player1MenuUI.SetActive(true);
        if(n==1)
            GameManager.instance.player2MenuUI.SetActive(true);
    }
}
