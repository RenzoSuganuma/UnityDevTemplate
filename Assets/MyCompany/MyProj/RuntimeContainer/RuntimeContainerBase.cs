
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCompany.MyProj.RuntimeContainer
{
    /// <summary> ランタイムのコンテナの基底クラス </summary>
    /// NOTE: これをひとつのオブジェクトとしてシーンに配置してひとつの箱として運用する前提
    public class RuntimeContainerBase : LifetimeScope
    {
        /// <summary> このコンテナにレジスタするコンポーネント </summary>
        [SerializeField] private Component[] _registerComponents;
        
        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var component in _registerComponents)
            {
                builder.RegisterComponent(component);
            }
        }
    }
}