using UnityEngine;

public class changeSize : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject parent;

    private int pictureLayerMask;
    
    private void Start()
    {
        pictureLayerMask = LayerMask.NameToLayer("Picture");
    }
    
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.gameObject.layer == pictureLayerMask)
                {
                   parent.SetActive(true);
                }
        }
    }
}