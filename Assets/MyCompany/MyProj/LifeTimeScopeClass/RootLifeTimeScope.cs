using MyCompany.MyProj.GameState;
using TestModules;
using VContainer;
using VContainer.Unity;

namespace MyCompany.MyProj.LifeTimeScopeClass
{
    public class RootLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<BootState>(Lifetime.Singleton);
            base.Configure(builder); // ここで基底の関数をコールしてコンテナを構築
        }

        protected override void Awake()
        {
            base.Awake(); // 先に↑のConfigureでコンテナを構築してから解決処理を実行
            Container.Resolve<BootState>().Initialize();
        }
    }
}