using UnityEngine;

[System.Serializable]
public class Upgrade
{
    [SerializeField]
    private float _value;

    public float Value 
    { 
        get => _value; 
        set => _value = value; 
    }

    public Upgrade(float value)
    {
        _value = value;
    }
}
