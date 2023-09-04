using App.Domain.Interfaces.Repositories;
using App.Domain.Models.Entities.Schemas.Authentication;
using FluentValidation;

namespace App.Domain.Models.EntitiesValidations.AddressValidations
{
    public class AddressUpdateValidation : AbstractValidator<Address>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AddressUpdateValidation(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;

            RuleFor(x => x.Id).NotNull().WithMessage("Informe o identificador do registro");
            RuleFor(x => x.ZipCode).NotNull().WithMessage("Informe o CEP");
            RuleFor(x => x.Street).NotNull().WithMessage("Informe o nome da rua");
            RuleFor(x => x.Number).NotNull().WithMessage("Informe o numero da residência");
            RuleFor(x => x.District).NotNull().WithMessage("Informe o nome do bairro");
            RuleFor(x => x.City).NotNull().WithMessage("Informe o nome da cidade");
            RuleFor(x => x.StateCode).NotNull().WithMessage("Informe a sigla do estado");

            RuleFor(x => x.Id).MustAsync(ValidationExistenceAsync).WithMessage("Registro não encontrado");
        }

        private async Task<bool> ValidationExistenceAsync(Guid id, CancellationToken cancellationToken) =>
            await _repositoryWrapper.Address.HasByIdAsync(id);
    }
}
