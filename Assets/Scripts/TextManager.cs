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
    public RessourceManager rm;

    void Update()
    {
        voltAmountText.text = rm.volts.ToString();
        wireAmountText.text = rm.wires.ToString();
        staticsAmountText.text = rm.statics.ToString();
        wiresBoostText.text = "Get " +rm.wiresPerBuy.ToString() + " improved wires ";
        wireCostText.text = "Using " +rm.wireCost.ToString() + "Volts";
        staticsBoostText.text = "Build " + rm.staticsPerBuy.ToString() +" static charge gathering devices";
        staticsCostText.text = "using "+rm.staticsVoltCost.ToString() + " Volts and" + rm.staticsWireCost.ToString() + " Wires";

    }
}
