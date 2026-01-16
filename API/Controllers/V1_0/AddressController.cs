using API.Interfaces.Services.V1;
using API.Models.Contracts.AddressModels;
using API.Models.Contracts.BaseModels;
using API.Models.Contracts.ErrorModels;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers.V1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/adresses")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService) =>
            _addressService = addressService;

        [HttpPost("", Name = "AddAddress")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAddressAsync([FromBody] AddressCreationModel model, CancellationToken cancellationToken)
        {
            await _addressService.AddAddressAsync(model, cancellationToken);
            return Created();
        }

        [HttpGet("", Name = "GetAllAdresses")]
        [ProducesResponseType(typeof(ModelCollectionBaseViewModel<AddressViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAdressesAsync([FromQuery, Required] FilterParamBaseQueryModel model, CancellationToken cancellationToken) =>
            Ok(await _addressService.GetAllAdressesAsync(model, cancellationToken));

        [HttpGet("{id}", Name = "GetAddressById")]
        [ProducesResponseType(typeof(AddressViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAddressByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken) =>
            Ok(await _addressService.GetAddressByIdAsync(id, cancellationToken));

        [HttpGet("search/{zipCode}", Name = "GetAddressByZipCode")]
        [ProducesResponseType(typeof(AddressViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAddressByZipCodeAsync([FromRoute] string zipCode, CancellationToken cancellationToken) =>
            Ok(await _addressService.GetAddressByZipCodeAsync(zipCode, cancellationToken));

        [HttpDelete("{id}", Name = "RemoveAddressById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveAddressByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _addressService.RemoveAddressByIdAsync(id, cancellationToken);
            return NoContent();
        }

        [HttpPut("", Name = "UpdateAddress")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAddressAsync([FromBody] AddressUpdateModel model, CancellationToken cancellationToken)
        {
            await _addressService.UpdateAddressAsync(model, cancellationToken);
            return NoContent();
        }
    }
}
