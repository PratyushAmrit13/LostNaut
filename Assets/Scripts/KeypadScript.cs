using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeypadScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ans;
    
    public void Number (int number)
    {
        ans.text += number.ToString();
    }
}
