using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEditorInternal;
using System;
// using Com.LuisPedroFonseca.ProCamera2D;
public static class MyMenuCommands
{
#if UNITY_EDITOR
    [MenuItem("My Commands/Special Command _1")]
    static void SpecialCommand()
    {
        if (Application.isPlaying)
            return;
        TilemapCollider2D[] maps = GameObject.FindObjectsOfType<TilemapCollider2D>();
        for (int i = 0; i < maps.Length; i++)
        {
            maps[i].enabled = false;
            EditorUtility.SetDirty(maps[i]);
        }
        Debug.Log("fix");
    }
    [MenuItem("My Commands/Special Command_R _2")]
    static void SpecialCommand_R()
    {
        if (Application.isPlaying)
            return;
        TilemapCollider2D[] maps = GameObject.FindObjectsOfType<TilemapCollider2D>();
        for (int i = 0; i < maps.Length; i++)
        {
            maps[i].enabled = true;
            EditorUtility.SetDirty(maps[i]);
        }
    }

    [MenuItem("My Commands/Special Command_Active _a")]
    static void SpecialCommand_Active()
    {
        if (Application.isPlaying)
            return;
        Transform t = Selection.activeTransform;
        t.gameObject.SetActive(false);
        EditorUtility.SetDirty(t);
    }
    [MenuItem("My Commands/Special Command_DeActive _s")]
    static void SpecialCommand_DeActive()
    {
        if (Application.isPlaying)
            return;
        Transform t = Selection.activeTransform;
        t.gameObject.SetActive(true);
        EditorUtility.SetDirty(t);
    }

    static bool PointInRect(Vector2 pos, Rect rect)
    {
        return !(pos.x > rect.x + rect.width / 2 || pos.x < rect.x - rect.width / 2 ||
            pos.y > rect.y + rect.height / 2 || pos.y < rect.y - rect.height / 2);
    }

    [MenuItem("My Commands/Special Command_CenterCam %e")]
    static void SpecialCommand_CenterCam()
    {
        if (Application.isPlaying)
            return;
        Transform t = Camera.main.transform;
        if (UnityEditor.SceneView.lastActiveSceneView.camera)
        {
            t.transform.SetPosX(UnityEditor.SceneView.lastActiveSceneView.camera.transform.position.x);
            t.transform.SetPosY(UnityEditor.SceneView.lastActiveSceneView.camera.transform.position.y);
        }
    }
    
    //open it
    [MenuItem("My Commands/Special Command_GoCommon #c")]
    static void SpecialCommand_GoCommonC()
    {
        //string itemPath = Application.dataPath + $"/Resources/Language/Common.txt";
        //itemPath = itemPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        //System.Diagnostics.Process.Start("explorer.exe", itemPath);
        TextAsset config = Resources.Load<TextAsset>("Language/Common");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }
  
    [MenuItem("My Commands/Special Command_GoLocation #f")]
    static void SpecialCommand_GoLocation()
    {
        TextAsset config = Resources.Load<TextAsset>("Geo/Distribution/collection");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }

    [MenuItem("My Commands/Special Command_SelectPlayer _p")]
    static void SpecialCommand_SelectPlayer()
    {
        if (Application.isPlaying)
            return;
        GameObject player = GameObject.Find("player");
        if (player)
        {
            Selection.activeGameObject = player;
        }
    }
    [MenuItem("My Commands/Special Command_SelectTeam %t")]
    static void SpecialCommand_SelectTeam()
    {
        GameObject player = GameObject.Find("Team");
        if (player)
            Selection.activeGameObject = player;
    }
    
    [MenuItem("My Commands/Special Command_SelectCamera _c")]
    static void SpecialCommand_SelectCamera()
    {
        if (Application.isPlaying)
            return;
        GameObject cam = Camera.main.gameObject;
        Selection.activeGameObject = cam;
    }
#endif
}