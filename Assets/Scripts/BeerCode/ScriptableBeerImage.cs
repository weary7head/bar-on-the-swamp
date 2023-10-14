using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BeerImage", menuName = "ScriptableObjects/CreateBeerImage")]
public class ScriptableBeerImage : ScriptableObject
{
    [Serializable]
    public class ImageName
    {
        public Ingredient.BaseType type;
        public Sprite image;
    }

    public List<ImageName> list = new();

    public Sprite CurrentImage;

    public void SetImage(Ingredient.BaseType type)
    {
        foreach (var imageName in list)
        {
            if (imageName.type == type) CurrentImage = imageName.image;
        }
    }
}
