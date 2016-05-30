namespace PW.Web.Command
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T t);
    }
}