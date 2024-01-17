namespace Skarnes20.Ado.Manager.Services;

public interface IManangerSettings
{
    string Organization { get; set; }

    string Project { get; set; }

    public Task<string> GetToken();

    public Task SetToken(string token);

    public void Clear();

}