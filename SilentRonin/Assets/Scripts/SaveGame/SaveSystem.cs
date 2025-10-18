using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string GetPath(string slotName)
    {
        return Application.persistentDataPath + "/" + slotName + ".json";
    }

    public static void SaveGame(SaveSlotData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetPath(data.slotName), json);
    }

    public static SaveSlotData LoadGame(string slotName)
    {
        string path = GetPath(slotName);
        if (!File.Exists(path))
            return null;

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<SaveSlotData>(json);
    }

    public static bool HasSave(string slotName)
    {
        return File.Exists(GetPath(slotName));
    }

    public static void DeleteSave(string slotName)
    {
        string path = GetPath(slotName);
        if (File.Exists(path)) File.Delete(path);
    }
}
