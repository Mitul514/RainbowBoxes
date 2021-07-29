using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
  [SerializeField] private GameObject m_Tile;
  [SerializeField] private int rowLength, colLength; //TODO : to be referred from JSON

  [Range(0f, 5f)]
  [SerializeField] private float m_tileSize;

  [Range(0, 5)]
  [SerializeField] private int m_adjScale;

  private Dictionary<int[,], GameObject> m_TileDict;

  int count = 0;

  public static BoxManager BMinstance { get; set; }

  private void Awake()
  {
    if (BMinstance == null)
    {
      BMinstance = this;
    }
  }

  private void Start()
  {
    m_TileDict = new Dictionary<int[,], GameObject>();
    CreateGrid();
  }

  private void CreateGrid()
  {
    //Creating Dynamic tilemap
    for (int row = 0; row < rowLength; row++)
    {
      for (int col = 0; col < colLength; col++)
      {
        GameObject tile = Instantiate(m_Tile, gameObject.transform);
        count++;
        tile.name = "Box-" + count.ToString();
        float posX = col * m_tileSize;
        float posY = row * -m_tileSize;
        var start_x = colLength * m_tileSize;
        var start_y = rowLength * m_tileSize;
        tile.transform.position = new Vector3(-start_x / 2 + m_tileSize / 2 + posX, 1, start_y / 2 - m_tileSize / 2 + posY);

        int[,] arr = new int[row, col];
        m_TileDict.Add(arr, tile);

        tile.GetComponent<BoxController>().SetData(count);
      }
    }
  }

  public void AdjacentsElements(int row, int column, int adjScale)
  {
    foreach (var kvp in m_TileDict)
    {
      //ROW x COLUMN indexes
      int rHorInd = kvp.Key.GetLength(0);
      int cVerInd = kvp.Key.GetLength(1);

      for (int j = row - adjScale; j <= row + adjScale; j++)
      {
        for (int i = column - adjScale; i <= column + adjScale; i++)
        {
          if (i >= 0 && j >= 0 && i < colLength && j < rowLength &&
              (rHorInd == j && cVerInd == i))
          {
            //Debug.Log("true -- (" + j + "," + i + ")" + "----- GameObject name :: "+ kvp.Value.name);
            var adjTileObj = kvp.Value;
            var nColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
            adjTileObj.GetComponent<Renderer>().material.color = nColor;

          }
        }
      }
    }
  }

  public void GetClickedObjects(GameObject obj)
  {
    foreach (var item in m_TileDict)
    {
      var val = item.Value.GetComponent<BoxController>().CurrVal;
      var currVal = obj.GetComponent<BoxController>().CurrVal;
      if (val == currVal)
      {
        Debug.Log("true ---- (" + item.Key.GetLength(0) + "," + item.Key.GetLength(1) + ")");
        AdjacentsElements(item.Key.GetLength(0), item.Key.GetLength(1), m_adjScale); //TODO : to be referred from JSON
      }
    }
  }
}
