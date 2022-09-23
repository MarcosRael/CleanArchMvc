using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
  public sealed class Category : Entity
  {
    public string Name { get; private set; }

    public Category(string name)
    {
      validateDomain(name);
    }

    public Category(int id, string name)
    {
      DomainExceptionValid.When(id < 0, 
          "Invalid Id value");

      Id = id;
      Name = name;
    }

    public void Update(string name)
    {
      validateDomain(name);
    }

    private void validateDomain(string name)
    {

      DomainExceptionValid.When(string.IsNullOrEmpty(name), 
          "invalid name. Name is required");

      DomainExceptionValid.When(name.Length < 3,
          "Invalid name, too short, minimum 3 charecters");

      Name = name;

    }

    public ICollection<Product> Products { get; set; }
  }
}
