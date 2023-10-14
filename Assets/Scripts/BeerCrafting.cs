using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BeerCrafting : MonoBehaviour
{
    private Ingredient _currentIngredient;
    public Image customCursor;
    public Slot boiler;
    public float distance = 100f;
    public Slot[] slots;
    public Button Button;
    public Beer Beer;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_currentIngredient != null)
            {
                customCursor.gameObject.SetActive(false);
                float dist = Vector2.Distance(Input.mousePosition, boiler.transform.position);
                if (dist <= distance)
                {
                    foreach (var slot in slots)
                    {
                        if (slot.ingredient == null && slot.typeOfIngredient == _currentIngredient.type)
                        {
                            slot.gameObject.SetActive(true);
                            slot.ingredient = _currentIngredient;
                            slot.GetComponent<Image>().sprite = _currentIngredient.ingredientImage;

                            _currentIngredient = null;
                            break;
                        }
                    }
                }
                else
                {
                    CursorToDefault();
                    _currentIngredient = null;
                }
            }
        }

        if (slots[0].ingredient != null) Button.gameObject.SetActive(true);
    }

    private void CursorToDefault()
    {
        customCursor.gameObject.SetActive(false);
        customCursor.sprite = null;
    }

    public void OnClickSlot(Slot slot)
    {
        slot.ingredient = null;
        slot.gameObject.SetActive(false);
        if(slots[0].ingredient == null) Button.gameObject.SetActive(false);
    }

    public void OnClickBeer(Slot slot)
    {
        slot.ingredient = null;
    }

    public void OnMouseDown(Ingredient ingredient)
    {
        if (_currentIngredient == null)
        {
            _currentIngredient = ingredient;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = _currentIngredient.ingredientImage;
        }
    }

    public void MakeBeer()
    {
        if (Beer != null)
        {
            Instantiate(Beer);
            Beer.SetProperty(slots[0].ingredient, slots[1].ingredient, slots[2].ingredient);
        }
    }
}