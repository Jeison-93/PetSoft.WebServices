namespace PetSoft.WebServices.Data.Dto
{
    /// <summary>
    /// Este DTO  se va a utilizar para retornar la informacion de las tablas genéricas(maestras)
    /// documenttype,usertype, species, servicestate, servicetype.
    /// </summary>
    public class GenericTableDto
    {
        public string? Code { get; set; }

        public string? Description { get; set; }

        public double? Value { get; set; }
    }
}
