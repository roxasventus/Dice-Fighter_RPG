using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // 다루게 될 데이터를 미리 열거형 enum으로 선언
    public enum InfoType { HP, MP }
    // 선언한 열거형을 타입으로 변수 추가 -> 유니티의 인스펙터 창 내에서 InfoType 열거형 값들 중 하나로 지정 가능
    public InfoType type;

    public int playernum;

    Slider mySlider;

    private float maxHP;
    private float maxMP;
    private float curHP;
    private float curMP;

    void Start()
    {
        if (playernum == 1)
        {
            maxHP = BattleManager.instance.player1.HP;
            maxMP = BattleManager.instance.player1.MP;
        }
        else if (playernum == 2)
        {
            maxHP = BattleManager.instance.player2.HP;
            maxMP = BattleManager.instance.player2.MP;
        }

        else {
            Debug.Log("잘못된 인덱스");
        }


        mySlider = GetComponent<Slider>();

    }
    
    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.HP:
                if (playernum == 1)
                {
                    curHP = BattleManager.instance.player1.HP;
                }
                else if (playernum == 2)
                {
                    curHP = BattleManager.instance.player2.HP;
                }

                mySlider.value = curHP / maxHP;

                break;
            case InfoType.MP:
                if (playernum == 1)
                {
                    curMP = BattleManager.instance.player1.MP;
                }
                else if (playernum == 2)
                {
                    curMP = BattleManager.instance.player2.MP;
                }
                mySlider.value = curMP / maxMP;
                break;
        }
    }
    
}
