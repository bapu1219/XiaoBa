using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
[CreateAssetMenu(fileName = "鬼切", menuName = "武器/鬼切")]
public class 鬼切 : 武器
{
    //這裡只需要放技能庫裡的技能就好
    
    public override IEnumerator 普攻()
    {
        可選技能[0].技能行為();
        yield return null;
    }
    public override IEnumerator 技能1()
    {
        可選技能[1].技能行為();
        yield return null;
    }
    public override IEnumerator 技能2()
    {
        可選技能[2].技能行為();
        yield return null;
    }
}
