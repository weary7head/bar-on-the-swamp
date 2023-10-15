using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorsActivator : MonoBehaviour
{
    [SerializeField] private List<Visitor> visitors;

    private int currentVisitorIndex = -1;
    private List<Visitor> doneVisitors = new();

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            currentVisitorIndex++;
            if (currentVisitorIndex < visitors.Count)
            {
                visitors[currentVisitorIndex].gameObject.SetActive(true);
            }
        }
    }
}
