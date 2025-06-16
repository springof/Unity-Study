using UnityEngine;

public class WirelessEarPhone2 : WirelessEarPhone
{
    public bool isNoiseCancelling;

    public void NoiseCancelling()
    {
        isNoiseCancelling = !isNoiseCancelling;

         string msg = isNoiseCancelling ? "노이즈 캔슬링 활성화" : "노이즈 캔슬링 비활성화";
        Debug.Log(msg);
    }
}