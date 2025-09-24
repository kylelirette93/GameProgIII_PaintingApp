using UnityEngine;
using UnityEngine.Tilemaps;

public class Paint : ICommand
{
    public Tile newTile;
    public Vector3Int position;
    public Tile previousTile;
    Tilemap map;
    public Paint(Tile newTile, Vector3Int position, Tilemap map)
    {
        this.newTile = newTile;
        this.position = position;
        this.map = map;
        previousTile = map.GetTile<Tile>(position);
    }
    public void Execute()
    {
        map.SetTile(position, newTile);
    }

    public void Undo()
    {
        map.SetTile(position, previousTile);
    }
}
