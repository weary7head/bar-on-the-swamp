using UnityEngine;

public class Player : MonoBehaviour
{
    public Beer Beer { get; set; }
    public Ingredient.BaseType CurrentOrderBeerType;

    public void GetOrder(Ingredient.BaseType targetOrderBeerType)
    {
        CurrentOrderBeerType = targetOrderBeerType;
    }
}
