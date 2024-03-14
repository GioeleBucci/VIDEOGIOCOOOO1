using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator;
    [SerializeField]
    private TestInputManager inputManager;

    public void Update()
    {
        Vector2 mousePosition = inputManager.GetSelectedMapPosition();
        mouseIndicator.transform.position = mousePosition;
    }
}
