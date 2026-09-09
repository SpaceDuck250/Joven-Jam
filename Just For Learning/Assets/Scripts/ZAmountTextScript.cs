using TMPro;
using UnityEngine;

public class ZAmountTextScript : MonoBehaviour
{
    public TextMeshProUGUI amountText;

    private void Start()
    {
        ZManagerScript.OnAmountZChanged += UpdateZText;
    }

    private void OnDestroy()
    {
        ZManagerScript.OnAmountZChanged -= UpdateZText;
    }
    
    public void UpdateZText(int newAmount)
    {
        amountText.text = "= " + newAmount.ToString();
    }
}
