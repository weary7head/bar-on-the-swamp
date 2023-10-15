using UnityEngine;
using UnityEngine.UI;

public class InventarySlot : MonoBehaviour
{
    public ScriptableBeerImage BeerImage;
    public GameObject Parent;
    private Beer Beer;

    public void SetBeer(Beer beer)
    {
        Beer = beer;
        BeerImage.SetImage(Beer.Base.baseIngredient);
        Parent.SetActive(true);
        gameObject.GetComponent<Image>().sprite = BeerImage.CurrentImage;
    }

    public void TakeBeer()
    {
        Beer = null;
        Parent.SetActive(false);
    }
}
