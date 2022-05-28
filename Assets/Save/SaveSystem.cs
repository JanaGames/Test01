using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
    //fileName = "/gamesave.save";
    public static void Save(string fileName, Save save) 
    {
        string json = JsonUtility.ToJson(save);
        WriteTo(fileName, json);  
    }
    public static Save Load(string fileName) 
    {
        Save save = new Save();
        string json = ReadFrom(fileName);
        JsonUtility.FromJsonOverwrite(json, save);
        return save;
    }
    public static void Delete(string fileName) 
    {
        string filePath = Application.persistentDataPath + "/" + fileName;
        string guiMessage = "guiMessage text";
        if (!File.Exists(filePath)) 
        {
            guiMessage = "no " + fileName + " file exists"; //Debug.Log( "no " + fileName + " file exists" );
        }
        else 
        {
            guiMessage = fileName + " file exists, deleting..."; //Debug.Log( fileName + " file exists, deleting..." );
             
            File.Delete(filePath);
             
            //UnityEditor.AssetDatabase.Refresh();
        }
    }
    public static void WriteTo(string fileName, string json) 
    {
        string path = Application.persistentDataPath + fileName;
        FileStream file = File.Create(path);
        using (StreamWriter writer = new StreamWriter(file)) writer.Write(json);
    }
    public static string ReadFrom(string fileName) 
    {
        string path = Application.persistentDataPath + fileName;
        string json = "";
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path)) json = reader.ReadToEnd();
        }
        else
        {
            //Debug.LogWarning("Save not found in " + path);
        }
        return json;
        //Debug.Log(save.nameNations);
    }
}
