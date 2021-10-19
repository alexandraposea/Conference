using Conference.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Application.Queries
{
    public class GetSuggestions
    {
        public class Query:IRequest<List<Model>>
        {
            //public string AttendeeEmail { get; set; }
            //public int ConferenceId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly ConferenceDbContext _dbContext;

            public QueryHandler(ConferenceDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var list = _dbContext.Conferences.Select(x => new Model
                {
                    Id = x.Id,
                    Name = x.Name,
                    OrganizerEmail = x.OrganizerEmail,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ConferenceTypeId = x.ConferenceTypeId,
                    LocationId = x.LocationId,
                    CategoryId = x.CategoryId
                })
                    .Take(3)
                    .ToList();

                return Task.FromResult(list);
            }
        }

        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string OrganizerEmail { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int ConferenceTypeId { get; set; }
            public int LocationId { get; set; }
            public int CategoryId { get; set; }
        }
    }
}
