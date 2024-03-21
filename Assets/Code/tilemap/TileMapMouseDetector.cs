using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// This script may be attached to a tilemap to detect the tile coordinates based on the position
/// of the mouse cursor.
/// </summary>
public class TileMapMouseDetector : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    private GridLayout gridLayout;
    private Vector3Int _tilePosition;
    public Vector3Int TilePosition { get { return _tilePosition; } }

    void Start()
    {
        this.gridLayout = tilemap.GetComponentInParent<GridLayout>();
        Debug.Log("I want auto-scrolling!!");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("Mouse position: " +  mousePos);
        _tilePosition = gridLayout.WorldToCell(mousePos);
        //Debug.Log("Tile coordinates: " + TilePosition);
    }
}
