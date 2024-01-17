namespace Skarnes20.Ado.Manager.Models;

public record TestPlanList(List<TestPlan> Value);

public record TestPlan(int Id, string Name);
