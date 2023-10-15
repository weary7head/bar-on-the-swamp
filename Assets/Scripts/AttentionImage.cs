
using UnityEngine;

public class AttentionImage : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] public ScriptableBeerImage BeerImage;
    [SerializeField] public Sprite Attention;


    [SerializeField] private SpriteRenderer imageToVisible;

    private void Update()
    {
        imageToVisible.gameObject.transform.LookAt(camera.transform);
    }

    public void SetImage(ImageType type, Ingredient.BaseType baseType)
    {
        switch (type)
        {
            case ImageType.Attention:
                imageToVisible.sprite = Attention;
                break;
            case ImageType.Beer:
                BeerImage.SetImage(baseType);
                imageToVisible.sprite = BeerImage.CurrentImage;
                Debug.Log(imageToVisible.sprite.name);
                break;
            
        }
    }

    public void SetImage() => imageToVisible.sprite = Attention;

    public void DisableAttention() => imageToVisible.gameObject.SetActive(false);
    public void EnableAttention() => imageToVisible.gameObject.SetActive(true);

    public enum ImageType
    {
        Attention,
        Beer
    }
}