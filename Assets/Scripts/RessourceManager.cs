using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class RessourceManager
    : MonoBehaviour
{
    public float volts;
    public int voltIncrease;
    public GameObject wireButton;
    public int wires;
    public float wireCost;
    public float initialWireCost;
    public int wiresBought;
    public int statics;
    public GameObject staticButton;
    public float staticsInitialVoltCost;
    public float staticsVoltCost;
    public int staticsInitialWireCost;
    public int staticsWireCost;
    public int staticsBought;
    public int staticChargeDelay;
    public GameObject toolButton;
    public int tools;
    public float toolsVoltCost;
    public float toolsInitialVoltCost;
    public int toolsWireCost;
    public int toolsInitialWireCost;
    public int toolsInitialStaticCost;
    public int toolsStaticCost;
    public int toolsBought;
    public string doorRessourceCostText;
    public int doorState;
    public int doorVoltCost;
    public int doorWiresCost;
    public int doorStaticCost;
    public int doorToolsCost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorRessourceCostText = doorVoltCost.ToString() +" Volts";
        wireButton.SetActive(false);
        staticButton.SetActive(false);
        toolButton.SetActive(false);
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
    public void staticCharge()
    {
        volts += voltIncrease * 1f / 100f;
    }
    public float priceIncrease(float basecost,float price,int bought, float scale)
    {
        return (price + scale*basecost * Mathf.Pow(1.05f, bought));
    }
    public void betterWiresBuy()
    {
        if (volts >= wireCost)
        {
            volts -= wireCost;
            wires += 1;
            wireCost = priceIncrease(initialWireCost,wireCost, wiresBought, 1) ;
            wiresBought += 1;
        }
    }
    public void staticGatheringBuy()
    {
        if (volts >= staticsVoltCost && wires>= staticsWireCost) 
        {
            volts -= staticsVoltCost;
            wires -= staticsWireCost;
            staticsVoltCost = priceIncrease(staticsInitialVoltCost,staticsVoltCost,staticsBought, 2);
            staticsWireCost += Mathf.RoundToInt(priceIncrease(staticsInitialWireCost,staticsWireCost, staticsBought, 1));
            statics += 1;
            staticsBought +=1;
        }
    }

    public IEnumerator StaticsCharge()
    {
        while (true)
        { 
            yield return new WaitForSeconds(staticChargeDelay);
            for (int i = 0; i < statics; i++)
            {
                staticCharge();
            }
        }
    }

    public void toolsBuy() 
    { 
    if (volts >= toolsVoltCost && wires >= toolsWireCost && statics >= toolsStaticCost) 
        {
            volts -= toolsVoltCost;
            wires -= toolsWireCost;
            statics -= toolsStaticCost;
            tools += 1;
            toolsVoltCost = priceIncrease(toolsInitialVoltCost,toolsVoltCost,toolsBought, 3);
            toolsWireCost = Mathf.RoundToInt(priceIncrease(toolsInitialWireCost, toolsWireCost, toolsBought, 2));
            toolsStaticCost = Mathf.RoundToInt(priceIncrease(toolsInitialStaticCost, toolsStaticCost, toolsBought, 1));
            toolsBought+=1;
            wireCost = wireCost / 10;
            staticsVoltCost = staticsVoltCost / 10;
            staticsWireCost = staticsWireCost / 10;
        }
    }
    public void  doorOppening()
    {
        if (doorState ==0 && volts >= doorVoltCost)
        {
            doorState = 1;
            doorVoltCost = 5000;
            doorWiresCost = 20;
            wireCost = 10;
            wiresBought = 1;
            doorRessourceCostText = doorVoltCost.ToString() + "Volts and " + doorWiresCost.ToString() + " Wires";
            volts = 0;
            wireButton.SetActive(true);
        }
        if (doorState == 1 && volts >= doorVoltCost && wires>=doorWiresCost)
        {
            doorState = 2;
            doorVoltCost = 50000;
            doorWiresCost = 200;
            doorStaticCost = 10;
            wireCost = 10;
            wiresBought = 1;
            staticsVoltCost = 5000f;
            staticsWireCost = 100;
            staticsBought = 1;
            doorRessourceCostText = doorVoltCost.ToString() + " Volts, " + doorWiresCost.ToString() + " Wires and "+ doorStaticCost.ToString() + " Statics";
            volts = 0;
            wires = 0;
            staticButton.SetActive(true);
        }
        if (doorState == 2 && volts >= doorVoltCost && wires >= doorWiresCost && statics>=doorStaticCost)
        {
            doorState = 3;
            doorVoltCost = 50000000;
            doorWiresCost = 200000;
            doorStaticCost = 10000;
            doorToolsCost = 5;
            wireCost = 10;
            wiresBought = 1;
            staticsVoltCost = 500f;
            staticsWireCost = 10;
            staticsBought = 1;
            toolsWireCost = 200;
            toolsVoltCost = 50000;
            toolsStaticCost = 100;
            doorRessourceCostText = doorVoltCost.ToString() + " Vowolts, " + doorWiresCost.ToString() + " Wires, " + doorStaticCost.ToString() + " Statics and " + doorToolsCost.ToString() + "touwuols";
            volts = 0;
            wires = 0;
            statics = 0;
            toolButton.SetActive(true);

        }
    }

}

