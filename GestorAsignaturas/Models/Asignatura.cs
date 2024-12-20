using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorAsignaturas.Models
{
    public class Asignatura : IValidatableObject
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre de la asignatura es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la asignatura no puede superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El código de la asignatura es obligatorio.")]
        [StringLength(7, ErrorMessage = "El código de la asignatura no puede superar los 7 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El número de créditos de la asignatura es obligatorio.")]
        [Range(0, 15, ErrorMessage = "El número de créditos debe estar entre 0 y 15.")]
        public int Creditos { get; set; }

        // Componentes de aprendizaje
        [Required(ErrorMessage = "CD es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "CD debe ser mayor a 0.")]
        public int CD { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "CP no puede ser negativo.")]
        public int CP { get; set; }

        [Required(ErrorMessage = "AA es obligatorio.")]
        public int AA { get; set; } // Validación dinámica en el método Validate

        // Propiedad calculada: Horas
        public int Horas
        {
            get
            {
                return CD + CP + AA;
            }
        }

        // Área de la asignatura
        public string Area { get; set; } = "sin área";

        // Validaciones adicionales implementadas con IValidatableObject
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int horasEsperadas = Creditos > 0 ? Creditos * 3 : 2;

            // Validar si las horas calculadas cumplen con los créditos
            if (Horas != horasEsperadas)
            {
                yield return new ValidationResult(
                    $"La suma de CD, CP y AA debe ser igual a {horasEsperadas} horas para {Creditos} créditos.",
                    new[] { "CD", "CP", "AA" }
                );
            }

            // Validar que si los créditos son 0, solo el CD puede ser 2 y CP y AA deben ser 0
            if (Creditos == 0)
            {
                if (CD != 2 || CP != 0 || AA != 0)
                {
                    yield return new ValidationResult(
                        "Si la asignatura tiene 0 créditos, solo el CD debe ser 2 y CP y AA deben ser 0.",
                        new[] { "CD", "CP", "AA" }
                    );
                }
            }
            else
            {
                // Validar que CD y AA no sean 0 cuando los créditos son mayores a 0
                if (CD <= 0 || AA <= 0)
                {
                    yield return new ValidationResult(
                        "CD y AA deben ser mayores a 0 cuando los créditos son mayores a 0.",
                        new[] { "CD", "AA" }
                    );
                }
            }
        }
        public bool ValidarHoras()
        {
            int horasEsperadas = Creditos > 0 ? Creditos * 3 : 2;
            return Horas == horasEsperadas;
        }
    }
}
