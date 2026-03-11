# Accesos de Cada Role.

**Acceso Teorico.**

El objetivo es definir los niveles de acceso base del sistema para cada rol. Es importante recordar que estos permisos son dinámicos y configurables, permitiendo a cada empresa adaptarlos según sus necesidades específicas.

```*```: Disponibilidad total.

```self:```  Acceso limitado a su propia información y recursos directamente asociados a su usuario..

```company:``` Acceso a la información de la compañía o compañías a las que el usuario está asignado.

```depart:``` Acceso a la información del o los departamentos a los que el usuario pertenece.

```squad:```  Acceso a la información de los equipos o squads de trabajo de los que el usuario es miembro.



| Roles/Modulos | Analisis Datos      | Usuarios            | Empleados           | Acceso del sistema.                   |
|---------------|---------------------|---------------------|---------------------|---------------------------------------|
| Director      |          *          |          *          |          *          |                   *                   |
| Gerente       |   *.[self,company]  |   *.[self,company]  |   *.[self,company]  | [update,read,delete].[self,company] |
| Supervisor    |   *.[self,depart]   |      *.[depart]     |      *.[depart]     | [update,read,delete].[self,depart]   |
| Coordinador   | [read].[self,squad] | [read].[self,squad] | [read].[self,squad] | [update,read].[self,depart]            |
| Empleado      |    [read].[self]    |    [read].[self]    |    [read].[self]    |                   -                   |

<br>

# Accceso de Endpoint por Role.

En esta sección se definirán las reglas explícitas para el control de permisos dentro del sistema desde una perspectiva lógica y sintáctica.

Mientras que en la sección anterior se presentó el modelo teórico de acceso de manera conceptual, aquí se establecerán las reglas necesarias para su aplicación práctica, permitiendo su implementación directa en los endpoints y servicios del sistema.

| Endpoint / Role 	| Method          	| Director                          	| Gerente                                     	| Supervisor                                  	| Coordinador                               	| Empleado         	|
|-----------------	|-----------------	|-----------------------------------	|---------------------------------------------	|---------------------------------------------	|-------------------------------------------	|------------------	|
| /auth/logout    	| POST            	| auth.logout.self<br>auth.logout.* 	| auth.logout.self<br>auth.logout.subordinate 	| auth.logout.self<br>auth.logout.subordinate 	| auth.logout.self                          	| auth.logout.self 	|
| /auth/access    	| GET o GET {id}  	| auth.access.self<br>auth.access.* 	| auth.access.self<br>auth.access.subordinate 	| auth.access.self<br>auth.access.subordinate 	| auth.access.self                          	| auth.access.self 	|
| /user           	| GET o GET {id}  	| user.read.self<br>user.read.*     	| user.read.self<br>user.read.subordinate     	| user.read.self<br>user.read.subordinate     	| auth.access.self<br>user.read.subordinate 	| auth.access.self 	|
|                 	|                 	|                                   	|                                             	|                                             	|                                           	|                  	|
|                 	|                 	|                                   	|                                             	|                                             	|                                           	|                  	|

```json
{
  "perm": {
    "COMPANY:1": [
      "auth.logout.self",
      "auth.logout.subordinate"
    ],
    "COMPANY:2": [
      "auth.logout.subordinate"
    ]
  }
}
```

asi se veran la claim con el permiso