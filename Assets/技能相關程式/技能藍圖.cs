using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class 技能藍圖 : ScriptableObject
{
    [Header("技能基本資料")]
    public string 技能名稱;
    [Range(0.01f, 2)]public float 攻擊範圍;
    public float 攻擊倍率;
    public int 消耗魔力;

    [Header("判斷敵人")]
    public LayerMask 敵人圖層; //敵人目標圖層,檢查敵人
    public bool 是否在範圍;
    public Transform 攻擊範圍偵測器 { get { return 遊戲管理員.管理員.目前操作玩家.攻擊範圍偵測器; } }


    public abstract void 技能行為();

    public bool 檢測魔力()
    {
        if (遊戲管理員.管理員.目前操作玩家.目前魔力 >= 消耗魔力)
        {
            遊戲管理員.管理員.目前操作玩家.目前魔力 -= 消耗魔力;
            Debug.Log("目前魔力為" + 遊戲管理員.管理員.目前操作玩家.目前魔力);
            return true;
        }
        else
            Debug.Log("當前魔力不足");
        return false;
    }


    // public 技能藍圖(string 技能名稱, float 攻擊範圍, float 攻擊倍率, LayerMask 敵人圖層 = default)
    // {
    //     this.技能名稱 = 技能名稱;
    //     this.攻擊範圍 = 攻擊範圍;
    //     this.攻擊倍率 = 攻擊倍率;

    // }


    //底層的技能藍圖

    // 1 我需要檢測攻擊範圍
    // 2 使用技能後要有的反應 (我想先給個預設技能,實際執行在製作一個技能覆蓋)
    // 3 判定是否打擊到敵人
    // 4 打擊到需要執行敵人受傷反應


    // 1.我按下普功
    // 2.檢查是否打到敵人
    // 3.範圍內有敵人,顯示我打到敵人,敵人受傷-100滴血
    // 4.更新敵人血量狀態

}
