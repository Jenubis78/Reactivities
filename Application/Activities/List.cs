using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities;

public class List
{
    public class Query : IRequest<List<Activity>>
    {
    }

    public class Handler : IRequestHandler<Query, List<Activity>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context, ILogger<List> logger)
        {
            //  _logger = logger;
            _context = context;
        }

        public ILogger<List> _logger { get; }

        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
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
            return await _context.Activities.ToListAsync();
        }
    }
}