namespace SystemBase.Models;

// Valor jerárquico FIJO e interno del campus (mismo patrón que RoleCode).
// El nombre visible es personalizable en Campus.name; este code no cambia.
public enum CampusCode
{
    Sede = 1,    // manda
    Oficina = 2,
    Local = 3    // más bajo
}
