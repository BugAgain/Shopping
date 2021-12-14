using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> BestSellers { get; set; }
        
        public IEnumerable<Product> WeRecommended { get; set; }
        
        public IEnumerable<Product> CorporateGifting { get; set; }

        // Reviews
    }
}
