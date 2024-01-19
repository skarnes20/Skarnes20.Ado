namespace Skarnes20.Ado.Manager.Models;

public record ProjectList(List<ProjectModel> Value);

[ObservableObject]
public partial class ProjectModel
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}