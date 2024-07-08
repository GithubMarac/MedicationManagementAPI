using MedicationManagementApi.Models;
using MedicationManagementApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationManagementApi.Services
{
    public class MedicationService
    {
        private readonly MedicationContext _context;

        public MedicationService(MedicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medication>> GetMedicationsAsync()
        {
            return await _context.Medications.ToListAsync();
        }

        public async Task<Medication> GetMedicationByIdAsync(int id)
        {
            return await _context.Medications.FindAsync(id);
        }

        public async Task<Medication> AddMedicationAsync(Medication medication)
        {
            _context.Medications.Add(medication);
            await _context.SaveChangesAsync();
            return medication;
        }

        public async Task<Medication> UpdateMedicationAsync(Medication medication)
        {
            _context.Entry(medication).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medication;
        }

        public async Task DeleteMedicationAsync(int id)
        {
            var medication = await _context.Medications.FindAsync(id);
            if (medication != null)
            {
                _context.Medications.Remove(medication);
                await _context.SaveChangesAsync();
            }
        }
    }
}
