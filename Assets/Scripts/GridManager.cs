using System.Xml.Serialization;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    public int width = 15;
    public int height = 20;

    public Transform[,] grid;
    public Color linColor = new Color(1f, 1f, 1f, 0.3f);

    public void Awake()
    {
        Instance = this;
        grid = new Transform[width, height];
    }
    public void Start() 
    {
        DrawGrid();
    }

    public void DrawGrid()
    {
        GameObject gridHolder = new GameObject("GridLines");
        gridHolder.transform.parent = transform;

        //设置画布垂直分割线
        for (int x = 0; x <= width; x++) 
        {
            float posX = x - (width / 2f);
            CreateLine(gridHolder, new Vector3(posX, -height / 2f, 0), new Vector3(posX, height / 2f, 0f));
        }

        //设置画布水平分割线
        for (int y = 0; y <= height; y++) 
        {
            float posY = y - (height / 2f);
            CreateLine(gridHolder, new Vector3(-width / 2f, posY, 0), new Vector3(width / 2f, posY, 0));
        }
    }
    public void CreateLine(GameObject parent, Vector3 start, Vector3 end) 
    {
        GameObject lineObject = new GameObject("Line");
        lineObject.transform.parent = parent.transform;
        LineRenderer line = lineObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = linColor;
        line.endColor = linColor;
        line.startWidth = 0.05f;
        line.positionCount = 2;
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        line.sortingOrder = 2;
    }

    //将网格坐标转换为世界坐标
    public Vector2 GridToWorldPosition(int x, int y) 
    {
        float worldX = x - 7.0f;
        float worldY = y - 9.5f;
        return new Vector2(worldX, worldY);
    }
    public Vector2 WorldToGridPosition(float worldX, float worldY)
    {
        int gridX = Mathf.RoundToInt(worldX + 7.0f);
        int gridY = Mathf.RoundToInt(worldY + 9.5f);
        return new Vector2(gridX, gridY);
    }
}
