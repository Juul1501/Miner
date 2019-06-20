using UnityEngine;

[System.Serializable]
public class Upgrade : Data
{
    [SerializeField]
    private float _value;

    [SerializeField]
    private int _level;

    [SerializeField]    
    private int _price;

    public float Value 
    { 
        get => _value; 
        set => _value = value; 
    }
    public int level 
    { 
        get => _level; 
        set => _level = value; 
    }
    public int Price 
    { 
        get => _price; 
        set => _price = value; 
    }

    public Upgrade(float value, int level, int price)
    {
        _value = value;
        _level = level;
        _price = price;

    }
}
