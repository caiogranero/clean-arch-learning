using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyCleanCode.Domain.Entities;
using MyCleanCode.Persistence;

namespace MyCleanCode.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly CleanCodeContext _cleanCodeContext;

        public UpdateEventCommandHandler(IMapper mapper, CleanCodeContext cleanCodeContext)
        {
            _mapper = mapper;
            _cleanCodeContext = cleanCodeContext;
        }
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _cleanCodeContext.Events.FindAsync(request.EventId);
            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            
            _cleanCodeContext.Events.Update(eventToUpdate);
            await _cleanCodeContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}