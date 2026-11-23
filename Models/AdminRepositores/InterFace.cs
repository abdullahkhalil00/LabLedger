
using Laboratory;
using LabLedger.Models;
using Equipmentnamespace;
namespace AdminInterface
{
    public interface ILaboratores
    {
        void CreateLab(string name, string location, string labcode,
            string labassistant, bool status, string description);

        void UpdateLab(int id, string name, string location,
            string labcode, string labassistant, bool status,
            string description);

        void DeleteLab(int id);

        List<LaboratoryModel> GetAllLabs();
    }

    public interface IEquipmentCatalog
    {
        List<EquipmentCatalog> GetAllEquipments();

        EquipmentCatalog GetEquipmentById(int id);

        void CreateEquipment(EquipmentCatalog equipment);

        void UpdateEquipment(EquipmentCatalog equipment);

        void DeleteEquipment(int id);
    }
}
