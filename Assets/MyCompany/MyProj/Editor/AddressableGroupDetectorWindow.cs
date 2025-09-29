using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace MyCompany.MyProj.Editor
{
    public class AddressableGroupDetectorWindow : EditorWindow
    {
        private AddressableAssetGroup _targetGroup;
        private string _saveFolder;

        [MenuItem("MyCompany/MyProj/AddressableGroupDetectorWindow")]
        public static void Init()
        {
            CreateWindow<AddressableGroupDetectorWindow>();
        }

        private void OnGUI()
        {
            _targetGroup =
                (AddressableAssetGroup)EditorGUILayout.ObjectField(_targetGroup, typeof(AddressableAssetGroup), false);
            _saveFolder = EditorGUILayout.TextField("SavePath", _saveFolder);
            if (_targetGroup == null) return;
            var path = _saveFolder + $"/AAG{_targetGroup.name.Replace(" ", "")}.cs";

            if (GUILayout.Button("Generate"))
            {
                var fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                List<string> content = new List<string>();
                content.Add($"public class AAG{_targetGroup.name.Replace(" ", "")}" + "\n{\n");
                foreach (var obj in _targetGroup.entries)
                {
                    var line =
                        $"public const string k{obj.AssetPath.Split('.')[0].Replace("/", "_")} = \"{obj.AssetPath}\";\n";
                    content.Add(line);
                }

                content.Add("}\n");
                File.WriteAllLines(path, content, System.Text.Encoding.UTF8);
                fs.Flush();
                fs.Close();
            }
        }
    }
}