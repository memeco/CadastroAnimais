using MySql.Data.MySqlClient;

class BancodeDados
{
    private static string connectionString = "Server=database-lab2.cxw2ioo8az9d.sa-east-1.rds.amazonaws.com;Database=db_animais;Uid=Aula01;Pwd=Aula01;";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}