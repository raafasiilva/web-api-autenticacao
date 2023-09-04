using API.Interfaces.Services.V1;
using API.Models.Contracts.AddressModels;
using API.Models.Contracts.BaseModels;
using API.Models.Contracts.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers.V1
{
    [Route("api/v1/adresses")]
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService) =>
            _addressService = addressService;

        [HttpPost("", Name = "AddAddress")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAddressAsync([FromBody] AddressCreationModel model)
        {
            await _addressService.AddAddressAsync(model);
            return Created();
        }

        [HttpGet("", Name = "GetAllAdresses")]
        [ProducesResponseType(typeof(ModelCollectionBaseViewModel<AddressViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAdressesAsync([FromQuery, Required] FilterParamBaseQueryModel model) =>
            Ok(await _addressService.GetAllAdressesAsync(model));

        [HttpGet("{id}", Name = "GetAddressById")]
        [ProducesResponseType(typeof(AddressViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAddressByIdAsync([FromRoute] Guid id) =>
            Ok(await _addressService.GetAddressByIdAsync(id));

        [HttpGet("search/{zipCode}", Name = "GetAddressByZipCode")]
        [ProducesResponseType(typeof(AddressViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAddressByZipCodeAsync([FromRoute] string zipCode) =>
            Ok(await _addressService.GetAddressByZipCodeAsync(zipCode));

        [HttpDelete("{id}", Name = "RemoveAddressById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveAddressByIdAsync([FromRoute] Guid id)
        {
            await _addressService.RemoveAddressByIdAsync(id);
            return NoContent();
        }

        [HttpPut("", Name = "UpdateAddress")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorViewModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAddressAsync([FromBody] AddressUpdateModel model)
        {
            await _addressService.UpdateAddressAsync(model);
            return NoContent();
        }
    }
}
