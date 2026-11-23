
using Microsoft.Data.SqlClient;
using Laboratory;
using System;
using System.Collections.Generic;
using AdminInterface;
namespace LabRepo
{
    public class LabRepository : ILaboratores
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=LabLedgerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        void ILaboratores.CreateLab(string name, string location, string labcode, string labassistant, Boolean status, string description)
        {
            string query = @"INSERT INTO dbo.Laboratories
             (LaboratoryName, Location, Labcode, LabAssistant, Status, Description)
             VALUES
             (@LaboratoryName, @Location, @Labcode, @LabAssistant, @Status, @Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LaboratoryName", name);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Labcode", labcode);
                    command.Parameters.AddWithValue("@LabAssistant", labassistant);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Description", description);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        void ILaboratores.DeleteLab(int id)
        {
            string query = @"DELETE FROM dbo.Laboratories
                         WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        void ILaboratores.UpdateLab(int id, string name, string location, string labcode, string labassistant, Boolean status, string description)
        {
            string query = @"UPDATE dbo.Laboratories
                         SET LaboratoryName = @name,
                             Location = @location,
                             Labcode = @labcode,
                             LabAssistant = @labassistant,
                             Status = @status,
                             Description = @Description
                         WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@location", location);
                    command.Parameters.AddWithValue("@labcode", labcode);
                    command.Parameters.AddWithValue("@labassistant", labassistant);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@Description", description);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<LaboratoryModel> GetAllLabs()
        {
            List<LaboratoryModel> laboratories = new List<LaboratoryModel>();

            string query = "SELECT * FROM dbo.Laboratories";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            laboratories.Add(new LaboratoryModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                laboratoryName = reader["LaboratoryName"].ToString(),
                                Location = reader["Location"].ToString(),
                                Labcode = reader["Labcode"].ToString(),
                                Description = reader["Description"].ToString(),
                                LabAssistant = reader["LabAssistant"].ToString(),
                                status = Convert.ToBoolean(reader["Status"])
                            });
                        }
                    }
                }
            }

            return laboratories;
        }
    }
}
