using UnityEngine;

[System.Serializable]
public class Upgrade : Data
{
    [SerializeField]
    private float _value;

    [SerializeField]
    private int _level;

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

    public Upgrade(float value, int level)
    {
        _value = value;
        _level = level;

    }
}
