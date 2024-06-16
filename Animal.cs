using MySql.Data.MySqlClient;
using System.Collections.Generic;

class Animal
{
    public int ID_Animal { get; private set; }
    public string Nome { get; private set; }
    public string Especie { get; private set; }
    public string Raca { get; private set; }
    public int Idade { get; private set; }
    public decimal Peso { get; private set; }
    public string Cor { get; private set; }

    public Animal(string nome, string especie, string raca, int idade, decimal peso, string cor)
    {
        Nome = nome;
        Especie = especie;
        Raca = raca;
        Idade = idade;
        Peso = peso;
        Cor = cor;
    }

    public void SetID(int id)
    {
        ID_Animal = id;
    }

    public void UpdateDetails(string nome, string especie, string raca, int idade, decimal peso, string cor)
    {
        Nome = nome;
        Especie = especie;
        Raca = raca;
        Idade = idade;
        Peso = peso;
        Cor = cor;
    }

    public void AddAnimal()
    {
        using (var connection = BancodeDados.GetConnection())
        {
            connection.Open();
            string query = "INSERT INTO animais (Nome, Especie, Raca, Idade, Peso, Cor) VALUES (@Nome, @Especie, @Raca, @Idade, @Peso, @Cor)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Especie", Especie);
            cmd.Parameters.AddWithValue("@Raca", Raca);
            cmd.Parameters.AddWithValue("@Idade", Idade);
            cmd.Parameters.AddWithValue("@Peso", Peso);
            cmd.Parameters.AddWithValue("@Cor", Cor);
            cmd.ExecuteNonQuery();
            SetID((int)cmd.LastInsertedId);
        }
    }

    public static List<Animal> GetAnimais()
    {
        List<Animal> animais = new List<Animal>();

        using (var connection = BancodeDados.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM animais";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var animal = new Animal(
                    reader.GetString("Nome"),
                    reader.GetString("Especie"),
                    reader.GetString("Raca"),
                    reader.GetInt32("Idade"),
                    reader.GetDecimal("Peso"),
                    reader.GetString("Cor")
                );
                animal.SetID(reader.GetInt32("ID_Animal"));
                animais.Add(animal);
            }
        }

        return animais;
    }

    public static List<Animal> SearchAnimal(int id)
    {
        List<Animal> animais=new List<Animal>();
        using (var connection=BancodeDados.GetConnection())
        {
            connection.Open();
            string query="select * from animais where ID_Animal like @ID_Animal";
            MySqlCommand cmd=new MySqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@ID_Animal",id);
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                var animal = new Animal(
                    reader.GetString("Nome"),
                    reader.GetString("Especie"),
                    reader.GetString("Raca"),
                    reader.GetInt32("Idade"),
                    reader.GetDecimal("Peso"),
                    reader.GetString("Cor")
                );
                animal.SetID(reader.GetInt32("ID_Animal"));
                animais.Add(animal);
            }
        }

        return animais;  
    }

    public void UpdateAnimal()
    {
        using (var connection = BancodeDados.GetConnection())
        {
            connection.Open();
            string query = "UPDATE animais SET Nome = @Nome, Especie = @Especie, Raca = @Raca, Idade = @Idade, Peso = @Peso, Cor = @Cor WHERE ID_Animal = @ID_Animal";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Especie", Especie);
            cmd.Parameters.AddWithValue("@Raca", Raca);
            cmd.Parameters.AddWithValue("@Idade", Idade);
            cmd.Parameters.AddWithValue("@Peso", Peso);
            cmd.Parameters.AddWithValue("@Cor", Cor);
            cmd.Parameters.AddWithValue("@ID_Animal", ID_Animal);
            cmd.ExecuteNonQuery();
        }
    }

    public static void DeleteAnimal(int id)
    {
        using (var connection = BancodeDados.GetConnection())
        {
            connection.Open();
            string query = "DELETE FROM animais WHERE ID_Animal = @ID_Animal";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID_Animal", id);
            cmd.ExecuteNonQuery();
        }
    }
}
