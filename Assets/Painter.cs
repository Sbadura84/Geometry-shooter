using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Painter : MonoBehaviour
{
    [SerializeField] private int mapHeight;
    [SerializeField] private int mapWidth;
    [SerializeField] private float multiplier;
    [SerializeField] List<Tile> tiles = new List<Tile>();
    [SerializeField] Tilemap basicTileMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("PerlinNoisePaint")]
    void PerlinNoisePaint()
    {
        for (int x = 0; x < mapHeight; x++)
        {
            for(int y = 0; y < mapWidth; y++)
            {
                float choice = Mathf.PerlinNoise(x * multiplier, y * multiplier);
                Debug.Log(x + ":x" + y+ ":y" + "choice:"+choice);
                if(choice > 0.7)
                {
                    basicTileMap.SetTile(new Vector3Int(x, y, 0), tiles[0]);
                }
                else
                {
                    basicTileMap.SetTile(new Vector3Int(x, y, 0), tiles[1]);
                }
            }
        }
    }
    [ContextMenu("Remove")]
    void RemovePaint()
    {
        basicTileMap.ClearAllTiles();
    
    }
}
