namespace EmployeeOOP.Classes
{
    public abstract class Employee
    {
        #region Properties
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? lastName { get; set; }
        public Date? BirthDate { get; set; }
        public Date? HiringDate { get; set; }
        public bool? IsActive { get; set; }

        #endregion

        #region Methods

        public Employee() { }

        public abstract decimal GetValueToPay();

        public override string ToString()
        {
            return $"INFORMACION EMPLEADO\n\t" +
                $"ID: {Id}\n\t" +
                $"Nombres: {FirstName}\n\t" +
                $"Apellidos: {lastName}\n\t" +
                $"Fecha de Nacimiento: {BirthDate}\n\t" +
                $"Fecha de Contratacion: {HiringDate}\n\t" +
                $"¿Empleado Activo?: {IsActive}\n\t";
        }

        #endregion
    }
}
