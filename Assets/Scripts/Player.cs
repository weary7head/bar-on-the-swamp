using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Beer beer;
    public Beer Beer
    {
        get => beer;
        set
        {
            beer = value;
            ChangeBeer?.Invoke();
        }
    }

    public Ingredient.BaseType CurrentOrderBeerType;
    public InventarySlot Slot;

    [CanBeNull] public event Action ChangeBeer; 

    public void GetOrder(Ingredient.BaseType targetOrderBeerType)
    {
        CurrentOrderBeerType = targetOrderBeerType;
    }

    private void Start() => ChangeBeer += WaitForBeer;
    private void WaitForBeer()
    {
        if (Beer != null) Slot.SetBeer(Beer);
        else Slot.TakeBeer();
    }
}
