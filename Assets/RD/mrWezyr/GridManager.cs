using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject tilePrefab;
    public int discoveryRange = 2;
    public float tileSpacing = 5f;

    private Dictionary<Vector2Int, GameObject> discoveredTiles;

    private void Start()
    {
        discoveredTiles = new Dictionary<Vector2Int, GameObject>();
    }

    private void Update()
    {
        int x = Mathf.RoundToInt(playerTransform.position.x / tileSpacing);
        int z = Mathf.RoundToInt(playerTransform.position.z / tileSpacing);

        LookInRange(new Vector2Int(x, z), discoveryRange);
    }

    public void LookInRange(Vector2Int startPos, int range)
    {
        for (int x = startPos.x - range; x <= startPos.x + range; x++)
        {
            for (int z = startPos.y - range; z <= startPos.y + range; z++)
            {
                DiscoverTile(new Vector2Int(x, z));
            }
        }
    }

    public void DiscoverTile(Vector2Int tilePos)
    {
        if (!discoveredTiles.ContainsKey(tilePos))
        {
            Vector3 tileWorldPos = new Vector3(tilePos.x * tileSpacing, 0, tilePos.y * tileSpacing);
            discoveredTiles.Add(tilePos, Instantiate(tilePrefab, tileWorldPos, Quaternion.identity));
        }
    }
}
