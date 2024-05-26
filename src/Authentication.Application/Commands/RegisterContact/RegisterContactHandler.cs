using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Authentication.Application.Commands.RegisterContact
{
    public class RegisterContactHandler : IRequestHandler<RegisterContactRequest, RegisterContactResponse>
    {
        public Task<RegisterContactResponse> Handle(RegisterContactRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}