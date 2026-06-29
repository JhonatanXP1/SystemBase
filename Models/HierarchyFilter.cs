namespace SystemBase.Models;

public class HierarchyFilter
{
    public HierarchyFilter (List<int>? idsExcepcion)
    {
        this.idsExcepcion = idsExcepcion;
    }

    // null = nivel no resuelto / sin acceso.
    // Un valor = solo se ven roles con code mayor (subordinados).
    public int? levelRole { get; set; }
    public List<int>? idsExcepcion { get; set; }
    public bool? isActive { get; set; }
    public bool? isDeleted { get; set; }
    public int? page { get; set; }
    public int? pageSize { get; set; }
}