
// ************************************************************************
// Practica 09
// Alex Calderon, Joselyn Martinez
// Fecha de realización: 15/12/2024
// Fecha de entrega: 18/12/2024

// Resultados:
// Acerca del Codigo antes de los cambios
//se observa el uso de ASP.NET MVC para el desarrollo de la interfaz de usuario considerando el patrón MVC
//(Modelo- Vista- Controlador). Además, del uso de Entity Framework para la gestión de la base de datos,
//lo que permitió el manejo de diferentes operaciones de lectura, creación, actualización y eliminación. 
//De manera específica, las pruebas que se realizaron para corroborar el funcionamiento correcto fueron:
//•	Se comprobó que el método Index del controlador AsignaturaController permita devolver de manera correcta
//la lista de las asignaturas presentes en la base de datos y que se pueda visualizar la lista completa.
//Además, de verificar que en la vista de detalles se muestra de la manera correcta la información de la asignatura correspondiente. 
//•	En la creación de asignaturas se realizo diferentes pruebas para poder asegurar que se cree de manera
//correcta una asignatura, y que los datos se guarden en la base datos. De manera similar se realizo con
//la edición y eliminación de las asignaturas al corroborar que la información se almacene de manera correcta.


// Acerca del Codigo despues de los cambios
//la aplicación permitieron mejorar el modelo de los datos y optimizar el proceso de gestión de las asignaturas.
//Donde, se puede visualizar en las figuras anteriores que se agregaron varios componentes de CD, CP y AA.
//De la misma manera, se ajusto las horas considerando los créditos de las asignaturas lo que permite el cálculo de las horas
//de manera automática sin tener la necesidad que la propiedad “Horas” se modifique.
//Además, las vistas se actualizaron para poder mostrar la información agregada.
//Finalmente, se realizaron cambios en el título de la aplicación para que sea más personalizado. 

// Conclusiones:
//•	Por medio de la práctica, se evidencio que al implementar ASP.NET MVC se logra tener una arquitectura mejor organizada,
//debido a que, permite separar de manera adecuada el acceso a los datos, las vistas y controladores.
//•	El uso de Entity Framework permite un mejor manejo de los datos en la base de datos junto con
//la manipulación adecuada de los objetos. Lo cual, brinda la capacidad de tener una gestión eficiente y sencilla de la información referentes
//a las asignaturas. 
//•	La implementación de validaciones personalizadas brinda la posibilidad de verificar
//diferentes parámetros de manera más específica considerando los requisitos del funcionamiento de la aplicación. 

// Recomendaciones:
//•	Se recomienda emplear el manejo de excepciones más detalladas en los controladores y la parte de base de datos, para poder identificar, reconocer e informar los errores o conflictos al usar la aplicación. 
//•	Es recomendable incluir un diseño más amigable para el usuario para facilitar su interacción, en el cual, se puede colocar estilos de manera específica o usar frameworks como Bootstrap para tener una interacción más dinámica.
// ************************************************************************

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
