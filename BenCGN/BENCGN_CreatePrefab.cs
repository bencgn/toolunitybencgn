using UnityEngine;
using UnityEditor;

public static class BENCGN_CreatePrefab

{
    [MenuItem("BENCGN/Apply changes to Prefab &a")]
    static void SaveChangesToPrefab()
    {
        GameObject[] selection = Selection.gameObjects;
        if (selection.Length < 1) return;
        Undo.RegisterCompleteObjectUndo(selection, "Apply Prefab");
        foreach (GameObject go in selection)
        {
            if (PrefabUtility.GetPrefabType(go) == PrefabType.PrefabInstance)
            {
                PrefabUtility.ReplacePrefab(go, PrefabUtility.GetPrefabParent(go));
                PrefabUtility.RevertPrefabInstance(go);
            }
        }
    }
}
