using UnityEngine;

/// <summary>
/// A class that ensures the cursor (the square delimiting the tiles) is snapped to world
/// coordinates.
/// </summary>
public class CursorSnapper : MonoBehaviour
{
    [SerializeField]
    private TileMapMouseDetector detector;
    [SerializeField]
    private Grid grid;

    // Update is called once per frame
    void Update()
    {
        transform.position = grid.GetCellCenterWorld(detector.TilePosition);
    }
}
