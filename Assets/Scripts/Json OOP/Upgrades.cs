using UnityEngine;

[System.Serializable]
public class Upgrades : Data
{
    [SerializeField]
    private Upgrade _fuelSpeedUpgrade;
    
    [SerializeField]
    private Upgrade _maxFuelUpgrade;

    [SerializeField]
    private Upgrade _slideLengthUpgrade;
    


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
    public Upgrade SlideLengthUpgrade 
    { 
        get => _slideLengthUpgrade; 
        set => _slideLengthUpgrade = value; 
    }
}
