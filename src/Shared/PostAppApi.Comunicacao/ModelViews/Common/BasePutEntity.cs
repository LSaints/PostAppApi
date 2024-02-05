using System.ComponentModel.DataAnnotations;

namespace PostAppApi.Comunicacao.ModelViews.Common
{
    public class BasePutEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
