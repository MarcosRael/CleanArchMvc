using System;
using FluentAssertions;
using Xunit;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Tests
{
  public class ProductUnitTest1
  {
    
    [Fact]
    public void CreateProduct_WithValidParemeters_ResultObjectValidState()
    {
      Action action = () => new Product(1, "Product Name", "Product Descript", 9.9m, 99, "product image");

      action.Should()
        .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValid>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
      Action action = () => new Product(-1, "Product Name", "Product Descript", 9.9m, 99, "product image");

      action.Should()
        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValid>()
        .WithMessage("Invalid Id value.");
    }

    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionInvalidId()
    {
      Action action = () => new Product(1, "Pr", "Product Descript", 9.9m, 99, "product image");

      action.Should()
        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValid>()
        .WithMessage("Invalid name, too short, minimum 3 characters.");
    }

    [Fact]
    public void CreateProduct_LongImageName_DomainExceptionInvalidId()
    {
      Action action = () => new Product(1, "Product Name", "Product Descript", 9.9m, 99, 
        "product image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo   oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");

      action.Should()
        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValid>()
        .WithMessage("Invalid image name, too long, maximum 250 characters.");
    }

    [Fact]
    public void CreateProduct_WithNullImageName_NoDomainException()
    {
      Action action = () => new Product(1, "Product Name", "Product Descript", 9.9m, 99, null);

      action.Should()
        .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValid>();
    }

    [Fact]
    public void CreateProduct_WithEmptyImageName_NoDomainException()
    {
      Action action = () => new Product(1, "Product Name", "Product Descript", 9.9m, 99, "");

      action.Should()
        .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValid>();
    }


    [Fact]
    public void CreateProduct_InvalidPriceValue_DomainException()
    {
      Action action = () => new Product(1, "Product Name", "Product Descript", -9.9m, 99, "product image");

      action.Should()
        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValid>()
        .WithMessage("Invalid price value.");
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
      Action action = () => new Product(1, "Product Name", "Product Descript", 9.9m, value, "product image");

      action.Should()
        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValid>()
        .WithMessage("Invalid stock value.");
    }




  }
}
