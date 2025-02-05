﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorWeapon : MonoBehaviour
{
    public WeaponData weaponData;
    public GameActor actor;
    public bool IsShakeTest = false;

    private const float MinValue = 0.8f;
    private const float MaxValue = 1.5f;
    public float GetAtk()
    {
        var randomDamage = (int)Random.Range(MinValue * weaponData.ATK, MaxValue * weaponData.ATK);
        return randomDamage;
    }

    public void SkillEnable(int level)
    {
        weaponData.Capcollider.enabled = true;
        weaponData.Capcollider.radius = 2.5f;
        weaponData.state = WeaponData.STATE.ACTIVE;
        AudioMgr.Instance.PlaySound("atk1");
        EventCenter.Instance.EventTrigger(CameraEvent.ShakeCamera, actor, (float)level, level * 0.2f);

        if (IsShakeTest)
        {
            CameraMgr.Instance.ShakeTest(level,level *0.12f);
        }
    }

    public void SkillDisable()
    {
        weaponData.Capcollider.enabled = false;
        weaponData.Capcollider.radius = 0.5f;
        weaponData.state = WeaponData.STATE.IDLE;
    }

    /// <summary>
    /// 伤害开始
    /// </summary>
    public void EqEnable()
    {
        weaponData.Capcollider.enabled = true;
        weaponData.Capcollider.radius = 2.5f;
        weaponData.state = WeaponData.STATE.ACTIVE;
        AudioMgr.Instance.PlaySound("atk1");
        EventCenter.Instance.EventTrigger(CameraEvent.ShakeCamera, actor, 2f, 0.2f);

        if (IsShakeTest)
        {
            CameraMgr.Instance.ShakeTest();
        }
    }

    /// <summary>
    /// 伤害结束
    /// </summary>
    public void EqDisable()
    {
        weaponData.Capcollider.enabled = false;
        weaponData.Capcollider.radius = 0.5f;
        weaponData.state = WeaponData.STATE.IDLE;
    }

    public void DefEnable()
    {
        //weaponData.Capcollider.isTrigger = false;
        weaponData.Capcollider.enabled = true;
        weaponData.Capcollider.radius = 5f;
        weaponData.state = WeaponData.STATE.DEFACTIVE;
    }

    public void DefDisable()
    {
        //weaponData.Capcollider.isTrigger = true;
        weaponData.Capcollider.enabled = false;
        weaponData.Capcollider.radius = 0.5f;
        weaponData.state = WeaponData.STATE.IDLE;
    }
}