using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MyCleanCode.Application.Contracts.Persistence;

namespace MyCleanCode.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must no exceeed 50 characters");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(x => x)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date alread exists");
            
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0);
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand eventCommand, CancellationToken cancellationToken)
        {
            return !(await _eventRepository.IsEventNameAndDateUnique(eventCommand.Name, eventCommand.Date));
        }
    }
}