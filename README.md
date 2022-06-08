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

Y además editar esta misma cadena en el archivo/clase <comiczoom/Models/ConnectionDB.cs>, precisamente esta:

string Cad = "Data Source=DESKTOP-7ND8I4M\\SQLEXPRESS; Initial Catalog=comiczoom; Integrated Security=True";
    
si es necesario, personalizar según tu equipo.

5. Ejecutar :)
