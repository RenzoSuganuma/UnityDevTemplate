using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MyCompany.MyProj.Infra
{
    public class AddressableResourceLoader
    {
        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            var handle = Addressables.LoadAssetAsync<T>(path);
            return handle.WaitForCompletion();
        }

        public static void Release<T>(T obj)
        {
            Addressables.Release(obj);
        }
    }
}