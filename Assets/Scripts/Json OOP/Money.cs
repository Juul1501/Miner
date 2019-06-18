using UnityEngine;

public class Money : Data
{
    [SerializeField]
    private int _amount;

    public int Amount 
    { 
        get => _amount; 
        set => _amount = value; 
    }

     public Money(int amount)
    {
        _amount = amount;
    }
}
