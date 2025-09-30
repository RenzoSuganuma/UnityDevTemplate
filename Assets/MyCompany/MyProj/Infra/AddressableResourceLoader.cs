using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace MyCompany.MyProj.Infra
{
    public class AddressableResourceLoader
    {
        public static (T inst, AsyncOperationHandle<T> handle) Load<T>(string path) where T : UnityEngine.Object
        {
            var handle = Addressables.LoadAssetAsync<T>(path);
            var obj = handle.WaitForCompletion();
            return (obj, handle);
        }

        public static void Release<T>(T obj)
        {
            Addressables.Release(obj);
        }

        public static void Release<T>(AsyncOperationHandle<T> obj)
        {
            Addressables.Release(obj);
        }
    }
}