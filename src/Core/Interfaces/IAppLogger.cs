namespace Nexos.Core.Interfaces
{
    public interface IAppLogger<T> 
    {
        void LogInformacion(string informacion, params object[] argumentos);
        void LogWarning(string informacion, params object[] argumentos);

    }
}