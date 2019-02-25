using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}