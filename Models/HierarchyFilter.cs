namespace SystemBase.Models;

public class HierarchyFilter
{
    public HierarchyFilter(List<int>? idsExcepcion)
    {
        this.idsExcepcion = idsExcepcion;
    }

    public int? levelRole { get; set; } = 0;
    public List<int>? idsExcepcion { get; set; }
    public bool? isActive { get; set; }
    public bool? isDeleted { get; set; }
    public int? page { get; set; }
    public int? pageSize { get; set; }
}