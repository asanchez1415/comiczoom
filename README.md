# Aplicación comiczoom
Instalación
1. Crear la base de datos con el nombre <comiczoom> (en sqlserver).

2. Ejecutar el contenido del archivo <db/database.sql> (estructura de la base de datos).

3. Ejecutar el contenido del archivo <db/data.sql> (información para poblar la base de datos).

4. Revisar la conexión string del archivo <comiczoom/Models/UserLogin.cs>, precisamente este:

string connectionString()
{
    return "Server=localhost\\SQLEXPRESS;Database=comiczoom;Trusted_Connection=True;";
}

si es necesario, personalizar según tu equipo.

5. Ejecutar :)

*Borrar .vs y carpeta obj dentro del proyecto*      
