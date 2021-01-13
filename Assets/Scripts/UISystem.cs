using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public static UISystem instance;
    public GameObject upgradeDialog;
    public GameObject retryButton;
    private Turret curTurret;
    void Start()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void ShowUpgradeDialog(Turret tur){
        curTurret = tur;
        upgradeDialog.SetActive(true);
    }

    public void UpgradeTurret(){
        curTurret.fireRate*=2;
        curTurret.bulletDamage*=2;
        PlayerStats.Money -= 100;
        upgradeDialog.SetActive(false);
    }

    public void Retry(){
        Application.LoadLevel(Application.loadedLevel);
    }
}
