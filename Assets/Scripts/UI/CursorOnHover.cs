using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for working with UI elements (check if necessary)

public class CursorOnHover : MonoBehaviour
{
    public Texture2D handCursor;

    void UnsetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        UnsetCursor();
    }
}