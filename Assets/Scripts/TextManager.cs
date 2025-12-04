using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI voltAmountText;
    public TextMeshProUGUI wireAmountText;
    public TextMeshProUGUI staticsAmountText;
    public TextMeshProUGUI wiresBoostText;
    public TextMeshProUGUI wireCostText;
    public TextMeshProUGUI staticsCostText;
    public TextMeshProUGUI staticsBoostText;
    public TextMeshProUGUI toolsCostText;
    public TextMeshProUGUI toolBoostText;
    public TextMeshProUGUI doorRessourceCostText;
    public RessourceManager rm;

    void Update()
    {
        voltAmountText.text = rm.volts.ToString();
        wireAmountText.text = rm.wires.ToString();
        staticsAmountText.text = rm.statics.ToString();
        wiresBoostText.text = "Get an improved wire ";
        wireCostText.text = "Using " +rm.wireCost.ToString() + " Volts";
        staticsBoostText.text = "Build a static charge gathering device";
        staticsCostText.text = "using "+rm.staticsVoltCost.ToString() + " Volts and " + rm.staticsWireCost.ToString() + " Wires";
        toolBoostText.text = "Build a tool that reduces costs using :";
        toolsCostText.text = rm.toolsVoltCost.ToString() +" Volts, " + rm.toolsWireCost.ToString() + "Wires and " + rm.toolsStaticCost.ToString() + "Static gatherers";
        doorRessourceCostText.text = rm.doorRessourceCostText;


    }
}
