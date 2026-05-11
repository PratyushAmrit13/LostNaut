using UnityEngine;
using TMPro;

public class PlayerOxygen : MonoBehaviour
{
    public float oxygen = 200f;
    public float oxygenDrainPerSecond = 1f;
    public TextMeshProUGUI oxygenText;
    public OxygenBarScript oxygenBar;

    void Start()
    {
        UpdateUI();
        oxygen = 200f;
        oxygenBar.SetMaxOxygen(200);
    }

    void Update()
    {
        oxygen -= oxygenDrainPerSecond * Time.deltaTime;
        oxygenBar.SetOxygen(Mathf.FloorToInt(oxygen));
        oxygen = Mathf.Max(oxygen, 0);

        UpdateUI();
    }

    public void AddOxygen(float amount)
    {
        oxygen += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        oxygenText.text = "Oxygen: " + Mathf.CeilToInt(oxygen);
    }
}