using UnityEngine;

public class StyleCreator
{
    public GUIStyle CreateLabelStyle()
    {
        GUIStyle style = new();
        style.fontStyle = FontStyle.Bold;
        style.fontSize = 18;
        style.normal.textColor = Color.red;
        return style;
    }
    public GUIStyle CreateTextStyle()
    {
        GUIStyle style = new();
        style.fontSize = 16;
        style.normal.textColor = Color.blue;
        return style;
    }
}
