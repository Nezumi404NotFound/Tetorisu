using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{

    public GameObject[] gameObjects;
    public GameObject objectSpawnPosition;

    private int mapWidth = 15;
    private int spawnGridY = 21;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            GameObject gameObject = gameObjects[Random.Range(0, gameObjects.Length)];

            int minRelativeX = 0;
            int maxRelativeX = 0;

            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.activeSelf)
                {
                    int relativeX = Mathf.RoundToInt(child.localPosition.x);
                    if (relativeX < minRelativeX) minRelativeX = relativeX;
                    if (relativeX > maxRelativeX) maxRelativeX = relativeX;
                }
            }

            //计算安全的网格范围，确保生成的物体不会超出地图边界
            int minSafeGrid = 0 - minRelativeX;
            int maxSafeGrid = mapWidth -1 - maxRelativeX;
            int randomGridX = Random.Range(minSafeGrid, maxSafeGrid + 1);

            Vector2 spawnWorldPosition = GridManager.Instance.GridToWorldPosition(randomGridX, spawnGridY);
            Instantiate(gameObject, spawnWorldPosition, Quaternion.identity);
        }
    }
}
