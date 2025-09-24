using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    int mapSize = 5;
    public Tilemap map;
    public Tile emptyTile;
    public Tile redTile;
    public Tile blueTile;
    public Tile greenTile;
    Tile selectedTile;
    Vector3Int selectedTilePos;
    CommandManager commandManager;

    private void Start()
    {
        InitializeMap(mapSize, mapSize);
        commandManager = new CommandManager();
    }

    public void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectedTilePos = new Vector3Int((int)mouseWorldPosition.x, (int)mouseWorldPosition.y, 0);

        if (selectedTilePos.x >= 0 && selectedTilePos.x < mapSize && selectedTilePos.y >= 0 && selectedTilePos.y < mapSize && selectedTile != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ICommand paint = new Paint(selectedTile, selectedTilePos, map);
                commandManager.ExecuteCommand(paint);
                Debug.Log("Selected Tile Position is at: " + selectedTilePos);
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            commandManager.Undo();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            commandManager.Redo();
        }
    }

    public void InitializeMap(int height, int width)
    {
        for (int y = 0; y < mapSize; y++)
        {
            for (int x = 0; x < mapSize; x++)
            {
                Vector3Int position = new Vector3Int((int)x, (int)y, 0);
                map.SetTile(position, emptyTile);
                Debug.Log("Tile set at: " + position);
            }
        }
    }

    public void SelectRedTile()
    {
        selectedTile = redTile;
    }
    public void SelectBlueTile()
    {
        selectedTile = blueTile;
    }
    public void SelectGreenTile()
    {
        selectedTile = greenTile;
    }
}
