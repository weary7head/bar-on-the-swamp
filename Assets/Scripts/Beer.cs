using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class Beer : MonoBehaviour
{
    public string Base;
    [CanBeNull] public string Addon;
    [CanBeNull] public string Specific;
    public Raiting raiting;

    private readonly Dictionary<Ingredient.BaseType, List<Ingredient.Taste>> _goodPair = new()
    {
        { Ingredient.BaseType.White, new(){Ingredient.Taste.Fruit}},
        { Ingredient.BaseType.Normal, new(){Ingredient.Taste.Spices}},
        { Ingredient.BaseType.Black, new(){Ingredient.Taste.Sweet}}
    };
    
    private readonly Dictionary<Ingredient.BaseType, List<Ingredient.Taste>> _normPair = new()
    {
        { Ingredient.BaseType.White, new(){Ingredient.Taste.Sweet, Ingredient.Taste.Spices}},
        { Ingredient.BaseType.Normal, new(){Ingredient.Taste.Sweet, Ingredient.Taste.Fruit}},
        { Ingredient.BaseType.Black, new(){Ingredient.Taste.Spices}}
    };
    public enum Raiting
    {
        Погане,
        Середнє,
        Добре
    }

    public void SetProperty(Ingredient baseIngredient, [CanBeNull] Ingredient addonIngredient,
        [CanBeNull] Ingredient specificIngredient)
    {
        Base = baseIngredient.ingredientName;
        if (addonIngredient != null)
        {
            Addon = addonIngredient.ingredientName;
            if (_goodPair[baseIngredient.baseIngredient].FirstOrDefault(ingredient => ingredient == addonIngredient.taste) !=
                null) raiting = Raiting.Добре;
            else if (_normPair[baseIngredient.baseIngredient]
                         .FirstOrDefault(ingredient => ingredient == addonIngredient.taste) !=
                     null)
                raiting = Raiting.Середнє;
            else raiting = Raiting.Погане;
        }
        if (specificIngredient != null) Specific = specificIngredient.ingredientName;
        string message = $"Ваше пиво {raiting}! Воно складалось з {Base}";
        if (addonIngredient != null) message += $", {Addon}";
        if (specificIngredient != null) message += $" та спеціального інградієнту{specificIngredient}";
        Debug.Log(message);
    }
}
