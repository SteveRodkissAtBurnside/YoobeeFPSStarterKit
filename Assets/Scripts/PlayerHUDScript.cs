using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDScript : MonoBehaviour
{
    /// <summary>
    /// Control the hud elements for the playerhud based on player stats
    /// </summary>

    public Text healthText;
    public Text batteryText;
    public Image batteryIndicaterImage;
    public GameObject messagePanel;
    //get the damage script of the player
    Damage playerDamage;
    //get the shooting script for the player
    PlayerShootingScript playerShootingScript;
    

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerDamage = player.GetComponent<Damage>();
        playerShootingScript = player.GetComponent<PlayerShootingScript>();
        messagePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //update the text elements
        healthText.text = $"{playerDamage.GetHealthPercent():0}%";
        batteryText.text = $"{playerShootingScript.GetBatteryPercent():0}";
        batteryIndicaterImage.fillAmount = playerShootingScript.GetBatteryPercent()/100f;
    }
}
