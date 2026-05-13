using UnityEngine;
using TMPro;
using System.Collections;

public class KeypadScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ans;
    [SerializeField] private int cans = 123;
    
    public void Number (int number)
    {
        ans.text += number.ToString();
    }

    public void Excecute()
    {
        if(ans.text == cans.ToString())
        {
            ans.text = "CORRECT";
        }
        else
        {
            ans.text = "INVALID";
        }

        StartCoroutine(ClearText());
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(1.5f);
        ans.text = "";
    }
}
