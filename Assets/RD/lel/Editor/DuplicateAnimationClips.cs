using UnityEditor;
using UnityEngine;

public class ExtractAnimationClips : Editor
{
    [MenuItem("Tools/Extract Animation Clips")]
    public static void ExtractClips()
    {
        Object[] selectedObjects = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);
        foreach (var selectedObject in selectedObjects)
        {
            Debug.Log(selectedObject.name);
            var animation = AssetDatabase.LoadAssetAtPath<AnimationClip>(AssetDatabase.GetAssetPath(selectedObject));
            Debug.Log(animation.name);
            animation.name = selectedObject.name;
            //save animation as a new asset typo of animation clip at the same folder
            string assetPath = AssetDatabase.GetAssetPath(selectedObject);
            string folderPath = assetPath.Substring(0, assetPath.LastIndexOf('/'));
            AssetDatabase.CreateAsset(Instantiate(animation), folderPath + "/" + selectedObject.name + ".anim");
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}