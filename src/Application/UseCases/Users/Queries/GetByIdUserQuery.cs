using Application.Common.Interfaces;
using Application.UseCases.Users.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Users.Queries;
public class GetByIdUserQuery:IRequest<UserResponse>
{
    public int Id { get; set; }
}
public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetByIdUserQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<UserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var foundUser =await  _context.Users.FindAsync(new object[] {request.Id},cancellationToken);
        if (foundUser == null)
            throw new NotFoundException("User is not found", request.Id);
       
        var responseFoundUser = _mapper.Map<UserResponse>(foundUser);   
        return responseFoundUser;
    }
}
