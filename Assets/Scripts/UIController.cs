using UnityEngine;

public class UIController : MonoBehaviour
{
    private new GameObject gameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void GetLeftButtonClicked() 
    {
        FindGameObject();
        if (gameObject != null) { gameObject.GetComponent<ObjectController>().MoveControl("Left"); }
    }
    public void GetRightButtonClicked() 
    {
        FindGameObject();
        if (gameObject != null) { gameObject.GetComponent<ObjectController>().MoveControl("Right"); }
    }
    public void GetSkipButtonDown() 
    {
        FindGameObject();
        if (gameObject != null) { gameObject.GetComponent<ObjectController>().MoveControl("Skip"); }
    }

    public void GetSkipButtonUp() 
    {
        FindGameObject();
        if (gameObject != null) { gameObject.GetComponent<ObjectController>().MoveControl("Unskip"); }
    }

    
    private void FindGameObject() 
    {
        gameObject = GameObject.FindGameObjectWithTag("Operating");
    }
}
