using UnityEngine;

namespace MyCompany.MyProj.Util.SaveData
{
    public sealed class SaveDataUtil
    {
        public static string GetDataFilePath(string key)
        {
            return $"{Application.persistentDataPath}/{key}_SaveData.json";
        }
    }
}