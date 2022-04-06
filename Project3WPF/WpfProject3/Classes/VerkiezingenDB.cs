using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfProject3.Classes
{
    class VerkiezingenDB
    {
        MySqlConnection _connection = new MySqlConnection("Server = localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");

        public void CreatePolitiekePartij(string partijNaam, string adres, string postcode, string gemeente, string email, string telefoon)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `partij` (`PartijId`, `PartijName`, `Adres`, `Postcode`, `Gemeente`, `EmailAdres`, `Telefoonnummer`) VALUES (NULL, @partijNaam, @adres, @postcode, @gemeente, @email, @telefoon);";
                command.Parameters.AddWithValue("partijNaam", partijNaam);
                command.Parameters.AddWithValue("adres", adres);
                command.Parameters.AddWithValue("postcode", postcode);
                command.Parameters.AddWithValue("gemeente", gemeente);
                command.Parameters.AddWithValue("email", email);
                command.Parameters.AddWithValue("telefoon", telefoon);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                _connection.Close();
            }
        }

        public void CreateStandpunt (string partijId, string partijNaam, string themaId, string thema, string standpunt)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `standpunten` (`StandpuntId`, `PartijId`, `PartijName`, `ThemaId`, `Thema`, `Standpunt`) VALUES (NULL, @partijId, @partijNaam, @themaId, @thema, @standpunt);";
                command.Parameters.AddWithValue("partijId", partijId);
                command.Parameters.AddWithValue("partijNaam", partijNaam);
                command.Parameters.AddWithValue("themaId", themaId);
                command.Parameters.AddWithValue("thema", thema);
                command.Parameters.AddWithValue("standpunt", standpunt);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }

        public void CreateVerkiezing(string soortId, string verkiezingsoort, string datum)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO `verkiezing` (`VerkiezingId`, `SoortId`, `Verkiezingsoort`, `Datum`) VALUES (NULL, @soortId, @verkiezingsoort, @datum)";
                command.Parameters.AddWithValue("soortId", soortId);
                command.Parameters.AddWithValue("verkiezingsoort", verkiezingsoort);
                command.Parameters.AddWithValue("datum", datum);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }

        public DataTable SelectPolitiekePartijen()
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM partij;";
                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
            return table;
        }

        public DataTable SelectThemas()
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM thema;";
                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
            return table;
        }

        public DataTable SelectStandpunten()
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM standpunten;";
                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
            return table;
        }

        public DataTable SelectPartijStandpunten(string partijId)
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM `standpunten` WHERE `standpunten`.`PartijId` = @partijId;";
                command.Parameters.AddWithValue("partijId", partijId);
                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
            return table;
        }

        public DataTable SelectPartijVerkiezingsdeelname(string partijId)
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM `verkiezingspartijen` WHERE `verkiezingspartijen`.`PartijId` = @partijId;";
                command.Parameters.AddWithValue("partijId", partijId);
                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
            return table;
        }

        public DataTable SelectVerkiezingen()
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM verkiezing;";
                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
            return table;
        }

        public DataTable SelectVerkiezingsoorten()
        {
            DataTable table = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM verkiezingsoort;";
                MySqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
            return table;
        }

        public void EditPolitiekePartij(string partijId, string partijNaam, string adres, string postcode, string gemeente, string emailAdres, string telefoon)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `partij` SET `PartijName` = @partijNaam, `Adres` = @adres, `Postcode` = @postcode, `Gemeente` = @gemeente, `EmailAdres` = @emailAdres, `Telefoonnummer` = @telefoon WHERE `partij`.`PartijId` = @partijId;";
                command.Parameters.AddWithValue("partijNaam", partijNaam);
                command.Parameters.AddWithValue("adres", adres);
                command.Parameters.AddWithValue("postcode", postcode);
                command.Parameters.AddWithValue("gemeente", gemeente);
                command.Parameters.AddWithValue("emailAdres", emailAdres);
                command.Parameters.AddWithValue("telefoon", telefoon);
                command.Parameters.AddWithValue("partijId", partijId);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }

        public void EditStandpunt(string standpuntId, string partijId, string partijNaam, string themaId, string thema, string standpunt)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `standpunten` SET `PartijId` = @partijId, `PartijName` = @partijNaam, `ThemaId` = @themaId, `Thema` = @thema, `Standpunt` = @standpunt WHERE `standpunten`.`StandpuntId` = @standpuntId;";
                command.Parameters.AddWithValue("partijId", partijId);
                command.Parameters.AddWithValue("partijNaam", partijNaam);
                command.Parameters.AddWithValue("themaId", themaId);
                command.Parameters.AddWithValue("thema", thema);
                command.Parameters.AddWithValue("standpunt", standpunt);
                command.Parameters.AddWithValue("standpuntId", standpuntId);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }

        public void EditVerkiezing(string verkiezingId, string soortId, string verkiezingsoort, string datum)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "UPDATE `verkiezing` SET `SoortId` = @soortId, `Verkiezingsoort` = @verkiezingsoort, `Datum` = @datum WHERE `verkiezing`.`VerkiezingId` = @verkiezingId;";
                command.Parameters.AddWithValue("soortId", soortId);
                command.Parameters.AddWithValue("verkiezingsoort", verkiezingsoort);
                command.Parameters.AddWithValue("datum", datum);
                command.Parameters.AddWithValue("verkiezingId", verkiezingId);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeletePolitiekePartij(string partijId)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `partij` WHERE `partij`.`PartijId` = @partijId;";
                command.Parameters.AddWithValue("partijId", partijId);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeleteStandpunt(string standpuntId)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `standpunten` WHERE `standpunten`.`StandpuntId` = @standpuntId";
                command.Parameters.AddWithValue("standpuntId", standpuntId);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeleteVerkiezing(string verkiezingId)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `verkiezing` WHERE `verkiezing`.`VerkiezingId` = @verkiezingId";
                command.Parameters.AddWithValue("verkiezingId", verkiezingId);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeletePartijStandpunten(string partijId)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `standpunten` WHERE `standpunten`.`PartijId` = @partijId;";
                command.Parameters.AddWithValue("partijId", partijId);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeletePartijVerkiezingsdeelname(string partijId)
        {
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "DELETE FROM `verkiezingspartijen` WHERE `verkiezingspartijen`.`PartijId` = @partijId;";
                command.Parameters.AddWithValue("partijId", partijId);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
