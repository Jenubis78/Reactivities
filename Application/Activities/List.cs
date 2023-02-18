using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities;

public class List
{
    public class Query : IRequest<Result<List<ActivityDto>>>
    {
    }

    public class Handler : IRequestHandler<Query, Result<List<ActivityDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IMapper mapper,IUserAccessor userAccessor)
        {
            _mapper = mapper;
            _userAccessor = userAccessor;
            //  _logger = logger;
            _context = context;
        }

      //  public ILogger<List> _logger { get; }

        public async Task<Result<List<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            /*   try
               {
                   
                       cancellationToken.ThrowIfCancellationRequested();
                       
                       _logger.LogInformation($"Task has completed");
                   }
               }
               catch (System.Exception)
               {
                   
                   _logger.LogInformation($"Task was cancelled");
               } */
               var activities = await _context.Activities.ProjectTo<ActivityDto>(_mapper.ConfigurationProvider, new{currentUsername = _userAccessor.GetUsername()}).ToListAsync(cancellationToken);
            
            return Result<List<ActivityDto>>.Success(activities);
        }
    }
}