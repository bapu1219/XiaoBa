using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 這裡儲存所有的武器技能,技能在這邊製作
/// </summary>
public class 技能事件管理員

{
    public List<技能藍圖> 技能庫 = new List<技能藍圖>();

   // public 技能藍圖 普通攻擊1 = new 技能藍圖("普通攻擊", 1, 100); 


    public void 普通攻擊(float 攻擊力)
    {
        Debug.Log("你使用王者之劍普攻了 造成了" + 攻擊力 + "點傷害");
        //玩家向前揮劍,隊攻擊範圍內的敵人造成倍率100%的傷害
    }
    public void 技能1(float 攻擊力)
    {
        Debug.Log("技能1 造成了" + 攻擊力 + "點傷害");
    }

    public void 技能2(float 攻擊力)
    {
        Debug.Log("技能1 造成了" + 攻擊力 + "點傷害");
    }






}
