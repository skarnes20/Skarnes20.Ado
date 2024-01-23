namespace Skarnes20.Ado.Manager.Services;

public class AdoService(ManagerClient client, IManangerSettings settings) : IAdoService
{
    private const string ApiVersion = "api-version=5.0";

    public async Task<IEnumerable<TestPlan>> GetAllTestPlans()
    {
        var url = new Uri($"{settings.Organization}/{settings.Project}/_apis/test/plans?{ApiVersion}");
        var testPlans = await client.GetAsync<TestPlanList>(url);
        return testPlans.Value;
    }

    public async Task<IEnumerable<ProjectModel>> GetProjects()
    {
        var url = new Uri($"{settings.Organization}/_apis/projects?api-version=7.1-preview.4");
        var projects = await client.GetAsync<ProjectList>(url);
        return projects.Value;
    }

    public async Task DeleteTestPlan(int id)
    {
        await client.DeleteAsync(new Uri($"{settings.Organization}/{settings.Project}/_apis/test/plans/{id}?{ApiVersion}"));
    }
}