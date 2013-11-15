using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.DataGenerator.Services.Interfaces
{
    public interface IBookTypeGeneratorService
    {
        List<Category> GenerateCategories();

        List<QuantityMap> GenerateQuantityMaps();

        List<BookType> GenerateBooks(List<Category> categories, List<QuantityMap> quantityMaps);
    }
}
