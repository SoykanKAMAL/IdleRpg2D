using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    //public Texture2D DefaultCursor;

    private void Start()
    {
        Cursor.SetCursor(default, default, CursorMode.ForceSoftware);
    }
}
