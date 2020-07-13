using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DarknessManager : MonoBehaviour
{
    public Tilemap DarkMap;
    public Tilemap BlurredMap;
    public Tilemap BackgroundMap;

    public Tile DarkTile;
    public Tile BlurredTile;

    

    void Start()
    {
        
        DarkMap.transform.position = BlurredMap.transform.position= BackgroundMap.transform.position;
        DarkMap.origin = BlurredMap.origin = BackgroundMap.origin;
        DarkMap.size = BlurredMap.size = BackgroundMap.size;
        DarkMap.transform.localScale = BlurredMap.transform.localScale = BackgroundMap.transform.localScale;


        foreach (Vector3Int p in DarkMap.cellBounds.allPositionsWithin)
        {
            DarkMap.SetTile(p, DarkTile);
        }

        foreach (Vector3Int p in BlurredMap.cellBounds.allPositionsWithin)
        {
            BlurredMap.SetTile(p, BlurredTile);
        }
    
    }
}
