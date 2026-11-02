using System;
using System.Collections;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [HideInInspector] public float objectFallingCircle = 1f;
    private float objectFallingCircleNow;
    private float objectFallingCircleAfterSkip = 0.5f;
    private float bottomLine = -9.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.tag = "Operating";
        objectFallingCircleNow = objectFallingCircle;
        StartCoroutine(ObjectAutoFalling());
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public void MoveControl(string str) 
    {
        if (str == "Left") { transform.position += new Vector3(-1, 0, 0); }
        else if (str == "Right") { transform.position += new Vector3(1, 0, 0); }
        else if (str == "Skip") { objectFallingCircleNow = objectFallingCircleAfterSkip; }
        else if (str == "Unskip") { objectFallingCircleNow = objectFallingCircle; }
    }

    public IEnumerator ObjectAutoFalling() 
    {
        while (true) 
        {
            //检查物体下方的网格是否为空，如果不为空则停止下落
            foreach (Transform child in gameObject.transform) 
            {
                Vector2 vector = GridManager.Instance.WorldToGridPosition(child.transform.position.x, child.transform.position.y - 1);
                //防止索引越界
                if (vector.y > 9.5f) break;

                if (GridManager.Instance.grid[(int)vector.x, (int)vector.y] != null) 
                {
                    ObjectsFixed();
                    yield break;
                }
            }
            transform.position += new Vector3(0, -1, 0);
            //当物体到达底部线时，停止下落并将标签更改为"GameObject"
            if (transform.position.y <= bottomLine)
            {
                ObjectsFixed();
                yield break;
            }
            yield return new WaitForSeconds(objectFallingCircleNow);
        }
    }
    
    //物体写入网格方法
    public void ObjectsFixed() 
    {
        //改变用于检索当前操作物体的Tag
        gameObject.tag = "GameObject";
        foreach (Transform child in gameObject.transform)
        {
            //将物体的世界坐标转换为网格坐标,并填入网格数组中
            Vector2 fixedObjectGridPosition = GridManager.Instance.WorldToGridPosition(child.position.x, child.position.y);
            GridManager.Instance.grid[(int)fixedObjectGridPosition.x, (int)fixedObjectGridPosition.y] = child;
            //Debug.Log("网格：" + fixedObjectGridPosition.x + ", " + fixedObjectGridPosition.y+"已被填入。");
        }
    }
}
