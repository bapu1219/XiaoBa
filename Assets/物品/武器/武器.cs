using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class 武器 : 物品藍圖
{
    public float 攻擊力倍率;
    public int 攻擊速度;
    public int 武器ID;
    protected float 角色攻擊力{get{return 遊戲管理員.管理員.目前操作玩家.當前角色.攻擊力;}}

    /// <summary>
    /// 技能事件管理員 已經把技能從管理員叫過來了,請從這裡選擇技能
    /// </summary>
    public 技能藍圖[] 可選技能; //protected 保護 只有繼承者才可以呼叫
    public abstract IEnumerator 普攻();
    public abstract IEnumerator 技能1();
    public abstract IEnumerator 技能2();
}
