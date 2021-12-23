using AutoMapper;
using HeshkoBookWeb.Data;
using HeshkoBookWeb.Models.Dto;
using HeshkoBookWeb.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeshkoBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<IActionResult>  Index()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Create(CategoryDTO categoryDTO)
        {

            if (categoryDTO.Name == categoryDTO.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The diplayOrder cannot exactly match the name ");
            }

            if (ModelState.IsValid)
            {
                Category category = _mapper.Map<Category>(categoryDTO);
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                TempData["success"] = "Create Category Successfully";

                return RedirectToAction("Index");
            }
            return View(categoryDTO);
           
        }

        public async Task<IActionResult>  Edit(int? id)
        {
            if (id == null || id == 0 )
            {
                return NotFound();
            }
           
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);


            if (category == null)  return NotFound();



            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
            

            return View(categoryDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (categoryDTO.Name == categoryDTO.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The diplayOrder cannot exactly match the name ");
            }
            if (ModelState.IsValid)
            {
                Category categoryModle = _mapper.Map<Category>(categoryDTO);

              

                _context.Categories.Update(categoryModle);

                await _context.SaveChangesAsync();
                TempData["success"] = " Update Category Successfully";

                return RedirectToAction("Index");
            }
            return View(categoryDTO);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);


            if (category == null) return NotFound();

            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);

            return View(categoryDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> DeleteConfirm(int? id) //  CategoryDTO categoryDTO disabled on one prop its mean disabled on all prop . I should send id I form
        {


                 var categoryModle = await _context.Categories.FindAsync(id);

                 if (categoryModle == null) return NotFound();

                _context.Categories.Remove(categoryModle);

                await _context.SaveChangesAsync();

                  TempData["success"] = "Delete Category Successfully";

            return RedirectToAction("Index");
            
            
        }
    }
}
