using UnityEngine.Windows;
using UnityEngine;
using UnityEditor;

public class SaveMap : MonoBehaviour {

    [HideInInspector]
    public static string exportName = "export";
    Texture2D texture;

    public void Save()
    {
        texture = NoiseGen.mTexture;
        var path = EditorUtility.SaveFilePanel("Save Map", "", exportName + ".png", "png");

        if (path.Length != 0)
        {
            var pngData = texture.EncodeToPNG();
            if (pngData != null)
                File.WriteAllBytes(path, pngData);
        }
    }
}
