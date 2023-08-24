using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSystemScript : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _camera;

    private float _screenWidth;
    private float _tileWidth;
    private float _tileHeight;

    private void Start() {
        _screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        _tileWidth = _screenWidth / _width;
        _tileHeight = _tileWidth;
        _tilePrefab.transform.localScale = new Vector3(_tileWidth, _tileHeight, 1f);
        GenerateGrid();
    }
    void GenerateGrid() {
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                Vector3 tilePosition = new Vector3(x * _tileWidth, y * _tileHeight, 0);
                var spawnedTile = Instantiate(_tilePrefab, tilePosition, Quaternion.identity);
                spawnedTile.name = $"Tile ({x}, {y})";
            }
        }

        Camera.main.transform.position = new Vector3((_width - 1) * _tileWidth / 2, (_height - 1) * _tileHeight / 2, -10);
    }

}
