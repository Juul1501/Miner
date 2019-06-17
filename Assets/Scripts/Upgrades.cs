using UnityEngine;

[System.Serializable]
public class Upgrades 
{
    [SerializeField]
    private Upgrade _fuelSpeedUpgrade;
    
    [SerializeField]
    private Upgrade _maxFuelUpgrade;


    public Upgrade FuelSpeedUpgrade 
    { 
        get => _fuelSpeedUpgrade; 
        set => _fuelSpeedUpgrade = value; 
    }

    public Upgrade MaxFuelUpgrade 
    { 
        get => _maxFuelUpgrade; 
        set => _maxFuelUpgrade = value; 
    }
    
}
