using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonIngredient : MonoBehaviour
{
    [SerializeField] private Ingredient ingredient;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        image.sprite = ingredient.ingredientImage;
        text.text = ingredient.ingredientName;
    }
}
