using UnityEngine;

public class WirelessEarPhone : EarPhone
{
    public float batterySize;
    public bool isWirelessCharged;

    public void Charged()
    {
        string msg = isWirelessCharged ? "무선 충전" : "유선 충전";
        Debug.Log(msg);
    }
}
