using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MyCompany.MyProj.Editor
{
    public class EngineLayerDetector
    {
        [InitializeOnLoadMethod]
        [MenuItem("MyCompany/MyProj/DetectEngineLayers")]
        public static void Init()
        {
            var content = new List<string>();

            var path = "Assets/MyCompany/MyProj/Util/UtilEngineLayer.cs";
            var fs = File.Open(path, FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.ReadWrite);

            content.Add($"public class UtilEngineLayer \n");
            content.Add("{\n");

            foreach (var l in UnityEditorInternal.InternalEditorUtility.layers)
            {
                content.Add($"public const string k{l.Replace(" ", "")} = \"{l}\";\n");
            }

            content.Add("}\n");

            File.WriteAllLines(path, content);
            fs.Flush();
            fs.Close();
        }
    }
}