using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    // Start is called before the first frame update
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

        // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButton(0)) // Перевірка лівого кліку миші
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Перевірка, чи це певний тип об'єкту, який ми хочемо зробити ціллю
               // if (hit.collider.CompareTag("Table"))
              //  {
                    // Встановлення пункту призначення для агента навігації
                    navMeshAgent.SetDestination(hit.point);
                //}
            }
        }
    }
}
