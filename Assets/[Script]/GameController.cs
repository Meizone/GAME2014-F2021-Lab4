using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Rect safeArea;
    private RectTransform Rect;
    
    //Anchor Variables
    private Vector2 AnchorMin;
    private Vector2 AnchorMax;


    // Start is called before the first frame update
    void Awake()
    {
        Rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckOrientation();
    }


private void CheckOrientation(){
        switch (Screen.orientation)
        {
            case ScreenOrientation.LandscapeLeft:
                UpdateAnchor();
                break;
            case ScreenOrientation.LandscapeRight:
                UpdateAnchor();
                break;
            case ScreenOrientation.Portrait:
                UpdateAnchor();
                break;
            default:
                UpdateAnchor();
                break;
        }
}

private void UpdateAnchor()
{
        safeArea = Screen.safeArea;
        AnchorMin = safeArea.position;
        AnchorMax = AnchorMin + safeArea.size;

        AnchorMin.x /= Screen.width;
        AnchorMin.y /= Screen.height;
        AnchorMax.x /= Screen.width;
        AnchorMax.y /= Screen.height;

        Rect.anchorMin = AnchorMin;
        Rect.anchorMax = AnchorMax;
}


}