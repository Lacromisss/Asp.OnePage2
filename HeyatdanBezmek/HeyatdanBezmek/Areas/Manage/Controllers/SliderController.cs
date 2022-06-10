using HeyatdanBezmek.Dal;
using HeyatdanBezmek.Models;
using HeyatdanBezmek.Utilites;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeyatdanBezmek.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }

        private  readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
           List< Slider> slider = _context.sliders.ToList();
            return View(slider);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            bool slider1 = _context.sliders.Any(x => x.Name == slider.Name);
            if (slider1)
            {

                return View();
            }
            if (slider.Photo.CheckSize(200))
            {
                ModelState.AddModelError("Photo", "200kb limitini kecmisiniz");
            }
            if (!slider.Photo.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "img formatinda fayl atin zehmet olmasa");


            }
            slider.ImgUrl = await slider.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath,"Musi","images"));
            _context.sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            Slider slider = _context.sliders.Find(Id);
            if (slider==null)
            {
                return BadRequest();

            }
            _context.Remove(slider);

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int Id)
        {
            Slider slider = _context.sliders.Find(Id);
            if (slider==null)
            {

                return BadRequest();
            }
            return View(slider);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Update(int Id,Slider slider)
        {
            Slider slider2 = _context.sliders.Find(Id);
            string abc = "instagram (1).png";
            if (!ModelState.IsValid)
            {
                return View();

            }
            if (slider2==null)
            {
                return BadRequest();
            }
        
            if (slider.Photo.CheckSize(200))
            {
                ModelState.AddModelError("Photo", "200kb limitini kecmisiniz");
            }
            if (!slider.Photo.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "img formatinda fayl atin zehmet olmasa");


            }
            slider.ImgUrl = await slider.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Musi", "images"));
            slider2.Name = slider.Name;
            slider2.Degre = slider.Degre;
            slider2.Title = slider.Title;
            slider2.Description = slider.Description;
            slider2.ImgUrl = slider.ImgUrl;
          

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
