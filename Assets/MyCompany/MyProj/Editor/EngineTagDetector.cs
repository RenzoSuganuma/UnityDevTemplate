using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MyCompany.MyProj.Editor
{
    public class EngineTagDetector
    {
        [InitializeOnLoadMethod]
        [MenuItem("MyCompany/MyProj/DetectEngineTags")]
        public static void Init()
        {
            var content = new List<string>();

            var path = "Assets/MyCompany/MyProj/Util/UtilEngineTag.cs";
            var fs = File.Open(path, FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.ReadWrite);

            content.Add($"public class UtilEngineTag \n");
            content.Add("{\n");

            foreach (var tag in UnityEditorInternal.InternalEditorUtility.tags)
            {
                content.Add($"public const string k{tag.Replace(" ", "")} = \"{tag}\";\n");
            }

            content.Add("}\n");

            File.WriteAllLines(path, content);
            fs.Flush();
            fs.Close();
        }
    }
}