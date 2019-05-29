using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    // Start is called before the first frame update
    int maxActivePowerUps = 10;
    int activePowerUps = 0;
    static bool powerUpsEnabled = true;
    public Toggle myToggle;


    public int GetActivePowerUps()
    {
        return activePowerUps;
    }
    public int GetMaxActivePowerUps()
    {
        return maxActivePowerUps;
    }
    public void IncrementActivePowerUps()
    {
        activePowerUps += 1;
      //  Debug.Log(activePowerUps);
    }
    public void DecrementActivePowerUps()
    {
        activePowerUps -= 1;
        //Debug.Log(activePowerUps);
    }
    public void SetPowerUps()
    {
        powerUpsEnabled = myToggle.isOn;
       
    }
    public bool PowerUpsEnabled()
    {
        return powerUpsEnabled;
    }

}
