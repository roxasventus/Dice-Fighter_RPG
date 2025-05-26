using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public int playerNum;

    [SerializeField]
    private Status _playerData;
    public Status playerData { get => _playerData; }

    [Header("Basic Status")]
    public float ATK;
    public float DEF;
    public float HP;
    public float MP;

    [Header("Hit Status")]
    public float ACC;
    public float EVA;

    [Header("Critical Status")]
    public float CRIT; // 치명타 확률
    public float CRIT_DMG; // 치명타 피해량

    [Header("Skill Status")]
    public List<Skill> attackSkillList;
    public List<Skill> buffSkillList;

    [Header("Buff Status")]
    [SerializeField]
    private bool _isAtkBuffActive;
    public bool isAtkBuffActive { get => _isAtkBuffActive; }
    public void setAtkBuff() { _isAtkBuffActive = !_isAtkBuffActive; }

    [SerializeField]
    private bool _isDefBuffActive;
    public bool isDefBuffActive { get => _isDefBuffActive; }
    public void setDefBuff() { _isDefBuffActive = !_isDefBuffActive; }

    // Start is called before the first frame update
    void Awake()
    {
        
        if (playerNum == 1) {
             _playerData = CharacterManager.instance.player1;
        }

        else if (playerNum == 2)
        {
            _playerData = CharacterManager.instance.player2;
        }
        
        this.ATK = _playerData.ATK;
        this.DEF = _playerData.DEF;
        this.HP = _playerData.HP;
        this.MP = _playerData.MP;
        this.ACC = _playerData.ACC;
        this.EVA = _playerData.EVA;
        this.CRIT = _playerData.CRIT;
        this.CRIT_DMG = _playerData.CRIT_DMG;

        this.attackSkillList = _playerData.attackSkillList;
        this.buffSkillList = _playerData.buffSkillList;

        Animator animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = _playerData.animatorController;

    }

    // Update is called once per frame
    void Update()
    {
        if(BattleManager.instance.attacker != null  && BattleManager.instance.target != null){
            if (BattleManager.instance.target.HP <= 0)
            {
                StartCoroutine(showWinner());
            }
        }
    }


    public void stopAnimation()
    {

        // 애니메이션이 끝났으면 attack 파라미터를 false로 설정
        BattleManager.instance.attackerAnimator.SetBool("avoid", false);
        BattleManager.instance.attackerAnimator.SetBool("damage", false);
        BattleManager.instance.attackerAnimator.SetBool("ready", false);
        BattleManager.instance.attackerAnimator.SetBool("attack", false);
        BattleManager.instance.attackerAnimator.SetBool("magic", false);
        BattleManager.instance.attackerAnimator.SetBool("state", false);
        BattleManager.instance.attackerAnimator.SetBool("win", false);


        BattleManager.instance.targetAnimator.SetBool("avoid", false);
        BattleManager.instance.targetAnimator.SetBool("damage", false);
        BattleManager.instance.targetAnimator.SetBool("ready", false);
        BattleManager.instance.targetAnimator.SetBool("attack", false);
        BattleManager.instance.targetAnimator.SetBool("magic", false);
        BattleManager.instance.targetAnimator.SetBool("state", false);
        BattleManager.instance.targetAnimator.SetBool("win", false);

    }

    IEnumerator showWinner() {
        BattleManager.instance.attackerAnimator.SetBool("win", true);
        BattleManager.instance.targetAnimator.SetBool("lose", true);
        
        yield return new WaitForSeconds(2.0f);

        if (BattleManager.instance.attacker.gameObject.name == "player1")
            GameManager.instance.resultUI.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Winner is player1";
        else
            GameManager.instance.resultUI.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Winner is player2";

        GameManager.instance.resultUI.SetActive(true);
    }

}
