using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum 計時類型 { 正數, 倒數 }
/// <summary>
/// 計時器(使用密封禁止繼承)
/// </summary>
public sealed class Timer
{
    public 計時類型 計時類型 { get; private set; }
    public float 時長 { get; private set; }
    public float 當前時間 { get; private set; }
    public bool 是否結束
    {
        get
        {
            switch (計時類型)
            {
                case 計時類型.正數:
                    return 當前時間 >= 時長;
                case 計時類型.倒數:
                    return 當前時間 <= 0;
                default:
                    return true;
            }
        }
    }

    /// <summary>
    /// 創建計時器(可設定正數/倒數)
    /// </summary>
    /// <param name="時長">計時長度</param>
    /// <param name="計時類型">時間"正數/倒數"模式</param>
    public Timer(float 時長, 計時類型 計時類型 = 計時類型.正數)
    {
        this.時長 = 時長;
        this.計時類型 = 計時類型;
        Start();
    }
    /// <summary>
    /// 初始化計時器
    /// </summary>
    public void Start()
    {
        switch (計時類型)
        {
            case 計時類型.正數:
                當前時間 = 0f;
                break;

            case 計時類型.倒數:
                當前時間 = 時長;
                break;
        }
    }

    /// <summary>
    /// 更新計時器時間
    /// </summary>
    /// <param name="t">更新間隔</param>
    public bool Update(float t)
    {
        switch (計時類型)
        {
            case 計時類型.正數:
                當前時間 += t;
                break;

            case 計時類型.倒數:
                當前時間 -= t;
                break;
        }//Debug.Log(time);
        return 是否結束;
    }
}

