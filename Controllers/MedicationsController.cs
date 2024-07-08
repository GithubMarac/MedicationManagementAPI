using MedicationManagementApi.Models;
using MedicationManagementApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly MedicationService _medicationService;

        public MedicationsController(MedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedications()
        {
            return Ok(await _medicationService.GetMedicationsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetMedication(int id)
        {
            var medication = await _medicationService.GetMedicationByIdAsync(id);
            if (medication == null)
            {
                return NotFound();
            }
            return Ok(medication);
        }

        [HttpPost]
        public async Task<ActionResult<Medication>> PostMedication(Medication medication)
        {
            await _medicationService.AddMedicationAsync(medication);
            return CreatedAtAction(nameof(GetMedication), new { id = medication.Id }, medication);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedication(int id, Medication medication)
        {
            if (id != medication.Id)
            {
                return BadRequest();
            }

            await _medicationService.UpdateMedicationAsync(medication);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            await _medicationService.DeleteMedicationAsync(id);
            return NoContent();
        }
    }
}
