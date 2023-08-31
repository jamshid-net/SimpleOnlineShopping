using Application.Common.Interfaces;
using Application.UseCases.Users.Response;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Users.Queries;
public class GetAllUserQuery:IRequest<List<UserResponse>>
{ }
public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllUserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users.AsNoTracking().ToListAsync(cancellationToken);
        var responseUser = _mapper.Map<List<UserResponse>>(users);

        return responseUser;
    }
}
