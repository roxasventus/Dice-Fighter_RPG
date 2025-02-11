using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class Skill : ScriptableObject
{
    public float percent;

    [SerializeField]
    private string _skillName;
    public string skillName { get => _skillName; }

    [SerializeField]
    private AnimatorController animatorController;

    [Header("Attack Data")]
    [SerializeField]
    private float _damage;
    public float damage { get => _damage; }

    [SerializeField]
    private float _requireMP;
    public float requireMP { get => _requireMP; }

    public void SetDamage(float n) { _damage = n; }

    [Header("Buff Data")]

    [SerializeField]
    private bool _isAtkBuff;
    public bool isAtkBuff { get => _isAtkBuff; }

    [SerializeField]
    private bool _isDefBuff;
    public bool isDefBuff { get => _isDefBuff; }

}
