using LabLedger.Models;
using Microsoft.Data.SqlClient;

namespace LabLedger.Repositories
{
    public class StudentRepo : IEquipmentCatalog
    {
        private readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=LabLedgerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<EquipmentCatalog> GetAllEquipments()
        {
            List<EquipmentCatalog> equipments = new List<EquipmentCatalog>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM dbo.EquipmentCatalog";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EquipmentCatalog equipment = new EquipmentCatalog
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Category = reader["Category"].ToString(),
                                EquipmentName = reader["EquipmentName"].ToString(),
                                Location = reader["Location"].ToString(),
                                Status = reader["Status"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            };

                            equipments.Add(equipment);
                        }
                    }
                }
            }

            return equipments;
        }
    }
}