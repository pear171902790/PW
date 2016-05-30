using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using PW.Web.Command;

namespace PW.Command
{

    public interface ICommandService
    {
        void Excute<T>(T t) where T : ICommand;
    }

    public class CommandService:ICommandService
    {
        private readonly IWindsorContainer _windsorContainer;

        public CommandService(IWindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
        }

        public void Excute<T>(T t) where T : ICommand
        {
            _windsorContainer.UseComponent<ICommandHandler<T>>(
                    handler => handler.Handle(t)
                );
        }
    }

    public static class Extension
    {
        public static void UseComponent<TComponent>(this IWindsorContainer me, Action<TComponent> action)
        {
            using (var component = new DisposableComponent<TComponent>(me.Resolve<TComponent>(), me))
            {
                action(component.Instance);
            }
        }
    }

    public class DisposableComponent<T> : IDisposable
    {
        private readonly IWindsorContainer _container;

        public DisposableComponent(T component, IWindsorContainer container)
        {
            _container = container;
            Instance = component;
        }

        public T Instance { get; private set; }

        public void Dispose()
        {
            _container.Release(Instance);
        }
    }
}
