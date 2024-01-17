using AdoApiWrapper.Models;

namespace AdoApiWrapper;

public interface IAdoService
{
    public Task<IAsyncEnumerable<TestPlanResponse>> GetAllTestPlans();
}