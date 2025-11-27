using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class RessourceManager
    : MonoBehaviour
{
    public float volts;
    public int voltIncrease;
    public int wires;
    public float wireCost;
    public int statics;
    public int wiresPerBuy;
    public float staticsVoltCost;
    public int staticsWireCost;
    public int staticsPerBuy;
    public int staticChargeDelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wireCost = 10;
        voltIncrease = 1 ;
        wiresPerBuy = 1;
        staticsVoltCost = 500f;
        staticsWireCost = 10;
        staticsPerBuy = 1;
        staticChargeDelay = 10;
        StartCoroutine(StaticsCharge());
    }

    // Update is called once per frame
    void Update()
    {
        voltIncrease = 1 + wires;
    }
    public void charging()
    {
        volts += voltIncrease;
    }
    public void betterWiresBuy()
    {
        if (volts >= wireCost)
        {
            volts -= wireCost;
            wires += wiresPerBuy;
            wireCost = wireCost*1.5f;
            wiresPerBuy += 1;
        }
    }
    public void staticGatheringBuy()
    {
        if (volts >= staticsVoltCost && wires>= staticsWireCost) 
        {
            volts -= staticsVoltCost;
            wires -= staticsWireCost;
            staticsVoltCost = staticsVoltCost * 1.5f;
            staticsWireCost = Mathf.RoundToInt(staticsWireCost * 1.5f);
            statics += staticsPerBuy;
            staticsPerBuy += 1;
        }
    }

    public IEnumerator StaticsCharge()
    {
        while (true)
        { 
            yield return new WaitForSeconds(staticChargeDelay);
            for (int i = 0; i < statics; i++)
            {
                charging();
            }
        }
    }

}
