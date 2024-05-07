using Lesson_9_OnlineStore_DataAccess.Reposiotries.Abstracts;
using Lesson_9_OnlineStore_DataAccess.Reposiotries.Concretes;
using Lesson_9_OnlineStore_Domain.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_9_OnlineStore_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ITagRepository _TagRepository;

        public ProductController(IProductRepository productRepository, ITagRepository tagRepository)
        {
            _productRepository = productRepository;
            _TagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
 
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);
            if (existingProduct == null)
            {
                await _productRepository.AddAsync(product);
                await _productRepository.SaveChanges();
                return RedirectToAction("GetAllProducts");
                
            }
            return View(product);
        }



        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        [HttpGet]

        public async Task<IActionResult> AddProductTag(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            ViewBag.Tags = await _TagRepository.GetAllAsync();
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> AddProductTag(int id, int[] tags)
        {
            var category = await _productRepository.GetByIdAsync(id);

            foreach (var tagId in tags)
            {
                var tag = await _TagRepository.GetByIdAsync(tagId);
                category.Tags.Add(tag);
            }

            await _productRepository.SaveChanges();
            return RedirectToAction("AddProductTag");
        }




    }
}
