using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI voltText;
    public TextMeshProUGUI wireText;
    public TextMeshProUGUI wireCostText;
    public TextMeshProUGUI wiresPerBuyText;
    public TextMeshProUGUI staticsAmount;
    public TextMeshProUGUI staticsCostText;
    public TextMeshProUGUI staticsImproveText;
    public RessourceManager rm;

    void Update()
    {
        voltText.text = rm.voltAmount.ToString("000");
        wireText.text = rm.wires.ToString("000");
        wireCostText.text = rm.wireCost.ToString("00000");
        wiresPerBuyText.text = rm.wiresPerBuy.ToString("000");
        staticsAmount.text = rm.statics.ToString("000");
        staticsCostText.text = rm.staticsVoltCost.ToString() + " Volts and" + rm.staticsWireCost.ToString() + " Wires";
        staticsImproveText.text = rm.staticsPerBuy.ToString("000");
    }
}
