namespace SystemBase.Models;

// Nivel del árbol organizacional al que se ancla un UserAssignment.
// Mapeo scopeType → tabla destino del scopeId (polimórfico, sin FK física):
//   company -> Company.id
//   campus  -> Campus.id
//   area    -> CampusArea.id
//   shift   -> CampusAreaShift.id
//   team    -> CampusAreaShiftTeam.id
public enum scopeType
{
    company,
    campus,
    area,
    shift,
    team
}
