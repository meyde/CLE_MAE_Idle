using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class RessourceManager
    : MonoBehaviour
{
//déclarations de toutes les variables; il y a 5 ressource,les 4 après le Volt possédant un cout initial utilisé pour le scaling du prix,
//et un cout actuel, et ce pour chaque ressource précédente.
//Pour la porte, on a un flag pour l'état de la porte, ainsi que les couts de passage.
//Les ressources de récupération de volts en idle ont des variables supplémentaires nécessaires pour ajuster la vitesse de récupération.
//Les volts sont laissés en Float volontairement. 
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
    public GameObject panelButton;
    public int panels;
    public float panelsVoltCost;
    public float panelsInitialVoltCost;
    public int panelsWireCost;
    public int panelsInitialWireCost;
    public int panelsInitialStaticCost;
    public int panelsStaticCost;
    public int panelsToolCost;
    public int panelsInitialToolCost;
    public int panelsBought;
    public int panelsChargeDelay;
    public string doorRessourceCostText;
    public string doorText;
    public int doorState;
    public int doorVoltCost;
    public int doorWiresCost;
    public int doorStaticCost;
    public int doorToolsCost;
    public int doorPanelCost;
    void Start()
    {
        //on cache tout les boutons et on lance les coroutines
        doorRessourceCostText = doorVoltCost.ToString() +" Volts";
        wireButton.SetActive(false);
        staticButton.SetActive(false);
        toolButton.SetActive(false);
        panelButton.SetActive(false);
        StartCoroutine(StaticsCharge());
        StartCoroutine(PanelsCharge());
    }

    // Update is called once per frame
    void Update()
    //on ajuste le gain de volts par appui a chaque update.
    {
        voltIncrease = 1 + wires;
    }
    public void charging()
        // Appui sur le bouton.
    {

        volts += voltIncrease;
    }
    public void staticCharge()
        //Charge idle, uniquement appelé dans la coroutine associée
    {
        volts += voltIncrease * 1f / 100f;
    }
    public void panelCharge()
        //Charge idle, uniquement appelé dans la coroutine associée
    {
        volts += voltIncrease * 10;
    }
    public float priceIncrease(float basecost,float price,int bought, float scale)
        //calcul du scaling du prix. Plus la ressource considérée est antérieure a celle achetée, plus le scale sera élevé (et le prix montera plus vite)
    {
        return (price + scale*basecost * Mathf.Pow(1.05f, bought));
    }
    public void betterWiresBuy()
        //achat de wires, prix ajusté.
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
    //achat de statics, prix ajusté.
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
        //Coroutine des statics
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
    public IEnumerator PanelsCharge()
        //coroutine des panels
    {
        while (true)
        {
            yield return new WaitForSeconds(panelsChargeDelay);
            for(int i = 0;i < panels; i++)
            {
                panelCharge();
            }
        }
    }
    public void toolsBuy()
    //achat de tools, prix ajusté.
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

    public void panelsBuy()
    //achat de panels, prix ajusté.
    {
        if (volts >= panelsVoltCost && wires >= panelsWireCost && statics >= panelsStaticCost && tools >= panelsToolCost)
        {
            volts -= panelsVoltCost;
            wires -= panelsWireCost;
            statics -= panelsStaticCost;
            panels += 1;
            panelsVoltCost = priceIncrease(panelsInitialVoltCost, panelsVoltCost, panelsBought, 4);
            panelsWireCost = Mathf.RoundToInt(priceIncrease(panelsInitialWireCost, panelsWireCost, panelsBought, 3));
            panelsStaticCost = Mathf.RoundToInt(priceIncrease(panelsInitialStaticCost, panelsStaticCost, panelsBought, 2));
            panelsToolCost = Mathf.RoundToInt(priceIncrease(panelsInitialToolCost, panelsToolCost, panelsBought, 1));
            panelsBought += 1;
        }
    }

    public void  doorOppening()
        //Gestion de la porte. Si les ressources sont amassées, le boutton d'après est activé, les ressources réinitialisées (ainsi que leurs prix).
    {
        if (doorState ==0 && volts >= doorVoltCost)
        {
            doorState = 1;
            doorVoltCost = 500;
            doorWiresCost = 10;
            wireCost = initialWireCost;
            wiresBought = 0;
            doorRessourceCostText = doorVoltCost.ToString() + " Volts and " + doorWiresCost.ToString() + " Wires";
            volts = 0;
            wireButton.SetActive(true);
        }
        if (doorState == 1 && volts >= doorVoltCost && wires>=doorWiresCost)
        {
            doorState = 2;
            doorVoltCost = 5000;
            doorWiresCost = 100;
            doorStaticCost = 30;
            wireCost = initialWireCost;
            wiresBought = 0;
            staticsVoltCost = staticsInitialVoltCost;
            staticsWireCost = staticsInitialWireCost;
            doorRessourceCostText = doorVoltCost.ToString() + " Volts, " + doorWiresCost.ToString() + " Wires and "+ doorStaticCost.ToString() + " Statics";
            volts = 0;
            wires = 0;
            staticButton.SetActive(true);
        }
        if (doorState == 2 && volts >= doorVoltCost && wires >= doorWiresCost && statics>=doorStaticCost)
        {
            doorState = 3;
            doorVoltCost = 50000;
            doorWiresCost = 1000;
            doorStaticCost = 300;
            doorToolsCost = 20;
            wireCost = initialWireCost;
            wiresBought = 0;
            staticsVoltCost = staticsInitialVoltCost;
            staticsWireCost = staticsInitialWireCost;
            staticsBought = 0;
            toolsWireCost = toolsInitialWireCost;
            toolsVoltCost = toolsInitialVoltCost;
            toolsStaticCost = toolsInitialStaticCost;
            doorRessourceCostText = doorVoltCost.ToString() + " Volts, " + doorWiresCost.ToString() + " Wires, " + doorStaticCost.ToString() + " Statics and " + doorToolsCost.ToString() + "tools";
            volts = 0;
            wires = 0;
            statics = 0;
            toolButton.SetActive(true);
        }
        if (doorState == 3 && volts >= doorVoltCost && wires >= doorWiresCost && statics >= doorStaticCost)
        {
            doorState = 4;
            doorVoltCost = 999999999;
            doorWiresCost = 99999999;
            doorStaticCost = 9999999;
            doorToolsCost = 999999;
            doorPanelCost = 99999;
            wireCost = initialWireCost;
            wiresBought = 0;
            staticsVoltCost = staticsInitialVoltCost;
            staticsWireCost = staticsInitialWireCost;
            staticsBought = 0;
            toolsWireCost = toolsInitialWireCost;
            toolsVoltCost = toolsInitialVoltCost;
            toolsStaticCost = toolsInitialStaticCost;
            panelsVoltCost = panelsInitialVoltCost;
            panelsWireCost = panelsInitialWireCost;
            panelsStaticCost = panelsInitialStaticCost;
            panelsToolCost = panelsInitialToolCost;
            doorText = "Final door! to flee, gather : ";
            doorRessourceCostText = doorVoltCost.ToString() + " Volts, " + doorWiresCost.ToString() + " Wires, " + doorStaticCost.ToString() + " Statics and " + doorToolsCost.ToString() + "tools" + doorPanelCost.ToString() + "panels";
            volts = 0;
            wires = 0;
            statics = 0;
            panelButton.SetActive(true);
        }
    }

}

