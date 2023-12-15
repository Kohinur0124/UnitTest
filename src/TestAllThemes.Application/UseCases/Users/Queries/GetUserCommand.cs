using MediatR;

namespace TestAllThemes.Application.UseCases.User.Queries
{
    public class GetUserCommand : IRequest<List<Domain.Entities.UserS>>
    {
    }
}
