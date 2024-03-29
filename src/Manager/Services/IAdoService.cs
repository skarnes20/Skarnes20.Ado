﻿namespace Skarnes20.Ado.Manager.Services;

public interface IAdoService
{
    public Task<IEnumerable<TestPlan>> GetAllTestPlans();

    public Task<IEnumerable<ProjectModel>> GetProjects();

    public Task DeleteTestPlan(int  id);
}