using System.Collections;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ObjectAutoFalling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ObjectAutoFalling() 
    {
        while (true) 
        {
            transform.position += new Vector3(0, -1, 0);
            if (transform.position.y <= -9.5f)
            {
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
