using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
    //Gestion des textes dynamiques, effectués à chaque update. 
{
    public TextMeshProUGUI voltChargeText;
    public TextMeshProUGUI voltAmountText;
    public TextMeshProUGUI wireAmountText;
    public TextMeshProUGUI staticsAmountText;
    public TextMeshProUGUI wiresBoostText;
    public TextMeshProUGUI wireCostText;
    public TextMeshProUGUI staticsCostText;
    public TextMeshProUGUI staticsBoostText;
    public TextMeshProUGUI toolsCostText;
    public TextMeshProUGUI toolBoostText;
    public TextMeshProUGUI toolsAmountText;
    public TextMeshProUGUI panelsCostText;
    public TextMeshProUGUI panelBoostText;
    public TextMeshProUGUI panelAmountText; 
    public TextMeshProUGUI doorText;
    public TextMeshProUGUI doorRessourceCostText;
    public RessourceManager rm;

    void Update()
    {
        voltChargeText.text = "+ " + rm.voltIncrease.ToString() +" Volts";
        voltAmountText.text = rm.volts.ToString();
        wireAmountText.text = rm.wires.ToString();
        staticsAmountText.text = rm.statics.ToString();
        toolsAmountText.text = rm.tools.ToString();
        panelAmountText.text = rm.panels.ToString();
        wiresBoostText.text = "Get an improved wire ";
        wireCostText.text = "Using " +rm.wireCost.ToString() + " Volts";
        staticsBoostText.text = "Build a static charge gathering device";
        staticsCostText.text = "using "+rm.staticsVoltCost.ToString() + " Volts and " + rm.staticsWireCost.ToString() + " Wires";
        toolBoostText.text = "Build a tool that reduces costs";
        toolsCostText.text = "using " +rm.toolsVoltCost.ToString() +" Volts, " + rm.toolsWireCost.ToString() + "Wires and " + rm.toolsStaticCost.ToString() + "Static gatherers";
        panelBoostText.text = "Build a solar pannel";
        panelsCostText.text = "Using "+ rm.panelsVoltCost.ToString() + " Volts, " + rm.panelsWireCost.ToString() + "Wires, " + rm.panelsStaticCost.ToString() + "Static gatherers and"+ rm.panelsToolCost.ToString() +" Tools";
        doorRessourceCostText.text = rm.doorRessourceCostText;
        doorText.text = rm.doorText;


    }
}
