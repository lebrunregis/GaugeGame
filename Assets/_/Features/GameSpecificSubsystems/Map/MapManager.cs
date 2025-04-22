using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    #region Public

    public GameObject m_prefab;
    public Vector2Int m_mapDimensions;
    public byte[] m_leveldesign = new byte[]
    {
        0, 1, 2, 3, 4,
        5, 6, 0, 0, 0,
        0, 0, 0, 0, 0,
        0, 0, 0, 0, 0,
        0, 0, 0, 0, 0,
    };
    
    public enum Colors:byte
    {
        None,
        Blue,
        Green,
        Yellow,
        Red,
        Purple,
        Orange,
        End
    }
    
    public List<Material> m_materials = new List<Material>();

    public Material getMaterialFromColors(Colors color)
    {
        return m_materials[(byte)color];
    }
    #endregion

    #region UnityApi

    void Awake()
    {
        int size = m_mapDimensions.x * m_mapDimensions.y;
        GameObject currentCell;
        Vector3 position = Vector3.zero;
        for (int i = 0; i < size; i++)
        {
            Debug.Log("i= " + i);
            Vector2Int coords = Get2DCoordinates(i, m_mapDimensions);
            position.x = coords.x;
            position.z = coords.y;
            Debug.Log(coords.ToString());
            currentCell = Instantiate(m_prefab,position, Quaternion.identity);
            currentCell.name = "Cell "+ i;
            Debug.Log(Get2DCoordinatesToInt(coords, m_mapDimensions));
            currentCell.GetComponent<Renderer>().sharedMaterial = getMaterialFromColors(GetColorAt(i, m_leveldesign));
            //currentCell.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Utils

    public static int Get2DCoordinatesToInt(Vector2Int coordinates, Vector2Int dimensions)
    {
        return coordinates.x * dimensions.x + coordinates.y;
    }

    public static Vector2Int Get2DCoordinates(int i, Vector2Int dimensions)
    {
        return new Vector2Int( i / dimensions.x,i % dimensions.x );
    }

    public static Colors GetColorAt(int i, byte[] level)
    {
        return (Colors) level[i];
    }
    
    
    #endregion
}
