using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StatusData", menuName = "Scriptable Objects/StatusData")]
public class Status : ScriptableObject
{
    [Header("Character Status")]
    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private RuntimeAnimatorController _animatorController;
    public RuntimeAnimatorController animatorController { get => _animatorController; }

    [Header("Basic Status")]
    [SerializeField]
    private float _ATK;
    public float ATK { get => _ATK; }

    [SerializeField]
    private float _DEF;
    public float DEF { get => _DEF; }

    [SerializeField]
    private float _HP;
    public float HP { get => _HP; }

    [SerializeField]
    private float _MP;
    public float MP { get => _MP; }

    [Header("Hit Status")]
    [SerializeField]
    private float _ACC; // 명중률
    public float ACC { get => _ACC; }

    [SerializeField]
    private float _EVA; // 회피율
    public float EVA { get => _EVA; }

    [Header("Critical Status")]
    [SerializeField]
    private float _CRIT; // 치명타 확률
    public float CRIT { get => _CRIT; }

    [SerializeField]
    private float _CRIT_DMG; // 치명타 피해량
    public float CRIT_DMG { get => _CRIT_DMG; }

    [Header("Skill Status")]
    [SerializeField]
    private List<Skill> _attackSkillList;
    public List<Skill> attackSkillList { get => _attackSkillList; }
    [SerializeField]
    private List<Skill> _buffSkillList;
    public List<Skill> buffSkillList { get => _buffSkillList; }

}