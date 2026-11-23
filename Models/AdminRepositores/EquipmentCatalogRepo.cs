
using LabLedger.Models;
using Microsoft.Data.SqlClient;
using Equipmentnamespace;
using AdminInterface;
namespace LabLedger.Repositories
{
    public class EquipmentRepository : IEquipmentCatalog
    {
        private readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=LabLedgerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Get All Equipments
        public List<EquipmentCatalog> GetAllEquipments()
        {
            List<EquipmentCatalog> equipments = new List<EquipmentCatalog>();

            string query = "SELECT * FROM dbo.EquipmentCatalog";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            equipments.Add(new EquipmentCatalog
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Category = reader["Category"].ToString(),
                                EquipmentName = reader["EquipmentName"].ToString(),
                                Condition = reader["Condition"].ToString(),
                                Description = reader["Description"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                labname = reader["labname"].ToString()
                            });
                        }
                    }
                }
            }

            return equipments;
        }

        // Get Equipment By Id
        public EquipmentCatalog GetEquipmentById(int id)
        {
            EquipmentCatalog equipment = null;

            string query = "SELECT * FROM dbo.EquipmentCatalog WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            equipment = new EquipmentCatalog
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Category = reader["Category"].ToString(),
                                EquipmentName = reader["EquipmentName"].ToString(),
                                Condition = reader["Condition"].ToString(),
                                Description = reader["Description"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                labname = reader["labname"].ToString()
                            };
                        }
                    }
                }
            }

            return equipment;
        }

        // Create Equipment
        public void CreateEquipment(EquipmentCatalog equipment)
        {
            string query = @"INSERT INTO dbo.EquipmentCatalog
                            (Category, EquipmentName, [Condition], Description, Quantity, labname)
                            VALUES
                            (@Category, @EquipmentName, @Condition, @Description, @Quantity, @labname)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Category", (object)equipment.Category ?? DBNull.Value);
                    command.Parameters.AddWithValue("@EquipmentName", (object)equipment.EquipmentName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Condition", (object)equipment.Condition ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Description", (object)equipment.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Quantity", equipment.Quantity);
                    command.Parameters.AddWithValue("@labname", (object)equipment.labname ?? DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Update Equipment
        public void UpdateEquipment(EquipmentCatalog equipment)
        {
            string query = @"UPDATE dbo.EquipmentCatalog
                            SET Category = @Category,
                                EquipmentName = @EquipmentName,
                                [Condition] = @Condition,
                                Description = @Description,
                                Quantity = @Quantity,
                                labname = @labname
                            WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", equipment.Id);
                    command.Parameters.AddWithValue("@Category", (object)equipment.Category ?? DBNull.Value);
                    command.Parameters.AddWithValue("@EquipmentName", (object)equipment.EquipmentName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Condition", (object)equipment.Condition ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Description", (object)equipment.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Quantity", equipment.Quantity);
                    command.Parameters.AddWithValue("@labname", (object)equipment.labname ?? DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete Equipment
        public void DeleteEquipment(int id)
        {
            string query = "DELETE FROM dbo.EquipmentCatalog WHERE Id = @id";

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
    }
}
