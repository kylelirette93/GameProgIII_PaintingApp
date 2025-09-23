using UnityEngine;
using UnityEngine.Tilemaps;

public class Paint : ICommand
{
    public Tile selectedTile;
    public Tile previousTile;
    Tilemap map;
    public Paint(Tile selectedTile, Vector3Int position, Tilemap map)
    {       
        map.SetTile(position, selectedTile);
    }
    public void Execute()
    {
        
    }

    public void Undo()
    {
        Execute();
    }
}
