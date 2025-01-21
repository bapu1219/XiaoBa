using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "訓練用稻草人", menuName = "敵人/訓練用稻草人")]
public class 訓練用稻草人 : 敵人藍圖
{
    public override IEnumerator 移動(float 速度, Transform 敵人, Rigidbody2D 敵人移動)
    {
        敵人AI.朝向玩家移動(速度, 敵人, 敵人移動);
        yield return null;
    }

}
