using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyCleanCode.Domain.Entities;
using MyCleanCode.Persistence;

namespace MyCleanCode.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly CleanCodeContext _cleanCodeContext;

        public CreateEventCommandHandler(IMapper mapper, CleanCodeContext cleanCodeContext)
        {
            _mapper = mapper;
            _cleanCodeContext = cleanCodeContext;
        }
        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_cleanCodeContext);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);
            
            var @event = _mapper.Map<Event>(request);
            @event = (await _cleanCodeContext.Events.AddAsync(@event, cancellationToken)).Entity;
            return @event.EventId;
        }
    }
}