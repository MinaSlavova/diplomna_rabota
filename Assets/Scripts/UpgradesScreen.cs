using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesScreen : MonoBehaviour
{
    private Transform container;
    private Transform template;

    public Sprite healthSprite;
    public Sprite speedSprite;
    public Sprite atkSprite;
    public Sprite rapierSprite;
    public Sprite lanceSprite;
    public Sprite bowSprite;

    private void Awake()
    {
        container = transform.Find("Container");
        template = container.Find("Template");
        template.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateUpgradeButton(healthSprite, "Health", 6 , 0, 0, 0);
        CreateUpgradeButton(speedSprite, "Speed", 8, 4, 0, 1);
        CreateUpgradeButton(atkSprite, "Attack", 0, 4, 8, 2);
        CreateUpgradeButton(rapierSprite, "Rapier", 5, 5, 5, 3);
        CreateUpgradeButton(lanceSprite, "Lance", 10, 12, 10, 4);
        CreateUpgradeButton(bowSprite, "Bow", 5, 10, 0, 5);

        Hide();
    }

    private void CreateUpgradeButton(Sprite upgradeSprite, string upgradeName, int upgradeCostA, int upgradeCostS, int upgradeCostR, int position)
    {
        Transform upgradeTransform = Instantiate(template, container);
        upgradeTransform.gameObject.SetActive(true);
        RectTransform upgradeRectTransform = upgradeTransform.GetComponent<RectTransform>();

        float height = 120f;
        upgradeRectTransform.anchoredPosition = new Vector2(0, -height * position);

        upgradeTransform.Find("UpgradeName").GetComponent<TextMeshProUGUI>().SetText(upgradeName);
        upgradeTransform.GetChild(1).Find("Price").GetComponent<TextMeshProUGUI>().SetText(upgradeCostA.ToString());
        upgradeTransform.GetChild(2).Find("Price").GetComponent<TextMeshProUGUI>().SetText(upgradeCostS.ToString());
        upgradeTransform.GetChild(3).Find("Price").GetComponent<TextMeshProUGUI>().SetText(upgradeCostR.ToString());
        upgradeTransform.Find("UpgradeImage").GetComponent<Image>().sprite = upgradeSprite;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
