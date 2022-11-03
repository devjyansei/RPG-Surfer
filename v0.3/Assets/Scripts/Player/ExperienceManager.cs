using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;
    public Image expBar;
    Market market;

    [SerializeField] int currentLevel;
    public int experienceAmount;
    public int totalExpForLevelup;
    int upperLevelExp;
    int remainingExp;
    int gainedExp;
    private void Awake()
    {
        Instance = this;
        market = FindObjectOfType<Market>();
    }
    private void Start()
    {
        remainingExp = totalExpForLevelup;
    }
    public void GainExperience(int amount)
    {
        gainedExp += amount;
        experienceAmount += gainedExp;
        remainingExp = totalExpForLevelup - experienceAmount;
        CheckExp();
        UpdateExpBar();
        gainedExp = 0;
    }
    public void LevelUp()
    {

        experienceAmount = experienceAmount - totalExpForLevelup;
        currentLevel++;
        upperLevelExp = totalExpForLevelup + ((totalExpForLevelup / 100) * 30);
        CheckExp();
        market.OpenMarket();
        //boostlardan birini sec
    }
    void CheckExp()
    {
        if (experienceAmount >= totalExpForLevelup)
        {
            LevelUp();
            totalExpForLevelup = upperLevelExp;
        }
    }
    void UpdateExpBar()
    {       
        expBar.fillAmount = (float)experienceAmount / (float)totalExpForLevelup;
    }
}
