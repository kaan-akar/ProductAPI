using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.CQRS.Commands.Request;
using ProductAPI.CQRS.Commands.Response;
using ProductAPI.CQRS.Handlers.CommandHandlers;
using ProductAPI.CQRS.Handlers.QueryHandlers;
using ProductAPI.CQRS.Queries.Request;
using ProductAPI.CQRS.Queries.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest requestModel)
        {
       
            var allProducts = await _mediator.Send(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdProductQueryRequest requestModel)
        {
            var product = await _mediator.Send(requestModel);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Post([FromBody] GetProductByFilterQueryRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            return Ok(response);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        


        //private ProductDatabaseContext _context;
        //public ProductController(ProductDatabaseContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet]
        //public IQueryable<Product> GetAllProduct(int id, string ProductName, string ProductColour, float ProductPriceFrom, float ProductPriceTo)
        //{
        //    var result = _context.Products.AsQueryable();
        //    //if (id!=0)
        //    //{
        //    //    result = result.Where(x => x.ProductCode == id);
        //    //}
        //    //if (!(string.IsNullOrEmpty(ProductName)))
        //    //{
        //    //    result = result.Where(x => x.ProductName.Contains(ProductName));
        //    //}

        //    result = result.Where(q => 
        //    (id > 0 ? q.ProductCode == id : true) 
        //    && 
        //    (!string.IsNullOrEmpty(ProductName) ? q.ProductName.Contains(ProductName) : true)
        //    &&
        //    (!string.IsNullOrEmpty(ProductColour) ? q.ProductColour.Contains(ProductColour) : true)
        //    &&
        //    (ProductPriceFrom > 0 ? q.ProductPrice >= ProductPriceFrom : true)
        //    &&
        //    (ProductPriceTo > 0 ? q.ProductPrice <= ProductPriceTo : true)
        //    );

        //    //if (!(string.IsNullOrEmpty(ProductColour)))
        //    //{
        //    //    result = result.Where(x => x.ProductColour.Contains(ProductColour));
        //    //}
        //    //if (ProductPriceFrom > 0)
        //    //{
        //    //    result = result.Where(x => x.ProductPrice >= ProductPriceFrom);
        //    //}
        //    //if (ProductPriceTo != 0)
        //    //{
        //    //    result = result.Where(x => x.ProductPrice <= ProductPriceTo);
        //    //}



        //    return result;
        //}

        //[HttpGet("{id}")]
        //public Product GetProductById(int id)
        //{
        //    var _product = _context.Products.Find(id);
        //    if (_product != null)
        //    {
        //        return _product;
        //    }
        //    else
        //    {
        //        Console.WriteLine("BOŞ ID GİRDİNİZ");
        //        return _product;
        //    }

        //}

        //[HttpPost]
        //public ActionResult AddProduct([FromBody]Product product)
        //{
        //    var validator = new UserValidator();
        //    var result = validator.Validate(product);
        //    if (result.IsValid)
        //    {
        //        var _product = new Product()
        //        {
        //            ProductCode = product.ProductCode,
        //            ProductName = product.ProductName,
        //            ProductColour = product.ProductColour,
        //            ProductPrice = product.ProductPrice,
        //            ProductStockValue = product.ProductStockValue,
        //        };
        //        _context.Products.Add(_product);
        //        _context.SaveChanges();
        //        return Ok(product);
        //    }
        //    else
        //    {
        //        return BadRequest(result.Errors);
        //    }


        //}

        //[HttpPut("{id}")]
        //public Product UpdateProduct(int id,[FromBody] Product product)
        //{
        //    var _product = _context.Products.Find(id);
        //    if (product != null)
        //    {

        //        _product.ProductName = product.ProductName;
        //        _product.ProductColour = product.ProductColour;
        //        _product.ProductPrice = product.ProductPrice;
        //        _product.ProductStockValue = product.ProductStockValue;
        //        _context.SaveChanges();

        //    }
        //    return _product;
        //}

        //[HttpDelete("{id}")]
        //public void DeleteProduct(int id)
        //{
        //    var _product = _context.Products.Find(id);
        //    if (_product != null)
        //    {
        //        _context.Remove(_product);
        //        _context.SaveChanges();
        //    }
        //}   
    }
}
