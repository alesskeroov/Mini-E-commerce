using Azure.Core;
using Ecommerce_Backend.Application.Features.Commands.Products.CreateProduct;
using Ecommerce_Backend.Application.Features.Commands.Products.RemoveProduct;
using Ecommerce_Backend.Application.Features.Commands.Products.UpdateProduct;
using Ecommerce_Backend.Application.Features.Queries.Products.GetAllProducts;
using Ecommerce_Backend.Application.Features.Queries.Products.GetByIdProduct;
using Ecommerce_Backend.Application.Repositories;
using Ecommerce_Backend.Application.RequestParameters;
using Ecommerce_Backend.Application.ViewModels.Products;
using Ecommerce_Backend.Domain.Entities;
using Ecommerce_Backend.Persistence.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Ecommerce_Backend.API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class ProductsController : ControllerBase

    {
        readonly private IMediator _mediator;
        public ProductsController(IProductWriteRepository prductWriteRepository, IProductReadRepository prductReadRepository, IWebHostEnvironment webHostEnvironment, IMediator mediator, EcommerceDbContext ecommerceDbContext)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
          GetByIdProductQueryResponse response =  await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
          CreateProductCommandResponse response= await _mediator.Send(createProductCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateProductCommandRequest updateProductCommandRequest)
        {
           UpdateProductCommandResponse response=await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(RemoveProductCommandRequest removeProductCommandRequest)
        {
          RemoveProductCommandResponse response=  await _mediator.Send(removeProductCommandRequest);
            return Ok();
        }
        


    }    
}
