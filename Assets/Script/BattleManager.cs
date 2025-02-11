using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class BattleManager : MonoBehaviour
{
    public Player player1;
    public Player player2;

    public Player attacker;
    public Player target;

    public Animator attackerAnimator;
    public Animator targetAnimator;

    static public BattleManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void useAttackSkill(int n)
    {
        if (GameManager.instance.State == GameState.AttackPhase && attacker.MP >= attacker.attackSkillList[n].requireMP) {
            attackerAnimator = attacker.GetComponent<Animator>();
            targetAnimator = target.GetComponent<Animator>();

            if (n == 0)
            {
                attackerAnimator.SetBool("attack", true);
                targetAnimator.SetBool("damage", true);

                Skill skill = attacker.attackSkillList[n];
                skill.SetDamage(attacker.ATK * skill.percent);
                target.HP -= (attacker.attackSkillList[n].damage - target.DEF);

                if (target.isDefBuffActive == true)
                {
                    target.setDefBuff();
                    target.DEF = target.playerData.DEF;
                }

                attacker.MP -= attacker.attackSkillList[n].requireMP;
                GameManager.instance.State = GameState.DicePhase;

                if (attacker.name == "player1")
                {
                    GameManager.instance.player1MenuUI.SetActive(false);
                }
                else if (attacker.name == "player2")
                {
                    GameManager.instance.player2MenuUI.SetActive(false);
                }
            }
            else
            {
                StartCoroutine(useWaitAttackSkill(n));
            }
        }
    }

    IEnumerator useWaitAttackSkill(int n) {
        attackerAnimator.SetBool("ready", true);
        yield return new WaitForSeconds(0.4f);
        attackerAnimator.SetBool("ready", false);
        attackerAnimator.SetBool("attack", true);
        targetAnimator.SetBool("damage", true);

        Skill skill = attacker.attackSkillList[n];
        skill.SetDamage(attacker.ATK * skill.percent);
        target.HP -= (attacker.attackSkillList[n].damage - target.DEF);

        if (target.isDefBuffActive == true)
        {
            target.setDefBuff();
            target.DEF = target.playerData.DEF;
        }

        attacker.MP -= attacker.attackSkillList[n].requireMP;
        GameManager.instance.State = GameState.DicePhase;

        if (attacker.name == "player1")
        {
            GameManager.instance.player1MenuUI.SetActive(false);
        }
        else if (attacker.name == "player2")
        {
            GameManager.instance.player2MenuUI.SetActive(false);
        }
    }

    public void useBuffSkill(int n)
    {
        if (GameManager.instance.State == GameState.AttackPhase && attacker.MP >= attacker.attackSkillList[n].requireMP)
        {
            attackerAnimator = attacker.GetComponent<Animator>();
            targetAnimator = target.GetComponent<Animator>();

            StartCoroutine(useWaitBuffSkill(n));
        }
    }

    IEnumerator useWaitBuffSkill(int n)
    {
        attackerAnimator.SetBool("ready", true);
        yield return new WaitForSeconds(0.4f);
        attackerAnimator.SetBool("ready", false);
        attackerAnimator.SetBool("magic", true);

        Skill skill = attacker.buffSkillList[n];
        attacker.MP -= attacker.buffSkillList[n].requireMP;

        if (skill.isAtkBuff) {
            attacker.setAtkBuff();
            attacker.ATK *= (1 + skill.percent);
        }
        else if (skill.isDefBuff)
        {
            attacker.setDefBuff();
            attacker.DEF *= (1 + skill.percent);
        }


        GameManager.instance.State = GameState.DicePhase;

        if (attacker.name == "player1")
        {
            GameManager.instance.player1MenuUI.SetActive(false);
        }
        else if (attacker.name == "player2")
        {
            GameManager.instance.player2MenuUI.SetActive(false);
        }
    }
}
