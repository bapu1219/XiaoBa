using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class 彈幕控制 : MonoBehaviour
{
public int 速度;
public int 消失時間;
Timer 計時器;
    void Start()
    {
        計時器 = new Timer(消失時間,計時類型.倒數);
    }

    void Update()
    {
        if (計時器.Update(Time.deltaTime))
        {
            //時間到要執行的程式
            計時器.Start(); // 重啟計時器(如果要的話)
        }
    }

}
