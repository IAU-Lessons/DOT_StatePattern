using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectPlant : MonoBehaviour
{
    [SerializeField] private Vector3Event onMouseClicked;
    [SerializeField] private TextMeshProUGUI infoField;
    [SerializeField] private LayerMask layerMask;
    
    private void OnEnable()
    {
        onMouseClicked.AddListener(SelectRequest);
    }

    private void OnDisable()
    {
        onMouseClicked.RemoveListener(SelectRequest);
    }

    void SelectRequest(Vector3 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        // layerMask'i kullanarak Raycast'i gerçekleştir
        if (Physics.Raycast(ray, out hit, 500f, layerMask))
        {
            GameObject hitObject = hit.collider.gameObject;
            PlantStateMachine machine = hitObject.GetComponent<PlantStateMachine>();
            infoField.text = machine.CurrentStateName;
            hitObject.GetComponent<RandomRotation>().DrawCircleAroundObject();
        }
    }
}
