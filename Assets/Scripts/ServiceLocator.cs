using System;
using System.Collections.Generic;

namespace GameFramework
{
    public class ServiceLocator
    {
        private static Dictionary<String, Object> m_map = new Dictionary<String, Object>();

        public static void Register<T>(string key, T service)
        {
            m_map.Add(key, service);
        }

        public static T Get<T>(string key) where T : class
        {
            return m_map[key] as T;
        }

        public static void DisposeService()
        {
            m_map.Clear();
            m_map = null;
        }
    }
}