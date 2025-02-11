using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Intro, DicePhase, AttackPhase, EndPhase
    }

    static public GameManager instance;

    public int maxHP;
    public GameObject IntroUI;
    public GameObject player1UI;
    public GameObject player2UI;
    public GameObject player1MenuUI;
    public GameObject player2MenuUI;
    public GameObject diceUI;

    public GameState State = GameState.DicePhase;

    public bool isClose;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ��ų ��ư �ؽ�Ʈ �������ִ� ����
        skillButtonTextChange(1, 0, 0);
        skillButtonTextChange(1, 1, 1);
        skillButtonTextChange2(1, 2, 0);

        skillButtonTextChange(2, 0, 0);
        skillButtonTextChange(2, 1, 1);
        skillButtonTextChange2(2, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ���� ��ų ó��
    void skillButtonTextChange(int player, int nth_button, int n) {
        if (player == 1)
        {
            RectTransform button = player1MenuUI.GetComponent<RectTransform>().GetChild(nth_button).GetComponent<RectTransform>();
            TextMeshProUGUI button_text = button.GetChild(0).GetComponent<TextMeshProUGUI>();
            button_text.text = BattleManager.instance.player1.attackSkillList[n].skillName;
        }

        else if (player == 2)
        {
            RectTransform button = player2MenuUI.GetComponent<RectTransform>().GetChild(nth_button).GetComponent<RectTransform>();
            TextMeshProUGUI button_text = button.GetChild(0).GetComponent<TextMeshProUGUI>();
            button_text.text = BattleManager.instance.player2.attackSkillList[n].skillName;
        }
        else {
            Debug.Log("������ ���� �ε���");
        }

    }

    // ���� ��ų ó��
    void skillButtonTextChange2(int player, int nth_button, int n)
    {
        if (player == 1)
        {
            RectTransform button = player1MenuUI.GetComponent<RectTransform>().GetChild(nth_button).GetComponent<RectTransform>();
            TextMeshProUGUI button_text = button.GetChild(0).GetComponent<TextMeshProUGUI>();
            button_text.text = BattleManager.instance.player1.buffSkillList[n].skillName;
        }

        else if (player == 2)
        {
            RectTransform button = player2MenuUI.GetComponent<RectTransform>().GetChild(nth_button).GetComponent<RectTransform>();
            TextMeshProUGUI button_text = button.GetChild(0).GetComponent<TextMeshProUGUI>();
            button_text.text = BattleManager.instance.player2.buffSkillList[n].skillName;
        }
        else
        {
            Debug.Log("������ ���� �ε���");
        }

    }
}
