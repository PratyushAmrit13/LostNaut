using UnityEngine;
using TMPro;

public class PlayerOxygen : MonoBehaviour
{
    public float oxygen = 200f;
    public float oxygenDrainPerSecond = 1f;
    public TextMeshProUGUI oxygenText;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        oxygen -= oxygenDrainPerSecond * Time.deltaTime;
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