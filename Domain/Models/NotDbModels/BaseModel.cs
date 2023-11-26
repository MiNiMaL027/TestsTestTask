namespace Domain.Models.NotDbModels
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime? ArchivateDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }    
    }
}
