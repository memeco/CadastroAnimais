using MySql.Data.MySqlClient;

public class BancodeDados
{
    private static string connectionString = "Server=localhost;Database=db_animais;Uid=root;Pwd=;";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}