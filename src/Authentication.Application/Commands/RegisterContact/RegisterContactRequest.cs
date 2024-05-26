using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Authentication.Application.Commands.RegisterContact
{
    public class RegisterContactRequest : IRequest<RegisterContactResponse>
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int DDD { get; set; }

        [Required]
        public int Phone { get; set; }
    }
}