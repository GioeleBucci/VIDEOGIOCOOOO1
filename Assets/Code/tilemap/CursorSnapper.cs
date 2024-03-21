using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSnapper : MonoBehaviour
{
    [SerializeField]
    private TileMapMouseDetector detector;
    [SerializeField]
    private Grid grid;
    private GridLayout gridLayout;
    // Start is called before the first frame update
    void Start()
    {
        gridLayout = grid.GetComponent<GridLayout>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = grid.GetCellCenterWorld(detector.TilePosition);
    }
}
