namespace Skarnes20.Ado.Manager.Models;

public record TestPlanList(List<TestPlan> Value);

[ObservableObject]
public partial class TestPlan
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
