using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject _tilePrefab;

    [SerializeField]
    public int _gridWidth;

    [SerializeField]
    public int _gridHeight;

    [SerializeField]
    public float _tileSize = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for(int x = 0; x < _gridWidth; x++) 
        {
            for(int z  = 0; z < _gridHeight; z++) 
            {
                //calculate the position of the tile
                Vector3 tilePosition = new Vector3(x * _tileSize, 0, z * _tileSize);

                //rotate every other tile
                //so it checks to see if it should rotate and then rotates in accordingly
                Quaternion tilerotation = (x + z) % 2 == 0 ? Quaternion.identity : Quaternion.Euler(0, 90, 0);

                //instantiate the tile at the calculated position
                GameObject tile = Instantiate(_tilePrefab, tilePosition, tilerotation);

                // Log the position to see if it's being generated
                Debug.Log("Instantiating tile at position: " + tilePosition);

                //checking to make sure there is a rb on each tile
                if(tile.GetComponent<Rigidbody>() == null)
                {
                    Rigidbody rb = tile.AddComponent<Rigidbody>();
                    rb.isKinematic = true;  // Set to kinematic if you don't want physics-based movement
                }

                // making sure each tile has a BoxCollider
                if (tile.GetComponent<BoxCollider>() == null)
                {
                    tile.AddComponent<BoxCollider>();
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
