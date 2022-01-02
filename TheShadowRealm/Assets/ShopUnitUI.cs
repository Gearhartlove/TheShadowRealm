using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUnitUI : MonoBehaviour
{

    [SerializeField] GameObject Unit1;
    [SerializeField] GameObject Unit2;
    [SerializeField] GameObject Unit3;
    [SerializeField] GameObject Unit4;
    private List<GameObject> Units;

    [SerializeField] List<Sprite> Numbers;

    // Start is called before the first frame update
    void Awake()
    {
        Units = new List<GameObject>() { Unit1, Unit2, Unit3, Unit4 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStats(int unit, int value, int attack, int health, int speed)
    {
        GameObject currentUnit = Units[unit - 1];
        GameObject currentNumbers = currentUnit.transform.GetChild(1).gameObject;
        currentNumbers.transform.Find("Value Number").GetComponent<Image>().sprite = Numbers[value];
        currentNumbers.transform.Find("Attack Number").GetComponent<Image>().sprite = Numbers[attack];
        currentNumbers.transform.Find("Health Number").GetComponent<Image>().sprite = Numbers[health];
        currentNumbers.transform.Find("Speed Number").GetComponent<Image>().sprite = Numbers[speed];
    }

    public void HideStats(int unit)
    {
        Units[unit - 1].SetActive(false);
    }
    public void RevealStats(int unit)
    {
        Units[unit - 1].SetActive(true);
    }
}
