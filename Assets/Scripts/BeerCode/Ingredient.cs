using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/CreateIngredient", order = 1)]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public Sprite ingredientImage;
    public Type type = Type.Base;
    public Taste taste = Taste.None;
    public BaseType baseIngredient = BaseType.White;
    public SpecificType specificType = SpecificType.None;
    
    public enum Type
    {
        Base,
        Addons,
        Specific,
        Beer
    }

    public enum Taste
    {
        Fruit,
        Spices,
        Sweet,
        None
        
    }

    public enum BaseType
    {
        White,
        Normal,
        Black,
        None
    }

    public enum SpecificType
    {
        Blood,
        Mushroom,
        Soul,
        None
    }
}
